using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore;
using SynapseCore.Entities;
using SynapseACC.Entities;
using System.Reflection;
using SynapseCore.Database;
using SynapseAdvancedControls;
using System.Security.Principal;
using System.IO;
using System.Text.RegularExpressions;

namespace SynapseDeploymentTool
{

    public partial class frm_DataMig : Form
    {
        IList<SynapseModule> Prd_Modules;
        IList<ACCSynapseModule> Acc_Modules;

        IList<ACCTOPRD> AccToPrdID = ACCTOPRD.Load("WHERE PRDID<>0");

        IList<SynapseUser> Prd_Users;
        IList<ACCSynapseUser> Acc_Users;

        IList<SynapseProfile> Prd_Profiles;
        IList<ACCSynapseProfile> Acc_Profiles;

        IList<SynapseControl> Prd_Controls;
        IList<ACCSynapseControl> Acc_Controls;

        IList<SynapseProfile_Control> Prd_ProfileControls;
        IList<ACCSynapseProfile_Control> Acc_ProfileControls;

        IList<SynapseUser_Profile> Prd_UserProfiles;
        IList<ACCSynapseUser_Profile> Acc_UserProfiles;

        List<obj_sync> Presentation = new List<obj_sync>();

        IList<ResourcesControl> ResControls;

        public frm_DataMig()
        {
            InitializeComponent();
        }

        private void frm_DataMig_Load(object sender, EventArgs e)
        {
            col_Name.ImageGetter  = delegate(object x)
            {
                return ((obj_sync)x).State.ToString();
            };
            acc_gvf.AspectGetter = delegate(object x)
            {
                return ((ACCSynapseModule)x).gvf_Version(ACCSynapseModule.SynapseModuleMode.Development);
            };
            prd_gvf.AspectGetter = delegate(object x)
            {
                return ((SynapseModule)x).gvf_Version(SynapseModule.SynapseModuleMode.Production);
            };
            col_ACC_PROF.AspectGetter = delegate(object x)
            {
                return Acc_UserProfiles.Where(a => a.FK_SECURITY_USER == ((ACCSynapseUser)x).ID).Count().ToString();
            };
            col_PRD_PROF.AspectGetter = delegate(object x)
            {
                return Prd_UserProfiles.Where(a => a.FK_SECURITY_USER == ((SynapseUser)x).ID).Count().ToString();
            };
            LoadModules();

        }

        private void LoadModules()
        {
            Prd_Modules = SynapseModule.Load();
            Acc_Modules = ACCSynapseModule.Load();
            olv_Acc_Modules.ClearObjects();
            olv_Modules.ClearObjects();
            olv_Modules.SetObjects(Prd_Modules);
            olv_Acc_Modules.SetObjects(Acc_Modules);
            comboBox1.DisplayMember = "TECHNICALNAME";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = Acc_Modules;
            comboBox2.DisplayMember = "TECHNICALNAME";
            comboBox2.ValueMember = "ID";
            comboBox2.DataSource = Acc_Modules;

        }

        private void olv_Acc_Modules_FormatRow(object sender, SynapseAdvancedControls.FormatRowEventArgs e)
        {
            ACCSynapseModule acc = (ACCSynapseModule)e.Model;
            SynapseModule prd = (from m in Prd_Modules where m.ID==acc.ID select m).FirstOrDefault();
            if (prd == null)
                e.Item.BackColor = Color.Tomato;
            else
                if (prd.VERSION != acc.VERSION)
                    e.Item.BackColor = Color.Orange;


        }

        private void olv_Modules_FormatCell(object sender, SynapseAdvancedControls.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == this.col_version.Index || e.ColumnIndex == this.prd_gvf.Index)
            {
                SynapseModule prd = (SynapseModule)e.Model;
                ACCSynapseModule acc = (ACCSynapseModule)(from m in Acc_Modules where m.ID == prd.ID select m).FirstOrDefault();

                if (acc == null)
                    acc = (ACCSynapseModule)(from m in Acc_Modules where m.TECHNICALNAME == prd.TECHNICALNAME select m).FirstOrDefault();

                if (prd != null && prd.VERSION != acc.VERSION && e.ColumnIndex == this.col_version.Index)
                        e.SubItem.BackColor = Color.Orange;
                if (prd != null && prd.gvf_Version(SynapseModule.SynapseModuleMode.Production) != acc.gvf_Version(ACCSynapseModule.SynapseModuleMode.Development) && e.ColumnIndex == this.prd_gvf.Index)
                    e.SubItem.BackColor = Color.Orange;
            }
        }

