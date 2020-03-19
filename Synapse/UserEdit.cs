/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 24-05-2012
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using SynapseAdvancedControls;
using SynapseCore.Entities;
using SynapseCore.Controls;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace Synapse
{
	/// <summary>
	/// Description of UserEdit.
	/// </summary>
	public partial class UserEdit : SynapseForm
	{
		private Int64 CurrentUser;
		private IList<SynapseModule> ModuleCollection;
        IList<SynapseProfile> ProfileCollection;
		private string ModuleIdFilter="";
		public UserEdit()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            olv_GroupsOfUser.EmptyListMsg = GetLabel("UserEdit.olv_GroupOfUser.EmptyMsg");
            if (ModuleCollection != null)
            {
                cb_Modules.Items.Clear();
                cb_Modules.Items.Add("ALL");
                foreach (SynapseModule Mod in ModuleCollection)
                    cb_Modules.Items.Add(Mod);
                cb_Modules.SelectedIndex = 0;
            }
            base.initForm(Mode);
        }

		void UserEditLoad(object sender, EventArgs e)
		{
            Hashtable LevelForProfile = new Hashtable();
            this.ssl_StatusLabel.Text = FormUser.UserID;

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
				
            var UserCollection = SynapseUser.Load();


            if (SynapseForm.FormUser.IsMemberOf("SYNAPSE_SECURITY_ADMIN"))
                ProfileCollection = SynapseProfile.Load();
            else if (ModuleIdFilter.Length > 1)
                ProfileCollection = (from p in SynapseProfile.Load("WHERE FK_ModuleID in (" + ModuleIdFilter.TrimEnd(',') + ")") where p.LEVEL > (Int64)LevelForProfile[p.FK_ModuleID] select p).ToList();
            else
                ProfileCollection = new List<SynapseProfile>();
			IList<SynapseProfile> AllProfileCollection;
            AllProfileCollection = SynapseProfile.Load();
			
            ModuleCollection = SynapseModule.Load();
			
			olvcGroups.ImageGetter = delegate(object row) {
				return 0;
			};
			
			olvcUsers.ImageGetter = delegate(object row) {
				return 1;
			};
			
			olvc_GroupName.ImageGetter = delegate(object row) {
				
				return 0;
			};
			
			olvc_GroupName.AspectGetter = delegate(object x) {
				SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;
				
				foreach (SynapseProfile Sp in AllProfileCollection)
				{
					if (Sp.ID==SUserProfile.FK_SECURITY_PROFILE)
						return Sp.TECHNICALNAME;
				}
				return "Unknown";
			};
			olvc_Module.AspectGetter = delegate(object x) {
				SynapseUser_Profile SUserProfile = (SynapseUser_Profile)x;
				
				foreach (SynapseProfile Sp in AllProfileCollection)
				{
					if (Sp.ID==SUserProfile.FK_SECURITY_PROFILE)
					{
						foreach (SynapseModule Module in ModuleCollection)
						{
							if (Module.ID==Sp.FK_ModuleID)
								return Module.FriendlyName;
						}
					}
						
				}
				return "Unknown";
			};
			olv_GroupsOfUser.PrimarySortColumn=olvc_Module;
			olv_Groups.SetObjects(ProfileCollection);
			olv_Users.SetObjects(UserCollection);
			
			cb_Modules.DisplayMember="FriendlyName";
			cb_Modules.ValueMember="ID";
            cb_Modules.Items.Clear();
            cb_Modules.Items.Add("ALL");
            foreach (SynapseModule Mod in ModuleCollection)
                cb_Modules.Items.Add(Mod);
            cb_Modules.SelectedIndex = 0;
			
			
		}
	
		
		void Olv_UsersSelectedIndexChanged(object sender, EventArgs e)
		{
			if (olv_Users.SelectedObject!=null)
			{
				SynapseUser User = ((SynapseUser)olv_Users.SelectedObject);
				Int64 SelectedUser = User.ID;
			
				CurrentUser =SelectedUser;
				lbl_SelectedUser.Text= User.FIRSTNAME+" "+User.LASTNAME;

                var UserProfiles = SynapseUser_Profile.Load("WHERE FK_SECURITY_USER=" + SelectedUser.ToString());
				olv_GroupsOfUser.SetObjects(UserProfiles);
			}
			else
			{
				CurrentUser=0;
				lbl_SelectedUser.Text="";
			}
		}
		
	
		void Olv_GroupsOfUserModelCanDrop(object sender, SynapseAdvancedControls.ModelDropEventArgs e)
		{
			e.Effect= DragDropEffects.Copy;
		}
		
		void Olv_GroupsOfUserModelDropped(object sender, SynapseAdvancedControls.ModelDropEventArgs e)
		{
			if (CurrentUser!=0 && e.SourceModels.Count>0)
			{
				SynapseProfile profile = (SynapseProfile)e.SourceModels[0];
				SynapseUser_Profile SUserProfile = new SynapseUser_Profile();
				SUserProfile.FK_SECURITY_PROFILE = profile.ID;
				SUserProfile.FK_SECURITY_USER = CurrentUser;
				olv_GroupsOfUser.AddObject(SUserProfile);
			}
		}
		
		
		void btn_EditPermissionClick(object sender, EventArgs e)
		{
			SecurityEdit SecurityEditForm = new SecurityEdit();
			SecurityEditForm.ShowDialog();
			this.UserEditLoad(this,e);
		}
		
		void btn_SaveClick(object sender, EventArgs e)
		{
			foreach (SynapseUser_Profile link in olv_GroupsOfUser.Objects)
			{
				link.save();
			}
			UserEditLoad(this,e);
		}
		
		void menu_RemoveClick(object sender, EventArgs e)
		{
			if (olv_GroupsOfUser.SelectedObject!=null)
			{
				SynapseUser_Profile link = (SynapseUser_Profile)olv_GroupsOfUser.SelectedObject;
				if (link.ID==0)
				{
					olv_GroupsOfUser.RemoveObject(link);
				}
				else
				{
					link.delete();
					olv_GroupsOfUser.RemoveObject(link);
				}
			}
			//MessageBox.Show(olv_GroupsOfUser.SelectedObject.ToString());
		}
		
		void btn_NewUserClick(object sender, EventArgs e)
		{
			SynapseUser SUser = new SynapseUser();
			frmUserEdit UserEditForm = new frmUserEdit(ref SUser);
			if (UserEditForm.ShowDialog() == DialogResult.OK)
			{
				SUser.save();
                olv_Users.AddObject(SUser);
			}
		}
		
		void btn_NewGroupClick(object sender, EventArgs e)
		{
			SynapseProfile SProfile = new SynapseProfile();
			frmGroupEdit GroupEditForm = new frmGroupEdit(ref SProfile,ModuleCollection);
			if (GroupEditForm.ShowDialog() == DialogResult.OK)
			{
				SProfile.save();
                olv_Groups.AddObject(SProfile);
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cb_Modules.SelectedItem!=null && cb_Modules.Text!="ALL" )
			{
				
				olv_Groups.ModelFilter= new ModelFilter(delegate (object x) {
					if (cb_Modules.SelectedItem!=null && cb_Modules.Text!="ALL")
						return ((SynapseProfile)x).FK_ModuleID==((SynapseModule)cb_Modules.SelectedItem).ID;
					else
						return true;
				});
				olv_Groups.UseFiltering=true;
			}
			else
				olv_Groups.UseFiltering=false;
		}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (ctxmenu_Edit.SourceControl == olv_Users && olv_Users.SelectedObject != null)
            {
                frm_SynapseObjectEdit edit = new frm_SynapseObjectEdit((SynapseUser)olv_Users.SelectedObject);
                edit.Show();
            }

            if (ctxmenu_Edit.SourceControl == olv_Groups && olv_Groups.SelectedObject != null)
            {
                frm_SynapseObjectEdit edit = new frm_SynapseObjectEdit((SynapseProfile)olv_Groups.SelectedObject);
                edit.Show();
            }
        }

        private void ctxmenu_Edit_ParentChanged(object sender, EventArgs e)
        {

       
        }

        private void ctxmenu_Edit_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ctxmenu_Edit.SourceControl == olv_Groups)
                listUsersToolStripMenuItem.Visible = true;
            else
                listUsersToolStripMenuItem.Visible = false;
        }

        private void listUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctxmenu_Edit.SourceControl == olv_Groups && olv_Groups.SelectedObject != null)
            {
                var users = SynapseUser.LoadFromQuery("SELECT * FROM [SYNAPSE].[dbo].[V_Synapse_UserGroups] WHERE P_TECHNICALNAME = '"+((SynapseProfile)olv_Groups.SelectedObject).TECHNICALNAME+"'");
                string text=string.Empty;
                foreach (SynapseUser user in users)
                    text += string.Format("{0} {1} ({2})\n", user.FIRSTNAME, user.LASTNAME, user.UserID);
                MessageBox.Show(text, "List of users", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_SecurityOverview_Click(object sender, EventArgs e)
        {
            frmSecurityOverView Security = new frmSecurityOverView();
            Security.ShowDialog();
        }

        private void ctxmenu_Remove_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (olv_GroupsOfUser.SelectedObject != null)
            {
                SynapseUser_Profile link = (SynapseUser_Profile)olv_GroupsOfUser.SelectedObject;
                if ((from p in ProfileCollection where p.ID == link.FK_SECURITY_PROFILE select p).ToList().Count >= 1)
                {
                    menu_Remove.Enabled = true;
                    menu_Remove.AutoToolTip = false;
                }
                else
                {
                    menu_Remove.Enabled = false;
                    menu_Remove.ToolTipText = "Not allowed";
                    menu_Remove.AutoToolTip = true;
                }

            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt_Search.Text))
                filter = TextMatchFilter.Contains(olv_Users, txt_Search.Text);
            olv_Users.AdditionalFilter = filter;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {



            if (ctxmenu_Edit.SourceControl == olv_Groups && olv_Groups.SelectedObject != null)
            {
                var users = SynapseUser.LoadFromQuery("SELECT * FROM [SYNAPSE].[dbo].[V_Synapse_UserGroups] WHERE P_TECHNICALNAME = '" + ((SynapseProfile)olv_Groups.SelectedObject).TECHNICALNAME + "'");
                if (users.Count == 0)
                {
                    ((SynapseProfile)olv_Groups.SelectedObject).delete();
                    olv_Groups.RemoveObject(olv_Groups.SelectedObject);
                }
                else
                { 
                    string text=string.Empty;
                    foreach (SynapseUser user in users)
                        text += string.Format("{0} {1} ({2})\n", user.FIRSTNAME, user.LASTNAME, user.UserID);
                    MessageBox.Show("There are still some users assigned to this group please delete them first\n"+text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (ctxmenu_Edit.SourceControl == olv_Users && olv_Users.SelectedObject != null)
            {
                var usergroups = SynapseUser_Profile.Load("WHERE FK_SECURITY_USER = " + ((SynapseUser)olv_Users.SelectedObject).ID);
                foreach (SynapseUser_Profile sup in usergroups)
                    sup.delete();
                ((SynapseUser)olv_Users.SelectedObject).delete();
                olv_Users.RemoveObject(olv_Users.SelectedObject);
                olv_GroupsOfUser.Clear();
            }
        }
	}
	
}
