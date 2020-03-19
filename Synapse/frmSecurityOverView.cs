using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Synapse.Entities;
using SynapseCore.Entities;
using SynapseAdvancedControls;
using System.Collections;
using SynapseCore.Controls;
using System.Resources;


namespace Synapse
{

    public partial class frmSecurityOverView : SynapseForm
    {
        private IList<SynapseModule> ModuleCollection;
        IList<ControlSecurityOverview> myControls;
        IList<SynapseProfile> myProfiles;
        IList<SynapseModule> myModules;
        Hashtable HashMod = new Hashtable();
        ResourceManager resourceManager;
        private bool isExpanded = false;

        public frmSecurityOverView()
        {
            resourceManager = ResourceManager.CreateFileBasedResourceManager("formLabels", Application.StartupPath + @"/AllSynapseResources", null);
            InitializeComponent();
            //olvc_Module.AspectGetter = delegate(object x)
            //{
            //    if (x is string)
            //        return x.ToString();
            //    else
            //        return x;
            //};
            olvc_Comment.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };
            olvc_GROUP.ImageGetter = delegate(object x)
            {
                if (x is E_module)
                    return "module";
                if (x is E_form)
                    return "form";
                if (x is E_ctrl)
                    return "control";
                if (x is ControlSecurityOverview)
                    return "group";
                return "";
            };
            olvc_Text.AspectGetter = delegate(object x)
            {
                if (x is E_ctrl)
                {
                    E_ctrl Ctrl = (E_ctrl)x;
                    return SynapseCore.Security.Tools.GetLabel(ref resourceManager,Ctrl.form + "." + Ctrl.ctrl,false);
                }
                else
                    return string.Empty;
            };
            treeListView1.CanExpandGetter = delegate(object x)
            {
                if (x is ControlSecurityOverview)
                    return false;
                else
                    return true;
            };
            treeListView1.ChildrenGetter = delegate(object x)
            {
                if (x is E_module)
                {
                    E_module currentModule = (E_module)x;
                    List<E_form> forms = new List<E_form>();

                    foreach (string str in (from m in myControls where m.MODULE == currentModule.GROUP select m.FORM).Distinct())
                    {
                        forms.Add(new E_form(str,currentModule.GROUP));
                    }
                    return forms;
                }
                if (x is E_form)
                {
                    E_form currentForm = (E_form)x;
                    List<E_type> types = new List<E_type>();

                    foreach (string str in (from m in myControls where m.MODULE == currentForm.module && m.FORM == currentForm.form select m.TYPE).Distinct())
                    {
                        types.Add(new E_type(str,currentForm.form,currentForm.module));
                    }
                    return types;
                }
                if (x is E_type)
                {
                    E_type currentType = (E_type)x;
                    List<E_ctrl> ctrls = new List<E_ctrl>();

                    foreach (string str in (from m in myControls where m.MODULE == currentType.module && m.FORM == currentType.form && m.TYPE == currentType.type select m.CONTROL).Distinct())
                    {
                        ctrls.Add(new E_ctrl(str,currentType.type,currentType.form,currentType.module));
                    }
                    return ctrls;
                }
                if (x is E_ctrl)
                {
                    E_ctrl currentCtrl = (E_ctrl)x;
                    IList<ControlSecurityOverview> groups = (from c in myControls where c.MODULE == currentCtrl.module && c.FORM == currentCtrl.form && c.TYPE == currentCtrl.type && c.CONTROL == currentCtrl.ctrl select c).Distinct().ToList();
                    bool containsEverybody = false;
                    if ((from xg in groups where xg.GROUP == "Everybody" select xg).ToList().Count >= 1)
                        containsEverybody = true;
                    if (showImplicitGroupsToolStripMenuItem.Checked)
                    foreach (SynapseProfile profile in (from p in myProfiles where p.FK_ModuleID == (Int64)HashMod[currentCtrl.module] select p))
                    {

                        if ((from g in groups where g.GROUP == profile.TECHNICALNAME select g).ToList().Count == 0)
                        {
                            ControlSecurityOverview cso = new ControlSecurityOverview();
                            cso.GROUP = profile.TECHNICALNAME;
                            if (!containsEverybody)
                            {
                                cso.ACTIVE = false;
                                cso.VISIBLE = false;
                                cso.Comment = "Implicit";
                            }
                            else
                            {
                                cso.ACTIVE = true;
                                cso.VISIBLE = true;
                                cso.Comment = "Implicit as everybody";
                            }
                     

                            groups.Add(cso);
                        }
                    }
                    return (groups);
                }
                return null;
            };
            olvc_ACTIVE.Renderer = new MappedImageRenderer(true, imageList1.Images["true"], false, imageList1.Images["false"]);
            olvc_VISIBLE.Renderer = new MappedImageRenderer(true, imageList1.Images["true"], false, imageList1.Images["false"]);
        }

        private void frmSecurityOverView_Load(object sender, EventArgs e)
        {
            treeListView1.Columns[0].Text = SynapseForm.GetLabel("frmSecurityOverView.olvc_GROUP");
            treeListView1.Columns[1].Text = SynapseForm.GetLabel("frmSecurityOverView.olvc_VISIBLE");
            treeListView1.Columns[2].Text = SynapseForm.GetLabel("frmSecurityOverView.olvc_ACTIVE");
            treeListView1.Columns[3].Text = SynapseForm.GetLabel("frmSecurityOverView.olvc_Text");
            treeListView1.Columns[4].Text = SynapseForm.GetLabel("frmSecurityOverView.olvc_Comment");

            ModuleCollection = SynapseModule.Load();
            myControls = (from c in ControlSecurityOverview.Load() where c.GROUP!="Everybody" select c).ToList();
            myProfiles = SynapseProfile.Load();
            myModules = SynapseModule.Load();
            fillModules();

            foreach (SynapseModule mod in myModules)
            {
                HashMod.Add(mod.TECHNICALNAME, mod.ID);
            }
            List<E_module> modules=new List<E_module>();

            foreach (string str in (from m in myControls select m.MODULE).Distinct())
            {
                modules.Add((E_module)str);
            }

            treeListView1.SetObjects(modules);
        }