        private void btn_analyse_Click(object sender, EventArgs e)
        {
            Presentation.Clear();
            string[] ids = (from id in olv_Modules.CheckedObjects.Cast<SynapseModule>() select id.ID.ToString()).ToArray();
            string str_id = string.Join(",",ids);

            Prd_Users = SynapseUser.Load();
            Acc_Users = ACCSynapseUser.Load();
            obj_sync pr = new obj_sync();
            pr.Name = typeof(SynapseUser).FullName;
            pr.PrdCnt = Prd_Users.Count;
            pr.AccCnt = Acc_Users.Count;
            pr.Link = (from l in AccToPrdID where l.OBJECTTYPE == typeof(ACCSynapseUser).Name select l).Count();
            Presentation.Add(pr);
            
            Prd_Profiles = SynapseProfile.Load("WHERE FK_MODULEID in ("+str_id+")");
            Acc_Profiles = ACCSynapseProfile.Load("WHERE FK_MODULEID in (" + str_id + ")");
            pr = new obj_sync();
            pr.Name = typeof(SynapseProfile).FullName;
            pr.PrdCnt = Prd_Profiles.Count;
            pr.AccCnt = Acc_Profiles.Count;
            IList<Int64> Acc_Profiles_IDs = (from i in Acc_Profiles select i.ID).ToList();
            pr.Link = (from l in AccToPrdID where l.OBJECTTYPE == typeof(ACCSynapseProfile).Name && Acc_Profiles_IDs.Contains(l.ACCID) select l).Count();
            Presentation.Add(pr);
            string Prd_ProfilesID = string.Join(",", (from p in Prd_Profiles select p.ID.ToString()).ToArray());
            string Acc_ProfilesID = string.Join(",", (from p in Acc_Profiles select p.ID.ToString()).ToArray());

            Prd_Controls = SynapseControl.Load("WHERE FK_MODULE_ID in (" + str_id + ")");
            Acc_Controls = ACCSynapseControl.Load("WHERE FK_MODULE_ID in (" + str_id + ")");
            pr = new obj_sync();
            pr.Name = typeof(SynapseControl).FullName;
            pr.PrdCnt = Prd_Controls.Count;
            pr.AccCnt = Acc_Controls.Count;
            IList<Int64> Acc_Controls_IDs = (from i in Acc_Controls select i.ID).ToList();
            pr.Link = (from l in AccToPrdID where l.OBJECTTYPE == typeof(ACCSynapseControl).Name && Acc_Controls_IDs.Contains(l.ACCID) select l).Count();
            Presentation.Add(pr);
            string Prd_ControlsID = string.Join(",", (from c in Prd_Controls select c.ID.ToString()).ToArray());
            string Acc_ControlsID = string.Join(",", (from c in Acc_Controls select c.ID.ToString()).ToArray());

            if (Prd_ControlsID.Length <= 0)
                Prd_ProfileControls = new List<SynapseProfile_Control>();
            else
                Prd_ProfileControls = SynapseProfile_Control.Load("WHERE FK_CONTROLID in (" + Prd_ControlsID + ")");

            try
            {
                Acc_ProfileControls = ACCSynapseProfile_Control.Load("WHERE FK_CONTROLID in (" + Acc_ControlsID + ")");
            }
            catch
            {
                Acc_ProfileControls = new List<ACCSynapseProfile_Control>();
            }
            pr = new obj_sync();
            pr.Name = typeof(SynapseProfile_Control).FullName;
            pr.PrdCnt = Prd_ProfileControls.Count;
            pr.AccCnt = Acc_ProfileControls.Count;
            IList<Int64> Acc_ProfileControls_IDs = (from i in Acc_ProfileControls select i.ID).ToList();
            pr.Link = (from l in AccToPrdID where l.OBJECTTYPE == typeof(ACCSynapseProfile_Control).Name && Acc_ProfileControls_IDs.Contains(l.ACCID)  select l).Count();
            Presentation.Add(pr);

            if (Prd_ProfilesID.Length <= 0)
                Prd_UserProfiles = new List<SynapseUser_Profile>();
            else
                Prd_UserProfiles = SynapseUser_Profile.Load("WHERE FK_SECURITY_PROFILE in (" + Prd_ProfilesID + ")");

            Acc_UserProfiles = ACCSynapseUser_Profile.Load("WHERE FK_SECURITY_PROFILE in (" + Acc_ProfilesID + ")");
            pr = new obj_sync();
            pr.Name = typeof(SynapseUser_Profile).FullName;
            pr.PrdCnt = Prd_UserProfiles.Count;
            pr.AccCnt = Acc_UserProfiles.Count;
            IList<Int64> Acc_UserProfiles_IDs = (from i in Acc_UserProfiles select i.ID).ToList();
            pr.Link = (from l in AccToPrdID where l.OBJECTTYPE == typeof(ACCSynapseUser_Profile).Name && Acc_UserProfiles_IDs.Contains(l.ACCID) select l).Count();
            Presentation.Add(pr);

            olv_analyse.SetObjects(Presentation);
        }

