using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseAdvancedControls;
using SynapseCore.Entities;
using SynapseCore.Controls;
using System.Collections;
using System.Reflection;
namespace Synapse
{
    public partial class frmAccessRights : SynapseForm
    {
        private Int64 _currentUser;
        private Int64 _currentGroup;
        private IList<SynapseModule> ModuleCollection;
        private IList<SynapseProfile> AllProfileCollection;
        private IList<SynapseUser> AllUserCollection;
        private IList<SynapseProfile> ProfileCollection;
        private string ModuleIdFilter = "";

        public frmAccessRights()
        {
            InitializeComponent();

            AllUserCollection = SynapseUser.Load();
            AllProfileCollection = SynapseProfile.Load();
            ModuleCollection = SynapseModule.Load();

            olvUsers_USERID.ImageGetter = delegate(object row)
            {
                return 1;
            };

            olvUsers2_USERID.ImageGetter = delegate(object row)
            {
                return 1;
            };

            olvGroups_Group.ImageGetter = delegate(object row)
            {
                return 0;
            };

            olvGroups_Description.AspectGetter = delegate(object x)
            {
                return (((SynapseProfile)x).Description.ToString());
            };
            olvGroups_Owner.AspectGetter = delegate(object x)
            {
                return (((SynapseProfile)x).IS_OWNER);
            };
            olvGroups_Owner.Renderer = new MappedImageRenderer(new Object[] { true, imageList2.Images[0], "x", imageList2.Images[1] });

            olvGroup2_Group.ImageGetter = delegate(object row)
            {
                return 0;
            };

            olvGroup2_Owner.AspectGetter = delegate(object x)
            {
                return (((SynapseProfile)x).IS_OWNER);
            };
            olvGroup2_Owner.Renderer = new MappedImageRenderer(new Object[] { true, imageList2.Images[0], "x", imageList2.Images[1] });

            olvUserGroup_GroupName.ImageGetter = delegate(object row)
            {
                return 0;
            };

            olvUserGroup_GroupName.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseProfile Sp in AllProfileCollection)
                {
                    if (Sp.ID == SUserProfile.FK_SECURITY_PROFILE)
                        return Sp.TECHNICALNAME;
                }
                return "Unknown";
            };
            olvUserGroup_Description.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseProfile Sp in AllProfileCollection)
                {
                    if (Sp.ID == SUserProfile.FK_SECURITY_PROFILE)
                        return Sp.Description.ToString();
                }
                return "";
            };
            olvUserGroup_Module.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseProfile Sp in AllProfileCollection)
                {
                    if (Sp.ID == SUserProfile.FK_SECURITY_PROFILE)
                    {
                        foreach (SynapseModule Module in ModuleCollection)
                        {
                            if (Module.ID == Sp.FK_ModuleID)
                                return Module.FriendlyName;
                        }
                    }
                }
                return "Unknown";
            };
            olvUserGroups.PrimarySortColumn = olvUserGroup_Module;

            olvGroupUsers_USERID.ImageGetter = delegate(object row)
            {
                return 1;
            };

            olvGroupUsers_USERID.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseUser Su in AllUserCollection)
                {
                    if (Su.ID == SUserProfile.FK_SECURITY_USER)
                        return Su.UserID;
                }
                return "Unknown";
            };

            olvGroupUsers_FIRSTNAME.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseUser Su in AllUserCollection)
                {
                    if (Su.ID == SUserProfile.FK_SECURITY_USER)
                        return Su.FIRSTNAME;
                }
                return "Unknown";
            };

            olvGroupUsers_LASTNAME.AspectGetter = delegate(object x)
            {
                SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;

                foreach (SynapseUser Su in AllUserCollection)
                {
                    if (Su.ID == SUserProfile.FK_SECURITY_USER)
                        return Su.LASTNAME;
                }
                return "Unknown";
            };
            olvGroupUsers.PrimarySortColumn = olvGroupUsers_USERID;
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            mnuAddUserToGroup.Visible = false;
            mnuRemoveUserFromGroup.Visible = false;
            ctxAddUserToGroup.Visible = false;
            ctxRemoveUserFromGroup.Visible = false;

            olvUserGroups.EmptyListMsg = GetLabel("UserEdit.olv_GroupOfUser.EmptyMsg");
            fillUsers();
            fillModules();
            fillGroups();
        }

        private void fillUsers()
        {
            olvUsers.Items.Clear();

            tsbEditUser.Enabled = false;
            tsbDeleteUser.Enabled = false;
            ctxEditUser.Enabled = false;
            ctxDeleteUser.Enabled = false;
            mnuEditUser.Enabled = false;
            mnuDeleteUser.Enabled = false;

            IList<SynapseUser> userList = SynapseUser.Load();
            olvUsers.SetObjects(userList);
            olvUsers2.SetObjects(userList);
        }

        private void fillModules()
        {
            cbModules.Items.Clear();
            cbModules2.Items.Clear();

            if (ModuleCollection != null)
            {
                ModuleCollection = ModuleCollection.OrderBy(x => x.FriendlyName.ToString()).ToList();

                cbModules.Items.Add("*");
                cbModules2.Items.Add("*");
                foreach (SynapseModule Mod in ModuleCollection)
                {
                    cbModules.Items.Add(Mod);
                    cbModules2.Items.Add(Mod);
                }
                cbModules.SelectedIndex = 0;
                cbModules2.SelectedIndex = 0;
            }

            cbModules.DisplayMember = "FriendlyName";
            cbModules.ValueMember = "ID";

            cbModules2.DisplayMember = "FriendlyName";
            cbModules2.ValueMember = "ID";
        }

        private void fillGroups()
        {
            tsbEditGroup.Enabled = false;
            tsbDeleteGroup.Enabled = false;
            ctxEditGroup.Enabled = false;
            ctxDeleteGroup.Enabled = false;
            mnuEditGroup.Enabled = false;
            mnuDeleteGroup.Enabled = false;
            tsbAddUserGroup.Enabled = false;
            ctxAddUserGroup.Enabled = false;
            mnuAddUserGroup.Enabled = false;

            Hashtable LevelForProfile = new Hashtable();

            foreach (SynapseProfile Profile in SynapseForm.FormUser.Groups)
            {
                if (Profile.IS_OWNER)
                {
                    ModuleIdFilter += Profile.FK_ModuleID + ",";
                    if (!LevelForProfile.ContainsKey(Profile.FK_ModuleID))
                        LevelForProfile.Add(Profile.FK_ModuleID, Profile.LEVEL);
                    else
                        if ((Int64)LevelForProfile[Profile.FK_ModuleID] > Profile.LEVEL)
                            LevelForProfile[Profile.FK_ModuleID] = Profile.LEVEL;
                }
            }

            if (SynapseForm.FormUser.IsMemberOf("SYNAPSE_SECURITY_ADMIN"))
                ProfileCollection = SynapseProfile.Load();
            else if (ModuleIdFilter.Length > 1)
                ProfileCollection = (from p in SynapseProfile.Load("WHERE FK_ModuleID in (" + ModuleIdFilter.TrimEnd(',') + ")") where p.LEVEL > (Int64)LevelForProfile[p.FK_ModuleID] select p).ToList();
            else
                ProfileCollection = new List<SynapseProfile>();

            olvGroups.SetObjects(ProfileCollection.OrderBy(x => x.TECHNICALNAME.ToString()).ToList());
            olvGroups2.SetObjects(ProfileCollection.OrderBy(x => x.TECHNICALNAME.ToString()).ToList());
        }

        private void olvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbAddUserGroup.Enabled = false;
            ctxAddUserGroup.Enabled = false;
            mnuAddUserGroup.Enabled = false;

            if (olvUsers.SelectedItems.Count > 0)
            {
                tsbEditUser.Enabled = true;
                tsbDeleteUser.Enabled = true;
                ctxEditUser.Enabled = true;
                ctxDeleteUser.Enabled = true;
                mnuEditUser.Enabled = true;
                mnuDeleteUser.Enabled = true;

                SynapseUser User = ((SynapseUser)olvUsers.SelectedObject);
                _currentUser = User.ID;
                lbSelectedUser.Text = User.FIRSTNAME + " " + User.LASTNAME;

                fillUserGroups();

                if (olvGroups.SelectedItems.Count > 0)
                {
                    tsbAddUserGroup.Enabled = true;
                    ctxAddUserGroup.Enabled = true;
                    mnuAddUserGroup.Enabled = true;
                }
            }
            else
            {
                tsbEditUser.Enabled = false;
                tsbDeleteUser.Enabled = false;
                ctxEditUser.Enabled = false;
                ctxDeleteUser.Enabled = false;
                mnuEditUser.Enabled = false;
                mnuDeleteUser.Enabled = false;

                _currentUser = 0;
                lbSelectedUser.Text = "";

                olvUserGroups.Items.Clear();
            }
        }

        private void fillUserGroups()
        {
            tsbDeleteUserGroup.Enabled = false;
            ctxDeleteUserGroup.Enabled = false;
            mnuDeleteUserGroup.Enabled = false;

            IList<SynapseUser_Profile> UserProfiles = new List<SynapseUser_Profile>();

            if (cbModules.SelectedItem != null && cbModules.Text != "*")
            {
                UserProfiles = SynapseUser_Profile.LoadFromQuery("SELECT * FROM [Synapse_Security_User Profile] INNER JOIN Synapse_Security_Profile ON [Synapse_Security_User Profile].FK_SECURITY_PROFILE=Synapse_Security_Profile.ID WHERE [Synapse_Security_User Profile].FK_SECURITY_USER=" + _currentUser.ToString() + " AND Synapse_Security_Profile.FK_MODULEID=" + ((SynapseModule)cbModules.SelectedItem).ID.ToString());
            }
            else
            {
                UserProfiles = SynapseUser_Profile.Load("WHERE FK_SECURITY_USER=" + _currentUser.ToString());
            }

            olvUserGroups.SetObjects(UserProfiles);
        }

        private void txUserSearch_TextChanged(object sender, EventArgs e)
        {
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txUserSearch.Text))
                filter = TextMatchFilter.Contains(olvUsers, txUserSearch.Text);
            olvUsers.AdditionalFilter = filter;
        }

        private void NewUser_Click(object sender, EventArgs e)
        {
            frmUser fUser = new frmUser();
            fUser.Action = "NEW";
            fUser.User = new SynapseUser();
            if (fUser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SynapseUser _user = fUser.User;
                olvUsers.AddObject(_user);
                olvUsers2.AddObject(_user);

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        olvUsers.SelectedObject = _user;
                        break;
                    case 1:
                        olvUsers2.SelectedObject = _user;
                        break;
                }
                AllUserCollection = SynapseUser.Load();
            }
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            SynapseUser _user = new SynapseUser();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    _user = (SynapseUser)olvUsers.SelectedObject;
                    break;
                case 1:
                    _user = (SynapseUser)olvUsers2.SelectedObject;
                    break;
            }

            frmUser fUser = new frmUser();
            fUser.Action = "EDIT";
            fUser.User = _user;
            if (fUser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _user = fUser.User;
                olvUsers.RefreshObject(_user);
                olvUsers2.RefreshObject(_user);

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        olvUsers.SelectedObject = _user;
                        olvUsers2.SelectedObject = null;
                        break;
                    case 1:
                        olvUsers.SelectedObject = null;
                        olvUsers2.SelectedObject = _user;
                        break;
                }
                AllUserCollection = SynapseUser.Load();
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            SynapseUser _user = new SynapseUser();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    _user = (SynapseUser)olvUsers.SelectedObject;
                    break;
                case 1:
                    _user = (SynapseUser)olvUsers2.SelectedObject;
                    break;
            }

            if (MessageBox.Show(GetLabel("Quest.0001"), GetLabel("Quest"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                var usergroups = SynapseUser_Profile.Load("WHERE FK_SECURITY_USER = " + _user.ID);
                foreach (SynapseUser_Profile sup in usergroups)
                    sup.delete();

                olvUsers.RemoveObject(_user);
                olvUsers2.RemoveObject(_user);
                _user.delete();

                AllUserCollection = SynapseUser.Load();
                olvUserGroups.Items.Clear();
            }
        }

        private void olvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbAddUserGroup.Enabled = false;
            ctxAddUserGroup.Enabled = false;
            mnuAddUserGroup.Enabled = false;

            if (olvGroups.SelectedItems.Count > 0)
            {
                tsbEditGroup.Enabled = true;
                tsbDeleteGroup.Enabled = true;
                ctxEditGroup.Enabled = true;
                ctxDeleteGroup.Enabled = true;
                mnuEditGroup.Enabled = true;
                mnuDeleteGroup.Enabled = true;

                if (olvUsers.SelectedItems.Count > 0)
                {
                    tsbAddUserGroup.Enabled = true;
                    ctxAddUserGroup.Enabled = true;
                    mnuAddUserGroup.Enabled = true;
                }
            }
            else
            {
                tsbEditGroup.Enabled = false;
                tsbDeleteGroup.Enabled = false;
                ctxEditGroup.Enabled = false;
                ctxDeleteGroup.Enabled = false;
                mnuEditGroup.Enabled = false;
                mnuDeleteGroup.Enabled = false;
            }

            olvUserGroups.SelectedObject = null;
        }

        private void NewGroup_Click(object sender, EventArgs e)
        {
            frmGroup fGroup = new frmGroup();
            fGroup.Action = "NEW";
            fGroup.Profile = new SynapseProfile();
            if (fGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SynapseProfile _profile = fGroup.Profile;
                olvGroups.AddObject(_profile);
                olvGroups2.AddObject(_profile);

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        olvGroups.SelectedObject = _profile;
                        break;
                    case 1:
                        olvGroups2.SelectedObject = _profile;
                        break;
                }
                AllProfileCollection = SynapseProfile.Load();
            }
        }

        private void EditGroup_Click(object sender, EventArgs e)
        {
            if (tsbEditGroup.Visible || tsbEditGroup2.Visible)
            {
                SynapseProfile _profile = new SynapseProfile();
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        _profile = (SynapseProfile)olvGroups.SelectedObject;
                        break;
                    case 1:
                        _profile = (SynapseProfile)olvGroups2.SelectedObject;
                        break;
                }
                if (_profile != null)
                {
                    frmGroup fGroup = new frmGroup();
                    fGroup.Action = "EDIT";
                    fGroup.Profile = _profile;
                    if (fGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _profile = fGroup.Profile;
                        olvGroups.RefreshObject(_profile);
                        olvGroups2.RefreshObject(_profile);

                        switch (tabControl1.SelectedIndex)
                        {
                            case 0:
                                olvGroups.SelectedObject = _profile;
                                olvGroups2.SelectedObject = null;
                                break;
                            case 1:
                                olvGroups.SelectedObject = null;
                                olvGroups2.SelectedObject = _profile;
                                break;
                        }
                        AllProfileCollection = SynapseProfile.Load();
                    }
                }
            }
        }

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            SynapseProfile _profile = new SynapseProfile();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    _profile = (SynapseProfile)olvGroups.SelectedObject;
                    break;
                case 1:
                    _profile = (SynapseProfile)olvGroups2.SelectedObject;
                    break;
            }

            var users = SynapseUser.LoadFromQuery("SELECT * FROM [SYNAPSE].[dbo].[V_Synapse_UserGroups] WHERE P_TECHNICALNAME = '" + _profile.TECHNICALNAME + "'");
            if (users.Count == 0)
            {
                if (MessageBox.Show(GetLabel("Quest.0002"), GetLabel("Quest"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    SynapseCore.Database.DBFunction.StartTransaction();
                    try
                    {
                        foreach (SynapseLabel obj in _profile.Description.Labels)
                        {
                            obj.delete();
                        }
                        _profile.delete();

                        SynapseCore.Database.DBFunction.CommitTransaction();

                        olvGroups.RemoveObject(_profile);
                        olvGroups2.RemoveObject(_profile);
                    }
                    catch (Exception ex)
                    {
                        SynapseCore.Database.DBFunction.RollbackTransaction();
                        MessageBox.Show("Data not deleted from Database:" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                string text = string.Empty;
                foreach (SynapseUser user in users)
                    text += string.Format("{0} {1} ({2})\n", user.FIRSTNAME, user.LASTNAME, user.UserID);
                MessageBox.Show(GetLabel("Err.0003") + text, GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbEditGroup.Enabled = false;
            tsbDeleteGroup.Enabled = false;
            ctxEditGroup.Enabled = false;
            ctxDeleteGroup.Enabled = false;
            mnuEditGroup.Enabled = false;
            mnuDeleteGroup.Enabled = false;
            tsbAddUserGroup.Enabled = false;
            ctxAddUserGroup.Enabled = false;
            mnuAddUserGroup.Enabled = false;

            if (cbModules.SelectedItem != null && cbModules.Text != "*")
            {
                olvGroups.ModelFilter = new ModelFilter(delegate(object x)
                {
                    if (cbModules.SelectedItem != null && cbModules.Text != "*")
                        return ((SynapseProfile)x).FK_ModuleID == ((SynapseModule)cbModules.SelectedItem).ID;
                    else
                        return true;
                });
                olvGroups.UseFiltering = true;
            }
            else
            {
                olvGroups.UseFiltering = false;
            }

            fillUserGroups();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbEditGroup2.Enabled = false;
            tsbDeleteGroup2.Enabled = false;
            ctxEditGroup.Enabled = false;
            ctxDeleteGroup.Enabled = false;
            mnuEditGroup.Enabled = false;
            mnuDeleteGroup.Enabled = false;
            tsbAddUserToGroup.Enabled = false;
            ctxAddUserToGroup.Enabled = false;
            mnuAddUserToGroup.Enabled = false;
            tsbRemoveUserFromGroup.Enabled = false;
            ctxRemoveUserFromGroup.Enabled = false;
            mnuRemoveUserFromGroup.Enabled = false;

            olvGroups2.SelectedObject = null;
            olvGroupUsers.Items.Clear();

            if (cbModules2.SelectedItem != null && cbModules2.Text != "*")
            {
                olvGroups2.ModelFilter = new ModelFilter(delegate(object x)
                {
                    if (cbModules2.SelectedItem != null && cbModules2.Text != "*")
                        return ((SynapseProfile)x).FK_ModuleID == ((SynapseModule)cbModules2.SelectedItem).ID;
                    else
                        return true;
                });
                olvGroups2.UseFiltering = true;
            }
            else
            {
                olvGroups2.UseFiltering = false;
            }
        }

        private void olvUserGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvUserGroups.SelectedItems.Count > 0)
            {
                tsbDeleteUserGroup.Enabled = true & isActionAuthorized(olvUserGroups);
                ctxDeleteUserGroup.Enabled = true;
                mnuDeleteUserGroup.Enabled = true;
            }
            else
            {
                tsbDeleteUserGroup.Enabled = false;
                ctxDeleteUserGroup.Enabled = false;
                mnuDeleteUserGroup.Enabled = false;
            }

            olvGroups.SelectedObject = null;
        }

        private void olvUserGroups_ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            if (_currentUser != 0 && e.SourceModels.Count > 0)
            {
                if (isGroupAlreadyAssociated((SynapseProfile)e.SourceModels[0]))
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void olvUserGroups_ModelDropped(object sender, ModelDropEventArgs e)
        {
            if (_currentUser != 0 && e.SourceModels.Count > 0)
            {
                addGroupToUser((SynapseProfile)e.SourceModels[0]);
            }
        }

        private void tsbAddUserGroup_Click(object sender, EventArgs e)
        {
            addGroupToUser((SynapseProfile)olvGroups.SelectedObject);
        }

        private void addGroupToUser(SynapseProfile profile)
        {
            if (!isGroupAlreadyAssociated(profile))
            {
                SynapseUser_Profile link = new SynapseUser_Profile();
                link.FK_SECURITY_PROFILE = profile.ID;
                link.FK_SECURITY_USER = _currentUser;
                olvUserGroups.AddObject(link);

                link.save();
            }
        }

        private void tsbDeleteUserGroup_Click(object sender, EventArgs e)
        {
            SynapseUser_Profile link = (SynapseUser_Profile)olvUserGroups.SelectedObject;
            olvUserGroups.RemoveObject(link);

            link.delete();
        }

        private bool isGroupAlreadyAssociated(SynapseProfile profile)
        {
            foreach (SynapseUser_Profile link in olvUserGroups.Objects)
            {
                if (profile.ID == link.FK_SECURITY_PROFILE)
                {
                    return true;
                }
            }
            return false;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    olvGroupUsers.SelectedObject = null;
                    olvGroups2.SelectedObject = null;
                    olvUsers2.SelectedObject = null;

                    mnuAddUserGroup.Visible = true;
                    mnuDeleteUserGroup.Visible = true;
                    ctxAddUserGroup.Visible = true;
                    ctxDeleteUserGroup.Visible = true;

                    mnuAddUserToGroup.Visible = false;
                    mnuRemoveUserFromGroup.Visible = false;
                    ctxAddUserToGroup.Visible = false;
                    ctxRemoveUserFromGroup.Visible = false;
                    break;
                case 1:
                    olvUserGroups.SelectedObject = null;
                    olvUsers.SelectedObject = null;
                    olvGroups.SelectedObject = null;

                    mnuAddUserToGroup.Visible = true;
                    mnuRemoveUserFromGroup.Visible = true;
                    ctxAddUserToGroup.Visible = true;
                    ctxRemoveUserFromGroup.Visible = true;

                    mnuAddUserGroup.Visible = false;
                    mnuDeleteUserGroup.Visible = false;
                    ctxAddUserGroup.Visible = false;
                    ctxDeleteUserGroup.Visible = false;
                    break;
            }
        }

        private void olvGroups2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbAddUserToGroup.Enabled = false;
            ctxAddUserToGroup.Enabled = false;
            mnuAddUserToGroup.Enabled = false;

            if (olvGroups2.SelectedItems.Count > 0)
            {
                tsbEditGroup2.Enabled = true;
                tsbDeleteGroup2.Enabled = true;
                ctxEditGroup.Enabled = true;
                ctxDeleteGroup.Enabled = true;
                mnuEditGroup.Enabled = true;
                mnuDeleteGroup.Enabled = true;

                lbSelectedGroup.Text = ((SynapseProfile)olvGroups2.SelectedObject).TECHNICALNAME;
                lbGroupDescription.Text = ((SynapseProfile)olvGroups2.SelectedObject).Description.ToString();
                _currentGroup = ((SynapseProfile)olvGroups2.SelectedObject).ID;

                fillGroupUsers();

                if (olvUsers2.SelectedItems.Count > 0)
                {
                    tsbAddUserToGroup.Enabled = true;
                    ctxAddUserToGroup.Enabled = true;
                    mnuAddUserToGroup.Enabled = true;
                }
            }
            else
            {
                tsbEditGroup2.Enabled = false;
                tsbDeleteGroup2.Enabled = false;
                ctxEditGroup.Enabled = false;
                ctxDeleteGroup.Enabled = false;
                mnuEditGroup.Enabled = false;
                mnuDeleteGroup.Enabled = false;

                lbSelectedGroup.Text = "";
                lbGroupDescription.Text = "";
                _currentGroup = 0;
                olvGroupUsers.Items.Clear();
            }
        }

        private void txUserSearch2_TextChanged(object sender, EventArgs e)
        {
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txUserSearch2.Text))
                filter = TextMatchFilter.Contains(olvUsers2, txUserSearch2.Text);
            olvUsers2.AdditionalFilter = filter;
        }

        private void olvUsers2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbAddUserToGroup.Enabled = false;
            ctxAddUserToGroup.Enabled = false;
            mnuAddUserToGroup.Enabled = false;

            if (olvUsers2.SelectedItems.Count > 0)
            {
                tsbEditUser2.Enabled = true;
                tsbDeleteUser2.Enabled = true;
                ctxEditUser.Enabled = true;
                ctxDeleteUser.Enabled = true;
                mnuEditUser.Enabled = true;
                mnuDeleteUser.Enabled = true;

                SynapseUser User = ((SynapseUser)olvUsers2.SelectedObject);
                _currentUser = User.ID;

                if (olvGroups2.SelectedItems.Count > 0)
                {
                    tsbAddUserToGroup.Enabled = true;
                    ctxAddUserToGroup.Enabled = true;
                    mnuAddUserToGroup.Enabled = true;
                }
            }
            else
            {
                tsbEditUser2.Enabled = false;
                tsbDeleteUser2.Enabled = false;
                ctxEditUser.Enabled = false;
                ctxDeleteUser.Enabled = false;
                mnuEditUser.Enabled = false;
                mnuDeleteUser.Enabled = false;

                _currentUser = 0;
            }

            olvGroupUsers.SelectedObject = null;
        }

        private void fillGroupUsers()
        {
            tsbRemoveUserFromGroup.Enabled = false;
            ctxRemoveUserFromGroup.Enabled = false;
            mnuRemoveUserFromGroup.Enabled = false;


            IList<SynapseUser_Profile> UserProfiles = new List<SynapseUser_Profile>();
            UserProfiles = SynapseUser_Profile.Load("WHERE FK_SECURITY_PROFILE=" + _currentGroup.ToString());
            olvGroupUsers.SetObjects(UserProfiles);
        }

        private void olvGroupUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvGroupUsers.SelectedItems.Count > 0)
            {
                tsbRemoveUserFromGroup.Enabled = true & isActionAuthorized(olvGroupUsers);
                ctxRemoveUserFromGroup.Enabled = true;
                mnuRemoveUserFromGroup.Enabled = true;
            }
            else
            {
                tsbRemoveUserFromGroup.Enabled = false;
                ctxRemoveUserFromGroup.Enabled = false;
                mnuRemoveUserFromGroup.Enabled = false;
            }

            olvUsers2.SelectedObject = null;
        }

        private void olvGroupUsers_ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            if (_currentGroup != 0 && e.SourceModels.Count > 0)
            {
                if (isUserAlreadyAssociated((SynapseUser)e.SourceModels[0]))
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void olvGroupUsers_ModelDropped(object sender, ModelDropEventArgs e)
        {
            if (_currentGroup != 0 && e.SourceModels.Count > 0)
            {
                addUserToGroup((SynapseUser)e.SourceModels[0]);
            }
        }

        private void tsbAddUserToGroup_Click(object sender, EventArgs e)
        {
            addUserToGroup((SynapseUser)olvUsers2.SelectedObject);
        }

        private void addUserToGroup(SynapseUser user)
        {
            if (!isUserAlreadyAssociated(user))
            {
                SynapseUser_Profile link = new SynapseUser_Profile();
                link.FK_SECURITY_PROFILE = _currentGroup;
                link.FK_SECURITY_USER = user.ID;
                link.save();

                olvGroupUsers.AddObject(link);
            }
        }

        private bool isUserAlreadyAssociated(SynapseUser user)
        {
            foreach (SynapseUser_Profile link in olvGroupUsers.Objects)
            {
                if (user.ID == link.FK_SECURITY_USER)
                {
                    return true;
                }
            }
            return false;
        }

        private void tsbRemoveUserFromGroup_Click(object sender, EventArgs e)
        {
            SynapseUser_Profile link = (SynapseUser_Profile)olvGroupUsers.SelectedObject;
            olvGroupUsers.RemoveObject(link);

            link.delete();
        }

        private bool isActionAuthorized(ObjectListView olv)
        {
            if (olv.SelectedObject != null)
            {
                SynapseUser_Profile link = (SynapseUser_Profile)olv.SelectedObject;
                if ((from p in ProfileCollection where p.ID == link.FK_SECURITY_PROFILE select p).ToList().Count >= 1)
                {
                    mnuDeleteUserGroup.Enabled = true;
                    ctxDeleteUserGroup.Enabled = true;
                    mnuRemoveUserFromGroup.Enabled = true;
                    ctxRemoveUserFromGroup.Enabled = true;

                    return true;
                }
                else
                {
                    mnuDeleteUserGroup.Enabled = false;
                    ctxDeleteUserGroup.Enabled = false;
                    mnuRemoveUserFromGroup.Enabled = false;
                    ctxRemoveUserFromGroup.Enabled = false;

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void checkAuthorization(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    isActionAuthorized(olvUserGroups);
                    break;
                case 1:
                    isActionAuthorized(olvGroupUsers);
                    break;
            }
        }

        private void checkAuthorization(object sender, CancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    isActionAuthorized(olvUserGroups);
                    break;
                case 1:
                    isActionAuthorized(olvGroupUsers);
                    break;
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
