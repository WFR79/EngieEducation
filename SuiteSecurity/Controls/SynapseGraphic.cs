using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Graph;

namespace SynapseCore.Controls
{
    public partial class SynapseGraphic : UserControl
    {
        private SynapseGraph _Graph = new SynapseGraph();
        public SynapseGraph Graph
        {
            get { return _Graph; }
        }

        private float _FontSize;
        [Category("Custom Properties"), Description("Font Size")]
        public float FontSize
        {
            get { return _FontSize; }
            set
            {
                _FontSize = value;
                if (_FontSize == 0)
                    _FontSize=8.25F;

                zedGraph.Font = new Font("Microsoft Sans Serif", _FontSize);
            }
        }

        #region Custom Labels of ToolStripButtons
        private string _Text;
        [Category("Custom Labels"), Description("Text")]
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                gbGraph.Text=_Text;
            }
        }
        private string _CopyMenu;
        [Category("Custom Labels"), Description("Label of Copy Button")]
        public string CopyMenu
        {
            get { return _CopyMenu; }
            set 
            { 
                _CopyMenu = value;
                tsbCopy.Text = _CopyMenu;
            }
        }
        private string _SaveAsMenu;
        [Category("Custom Labels"), Description("Label of Save As... Button")]
        public string SaveAsMenu
        {
            get { return _SaveAsMenu; }
            set 
            { 
                _SaveAsMenu = value;
                tsbSave.Text = _SaveAsMenu;
            }
        }
        private string _PageSetupMenu;
        [Category("Custom Labels"), Description("Label of Page Setup... Button")]
        public string PageSetupMenu
        {
            get { return _PageSetupMenu; }
            set 
            { 
                _PageSetupMenu = value;
                tsbPage.Text = _PageSetupMenu;
            }
        }
        private string _PrintMenu;
        [Category("Custom Labels"), Description("Label of Print Button")]
        public string PrintMenu
        {
            get { return _PrintMenu; }
            set 
            { 
                _PrintMenu = value;
                tsbPrint.Text = _PrintMenu;
            }
        }
        private string _ShowPointValuesMenu;
        [Category("Custom Labels"), Description("Label of Show Point Values Button")]
        public string ShowPointValuesMenu
        {
            get { return _ShowPointValuesMenu; }
            set 
            { 
                _ShowPointValuesMenu = value;
                tsbValues.Text = _ShowPointValuesMenu;
            }
        }
        private string _UnZoomMenu;
        [Category("Custom Labels"), Description("Label of Un-Zoom Button")]
        public string UnZoomMenu
        {
            get { return _UnZoomMenu; }
            set 
            { 
                _UnZoomMenu = value;
                tsbZoomOut.Text = _UnZoomMenu;
            }
        }
        private string _UndoAllZoomMenu;
        [Category("Custom Labels"), Description("Label of Undo All Zoom/Pan Button")]
        public string UndoAllZoomMenu
        {
            get { return _UndoAllZoomMenu; }
            set 
            { 
                _UndoAllZoomMenu = value;
                tsbReset.Text = _UndoAllZoomMenu;
            }
        }
        private string _SetDefaultScaleMenu;
        [Category("Custom Labels"), Description("Label of Set Scale to Default Button")]
        public string SetDefaultScaleMenu
        {
            get { return _SetDefaultScaleMenu; }
            set 
            { 
                _SetDefaultScaleMenu = value;
                tsbDefaultScale.Text = _SetDefaultScaleMenu;
            }
        }
        private string _CurvesMenu;
        [Category("Custom Labels"), Description("Label of Curves Button")]
        public string CurvesMenu
        {
            get { return _CurvesMenu; }
            set 
            { 
                _CurvesMenu = value;
                tsbCurves.Text = _CurvesMenu;
            }
        }
        private string _ShowAllCurvesMenu;
        [Category("Custom Labels"), Description("Label of Show All Curves Button")]
        public string ShowAllCurvesMenu
        {
            get { return _ShowAllCurvesMenu; }
            set 
            { 
                _ShowAllCurvesMenu = value;
                tsbShowAll.Text = _ShowAllCurvesMenu;
            }
        }
        private string _ShowHideLegendMenu;
        [Category("Custom Labels"), Description("Label of Show/Hide Legend Button")]
        public string ShowHideLegendMenu
        {
            get { return _ShowHideLegendMenu; }
            set 
            { 
                _ShowHideLegendMenu = value;
                tsbLegend.Text = _ShowHideLegendMenu;
            }
        }
        private string _CurveOnlyMenu;
        [Category("Custom Labels"), Description("Label of This Curve Only Button")]
        public string CurveOnlyMenu
        {
            get { return _CurveOnlyMenu; }
            set { _CurveOnlyMenu = value; }
        }
        private string _ShowHideCurveMenu;
        [Category("Custom Labels"), Description("Label of Show/Hide this Curve Button")]
        public string ShowHideCurveMenu
        {
            get { return _ShowHideCurveMenu; }
            set { _ShowHideCurveMenu = value; }
        }

        private bool _HideCurvesMenu = false;
        [Category("Custom Properties"), Description("Hide Curves Button/Menu")]
        public bool HideCurvesMenu
        {
            get { return _HideCurvesMenu; }
            set
            {
                _HideCurvesMenu = value;
                tsbCurves.Visible = !_HideCurvesMenu;
            }
        }
        private bool _HideShowAllCurvesMenu = false;
        [Category("Custom Properties"), Description("Hide Show All Curves Button/Menu")]
        public bool HideShowAllCurvesMenu
        {
            get { return _HideShowAllCurvesMenu; }
            set
            {
                _HideShowAllCurvesMenu = value;
                tsbShowAll.Visible = !_HideShowAllCurvesMenu;
            }
        }
        #endregion

        public SynapseGraphic()
        {
            InitializeComponent();

            tsbLegend.Checked = true;
            tsbValues.Checked = true;
        }

        public void Clear()
        {
            zedGraph.MasterPane.PaneList.Clear();
             _Graph = new SynapseGraph();
        }

        public void Draw()
        {
             _Graph.CopyMenu = _CopyMenu;
             _Graph.SaveAsMenu = _SaveAsMenu;
             _Graph.PageSetupMenu = _PageSetupMenu;
             _Graph.PrintMenu = _PrintMenu;
             _Graph.ShowPointValuesMenu = _ShowPointValuesMenu;
             _Graph.UnZoomMenu = _UnZoomMenu;
             _Graph.UndoAllZoomMenu = _UndoAllZoomMenu;
             _Graph.SetDefaultScaleMenu = _SetDefaultScaleMenu;
             _Graph.CurvesMenu = _CurvesMenu;
             _Graph.ShowAllCurvesMenu = _ShowAllCurvesMenu;
             _Graph.ShowHideLegendMenu = _ShowHideLegendMenu;
             _Graph.CurveOnlyMenu = _CurveOnlyMenu;
             _Graph.ShowHideCurveMenu = _ShowHideCurveMenu;

             _Graph.HideCurvesMenu = _HideCurvesMenu;
             _Graph.HideShowAllCurvesMenu = _HideShowAllCurvesMenu;

             _Graph.DrawGraph(ref zedGraph);

            addCurvesButtons();

            zedGraph.IsShowPointValues = tsbValues.Checked;
            zedGraph.GraphPane.Legend.IsVisible = tsbLegend.Checked;
            zedGraph.RestoreScale(zedGraph.MasterPane.PaneList[0]);
        }

        #region Graph ToolStrip Properties and Events

        private void addCurvesButtons()
        {
            if (tsbCurves.Visible)
            {
                tsbCurves.DropDownItems.Clear();

                foreach (ZedGraph.CurveItem c in zedGraph.GraphPane.CurveList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();

                    item.Name = c.Label.Text;
                    item.Tag = c.Label.Text;
                    item.Text = c.Label.Text;
                    item.ForeColor = c.Color;

                    ToolStripMenuItem sitem1 = new ToolStripMenuItem();
                    sitem1.Name = c.Label.Text;
                    sitem1.Tag = c.Label.Text;
                    sitem1.Text = _CurveOnlyMenu;
                    sitem1.Click += new EventHandler(ShowOnly_Click);
                    item.DropDownItems.Add(sitem1);

                    ToolStripMenuItem sitem2 = new ToolStripMenuItem();
                    sitem2.Name = c.Label.Text;
                    sitem2.Tag = c.Label.Text;
                    sitem2.Text = _ShowHideCurveMenu;
                    sitem2.Checked = c.IsVisible;
                    sitem2.Click += new EventHandler(HideShow_Click);
                    item.DropDownItems.Add(sitem2);

                    tsbCurves.DropDownItems.Add(item);
                }
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            zedGraph.Copy(true);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            zedGraph.SaveAs();
        }

        private void tsbPage_Click(object sender, EventArgs e)
        {
            zedGraph.DoPageSetup();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            zedGraph.DoPrint();
        }

        private void tsbValues_Click(object sender, EventArgs e)
        {
            tsbValues.Checked = !tsbValues.Checked;
            zedGraph.IsShowPointValues = tsbValues.Checked;
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            zedGraph.ZoomOut(zedGraph.MasterPane.PaneList[0]);
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            zedGraph.ZoomOutAll(zedGraph.MasterPane.PaneList[0]);
        }

        private void tsbDefaultScale_Click(object sender, EventArgs e)
        {
            zedGraph.RestoreScale(zedGraph.MasterPane.PaneList[0]);
        }

        private void tsbLegend_Click(object sender, EventArgs e)
        {
            if (zedGraph.GraphPane != null)
            {
                zedGraph.GraphPane.Legend.IsVisible = !zedGraph.GraphPane.Legend.IsVisible;
                tsbLegend.Checked = zedGraph.GraphPane.Legend.IsVisible;

                zedGraph.AxisChange();
                zedGraph.Refresh();
            }
        }

        private void tsbShowAll_Click(object sender, EventArgs e)
        {
            if (zedGraph.GraphPane != null)
            {
                foreach (ZedGraph.CurveItem c in zedGraph.GraphPane.CurveList)
                {
                    c.IsVisible = true;
                }
                zedGraph.AxisChange();
                zedGraph.Refresh();
            }
        }

        private void ShowOnly_Click(object sender, EventArgs args)
        {
            foreach (ZedGraph.CurveItem c in zedGraph.GraphPane.CurveList)
            {
                if (c.Label.Text == ((ToolStripMenuItem)sender).Name)
                {
                    c.IsVisible = true;
                }
                else
                    c.IsVisible = false;
            }
            zedGraph.AxisChange();
            zedGraph.Refresh();

        }

        private void HideShow_Click(object sender, EventArgs args)
        {
            foreach (ZedGraph.CurveItem c in zedGraph.GraphPane.CurveList)
            {
                if (c.Label.Text == ((ToolStripMenuItem)sender).Name)
                {
                    c.IsVisible = !c.IsVisible;
                    ((ToolStripMenuItem)sender).Checked = c.IsVisible;
                }
            }
            zedGraph.AxisChange();
            zedGraph.Refresh();
        }
        #endregion
    }
}