        private void btn_Sync_Click(object sender, EventArgs e)
        {
            AccToPrdID = ACCTOPRD.Load("WHERE PRDID<>0");
            Int64 UsersCount = 0;
            Int64 ControlsCount = 0;
            Int64 ProfilesCount = 0;
            Int64 ProfileControlsCount = 0;
            Int64 UserAssignmentCount = 0;
            richTextBox1.Clear();
            if (chk_SyncUser.Checked)
            {
                // ======= Create user in prod ========
                foreach (ACCSynapseUser A_user in from au in Acc_Users where au.PrdID(AccToPrdID) == 0 select au)
                {
                    if(chk_verbose.Checked) richTextBox1.AppendText(A_user.GetType().Name+": "+ A_user.UserID+"\n");
                    SynapseUser user = new SynapseUser();
                    CopyProperties(user, A_user);
                    user.ID = 0;
                    if (chk_save.Checked)
                    {
                        user.save();
                    }
                    UsersCount++;
                    CreateLinkEntry(A_user, A_user.ID, user.ID);
                    
                }
            }
            // ======= Create controls in prod ========
            foreach (ACCSynapseControl A_ctrl in from ac in Acc_Controls where ac.PrdID(AccToPrdID) == 0 select ac)
            {
                if (chk_verbose.Checked) richTextBox1.AppendText(A_ctrl.GetType().Name + ": " + A_ctrl.CTRL_NAME + "\n");
                SynapseControl ctrl = new SynapseControl();
                CopyProperties(ctrl,A_ctrl);
                ctrl.ID = 0;
                if (chk_save.Checked)
                {
                    ctrl.save();
                }
                ControlsCount++;
                CreateLinkEntry(A_ctrl, A_ctrl.ID, ctrl.ID);

            }
            // ======= Create profiles in prod ========
            foreach (ACCSynapseProfile A_prof in from ap in Acc_Profiles where ap.PrdID(AccToPrdID) == 0 select ap)
            {
                if (chk_verbose.Checked) richTextBox1.AppendText(A_prof.GetType().Name + ": " + A_prof.TECHNICALNAME + "\n");
                SynapseProfile prof = new SynapseProfile();
                CopyProperties(prof, A_prof);
                prof.ID = 0;
                if (chk_save.Checked)
                {
                    prof.save();
                }
                ProfilesCount++;
                    CreateLinkEntry(A_prof, A_prof.ID, prof.ID);
               
            }
            // ======= Create link control-profile in prod ========
            foreach (ACCSynapseProfile_Control A_profControl in from apc in Acc_ProfileControls where apc.PrdID(AccToPrdID) == 0 select apc)
            {
                if (chk_verbose.Checked) richTextBox1.AppendText(A_profControl.GetType().Name + ": " + A_profControl.FK_PROFILEID + "=>" + A_profControl.FK_CONTROLID + "\n");
                SynapseProfile_Control ProfControl = new SynapseProfile_Control();
                ProfControl.IS_ACTIVE = A_profControl.IS_ACTIVE;
                ProfControl.IS_VISIBLE = A_profControl.IS_VISIBLE;
                try
                {
                    ProfControl.FK_CONTROLID = AccToPrdID.ConvertID(typeof(ACCSynapseControl), A_profControl.FK_CONTROLID);
                    ProfControl.FK_PROFILEID = AccToPrdID.ConvertID(typeof(ACCSynapseProfile), A_profControl.FK_PROFILEID);
                    if (chk_save.Checked)
                    {
                        ProfControl.save();
                    }
                    ProfileControlsCount++;
                    CreateLinkEntry(A_profControl, A_profControl.ID, ProfControl.ID);
                 
                }
                catch (MissingFieldException ex)
                {
                    richTextBox1.AppendText("ERROR(" + ex.Message + "): " + A_profControl.GetType().Name + ": " + A_profControl.FK_PROFILEID + "=>" + A_profControl.FK_CONTROLID + "\n", Color.Red);
                    richTextBox1.ScrollToCaret();
                }
                catch (KeyNotFoundException ex)
                {
                    richTextBox1.AppendText("WARNING(" + ex.Message + "): " + A_profControl.GetType().Name + ": " + A_profControl.FK_PROFILEID + "=>" + A_profControl.FK_CONTROLID + "\n", Color.Orange);
                    richTextBox1.ScrollToCaret();
                }
            }
            if (chk_UserAssignment.Checked)
            {
                // ======= Create link user-profile in prod ========
                foreach (ACCSynapseUser_Profile A_userP in from aup in Acc_UserProfiles where aup.PrdID(AccToPrdID) == 0 select aup)
                {
                    if (chk_verbose.Checked) richTextBox1.AppendText(A_userP.GetType().Name + ": " + A_userP.FK_SECURITY_PROFILE + "=>" + A_userP.FK_SECURITY_USER + "\n");
                    SynapseUser_Profile UserProf = new SynapseUser_Profile();
                    try
                    {
                        UserProf.FK_SECURITY_PROFILE = AccToPrdID.ConvertID(typeof(ACCSynapseProfile), A_userP.FK_SECURITY_PROFILE);
                        UserProf.FK_SECURITY_USER = AccToPrdID.ConvertID(typeof(ACCSynapseUser), A_userP.FK_SECURITY_USER);
                        if (chk_save.Checked)
                        {
                            UserProf.save();
                        }
                        UserAssignmentCount++;
                        CreateLinkEntry(A_userP, A_userP.ID, UserProf.ID);
                        
                    }
                    catch (MissingFieldException ex)
                    {
                        richTextBox1.AppendText("ERROR(" + ex.Message + "): " + A_userP.GetType().Name + ": " + A_userP.FK_SECURITY_PROFILE + "=>" + A_userP.FK_SECURITY_USER + "\n", Color.Red);
                        richTextBox1.ScrollToCaret();
                    }
                    catch (KeyNotFoundException ex)
                    {
                        richTextBox1.AppendText("WARNING(" + ex.Message + "): " + A_userP.GetType().Name + ": " + A_userP.FK_SECURITY_PROFILE + "=>" + A_userP.FK_SECURITY_USER + "\n", Color.Orange);
                        richTextBox1.ScrollToCaret();
                    }
                }
                
            }
            if (chk_save.Checked)
            foreach (ACCTOPRD atp in from l in AccToPrdID where l.ID == 0 select l)
            {
                atp.save();
            }
            Int64 lnk = 0;
            richTextBox1.AppendText(UsersCount + " Users will be added", Color.Blue);
            lnk = AccToPrdID.Where(l => l.ID == 0 && l.OBJECTTYPE == typeof(ACCSynapseUser).Name).Count();
            richTextBox1.AppendText(" with " + lnk + " new links\n", UsersCount == lnk ? Color.Blue : Color.Red);

            richTextBox1.AppendText(ControlsCount + " Controls will be added", Color.Blue);
            lnk = AccToPrdID.Where(l => l.ID == 0 && l.OBJECTTYPE == typeof(ACCSynapseControl).Name).Count();
            richTextBox1.AppendText(" with " + lnk + " new links\n", ControlsCount == lnk ? Color.Blue : Color.Red);

            richTextBox1.AppendText(ProfilesCount + " Profiles will be added", Color.Blue);
            lnk = AccToPrdID.Where(l => l.ID == 0 && l.OBJECTTYPE == typeof(ACCSynapseProfile).Name).Count();
            richTextBox1.AppendText(" with " + lnk + " new links\n", ProfilesCount == lnk ? Color.Blue : Color.Red);

            richTextBox1.AppendText(ProfileControlsCount + " Profile-Control link will be added", Color.Blue);
            lnk = AccToPrdID.Where(l => l.ID == 0 && l.OBJECTTYPE == typeof(ACCSynapseProfile_Control).Name).Count();
            richTextBox1.AppendText(" with " + lnk + " new links\n", ProfileControlsCount == lnk ? Color.Blue : Color.Red);

            richTextBox1.AppendText(UserAssignmentCount + " Users assignments will be added", Color.Blue);
            lnk = AccToPrdID.Where(l => l.ID == 0 && l.OBJECTTYPE == typeof(ACCSynapseUser_Profile).Name).Count();
            richTextBox1.AppendText(" with " + lnk + " new links\n", UserAssignmentCount == lnk ? Color.Blue : Color.Red);

            richTextBox1.ScrollToCaret();

        }
        private void CopyProperties(object dest, object src)
        {
            Type srctype = src.GetType();
            foreach (PropertyInfo pi in dest.GetType().GetProperties())
            {
                if (pi.CanWrite)
                {
                    if (pi.PropertyType.ToString() != "SynapseCore.Database.LabelBag")
                        pi.SetValue(dest, srctype.GetProperty(pi.Name).GetValue(src, null), null);
                    else
                    {
                        if (chk_save.Checked)
                        {
                            //--------------------------------------------
                            Int64 labelID = 0;
                            string DefaultText = null;
                            LabelId[] ids = (LabelId[])pi.GetCustomAttributes(typeof(LabelId), true);
                            foreach (LabelId id in ids)
                            {
                                PropertyInfo field = src.GetType().GetProperty(id.IDField);
                                labelID = (Int64)field.GetValue(src, null);
                                if (id.DefaultField != null)
                                {
                                    PropertyInfo defaultfield = src.GetType().GetProperty(id.DefaultField);
                                    DefaultText = (string)defaultfield.GetValue(src, null);
                                }
                            }

                            ACCLabelBag srclb = new ACCLabelBag();
                            srclb.load(labelID, DefaultText);
                            //--------------------------------------------
                            LabelBag destlb = new LabelBag();
                            destlb.Labels = new List<SynapseLabel>();
                            //CopyProperties(destlb, srclb);
                            foreach (ACCSynapseLabel a_lbl in srclb.Labels)
                            {
                                SynapseLabel p_lbl = new SynapseLabel();
                                CopyProperties(p_lbl, a_lbl);

                                destlb.Labels.Add(p_lbl);
                            }
                            Int64 nextid = SynapseLabel.GetNextID();
                            foreach (LabelId id in ids)
                            {
                                dest.GetType().GetProperty(id.IDField).SetValue(dest, nextid, null);
                            }
                            foreach (SynapseLabel lbl in destlb.Labels)
                            {
                                lbl.LABELID = nextid;

                            }
                            CreateLinkEntry(srclb, labelID, nextid);
                        }
                    }

                }
            }
        }
        private void CreateLinkEntry(object o, Int64 AccID,Int64 PrdID)
        {
            ACCTOPRD Link = new ACCTOPRD();
            Link.OBJECTTYPE = o.GetType().Name;
            Link.ACCID = AccID;
            Link.PRDID = PrdID;
            AccToPrdID.Add(Link);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ACCSynapseModule  amod in Acc_Modules)            
            {
                SynapseModule pmod = SynapseModule.LoadByID(amod.ID);
                if (amod.TECHNICALNAME == pmod.TECHNICALNAME)
                {
                    pmod.DEVSOURCE = amod.DEVSOURCE;
                    pmod.PRODSOURCE = amod.PRODSOURCE;
                    pmod.MODULECATEGORY = amod.MODULECATEGORY;
                    pmod.PATH = amod.PATH;
                    pmod.save();
                }
            }
            LoadModules();
        }

        private void diffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_diff f_diff = new frm_diff();
            IList<string> InAccOnly = null;
            IList<string> InPrdOnly = null;
            switch (((obj_sync)olv_analyse.SelectedObject).Name)
            { 
                case "SynapseCore.Entities.SynapseUser":
                    InAccOnly = (from au in Acc_Users where !(from pu in Prd_Users select pu.UserID).Contains(au.UserID) select au.UserID + "(" + au.FIRSTNAME + " " + au.LASTNAME + ")").ToList();
                    InPrdOnly = (from pu in Prd_Users where !(from au in Acc_Users select au.UserID).Contains(pu.UserID) select pu.UserID + "(" + pu.FIRSTNAME + " " + pu.LASTNAME + ")").ToList();
                    break;
                case "SynapseCore.Entities.SynapseProfile":
                    InAccOnly = (from ap in Acc_Profiles where !(from pp in Prd_Profiles select pp.TECHNICALNAME).Contains(ap.TECHNICALNAME) select ap.TECHNICALNAME).ToList();
                    InPrdOnly = (from pp in Prd_Profiles where !(from ap in Acc_Profiles select ap.TECHNICALNAME).Contains(pp.TECHNICALNAME) select pp.TECHNICALNAME).ToList();
                    break;
                case "SynapseCore.Entities.SynapseControl":
                    InAccOnly = (from ac in Acc_Controls where !(from pc in Prd_Controls select pc.FORM_NAME+"."+pc.CTRL_NAME).Contains(ac.FORM_NAME+"."+ac.CTRL_NAME) select ac.CTRL_NAME+"."+ac.FORM_NAME).ToList();
                    InPrdOnly = (from pc in Prd_Controls where !(from ac in Acc_Controls select ac.FORM_NAME + "." + ac.CTRL_NAME).Contains(pc.FORM_NAME + "." + pc.CTRL_NAME) select pc.CTRL_NAME + "." + pc.FORM_NAME).ToList();
                    break;
                case "SynapseCore.Entities.SynapseProfile_Control":
                    IList<string> AccID = (from apc in Acc_ProfileControls join ap in Acc_Profiles on apc.FK_PROFILEID equals ap.ID join ac in Acc_Controls on apc.FK_CONTROLID equals ac.ID select ap.TECHNICALNAME+"=>"+ac.FORM_NAME+"."+ac.CTRL_NAME).ToList();
                    IList<string> PrdID = (from ppc in Prd_ProfileControls join pp in Prd_Profiles on ppc.FK_PROFILEID equals pp.ID join pc in Prd_Controls on ppc.FK_CONTROLID equals pc.ID select pp.TECHNICALNAME + "=>" + pc.FORM_NAME + "." + pc.CTRL_NAME).ToList();
                    InPrdOnly = (from ppc in Prd_ProfileControls join pp in Prd_Profiles on ppc.FK_PROFILEID equals pp.ID join pc in Prd_Controls on ppc.FK_CONTROLID equals pc.ID where !AccID.Contains(pp.TECHNICALNAME + "=>" + pc.FORM_NAME + "." + pc.CTRL_NAME) select pp.TECHNICALNAME + "=>" + pc.FORM_NAME + "." + pc.CTRL_NAME).ToList();
                    InAccOnly = (from apc in Acc_ProfileControls join ap in Acc_Profiles on apc.FK_PROFILEID equals ap.ID join ac in Acc_Controls on apc.FK_CONTROLID equals ac.ID where !PrdID.Contains(ap.TECHNICALNAME + "=>" + ac.FORM_NAME + "." + ac.CTRL_NAME) select ap.TECHNICALNAME + "=>" + ac.FORM_NAME + "." + ac.CTRL_NAME).ToList();
                    break;
                case "SynapseCore.Entities.SynapseUser_Profile":
                    IList<string> AccIDup = (from aup in Acc_UserProfiles join ap in Acc_Profiles on aup.FK_SECURITY_PROFILE equals ap.ID join au in Acc_Users on aup.FK_SECURITY_USER equals au.ID select ap.TECHNICALNAME + "=>" + au.UserID).ToList();
                    IList<string> PrdIDup = (from pup in Prd_UserProfiles join pp in Prd_Profiles on pup.FK_SECURITY_PROFILE equals pp.ID join pu in Prd_Users on pup.FK_SECURITY_USER equals pu.ID select pp.TECHNICALNAME + "=>" + pu.UserID).ToList();
                    InPrdOnly = (from pup in Prd_UserProfiles join pp in Prd_Profiles on pup.FK_SECURITY_PROFILE equals pp.ID join pu in Prd_Users on pup.FK_SECURITY_USER equals pu.ID where !AccIDup.Contains(pp.TECHNICALNAME + "=>" + pu.UserID) select pp.TECHNICALNAME + "=>" + pu.UserID + "(" + pu.FIRSTNAME + " " + pu.LASTNAME + ")").ToList();
                    InAccOnly = (from aup in Acc_UserProfiles join ap in Acc_Profiles on aup.FK_SECURITY_PROFILE equals ap.ID join au in Acc_Users on aup.FK_SECURITY_USER equals au.ID where !PrdIDup.Contains(ap.TECHNICALNAME + "=>" + au.UserID) select ap.TECHNICALNAME + "=>" + au.UserID + "(" + au.FIRSTNAME + " " + au.LASTNAME + ")").ToList();
                    break;
            }
            f_diff.AccList.SetObjects(InAccOnly);
            f_diff.PrdList.SetObjects(InPrdOnly);
            f_diff.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ACCSynapseModule mod=null;
            if (olv_Acc_Modules.SelectedObject != null)
                mod = (ACCSynapseModule)olv_Acc_Modules.SelectedObject;
            if (mod != null)
            {
                frm_ReleaseNote releaseNote = new frm_ReleaseNote();
                releaseNote.UID = WindowsIdentity.GetCurrent().Name;
                releaseNote.Rdate = DateTime.Now.ToShortDateString();
                releaseNote.Version = mod.VERSION;
                releaseNote.ShowDialog();
                mod.VERSION = releaseNote.Version;
                mod.VERSIONDATE = releaseNote.Rdate;
                mod.save();
                mod.set_gvf_Version(releaseNote.Rdate,releaseNote.UID,releaseNote.Notes, ACCSynapseModule.SynapseModuleMode.Development);
            }
            LoadModules();

        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ACCSynapseModule mod = null;
            if (olv_Acc_Modules.SelectedObject != null)
                mod = (ACCSynapseModule)olv_Acc_Modules.SelectedObject;
            if (mod != null)
            {
                    ACCSynapseModule amod = (ACCSynapseModule)olv_Acc_Modules.SelectedObject;
                    SynapseModule pmod = SynapseModule.LoadByID(amod.ID);
                    if (pmod != null)
                    {
                        pmod.MODULECATEGORY = amod.MODULECATEGORY;
                        pmod.PATH = amod.PATH;
                        pmod.VERSION = amod.VERSION;
                        pmod.VERSIONDATE = amod.VERSIONDATE;
                        pmod.TECHNICALNAME = amod.TECHNICALNAME;
                        pmod.DEVSOURCE = amod.DEVSOURCE;
                        pmod.PRODSOURCE = amod.PRODSOURCE;
                        pmod.IS_ACTIVE = amod.IS_ACTIVE;
                        pmod.save();
                    }

                if (mod.DEVSOURCE != mod.PRODSOURCE)
                {
                    GenInstaller.Installer.DoInstall(new System.IO.DirectoryInfo(mod.DEVSOURCE), new System.IO.DirectoryInfo(mod.PRODSOURCE), GenInstaller.InstallOptions.Normal);
                    try
                    {
                        GenInstaller.Installer.ChangeTextInFiles("XS006726", "sql-gen-prd.electrabel.be", new System.IO.DirectoryInfo(mod.PRODSOURCE).GetFiles("*.config", System.IO.SearchOption.TopDirectoryOnly));
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            LoadModules();
        }

        private void btn_RefreshUsers_Click(object sender, EventArgs e)
        {
            olv_PRDUSERS.ClearObjects();
            olv_ACCUSERS.ClearObjects();
            Prd_Users = SynapseUser.Load();
            Acc_Users = ACCSynapseUser.Load();
            Prd_UserProfiles = SynapseUser_Profile.Load();
            Acc_UserProfiles = ACCSynapseUser_Profile.Load();
            olv_ACCUSERS.SetObjects(Acc_Users.OrderBy(au=>au.UserID));
            olv_PRDUSERS.SetObjects(Prd_Users.OrderBy(pu=>pu.UserID));

        }

        private void olv_ACCUSERS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_SyncUserDB_Click(object sender, EventArgs e)
        {
            foreach (ACCSynapseUser auser in Acc_Users)
            {
                SynapseUser puser = SynapseUser.LoadByUserID(auser.UserID);
                if (puser.UserID != auser.UserID)
                {
                    puser = new SynapseUser();
                    puser.CULTURE = auser.CULTURE;
                    puser.FIRSTNAME = auser.FIRSTNAME;
                    puser.LASTNAME = auser.LASTNAME;
                    puser.UserID = auser.UserID;
                    puser.save();
                }
            }
            foreach (SynapseUser puser in Prd_Users)
            {
                ACCSynapseUser auser = ACCSynapseUser.LoadByUserID(puser.UserID);
                if (puser.UserID != auser.UserID)
                {
                    auser = new ACCSynapseUser();
                    auser.CULTURE = puser.CULTURE;
                    auser.FIRSTNAME = puser.FIRSTNAME;
                    auser.LASTNAME = puser.LASTNAME;
                    auser.UserID = puser.UserID;
                    auser.save();
                }
            }
            AccToPrdID = ACCTOPRD.Load("WHERE PRDID<>0");
            foreach (ACCSynapseUser auser in Acc_Users)
            {
                SynapseUser puser = SynapseUser.LoadByUserID(auser.UserID);
                if (puser == null)
                {
                    ACCTOPRD lnk = AccToPrdID.Where(a => a.ACCID == auser.ID && a.PRDID == puser.ID && a.OBJECTTYPE == typeof(ACCSynapseUser).Name).FirstOrDefault();
                    if (lnk == null)
                    {
                        lnk = new ACCTOPRD();
                        lnk.OBJECTTYPE = typeof(ACCSynapseUser).Name;
                        lnk.ACCID = auser.ID;
                        lnk.PRDID = puser.ID;
                    }
                }
            }



        }

        private void btn_Prd_Delete_Click(object sender, EventArgs e)
        {
            foreach (SynapseUser u in olv_PRDUSERS.CheckedObjects)
            {
                IList<SynapseUser_Profile> profiles = SynapseUser_Profile.Load("WHERE [FK_SECURITY_USER] = " + u.ID);
                foreach (SynapseUser_Profile up in profiles)
                {
                    up.delete();
                }
                u.delete();
                
            }
        }

        private void btn_Acc_Delete_Click(object sender, EventArgs e)
        {
            foreach (ACCSynapseUser u in olv_ACCUSERS.CheckedObjects)
            {
                IList<ACCSynapseUser_Profile> profiles = ACCSynapseUser_Profile.Load("WHERE [FK_SECURITY_USER] = " + u.ID);
                foreach (ACCSynapseUser_Profile up in profiles)
                {
                    up.delete();
                }
                u.delete();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in olv_ACCUSERS.Items)
            {
                lvi.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in olv_PRDUSERS.Items)
            {
                lvi.Checked = true;
            }
        }

        private void btn_SyncAcc_Click(object sender, EventArgs e)
        {
            SynapseModule mod = SynapseModule.LoadByID((long)comboBox1.SelectedValue);
            IList<ACCSynapseProfile> Ap = ACCSynapseProfile.Load("WHERE FK_MODULEID = " + mod.ID);
            IList<SynapseProfile> Pp = SynapseProfile.Load("WHERE FK_MODULEID = " + mod.ID);
            if (Ap.Count != Pp.Count)
            {
                MessageBox.Show("ERROR : Sync before");
                return;
            }
            IList<ACCTOPRD> links = ACCTOPRD.Load("WHERE OBJECTTYPE = 'ACCSynapseProfile'");
            foreach (ACCSynapseProfile aprof in Ap)
            {
                if (links.Where(l => l.ACCID == aprof.ID).Count() == 0)
                {
                    ACCTOPRD atop = new ACCTOPRD();
                    atop.ACCID = aprof.ID;
                    atop.PRDID = Pp.Where(p => p.TECHNICALNAME == aprof.TECHNICALNAME).FirstOrDefault().ID;
                    atop.OBJECTTYPE = typeof(ACCSynapseProfile).Name;
                    if (atop.ACCID != 0 && atop.PRDID != 0)
                        atop.save();
                }
            }
            links = ACCTOPRD.Load("WHERE OBJECTTYPE = 'ACCSynapseProfile'");
            foreach (ACCSynapseUser u in olv_ACCUSERS.CheckedObjects)
            {
                SynapseUser pu = SynapseUser.LoadByUserID(u.UserID);
                IList<ACCSynapseUser_Profile> AccRoles = ACCSynapseUser_Profile.Load("WHERE [FK_SECURITY_USER] = " + u.ID + " AND [FK_SECURITY_PROFILE] in (" + string.Join(",", Ap.Select(a => a.ID.ToString()).ToArray()) + ")");
                IList<SynapseUser_Profile> PrdRoles = SynapseUser_Profile.Load("WHERE [FK_SECURITY_USER] = " + pu.ID + " AND [FK_SECURITY_PROFILE] in (" + string.Join(",", Pp.Select(a => a.ID.ToString()).ToArray()) + ")");
                foreach (ACCSynapseUser_Profile Aup in AccRoles)
                {
                    if (PrdRoles.Where(pr => pr.FK_SECURITY_PROFILE == Ap.Where(a => a.ID == Aup.FK_SECURITY_PROFILE).FirstOrDefault().PrdID(links)).Count() == 0)
                    {
                        SynapseUser_Profile pup = new SynapseUser_Profile();
                        pup.FK_SECURITY_USER = pu.ID;
                        pup.FK_SECURITY_PROFILE = Ap.Where(a => a.ID == Aup.FK_SECURITY_PROFILE).FirstOrDefault().PrdID(links);
                        if (MessageBox.Show("Add Group "+Ap.Where(a => a.ID == Aup.FK_SECURITY_PROFILE).FirstOrDefault().TECHNICALNAME+" to user "+pu.LASTNAME+" "+pu.FIRSTNAME,"Modify ?",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            pup.save();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str_id = comboBox2.SelectedValue.ToString();

            Acc_Controls = ACCSynapseControl.Load("WHERE FK_MODULE_ID in (" + str_id + ")");
            ResControls = new List<ResourcesControl>();
            richTextBox2.Clear();
            string[] resfiles = Directory.GetFiles(textBox1.Text, "*.SynapseResource");
            foreach (string rf in resfiles)
            {
                string[] reslines = File.ReadAllLines(rf);
                foreach (string rl in reslines)
                {
                    MatchCollection coll = Regex.Matches(rl, @"(?<Form>.*)\x2E(?<Control>.*)=(?<Text>.*)");
                    foreach (Match match in coll)
                    {
                        ResControls.Add(new ResourcesControl { controlName = match.Groups["Control"].Value, formName = match.Groups["Form"].Value });
                    }
                }
            }
            richTextBox2.AppendText(string.Format("Forms found in resources:{0}\n", ResControls.Select(rc => rc.formName).Distinct().Count()));
            richTextBox2.AppendText(string.Format("Controls found in resources:{0}\n", ResControls.Select(rc => rc.formName+"."+rc.controlName).Distinct().Count()));
            richTextBox2.AppendText(string.Format("Forms found in database:{0}\n", Acc_Controls.Select(dc => dc.FORM_NAME).Distinct().Count()));
            richTextBox2.AppendText(string.Format("Controls found in database:{0}\n", Acc_Controls.Select(dc => dc.FORM_NAME+"."+dc.CTRL_NAME).Distinct().Count()));

            var deadctrl = (from c in Acc_Controls where !ResControls.Select(rc => rc.formName + "." + rc.controlName).Distinct().Contains(c.FORM_NAME + "." + c.CTRL_NAME) select c).ToList();

            objectListView1.SetObjects(deadctrl);
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
    public class obj_sync
    {
        public string Name { get; set; }
        public Int64 PrdCnt { get; set; }
        public Int64 AccCnt { get; set; }
        public Int64 Link { get; set; }
        public Int64 State { get{
        if (PrdCnt==AccCnt)
            return 0;
        if (AccCnt>PrdCnt)
            return 1;
        if (PrdCnt>AccCnt)
            return 2;
        return 10;
        } }
    }

    public class ResourcesControl
    {
        public Int64 ModuleID { get; set; }
        public string formName{get;set;}
        public string controlName{get;set;}

    }
}