        private void fillModules()
        {
            cbModules.Items.Clear();

            if (ModuleCollection != null)
            {
                ModuleCollection = ModuleCollection.OrderBy(x => x.FriendlyName.ToString()).ToList();

                cbModules.Items.Add("*");
                foreach (SynapseModule Mod in ModuleCollection)
                {
                    cbModules.Items.Add(Mod);
                }
                cbModules.SelectedIndex = 0;
            }

            cbModules.DisplayMember = "FriendlyName";
            cbModules.ValueMember = "ID";
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeListView1.ExpandAll();
            isExpanded = true;
        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeListView1.CollapseAll();
            isExpanded = false;
        }

        private void onlyControlsWithSecurityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == onlyControlsWithSecurityToolStripMenuItem)
            {
                onlyControlsWithSecurityToolStripMenuItem.Checked = !onlyControlsWithSecurityToolStripMenuItem.Checked;
                allControlsToolStripMenuItem.Checked = !onlyControlsWithSecurityToolStripMenuItem.Checked;
            }
            if (sender == allControlsToolStripMenuItem)
            {
                allControlsToolStripMenuItem.Checked = !allControlsToolStripMenuItem.Checked;
                onlyControlsWithSecurityToolStripMenuItem.Checked = !allControlsToolStripMenuItem.Checked;
            }
            RefreshTreeview();
        }

        private void RefreshTreeview()
        {
            treeListView1.ClearObjects();

            if (onlyControlsWithSecurityToolStripMenuItem.Checked)
            {
                myControls = (from c in ControlSecurityOverview.Load() where c.GROUP != "Everybody" select c).ToList();
                //treeListView1.ClearObjects();
                //List<E_module> modules = new List<E_module>();

                //foreach (string str in (from m in myControls select m.MODULE).Distinct())
                //{
                //    modules.Add((E_module)str);
                //}

                //treeListView1.SetObjects(modules);
            }
            else
            {
                myControls = ControlSecurityOverview.Load();
                //treeListView1.ClearObjects();
                //List<E_module> modules = new List<E_module>();

                //foreach (string str in (from m in myControls select m.MODULE).Distinct())
                //{
                //    modules.Add((E_module)str);
                //}

                //treeListView1.SetObjects(modules);
            }

            List<E_module> modules = new List<E_module>();

            if (cbModules.SelectedIndex > 0)
            {
                foreach (string str in (from m in myControls where m.MODULEID == ((SynapseModule)cbModules.SelectedItem).ID select m.MODULE).Distinct())
                {
                    modules.Add((E_module)str);
                }
            }
            else
            {
                foreach (string str in (from m in myControls select m.MODULE).Distinct())
                {
                    modules.Add((E_module)str);
                }
            }
            treeListView1.SetObjects(modules);
            if (isExpanded)
                treeListView1.ExpandAll();
        }

        private void showImplicitGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showImplicitGroupsToolStripMenuItem.Checked = !showImplicitGroupsToolStripMenuItem.Checked;
            RefreshTreeview();
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewPrinter lvp = new ListViewPrinter();
            lvp.ListView = treeListView1;
            lvp.Header = "Synapse Security Overview Report";
            lvp.Footer = "By Synapse a generation suite";

            lvp.IsShrinkToFit = true;
          
            lvp.PrintWithDialog();

        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            isExpanded = false;
            RefreshTreeview();
        }

        
    }
    public class E_module
    {
        private string _module;
        public string GROUP
        {
            get { return _module; }
        }
        public E_module(string module)
        {
            _module = module;
        }

        public static implicit operator E_module(string module)
        {
            if (module == null)
                return null;
            return new E_module(module);
        }
    }
    public class E_form
    {
        private string _form;
        private string _module;
        public string GROUP
        {
            get { return _form; }
        }
        public string module
        {
            get { return _module; }
        }
        public string form
        {
            get { return _form; }
        }
        public E_form(string form, string module)
        {
            _form = form;
            _module = module;
        }
    }
    public class E_type
    {
        private string _type;
        private string _form;
        private string _module;
        public string GROUP
        {
            get { return _type.Replace("System.Windows.Forms.", ""); }
        }
        public string module
        {
            get { return _module; }
        }
        public string form
        {
            get { return _form; }
        }
        public string type
        {
            get { return _type; }
        }
        public E_type(string type, string form, string module)
        {
            _type = type;
            _form = form;
            _module = module;
        }


    }
    public class E_ctrl
    {
        private string _ctrl;
        private string _type;
        private string _form;
        private string _module;
        public string GROUP
        {
            get { return _ctrl; }
        }
        public string module
        {
            get { return _module; }
        }
        public string form
        {
            get { return _form; }
        }
        public string type
        {
            get { return _type; }
        }
        public string ctrl
        {
            get { return _ctrl; }
        }

        public E_ctrl(string ctrl, string type, string form, string module)
        {
            _ctrl = ctrl;
            _type = type;
            _form = form;
            _module = module;
        }
    }
}
