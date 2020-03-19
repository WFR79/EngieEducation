using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseReport.Entities;
using SynapseReport.UserControls;
using SynapseReport.Functionalities;
using SynapseCore.Database;
using SynapseAdvancedControls;

namespace SynapseReport.Forms
{
    public partial class frmReport : SynapseForm
    {
        private bool _standAlone;
        private bool _SplitResized = false;
        private Int64 _InterfaceID = 0;

        public Int64 InterfaceID
        {
            get { return _InterfaceID; }
            set { _InterfaceID = value; }
        }

        public frmReport()
        {
            _standAlone = false;
            InitializeComponent();
            setAspectGetter();
        }

        public frmReport(bool StandAlone=false)
        {
            _standAlone = StandAlone;
            InitializeComponent();
            setAspectGetter();
        }

        private void setAspectGetter()
        {
            #region AspectGetter
            treeReport.CanExpandGetter = delegate(object x)
            {
                if (x is Category)
                {
                    return true;
                }
                else
                    return false;
            };

            treeReport.ChildrenGetter = delegate(object x)
            {
                Category _cat = (Category)x;
                IList<Definition> _reports = new List<Definition>();

                _reports = Definition.Load("WHERE SynapseReport_DEFINITION.FK_CATEGORY=" + _cat.ID + " AND SynapseReport_DEFINITION.AVAILABLE='True'");

                return _reports.OrderBy(l =>l.LABEL.ToString());
            };

            colName.AspectGetter = delegate(object x)
            {
                if (x is Category)
                    return (((Category)x).LABEL.ToString());
                else
                    return (((Definition)x).LABEL.ToString());
            };

            colName.ImageGetter = delegate(object x)
            {
                if (x is Category)
                    return "category";
                else
                    return "report";
            };
            #endregion
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            if (!_standAlone)
            {
                this.mnuMain.Visible = false;
                this.statusStrip.Visible = false;

                if (!_SplitResized)
                {
                    splitContainer1.Top = splitContainer1.Top - mnuMain.Height;
                    splitContainer1.Height = splitContainer1.Height + mnuMain.Height + statusStrip.Height;
                    _SplitResized = true;
                }
            }
            else
            { 
                tssUser.Text = string.Format("{0} {1} ({2})", FormUser.FirstName, FormUser.LastName, FormUser.UserID);            
            }
            lbModule.Text = GlobalVariables.selectedOrigin.FriendlyName.ToString();
            this.Text = GetLabel("frmReport") + " - " + lbModule.Text;
            tabControl1.Visible = false;
            tabControl1.TabPages.Clear();
            listCategory();

            treeReport.ExpandAll();
        }

        private void listCategory()
        {
            IList<Category> _Categories = new List<Category>();

            string _Query = "";
            if (_InterfaceID != 0)
                _Query = " OR FK_INTERFACE=" + _InterfaceID;

            switch (GlobalVariables.selectedOrigin.ORIGIN)
            {
                case Origin.Module:
                    _Categories = Category.Load("WHERE FK_MODULE=" + GlobalVariables.selectedOrigin.MODULEID + _Query);
                    break;
                case Origin.Interface:
                    _Categories = Category.Load("WHERE FK_INTERFACE=" + GlobalVariables.selectedOrigin.INTERFACEID);
                    break;
            }
            treeReport.SetObjects(_Categories.OrderBy(c => c.LABEL.ToString()));
        }

        private void treeReport_DoubleClick(object sender, EventArgs e)
        {
            if (treeReport.SelectedObject != null)
            {
                if (treeReport.SelectedObject is Category)
                {
                    if (treeReport.IsExpanded(treeReport.SelectedObject))
                        treeReport.Collapse(treeReport.SelectedObject);
                    else
                        treeReport.Expand(treeReport.SelectedObject);
                }
                else
                {
                    Definition _report = (Definition)treeReport.SelectedObject;

                    // If the Report List is mixed between Modue & Interface, reset the origin for each report
                    if (_InterfaceID!=0)
                        if (_report.FK_INTERFACE != 0)
                            ReportOrigin.setTo(SynapseInterface.LoadByID(_report.FK_INTERFACE));
                        else
                            ReportOrigin.setTo(SynapseModule.LoadByID(_report.FK_MODULE));

                    string pageTitle = string.Empty;

                    if (_report.ADDCATEGORY)
                        pageTitle = Category.LoadByID(_report.FK_CATEGORY).LABEL.ToString() + " - " + _report.LABEL.ToString();
                    else
                        pageTitle = _report.LABEL.ToString();

                    TabPage _page = new TabPage(pageTitle);
                    reportControl _rep = new reportControl();
                    _rep.ReportId = _report.ID;
                    _rep.IsForDesign = false;
                    _rep.Dock = DockStyle.Fill;
                    _rep.Load();
                    _page.Controls.Add(_rep);
                    tabControl1.TabPages.Add(_page);
                    _page.ImageKey = "report";
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    tabControl1.Visible = true;

                    _rep.Focus();
                }
            }
        }

        private void closeThisTab(object sender, EventArgs e)
        {
            closeTab();
        }

        public void closeTab()
        {
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);

            if (tabControl1.TabPages.Count < 1)
            {
                tabControl1.Visible = false;
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbShowList_Click(object sender, EventArgs e)
        {
            if (tsbShowList.Tag.ToString()=="expanded")
            {
                tsbShowList.Tag = "collapsed";
                splitContainer1.Panel1Collapsed = true;
                tsbShowList.Image = Properties.Resources.expandHoriz;
            }
            else
            {
                tsbShowList.Tag = "expanded";
                splitContainer1.Panel1Collapsed = false;
                tsbShowList.Image = Properties.Resources.collapseHoriz;
            }
        }
    }
}
