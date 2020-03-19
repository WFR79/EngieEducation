using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using SynapseCore.Controls;
using SynapseCore.Entities;
using Synapse.Entities;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Synapse
{
    public partial class Startup : SynapseForm
    {
        private TreeNode oldTreeNode;
        private int catWidth = 0;
        private IList<SynapseFavorite> _Favorites;
        SynapseModule.SynapseModuleMode CurrentMode = SynapseModule.SynapseModuleMode.Production;

        public Startup()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            tsbRun.Enabled = false;
            ctxRun.Enabled = false;
            mnuRun.Enabled = false;
            tsbRemove.Enabled = false;
            ctxRemove.Enabled = false;
            mnuRemove.Enabled = false;
            tsbAddFavorites.Enabled = false;
            ctxAddFavorites.Enabled = false;
            mnuAddFavorites.Enabled = false;
            ctxPaste.Enabled = false;
            ctxDesktopShortcut.Enabled = false;
            mnuDesktopShortcut.Enabled = false;
            ctxForceInstall.Enabled = false;
            mnuForceInstall.Enabled = false;

            tsbModules.Visible = false;
            tsbSecurity.Visible = false;
            tsbAdministration.Visible = currentUserIsOwner();

            loadModules();
            loadCategories();
            loadFavorites();

            lvModule.View = View.LargeIcon;
            tsbIcons.Checked = true;
            ctxIcons.Checked = true;
            mnuIcons.Checked = true;

            tssUser.Text = string.Format("{0} {1} ({2})", FormUser.FirstName, FormUser.LastName, FormUser.UserID);
            lbDetail.Text = string.Format(GetLabel("Startup.DetailFormat"), CurrentSynapse.FriendlyName, CurrentSynapse.VERSION, CurrentSynapse.VERSIONDATE);
            pnlDetail.TitleText = GetLabel("Startup.pnlDetail");
            pnlCategories.TitleText = GetLabel("Startup.pnlCategories");
            pnlFavorites.TitleText = GetLabel("Startup.pnlFavorites");
            lvModule.Columns[0].Text = GetLabel("Startup.lvModule.col1");
            lvModule.Columns[1].Text = GetLabel("Startup.lvModule.col2");
            lvModule.Columns[2].Text = GetLabel("Startup.lvModule.col3");
            ctxRemoveFavorites.Text = GetLabel("Startup.ctxRemoveFavorites");
            if (this.BackColor != SystemColors.Control)
                toolStrip2.BackColor = this.BackColor;
        }

        private bool currentUserIsOwner()
        {
            foreach (SynapseProfile prf in FormUser.Groups)
            {
                if (prf.IS_OWNER || prf.TECHNICALNAME == "SYNAPSE_SECURITY_ADMIN")
                    return true;
            }
            return false;
        }

        private void loadModules(string cat="")
        {
            smallImages.Images.Clear();
            largeImages.Images.Clear();
            if (SynapseCore.Database.DBFunction.ConnectionName != "Default")
            {
                CurrentMode = SynapseModule.SynapseModuleMode.Development;
            }
            IList<SynapseModule> AllModules = SynapseModule.Load(); 
            lvModule.Items.Clear();
            lvModule.Groups.Clear();
            treeFavorites.Nodes.Clear();
            string[] SynapseDirs = new string[] { "ModulesIcons", "Prod", "Dev", "Resources", "AllSynapseResources" };
            foreach (DirectoryInfo dir in new DirectoryInfo(Application.StartupPath).GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                if (!SynapseDirs.Contains(dir.Name))
                    dir.Delete(true);
            }
            IEnumerable<SynapseModule> Modules;
            if (cat == "")
                Modules = from x in FormUser.Modules where x.ID != 1 select x;
            else
                Modules = from x in FormUser.Modules where x.ID != 1 && x.MODULECATEGORY == cat select x;

            //clean modules
            foreach (SynapseModule mod in (from m in AllModules where !FormUser.Modules.Select(mod=>mod.ID).Contains(m.ID) select m))
            {
                mod.UnInstall(Application.StartupPath,CurrentMode);
            }
            
            foreach (SynapseModule module in Modules)
            {
                if (!module.is_uptodate(Application.StartupPath,CurrentMode))
                {
                    module.Update(Application.StartupPath,CurrentMode);
                }

                ListViewItem lvi = new ListViewItem();
                lvi.UseItemStyleForSubItems = false;
                lvi.Font = new System.Drawing.Font(lvi.Font, FontStyle.Bold);
                lvi.ForeColor = Color.DarkBlue;
                lvi.Name = module.TECHNICALNAME;
                lvi.Text = module.FriendlyName.ToString();
                lvi.SubItems.Add(module.Description.ToString());
                lvi.SubItems.Add(module.VERSION);
                lvi.SubItems.Add(module.PATH);
                lvi.SubItems.Add(module.VERSIONDATE);
                
                lvi.Tag = module;

                ListViewGroup lgroup = new ListViewGroup(module.MODULECATEGORY, module.MODULECATEGORY);
                if (!lvModule.Groups.Contains(lgroup))
                    lvModule.Groups.Add(lgroup);
                lvi.Group = lvModule.Groups[module.MODULECATEGORY];

                string IconFile = Application.StartupPath + (CurrentMode==SynapseModule.SynapseModuleMode.Production?"\\Prod\\":"\\Dev\\") + module.TECHNICALNAME + "\\" + module.TECHNICALNAME + ".ico";

                Image img;
                if (File.Exists(IconFile))
                {
                    img =Image.FromFile(IconFile);
                }
                else
                {
                    img = Image.FromFile(Application.StartupPath + "\\ModulesIcons\\Default.png");
                }

                smallImages.Images.Add(module.TECHNICALNAME, img);
                largeImages.Images.Add(module.TECHNICALNAME, img);

                Bitmap bm = MakeGrayscale(new Bitmap(img));
                smallImages.Images.Add(module.TECHNICALNAME + "_INACTIVE", bm);
                largeImages.Images.Add(module.TECHNICALNAME + "_INACTIVE", bm);

                string Inactive = module.IS_ACTIVE ? "" : "_INACTIVE";
                lvi.ImageKey = module.TECHNICALNAME + Inactive;

                lvModule.Items.Add(lvi);
            }
        }

        private void Change_Views(object sender, EventArgs e)
        {
            tsbTiles.Checked = false;
            tsbIcons.Checked = false;
            tsbList.Checked = false;
            tsbDetail.Checked = false;

            ctxTiles.Checked = false;
            ctxIcons.Checked = false;
            ctxList.Checked = false;
            ctxDetail.Checked = false;

            mnuTiles.Checked = false;
            mnuIcons.Checked = false;
            mnuList.Checked = false;
            mnuDetail.Checked = false;

            ToolStripMenuItem mnu;
            mnu=(ToolStripMenuItem)sender;

            switch (mnu.Name)
            {
                case "tsbTiles":
                case "mnuTiles":
                case "ctxTiles":
                    lvModule.View = View.Tile;
                    tsbTiles.Checked = true;
                    ctxTiles.Checked = true;
                    mnuTiles.Checked = true;
                    break;
                case "tsbIcons":
                case "mnuIcons":
                case "ctxIcons":
                    lvModule.View = View.LargeIcon;
                    tsbIcons.Checked = true;
                    ctxIcons.Checked = true;
                    mnuIcons.Checked = true;
                    break;
                case "tsbList":
                case "mnuList":
                case "ctxList":
                    lvModule.View = View.List;
                    lvModule.Columns[0].Width = 200;
                    tsbList.Checked = true;
                    ctxList.Checked = true;
                    mnuList.Checked = true;
                    break;
                case "tsbDetail":
                case "mnuDetail":
                case "ctxDetail":
                    lvModule.View = View.Details;
                    tsbDetail.Checked = true;
                    ctxDetail.Checked = true;
                    mnuDetail.Checked = true;
                    break;
                default:
                    lvModule.View = View.LargeIcon;
                    tsbIcons.Checked = true;
                    ctxIcons.Checked = true;
                    mnuIcons.Checked = true;
                    break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count == 0)
            {
                lbDetailTitle.Text = CurrentSynapse.TECHNICALNAME;
                lbDetail.Text = string.Format(GetLabel("Startup.DetailFormat"), CurrentSynapse.FriendlyName, CurrentSynapse.VERSION, CurrentSynapse.VERSIONDATE); 
                tsbRun.Enabled = false;
                ctxRun.Enabled = false;
                mnuRun.Enabled = false;
                tsbRemove.Enabled = false;
                ctxRemove.Enabled = false;
                mnuRemove.Enabled = false;
                tsbAddFavorites.Enabled = false;
                ctxAddFavorites.Enabled = false;
                mnuAddFavorites.Enabled = false;
                ctxDesktopShortcut.Enabled = false;
                mnuDesktopShortcut.Enabled = false;
                ctxForceInstall.Enabled = false;
                mnuForceInstall.Enabled = false;
            }
            else
            {
                tsbRun.Enabled = true;
                ctxRun.Enabled = true;
                mnuRun.Enabled = true;
                tsbAddFavorites.Enabled = true;
                ctxAddFavorites.Enabled = true;
                mnuAddFavorites.Enabled = true;

                if (lvModule.SelectedItems[0].Group == lvModule.Groups["X"])
                {
                    tsbRemove.Enabled = true;
                    ctxRemove.Enabled = true;
                    mnuRemove.Enabled = true;
                }
                else
                {
                    tsbRemove.Enabled = false;
                    ctxRemove.Enabled = false;
                    mnuRemove.Enabled = false;

                    ctxDesktopShortcut.Enabled = true;
                    mnuDesktopShortcut.Enabled = true;
                    ctxForceInstall.Enabled = true;
                    mnuForceInstall.Enabled = true;
                }

                lbDetailTitle.Text = lvModule.SelectedItems[0].SubItems[0].Text;
                lbDetail.Text = string.Format(GetLabel("Startup.DetailFormat"), lvModule.SelectedItems[0].SubItems[1].Text, lvModule.SelectedItems[0].SubItems[2].Text, lvModule.SelectedItems[0].SubItems[4].Text);
            }
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (lvModule.SelectedItems.Count > 0)
                {
                    ((SynapseModule)lvModule.SelectedItems[0].Tag).start(Application.StartupPath);
                }
            }
        }

        private void RemovePersonal_Module(object sender, EventArgs e)
        {
            if (MessageBox.Show(GetLabel("Startup.Quest001"), GetLabel("Startup.ModuleRemoval"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lvModule.SelectedItems.Count>0)
                {
                    int index = 0;
                    foreach (SynapseFavorite fav in from f in _Favorites where f.FAVTYPE == 2 select f)
                    {
                        if (fav.TEXT == lvModule.SelectedItems[0].Text)
                        {
                            index = _Favorites.IndexOf(fav);
                            if (fav.ID != 0)
                                fav.delete();
                            break;
                        }
                    }
                    _Favorites.RemoveAt(index);
                    lvModule.SelectedItems[0].Remove();
                }
            }
        }

        private void Refresh_List(object sender, EventArgs e)
        {
            FormUser.ReloadModulesAndGroups();

            loadModules();
            loadCategories();
            loadFavorites();
        }

        private void Start_Module(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count > 0)
            {
                if (lvModule.SelectedItems[0].Tag is SynapseModule)
                    StartSynapseModule((SynapseModule)lvModule.SelectedItems[0].Tag);
                else
                    StartOtherModule((string)lvModule.SelectedItems[0].Tag, false);
                
                lvModule.SelectedItems.Clear();                
            }
        }

        private void StartSynapseModule(SynapseModule thisModule)
        {
            if (thisModule.IS_ACTIVE)
            {
                string args = CurrentMode == SynapseModule.SynapseModuleMode.Production ? "" : "/dev";
                thisModule.start(Application.StartupPath, args, CurrentMode);
            }
            else
            {
                MessageBox.Show(GetLabel("Err.0019"), "Synapse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartOtherModule(string path, bool checkIfSynapseModule)
        {
            if (checkIfSynapseModule)
            {
                SynapseModule mod = SynapseModule.Load("WHERE PATH='" + path + "'").FirstOrDefault();
                if (mod != null)
                {
                    StartSynapseModule(mod);
                    return;
                }
            }

            try
            {
                if (path.Substring(path.Length - 3, 3) == "lnk")
                    Process.Start(path);
                else
                {
                    ProcessStartInfo pStart = new ProcessStartInfo(path);
                    pStart.WorkingDirectory = path.Substring(0, path.LastIndexOf("\\"));
                    pStart.UseShellExecute = false;

                    Process.Start(pStart);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("This Module ({0}) could not be Started: {1}", path, ex.Message), GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            treeFavorites.SelectedNode = null;
        }

        private void AddToFavorites(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count > 0)
            {
                TreeNode treen;
                treen = new TreeNode(lvModule.SelectedItems[0].Text);
                treen.ImageKey = lvModule.SelectedItems[0].ImageKey;
                treen.SelectedImageKey = lvModule.SelectedItems[0].ImageKey;
                treeFavorites.Nodes.Add(treen);

                SynapseFavorite fav = new SynapseFavorite();

                if (lvModule.SelectedItems[0].Tag.GetType().ToString() == "System.String")
                {
                    treen.Tag = (String)lvModule.SelectedItems[0].Tag;
                    fav.PATH = (String)lvModule.SelectedItems[0].Tag;
                    fav.TECHNICALNAME = lvModule.SelectedItems[0].Text;
                }
                else
                {
                    treen.Tag = ((SynapseModule)lvModule.SelectedItems[0].Tag).PATH;
                    fav.PATH=((SynapseModule)lvModule.SelectedItems[0].Tag).PATH;
                    fav.TECHNICALNAME=((SynapseModule)lvModule.SelectedItems[0].Tag).TECHNICALNAME;
                }

                fav.TEXT = lvModule.SelectedItems[0].Text;
                fav.FAVTYPE = 1;
                fav.USERID=FormUser.UserID;
                
                _Favorites.Add(fav);

                treeFavorites.Sort();
            }
        }

        private void RemoveFavorites_Click(object sender, EventArgs e)
        {
            if (treeFavorites.SelectedNode != null)
            {
                int index = 0;
                foreach (SynapseFavorite fav in from f in _Favorites where f.FAVTYPE==1 select f)
                {
                    if (fav.TEXT == treeFavorites.SelectedNode.Text)
                    {
                        index = _Favorites.IndexOf(fav);
                        if (fav.ID!=0)
                            fav.delete();
                        break;
                    }
                }
                _Favorites.RemoveAt(index);
                treeFavorites.SelectedNode.Remove();
                treeFavorites.SelectedNode = null;
            }
        }

        private void Request_Module(object sender, EventArgs e)
        {
            frmRequest fRequest=new frmRequest();
            fRequest.ShowDialog();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            ctxRemoveFavorites.Enabled = false;
            TreeNode treen = treeFavorites.GetNodeAt(e.X, e.Y);

            if (treen != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    treeFavorites.SelectedNode = treen;
                    ctxRemoveFavorites.Enabled = true;
                }
                else
                {
                    StartOtherModule((string)treen.Tag, true);
                }
            }
        }

        private void AddPersonal_Module(object sender, EventArgs e)
        {
            addLocalModule();
        }

        private void addLocalModule()
        {
            openFileDialog1.Filter = "Executable (*.exe; *.lnk)|*.exe;*.lnk";
            openFileDialog1.InitialDirectory="C:\\";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fname = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1, openFileDialog1.FileName.Length - (openFileDialog1.FileName.LastIndexOf("\\") + 5));
                string cmdLine = openFileDialog1.FileName;
                addModuleToList(fname, cmdLine);
            }
        }

        private void addModuleToList(string fname, string cmdLine)
        {
            ListViewItem item;

            smallImages.Images.Add(fname, getIcon(cmdLine));
            largeImages.Images.Add(fname, getIcon(cmdLine));

            item = new ListViewItem(fname);
            item.UseItemStyleForSubItems = false;
            item.Font = new System.Drawing.Font(item.Font, FontStyle.Bold);
            item.ForeColor = Color.DarkBlue;
            item.Tag = cmdLine;
            item.SubItems.Add(cmdLine);
            item.SubItems.Add(getVersion(cmdLine));
            item.SubItems.Add(cmdLine);
            item.SubItems.Add(getDate(cmdLine));
            item.ImageKey = fname;

            SynapseFavorite fav = new SynapseFavorite();
            fav.FAVTYPE = 2;
            fav.PATH = cmdLine;
            fav.TEXT = fname;
            fav.USERID = FormUser.UserID;
            fav.TECHNICALNAME = fname;
            _Favorites.Add(fav);

            if (lvModule.Groups["X"] == null)
            {
                ListViewGroup group;
                group = new ListViewGroup("X", GetLabel("Startup.Personal"));
                lvModule.Groups.Add(group);
            }

            item.Group = lvModule.Groups["X"];
            lvModule.Items.Add(item);
        }

        private Icon getIcon(string filePath)
        {
            Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            try
            {
                //Gets the icon associated with the currently executing assembly
                //(or pass a different file path and name for a different executable)
                appIcon = Icon.ExtractAssociatedIcon(filePath);
            }
            catch (Exception ex)
            {
                //handle
            }
            return appIcon;
        }

        private string getVersion(string filePath)
        {
            string fileVer = "";
            try
            {
                FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(filePath);
                fileVer=myFI.FileMajorPart + "." + myFI.FileMinorPart;
            }
            catch (Exception ex)
            {

            }

            return fileVer;
        }

        private string getDate(string filePath)
        {
            string fileDate = "";
            try
            {
                DateTime lastModified = System.IO.File.GetLastWriteTime(filePath);
                fileDate = lastModified.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {

            }
            return fileDate;
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treen;
            treen = new TreeNode(lvModule.SelectedItems[0].Text);
            if (lvModule.SelectedItems[0].Tag is SynapseModule)
                treen.Tag = ((SynapseModule)lvModule.SelectedItems[0].Tag).PATH;
            else
                treen.Tag = lvModule.SelectedItems[0].Tag;

            treen.ImageKey = lvModule.SelectedItems[0].ImageKey;
            treen.SelectedImageKey = lvModule.SelectedItems[0].ImageKey;

            DoDragDrop(treen, DragDropEffects.Copy);
        }

        private void favorites_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void favorites_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode",true)==true)
            {
                TreeNode tmpNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                treeFavorites.Nodes.Add(tmpNode);

                SynapseFavorite fav = new SynapseFavorite();
                fav.PATH = tmpNode.Tag.ToString();
                fav.TEXT = tmpNode.Text;
                fav.USERID = FormUser.UserID;
                fav.FAVTYPE = 1;
                fav.TECHNICALNAME = tmpNode.SelectedImageKey;

                _Favorites.Add(fav);

                treeFavorites.Sort();
            }
        }

        private void modules_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void modules_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string cmdLine in files) 
            {
                string fname = cmdLine.Substring(cmdLine.LastIndexOf("\\") + 1, cmdLine.Length - (cmdLine.LastIndexOf("\\") + 5));

                addModuleToList(fname, cmdLine);
            } 
        }

        private void ctxPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = (string[])Clipboard.GetData(DataFormats.FileDrop);
                foreach (string cmdLine in files)
                {
                    string fname = cmdLine.Substring(cmdLine.LastIndexOf("\\") + 1, cmdLine.Length - (cmdLine.LastIndexOf("\\") + 5));

                    addModuleToList(fname, cmdLine);
                }

                Clipboard.Clear();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.FileDrop, false))
            {
                ctxPaste.Enabled = true;
            }
            else
            {
                ctxPaste.Enabled = false;
            }
        }

        private void loadCategories()
        {
            treeCategories.Nodes.Clear();

            TreeNode treen2;

            treen2 = new TreeNode(GetLabel("Startup.Categories.All"));
            treen2.Tag = "";
            treeCategories.Nodes.Add(treen2);

            foreach (string modcat in (from x in FormUser.Modules where x.ID != 1 select x.MODULECATEGORY).Distinct())
            {
                treen2 = new TreeNode(modcat);
                treen2.Tag = modcat;
                treeCategories.Nodes[0].Nodes.Add(treen2);
            }
            treen2 = new TreeNode(GetLabel("Startup.Categories.Personal"));
            treen2.Tag = "X";
            treeCategories.Nodes[0].Nodes.Add(treen2);

            treeCategories.ExpandAll();
        }

        private void ShowHide_Categories(object sender, EventArgs e)
        {
            //if (tsbCategories.CheckState == CheckState.Checked)
            //{
            //    treeCategories.Visible = true;
            //    lvModule.Left = lvModule.Left + catWidth;
            //    lvModule.Width = lvModule.Width - catWidth;
            //    treeCategories.ExpandAll();
            //}
            //else
            //{
            //    treeCategories.Visible = false;
            //    lvModule.Left = lvModule.Left - catWidth;
            //    lvModule.Width = lvModule.Width + catWidth;
            //}
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeCategories.SelectedNode.Level == 1)
            {
                loadModules((string)treeCategories.SelectedNode.Tag);
                if ((string)treeCategories.SelectedNode.Tag == "X")
                {
                    loadFavorites();
                }
                else
                {
                    loadFavorites(true);
                }
            }
            else
            {
                loadModules();
                loadFavorites();
            }
        }

        private void Admin_Security(object sender, EventArgs e)
        {
            UserEdit myUserEditForm = new UserEdit();
            myUserEditForm.Show();
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }

        private void loadFavorites(bool onlyFavorites = false)
        {
            _Favorites = SynapseFavorite.LoadFromQuery("SELECT * FROM [Synapse_Favorites] WHERE USERID='" + FormUser.UserID + "'");
            foreach (SynapseFavorite Fav in _Favorites)
            {
                if (Fav.FAVTYPE == 1)
                {
                    TreeNode treen;

                    smallImages.Images.Add(Fav.TECHNICALNAME, getIcon(Fav.PATH));
                    largeImages.Images.Add(Fav.TECHNICALNAME, getIcon(Fav.PATH));

                    treen = new TreeNode(Fav.TEXT);
                    treen.Tag = Fav.PATH;
                    treen.ImageKey = Fav.TECHNICALNAME;
                    treen.SelectedImageKey = Fav.TECHNICALNAME;
                    treeFavorites.Nodes.Add(treen);
                }
                else
                {
                    if (!onlyFavorites)
                    { 
                        ListViewItem item;

                        smallImages.Images.Add(Fav.TECHNICALNAME, getIcon(Fav.PATH));
                        largeImages.Images.Add(Fav.TECHNICALNAME, getIcon(Fav.PATH));

                        item = new ListViewItem(Fav.TECHNICALNAME);
                        item.UseItemStyleForSubItems = false;
                        item.Tag = Fav.PATH;
                        item.SubItems.Add(Fav.PATH);
                        item.SubItems.Add(getVersion(Fav.PATH));
                        item.SubItems.Add(Fav.PATH);
                        item.SubItems.Add(getDate(Fav.PATH));
                        item.ImageKey = Fav.TECHNICALNAME;
                        if (lvModule.Groups["X"] == null)
                        {
                            ListViewGroup group;
                            group = new ListViewGroup("X", GetLabel("Startup.Personal"));
                            lvModule.Groups.Add(group);
                        }

                        item.Group = lvModule.Groups["X"];
                        item.ForeColor = Color.DarkBlue;
                        item.Font = new System.Drawing.Font(item.Font, FontStyle.Bold);
                        lvModule.Items.Add(item);
                    }
                }
            }

            treeFavorites.Sort();
        }

        private void Admin_Module(object sender, EventArgs e)
        {
            frm_ModulesEdit moduleEdit = new frm_ModulesEdit();
            moduleEdit.Show();
        }

        private void Startup_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (SynapseFavorite fav in _Favorites)
            {
                fav.save();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbAdministration_Click(object sender, EventArgs e)
        {
            frmAdministration fAdministration = new frmAdministration();
            fAdministration.Show();
        }

        private void tsbLabo_Click(object sender, EventArgs e)
        {

            string file = Application.ExecutablePath;

            if (file != null)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("starting " + file);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                proc.StartInfo.FileName = file;
                proc.StartInfo.WorkingDirectory = Path.GetFullPath(file);
                //proc.StartInfo.Arguments = filename;
                proc.StartInfo.Arguments = "/con:ACC";
                proc.Start();
                this.Close();
            }
        }

        private void forceInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count > 0)
            {
                if (lvModule.SelectedItems[0].Tag is SynapseModule)
                {
                    SynapseModule module = ((SynapseModule)lvModule.SelectedItems[0].Tag);
                    smallImages.Images.RemoveByKey(module.TECHNICALNAME);
                    largeImages.Images.RemoveByKey(module.TECHNICALNAME);

                        module.ForceUpdate(Application.StartupPath, CurrentMode);
                        string IconFile = Application.StartupPath + (CurrentMode == SynapseModule.SynapseModuleMode.Production ? "\\Prod\\" : "\\Dev\\") + module.TECHNICALNAME + "\\" + module.TECHNICALNAME + ".ico";

                        if (File.Exists(IconFile))
                        {
                            smallImages.Images.Add(module.TECHNICALNAME, Image.FromFile(IconFile));
                            largeImages.Images.Add(module.TECHNICALNAME, Image.FromFile(IconFile));
                        }
                        else
                        {
                            smallImages.Images.Add(module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\Default.png"));
                            largeImages.Images.Add(module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\Default.png"));
                        }
                }

                lvModule.SelectedItems.Clear();
            }
        }

        private void ctxDesktopShortcut_Click(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count > 0)
            {
                if (lvModule.SelectedItems[0].Tag is SynapseModule)
                {
                    SynapseModule module = ((SynapseModule)lvModule.SelectedItems[0].Tag);
                    string modulefile = module.getModuleExecutablePath(Application.StartupPath, CurrentMode);

                    if (modulefile != null)
                    {
                        IShellLink link = (IShellLink)new ShellLink();
                        link.SetDescription(module.FriendlyName.ToString());
                        link.SetPath(modulefile);
                        link.SetIconLocation(Application.StartupPath + (CurrentMode == SynapseModule.SynapseModuleMode.Production ? "\\Prod\\" : "\\Dev\\") + module.TECHNICALNAME + "\\" + module.TECHNICALNAME + ".ico", 0);

                        IPersistFile file = (IPersistFile)link;
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                        file.Save(Path.Combine(desktopPath, (CurrentMode == SynapseModule.SynapseModuleMode.Production ? "" : "(Test) ") + module.FriendlyName.ToString() + ".lnk"), false);
                    }
                }
            }
        }

        private static Bitmap MakeGrayscale(Bitmap original)
        {
            //make an empty bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = original.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    int grayScale = (int)((originalColor.R * .299) + (originalColor.G * .587) + (originalColor.B * .114));

                    //create the color object
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    //set the new image's pixel to the grayscale version
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Used for Desktop Shortcut Creation
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

}
