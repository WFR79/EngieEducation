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
    public partial class frmAccessTree : SynapseForm
    {
        private IList<SynapseModule> ModuleCollection;
        private IList<SynapseProfile> AllProfileCollection;
        private IList<SynapseUser> AllUserCollection;
        private IList<SynapseProfile> ProfileCollection;
        private string ModuleIdFilter = "";

        public frmAccessTree()
        {
            InitializeComponent();

            #region AspectGetter
            treeMain.CanExpandGetter = delegate(object x)
            {
                if (x is string)
                    return true;
                if (x is SynapseModule)
                    return true;
                if (x is SynapseUser)
                {
                    if (treeMain.GetParent(x) is SynapseProfile)
                        return false;
                    else
                        return true;
                }
                if (x is SynapseProfile)
                {
                    if (treeMain.GetParent(x) is UserGroups)
                        return false;
                    else
                        return true;
                }
                if (x is ModuleGroups)
                    return true;
                if (x is UserGroups)
                    return true;
                return false;
            };

            olvColName.AspectGetter = delegate(object x)
            {
                if (x is string)
                    return ((string)x).ToUpperInvariant();

                if (x is SynapseModule)
                {
                    SynapseModule _module = (SynapseModule)x;
                    return _module.FriendlyName;
                }

                if (x is SynapseProfile)
                {
                    SynapseProfile _profile = (SynapseProfile)x;
                    return _profile.TECHNICALNAME;
                }

                if (x is SynapseUser)
                {
                    SynapseUser _user=(SynapseUser)x;
                    string _col = _user.UserID + " " + _user.LASTNAME + " " + _user.FIRSTNAME;
                    return _col;
                }

                if (x is ModuleGroups)
                {
                    return "MODULE'S GROUPS";
                }

                if (x is UserGroups)
                {
                    return "USER'S GROUPS";
                }
                return "";
            };

            olvColName.ImageGetter = delegate(object x)
            {
                if (x is string)
                {
                    return x;
                }
                if (x is ModuleGroups)
                    return "GROUPS";
                if (x is UserGroups)
                    return "GROUPS";

                return "";
            };

            treeMain.ChildrenGetter = delegate(object x)
            {
                if (x is string)
                {
                    string _type = (string)x;
                    switch (_type)
                    {
                        case "MODULES":
                            return ModuleCollection.OrderBy(n => n.FriendlyName.ToString()).ToList();
                        case "GROUPS":
                            return getAutorizedGroups(AllProfileCollection).OrderBy(n => n.TECHNICALNAME.ToString()).ToList();
                        case "USERS":
                            return getUsers(0).OrderBy(n => n.UserID.ToString()).ToList();
                    }
                    return "";
                }
                if (x is SynapseUser)
                {
                    IList<UserGroups> _groupingGroups = new List<UserGroups>();
                    UserGroups _groups = new UserGroups();
                    _groups.User = (SynapseUser)x;
                    _groupingGroups.Add(_groups);
                    return _groupingGroups;
                }
                if (x is SynapseProfile)
                {
                    IList<SynapseUser> userList = new List<SynapseUser>();
                    userList = getUsers(((SynapseProfile)x).ID);
                    //userList = SynapseUser.LoadFromQuery("SELECT dbo.Synapse_Security_User.* FROM dbo.Synapse_Security_User INNER JOIN dbo.[Synapse_Security_User Profile] ON dbo.Synapse_Security_User.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_USER WHERE dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE = " + ((SynapseProfile)x).ID);
                    return userList.OrderBy(n => n.UserID.ToString()).ToList();
                }

                if (x is UserGroups)
                {
                    IList<SynapseProfile> UserProfiles = SynapseProfile.Load("INNER JOIN [Synapse_Security_User Profile] ON Synapse_Security_Profile.ID=[Synapse_Security_User Profile].FK_SECURITY_PROFILE WHERE [Synapse_Security_User Profile].FK_SECURITY_USER=" + ((UserGroups)x).User.ID.ToString());
                    return getAutorizedGroups(UserProfiles).OrderBy(n => n.TECHNICALNAME.ToString()).ToList(); ;
                }

                if (x is SynapseModule)
                {
                    IList<ModuleGroups> _groupingGroups = new List<ModuleGroups>();
                    ModuleGroups _groups = new ModuleGroups();
                    _groups.Module = (SynapseModule)x;
                    _groupingGroups.Add(_groups);
                    return _groupingGroups;
                }

                if (x is ModuleGroups)
                {
                    IList<SynapseProfile> UserProfiles = SynapseProfile.Load("INNER JOIN [Synapse_Module] ON Synapse_Security_Profile.FK_MODULEID=[Synapse_Module].ID WHERE [Synapse_Module].ID=" + ((ModuleGroups)x).Module.ID.ToString());
                    return getAutorizedGroups(UserProfiles).OrderBy(n => n.TECHNICALNAME.ToString()).ToList();
                }
                return "";
            };
            #endregion
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            ModuleCollection = SynapseModule.Load();
            AllUserCollection = SynapseUser.Load();
            AllProfileCollection = SynapseProfile.Load();
            initTree();
        }

        private void initTree()
        {
            IList<string> _type = new List<string>();
            _type.Add("MODULES");
            _type.Add("GROUPS");
            _type.Add("USERS");
            treeMain.SetObjects(_type);

            lbEmpty.Visible = true;
            lbEmpty.Dock = DockStyle.Fill;
            olvGroupUsers.Visible = false;
            olvGroupUsers.Dock = DockStyle.Fill;
        }

        private List<SynapseUser> getUsers(Int64 profileID)
        {
            IList<SynapseUser> userList;
            if (profileID == 0)
            {
                userList = SynapseUser.Load();
            }
            else
            {
                userList = SynapseUser.LoadFromQuery("SELECT dbo.Synapse_Security_User.* FROM dbo.Synapse_Security_User INNER JOIN dbo.[Synapse_Security_User Profile] ON dbo.Synapse_Security_User.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_USER WHERE dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE = " + profileID);
            }
            return userList.OrderBy(n => n.UserID.ToString()).ToList();
        }

        private IList<SynapseProfile> getAutorizedGroups(IList<SynapseProfile> initList)
        {
            if (initList != null)
            {
                if (SynapseForm.FormUser.IsMemberOf("SYNAPSE_SECURITY_ADMIN"))
                    return initList;

                ProfileCollection = new List<SynapseProfile>();

                Hashtable LevelForProfile = new Hashtable();
                foreach (SynapseProfile Profile in SynapseForm.FormUser.Groups)
                {
                    if (Profile.IS_OWNER)
                    {
                        if (!LevelForProfile.ContainsKey(Profile.FK_ModuleID))
                            LevelForProfile.Add(Profile.FK_ModuleID, Profile.LEVEL);
                        else
                            if ((Int64)LevelForProfile[Profile.FK_ModuleID] > Profile.LEVEL)
                                LevelForProfile[Profile.FK_ModuleID] = Profile.LEVEL;
                    }
                }

                foreach (SynapseProfile _prof in initList)
                {
                    if (LevelForProfile[_prof.FK_ModuleID] != null)
                    {
                        if (_prof.LEVEL > (Int64)LevelForProfile[_prof.FK_ModuleID])
                        {
                            ProfileCollection.Add(_prof);
                        }
                    }
                }

                return ProfileCollection;

                //if (ModuleIdFilter.Length > 1)
                //    ProfileCollection = (from p in initList where p.LEVEL > (Int64)LevelForProfile[p.FK_ModuleID] select p).ToList();
                //else
                //    ProfileCollection = new List<SynapseProfile>();

                //return ProfileCollection;
            }
            else
            {
                return new List<SynapseProfile>();
            }
        }

        private void treeMain_DoubleClick(object sender, EventArgs e)
        {
            if (treeMain.SelectedObject != null)
            {
                if (treeMain.IsExpanded(treeMain.SelectedObject))
                    treeMain.Collapse(treeMain.SelectedObject);
                else
                    treeMain.Expand(treeMain.SelectedObject);
            }
        }

        private void treeMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //olvGroupUsers.Items.Clear();

            if (treeMain.SelectedObject != null)
            {
                if (treeMain.SelectedObject is string)
                {
                    if ((string)treeMain.SelectedObject == "USERS")
                    {
                        lbSelected.Text = "USERS";
                        olvGroupUsers.SetObjects(SynapseUser.Load().OrderBy(x => x.UserID.ToString()).ToList());
                        olvGroupUsers.Visible = true;
                        lbEmpty.Visible = false;
                        return;
                    }
                }

                if (treeMain.SelectedObject is SynapseProfile)
                {
                    if (treeMain.GetParent(treeMain.SelectedObject) is UserGroups)
                    { }
                    else
                    {
                        lbSelected.Text = ((SynapseProfile)treeMain.SelectedObject).TECHNICALNAME;
                        olvGroupUsers.SetObjects(getUsers(((SynapseProfile)treeMain.SelectedObject).ID));
                        olvGroupUsers.Visible = true;
                        lbEmpty.Visible = false;
                        return;
                    }
                }

                lbEmpty.Visible = true;
                lbSelected.Text = "";
                olvGroupUsers.Visible = false;
            }
        }
    }

    public class UserGroups
    {
        private SynapseUser _user;

        public SynapseUser User
        {
            get { return _user; }
            set { _user = value; }
        }
    }

    public class ModuleGroups
    {
        private SynapseModule _module;

        public SynapseModule Module
        {
            get { return _module; }
            set { _module = value; }
        }
    }
}
