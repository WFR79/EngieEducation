using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Entities;
using SynapseCore.Controls;
using System.IO;
using System.Collections;


namespace Synapse
{
    public partial class frm_ModulesEdit : SynapseForm
    {
        IList<SynapseModule> modules;
        Hashtable usage = new Hashtable();

        public frm_ModulesEdit()
        {
            InitializeComponent();

            olvModules_FriendlyName.ImageGetter = delegate(object x)
            {
                return ((SynapseModule)x).TECHNICALNAME;
            };

            olvModules_FriendlyName.AspectGetter = delegate(object x)
            {
                return (((SynapseModule)x).FriendlyName.ToString());
            };
            olvModules_Description.AspectGetter = delegate(object x)
            {
                return (((SynapseModule)x).Description.ToString());
            };
            olvModules_Usage.AspectGetter = delegate(object x)
            {
                if (usage.ContainsKey(((SynapseModule)x).ID))
                    return usage[((SynapseModule)x).ID].ToString();
                else
                    return "";
            };
        }

        private void frm_ModulesEdit_Load(object sender, EventArgs e)
        {
            listModule();
        }

        private void listModule()
        {
            ctxEdit.Enabled = false;
            tsbEdit.Enabled = false;
            ctxDelete.Enabled = false;
            tsbDelete.Enabled = false;

            var stats = ComboBoxObject.LoadFromQuery("SELECT [FK_MODULE_ID] as Value,cast(ROUND(cast(sum([ACTIVITY_TIME]) as float)/3600,2) as nvarchar) + 'h ('+cast(ROUND((cast(sum([ACTIVITY_TIME]) as float)/cast(sum([OPENED_TIME]) as float))*100,1) as nvarchar)+'%) - ' + CAST(COUNT(Distinct FORMNAME) as nvarchar) + ' Forms - ' + cast(COUNT(DISTINCT USERID) as nvarchar) + ' Users' as Text FROM [SYNAPSE].[dbo].[Synapse_Statistics] GROUP BY FK_MODULE_ID");
            usage.Clear();

            foreach (ComboBoxObject stat in stats)
            {
                usage.Add(stat.Value, stat.Text);
            }

            modules = SynapseModule.Load();
            foreach (SynapseModule module in modules)
            {
                if (File.Exists(Application.StartupPath + "\\ModulesIcons\\" + module.TECHNICALNAME + ".ico"))
                {
                    LargeImageList.Images.Add(module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\" + module.TECHNICALNAME + ".ico"));
                }
                else
                {
                    LargeImageList.Images.Add(module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\Default.png"));
                }
            }

            olvModules.SetObjects(modules.OrderBy(x => x.FriendlyName.ToString()).ToList());
        }

        private void Edit_Module(object sender, EventArgs e)
        {
            if (olvModules.SelectedObject != null)
            {
                frmModule fModule = new frmModule();
                fModule.Action = "EDIT";
                fModule.ID = ((SynapseModule)olvModules.SelectedObject).ID;
                if (fModule.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    listModule();
                }
            }
        }

        private void New_Module(object sender, EventArgs e)
        {
            frmModule fModule = new frmModule();
            fModule.Action = "NEW";
            fModule.ID = 0;
            if (fModule.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listModule();
            }
        }

        private void Delete_Module(object sender, EventArgs e)
        {
            if (MessageBox.Show(GetLabel("Quest.0003"),GetLabel("Quest"),MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                SynapseModule _module = (SynapseModule)olvModules.SelectedObject;
                IList<SynapseProfile_Control> _profileControl = SynapseProfile_Control.LoadFromQuery("SELECT dbo.[Synapse_Security_Profile Control].* FROM dbo.[Synapse_Security_Profile Control] INNER JOIN dbo.Synapse_Security_Profile ON dbo.[Synapse_Security_Profile Control].FK_PROFILEID = dbo.Synapse_Security_Profile.ID INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Security_Profile.FK_MODULEID = dbo.Synapse_Module.ID WHERE (dbo.Synapse_Module.ID = " + _module.ID + ")");
                IList<SynapseUser_Profile> _userProfile = SynapseUser_Profile.LoadFromQuery("SELECT dbo.[Synapse_Security_User Profile].* FROM dbo.[Synapse_Security_User Profile] INNER JOIN dbo.Synapse_Security_Profile ON dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE = dbo.Synapse_Security_Profile.ID INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Security_Profile.FK_MODULEID = dbo.Synapse_Module.ID WHERE (dbo.Synapse_Module.ID = " + _module.ID + ")");
                IList<SynapseProfile> _profile = SynapseProfile.LoadFromQuery("SELECT dbo.Synapse_Security_Profile.* FROM dbo.Synapse_Security_Profile INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Security_Profile.FK_MODULEID = dbo.Synapse_Module.ID WHERE (dbo.Synapse_Module.ID = " + _module.ID + ")");
                IList<SynapseControl> _control = SynapseControl.Load("WHERE FK_MODULE_ID=" + _module.ID);

                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    foreach (SynapseProfile_Control obj in _profileControl)
                    {
                        obj.delete();
                    }
                    foreach (SynapseUser_Profile obj in _userProfile)
                    {
                        obj.delete();
                    }
                    foreach (SynapseProfile obj in _profile)
                    {
                        obj.delete();
                    }
                    foreach (SynapseControl obj in _control)
                    {
                        obj.delete();
                    }
                    foreach (SynapseLabel obj in ((SynapseModule)olvModules.SelectedObject).FriendlyName.Labels)
                    {
                        obj.delete();
                    }
                    foreach (SynapseLabel obj in ((SynapseModule)olvModules.SelectedObject).Description.Labels)
                    {
                        obj.delete();
                    }

                    _module.delete();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    listModule();
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    MessageBox.Show("Data not deleted from Database:" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void olvModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvModules.SelectedObject != null)
            {
                ctxEdit.Enabled = true;
                tsbEdit.Enabled = true;
                ctxDelete.Enabled = true;
                tsbDelete.Enabled = true;
            }
            else
            {
                ctxEdit.Enabled = false;
                tsbEdit.Enabled = false;
                ctxDelete.Enabled = false;
                tsbDelete.Enabled = false;
            }
        }
    }
}
