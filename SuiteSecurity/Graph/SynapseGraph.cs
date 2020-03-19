using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.ComponentModel;
namespace SynapseCore.Graph
{
    public enum XAxisType
    { 
        Values,
        Labels,
        Dates
    }

    public enum BarType
    {
        Cluster,
        SortedOverlay,
        Stack
    }

    public class SynapseGraph
    {
        GraphPane myPane = new GraphPane();
        List<SynapseGraphTrace> TraceCollection = new List<SynapseGraphTrace>();
        public string Title
        { get; set; }
        public string X_Axis_Title
        { get; set; }
        public string Y_Axis_Title
        { get; set; }

        ZedGraphControl zedGraph;

        public SynapseGraph()
        {

        }

        private XAxisType _XAxisType = XAxisType.Values;

        public XAxisType XAxisType
        {
            get { return _XAxisType; }
            set { _XAxisType = value; }
        }

        private float _XAxisAngle = 0;

        public float XAxisAngle
        {
            get { return _XAxisAngle; }
            set { _XAxisAngle = value; }
        }

        private BarType _BarType = BarType.SortedOverlay;

        public BarType BarType
        {
            get { return _BarType; }
            set { _BarType = value; }
        }

        private bool _AddTextValue = false;

        public bool AddTextValue
        {
            get { return _AddTextValue; }
            set { _AddTextValue = value; }
        }

        private string _TextValueFormat = "0";

        public string TextValueFormat
        {
            get { return _TextValueFormat; }
            set { _TextValueFormat = value; }
        }

        private int _TextValueFontSize = 7;
        public int TextValueFontSize
        {
            get { return _TextValueFontSize; }
            set { _TextValueFontSize = value; }
        }

        private TraceType _TraceType;

        public TraceType TraceType
        {
            get { return _TraceType; }
            set { _TraceType = value; }
        }

        public GraphPane MyPane
        {
            get { return myPane; }
            set { myPane = value; }
        }

        #region Custom Labels of Context Menus
        private string _CopyMenu;
        public string CopyMenu
        {
            get { return _CopyMenu; }
            set { _CopyMenu = value; }
        }
        private string _SaveAsMenu;
        public string SaveAsMenu
        {
            get { return _SaveAsMenu; }
            set { _SaveAsMenu = value; }
        }
        private string _PageSetupMenu;
        public string PageSetupMenu
        {
            get { return _PageSetupMenu; }
            set { _PageSetupMenu = value; }
        }
        private string _PrintMenu;
        public string PrintMenu
        {
            get { return _PrintMenu; }
            set { _PrintMenu = value; }
        }
        private string _ShowPointValuesMenu;
        public string ShowPointValuesMenu
        {
            get { return _ShowPointValuesMenu; }
            set { _ShowPointValuesMenu = value; }
        }
        private string _UnZoomMenu;
        public string UnZoomMenu
        {
            get { return _UnZoomMenu; }
            set { _UnZoomMenu = value; }
        }
        private string _UndoAllZoomMenu;
        public string UndoAllZoomMenu
        {
            get { return _UndoAllZoomMenu; }
            set { _UndoAllZoomMenu = value; }
        }
        private string _SetDefaultScaleMenu;
        public string SetDefaultScaleMenu
        {
            get { return _SetDefaultScaleMenu; }
            set { _SetDefaultScaleMenu = value; }
        }
        private string _CurvesMenu;
        public string CurvesMenu
        {
            get { return _CurvesMenu; }
            set { _CurvesMenu = value; }
        }
        private string _ShowAllCurvesMenu;
        public string ShowAllCurvesMenu
        {
            get { return _ShowAllCurvesMenu; }
            set { _ShowAllCurvesMenu = value; }
        }
        private string _ShowHideLegendMenu;
        public string ShowHideLegendMenu
        {
            get { return _ShowHideLegendMenu; }
            set { _ShowHideLegendMenu = value; }
        }
        private string _CurveOnlyMenu;
        public string CurveOnlyMenu
        {
            get { return _CurveOnlyMenu; }
            set { _CurveOnlyMenu = value; }
        }
        private string _ShowHideCurveMenu;
        public string ShowHideCurveMenu
        {
            get { return _ShowHideCurveMenu; }
            set { _ShowHideCurveMenu = value; }
        }

        private bool _HideCurvesMenu = false;
        public bool HideCurvesMenu
        {
            get { return _HideCurvesMenu; }
            set { _HideCurvesMenu = value; }
        }
        private bool _HideShowAllCurvesMenu = false;
        public bool HideShowAllCurvesMenu
        {
            get { return _HideShowAllCurvesMenu; }
            set { _HideShowAllCurvesMenu = value; }
        }
        #endregion

        public void ConfigPane()
        {
            myPane = new GraphPane();
            //myPane.Fill = new Fill(Color.FromArgb(210, 210, 210), Color.FromArgb(240, 250, 240));
            myPane.Fill = new Fill(Color.LightGray);

            // Set the Titles
            myPane.Title.Text = Title;
            myPane.Title.FontSpec.Size = 12;

            myPane.XAxis.Title.Text = X_Axis_Title;
            myPane.YAxis.Title.Text = Y_Axis_Title;

            myPane.XAxis.Title.FontSpec.Size = 10;
            myPane.YAxis.Title.FontSpec.Size = 10;

            myPane.XAxis.Scale.FontSpec.Size = 10;
            myPane.YAxis.Scale.FontSpec.Size = 10;

            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.MajorGrid.Color = Color.Gray;

            myPane.XAxis.Scale.FontSpec.Angle = _XAxisAngle;

            // Add a background gradient fill to the axis frame
            //myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), -45F);
            myPane.Chart.Fill = new Fill(Color.White);
            myPane.Legend.Position = ZedGraph.LegendPos.Right;
            myPane.Legend.FontSpec.Size = 10;

            switch (_BarType)
            {
                case Graph.BarType.Cluster:
                    myPane.BarSettings.Type = ZedGraph.BarType.Cluster;
                    myPane.XAxis.MajorTic.IsBetweenLabels=true;
                    break;
                case Graph.BarType.SortedOverlay:
                    myPane.BarSettings.Type = ZedGraph.BarType.SortedOverlay;
                    myPane.XAxis.MajorTic.IsBetweenLabels = false;
                    break;
                case Graph.BarType.Stack:
                    myPane.BarSettings.Type = ZedGraph.BarType.Stack;
                    myPane.XAxis.MajorTic.IsBetweenLabels = false;
                    break;
            }

            myPane.BarSettings.MinBarGap = 0.1F;
            myPane.BarSettings.ClusterScaleWidthAuto = true;

            switch (_XAxisType)
            { 
                case Graph.XAxisType.Values:
                    myPane.XAxis.Type = AxisType.Linear;
                    break;
                case Graph.XAxisType.Labels:
                    myPane.XAxis.Type = AxisType.Text;
                    break;
                case Graph.XAxisType.Dates:
                    myPane.XAxis.Type = AxisType.Date;
                    //myPane.XAxis.Scale.Format="dd/MM/yyyy";
                    break;
            }

        }
        public void DrawPane()
        {
            List<string> Labels = new List<string>();
            foreach (SynapseGraphTrace trace in TraceCollection)
            {
                Labels = (from p in trace.PointList.OrderBy(p => p.x) select p.label).ToList();
                PointPairList _pointPairList = new PointPairList();
                switch (trace.XType)
                {
                    case XAxisType.Dates:
                        foreach (SynapseGraphPoint p in trace.PointList.OrderBy(t => t.x))
                        {
                            _pointPairList.Add((double)new XDate(p.Date), (double)p.y);
                        }
                        break;
                    default:
                        foreach (SynapseGraphPoint p in trace.PointList.OrderBy(t => t.x))
                        {
                            _pointPairList.Add((double)p.x, (double)p.y);
                        }
                        break;  
                }
                
                switch (trace.Type)
                {
                    case TraceType.Curve:
                        LineItem _curveItem = myPane.AddCurve(trace.Label, _pointPairList, trace.Color, trace.Symbol);
                        _curveItem.Tag = trace.Tag;
                        _curveItem.Symbol.Size = 6.0F;
                        _curveItem.Line.IsSmooth = true;
                        _curveItem.Line.SmoothTension = 0.5F;
                        break;
                    case TraceType.Line:
                        LineItem _lineItem = myPane.AddCurve(trace.Label, _pointPairList, trace.Color, trace.Symbol);
                        _lineItem.Tag = trace.Tag;
                        _lineItem.Symbol.Size = 6.0F;
                        _lineItem.Line.IsSmooth = true;
                        _lineItem.Line.SmoothTension = 0.0F;
                        break;
                    case TraceType.Square:
                        LineItem _squareItem = myPane.AddCurve(trace.Label, _pointPairList, trace.Color, SymbolType.Square);
                        _squareItem.Tag = trace.Tag;
                        _squareItem.Symbol.Size = 8.0F;
                        _squareItem.Symbol.Fill = new Fill(trace.Color);
                        _squareItem.Line.IsVisible = false;
                        _squareItem.Line.IsSmooth = true;
                        _squareItem.Line.SmoothTension = 0.0F;
                        break;
                    case TraceType.Bar:
                        BarItem myBar = myPane.AddBar(trace.Label, _pointPairList, trace.Color);
                        myBar.Tag = trace.Tag;
                        break;
                }
            }
            myPane.XAxis.Scale.TextLabels = Labels.ToArray();
            //myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;
        }
        public void AddTace(string label, IList<SynapseGraphPoint> ListOfPoint, TraceType type, Color color, SymbolType symbol = SymbolType.Default, object Tag = null, XAxisType xtype= Graph.XAxisType.Values)
        {
            TraceCollection.Add(new SynapseGraphTrace(label, type, ListOfPoint, color, symbol, Tag,xtype));
            XAxisType = xtype;
        }
        public void DrawValues()
        {
            if (_AddTextValue && _TraceType == TraceType.Bar)
                BarItem.CreateBarLabels(myPane, false, "0", "Arial", 7, Color.Black, false, false, false);

            if (_AddTextValue && (_TraceType == TraceType.Square || TraceType == TraceType.Line || TraceType == TraceType.Curve))
            {
                foreach (SynapseGraphTrace trace in TraceCollection)
                {
                    foreach (SynapseGraphPoint pt in trace.PointList)
                    {
                        string lb = pt.y.ToString(_TextValueFormat);
                        TextObj text = new TextObj();
                        text.Text = lb;
                        text.Location.AlignH = AlignH.Left;
                        text.Location.AlignV = AlignV.Bottom;
                        text.Location.CoordinateFrame = CoordType.AxisXYScale;
                        //text.Location.X = (float)pt.x - 0.06;
                        //text.Location.Y = (float)pt.y + 0.1;

                        text.Location.X = trace.XType == Graph.XAxisType.Dates ? (float)((new XDate(pt.Date))) : (float)pt.x - 0.14;
                        text.Location.Y = (float)pt.y * 1.05;// -1.3;

                        text.ZOrder = ZOrder.A_InFront;
                        text.FontSpec.Size = _TextValueFontSize;
                        text.FontSpec.Border.IsVisible = false;
                        text.FontSpec.Fill.IsVisible = false;

                        myPane.GraphObjList.Add(text);
                    }
                }
            }
        }

        public void DrawGraph(ref ZedGraphControl control)
        {
            zedGraph = control;
            ConfigPane();
            DrawPane();
            DrawValues();
            
            zedGraph.GraphPane = myPane;
            zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);
            zedGraph.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);
            zedGraph.GraphPane.ReSize(zedGraph.CreateGraphics(), zedGraph.MasterPane.Rect);

            zedGraph.AxisChange();
        }

        public Bitmap GetImage(int width, int height, float dpi, bool isAntiAlias,bool init=true)
        {
            if (init)
            {
                ConfigPane();
                DrawPane();
            }
            myPane.AxisChange();
           
            return myPane.GetImage(width, height, dpi, isAntiAlias);
        }

        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
              CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];
            //return string.Format(GetLabel("graph_PointValue"),curve.Label.Text, pt.X.ToString("f0"), pt.Y.ToString("f2"));
            return pt.Y.ToString("f2");
        }

        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            if (control.IsShowContextMenu)
            {
                menuStrip.Items.Find("copy", false).FirstOrDefault().Text = _CopyMenu;
                menuStrip.Items.Find("save_as", false).FirstOrDefault().Text = _SaveAsMenu;
                menuStrip.Items.Find("page_setup", false).FirstOrDefault().Text = _PageSetupMenu;
                menuStrip.Items.Find("print", false).FirstOrDefault().Text = _PrintMenu;
                menuStrip.Items.Find("show_val", false).FirstOrDefault().Text = _ShowPointValuesMenu;
                menuStrip.Items.Find("unzoom", false).FirstOrDefault().Text = _UnZoomMenu;
                menuStrip.Items.Find("undo_all", false).FirstOrDefault().Text = _UndoAllZoomMenu;
                menuStrip.Items.Find("set_default", false).FirstOrDefault().Text = _SetDefaultScaleMenu;

                if (menuStrip.Items.Count > 8)
                {
                    for (int i = menuStrip.Items.Count; i > 8; i--)
                    {
                        menuStrip.Items.RemoveAt(i - 1);
                    }
                }

                ToolStripMenuItem ShowAll = new ToolStripMenuItem();
                ShowAll.Text = _ShowAllCurvesMenu;
                ShowAll.Click += new EventHandler(ShowAll_Click);

                ToolStripMenuItem Legend = new ToolStripMenuItem();
                Legend.Text = _ShowHideLegendMenu;
                Legend.Checked = zedGraph.GraphPane.Legend.IsVisible;
                Legend.Click += new EventHandler(Legend_Click);

                ToolStripMenuItem Curves = new ToolStripMenuItem();
                Curves.Text = _CurvesMenu;

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

                    Curves.DropDownItems.Add(item);
                }

                if (!_HideCurvesMenu)
                    menuStrip.Items.Add(Curves);
                if (!_HideShowAllCurvesMenu)
                    menuStrip.Items.Add(ShowAll);
                menuStrip.Items.Add(Legend);
            }
        }

        void Legend_Click(object sender, EventArgs e)
        {
            zedGraph.GraphPane.Legend.IsVisible = !zedGraph.GraphPane.Legend.IsVisible;
            ((ToolStripMenuItem)sender).Checked = zedGraph.GraphPane.Legend.IsVisible;
            zedGraph.AxisChange();
            zedGraph.Refresh();
        }

        void ShowAll_Click(object sender, EventArgs e)
        {
            foreach (ZedGraph.CurveItem c in zedGraph.GraphPane.CurveList)
            {
                c.IsVisible = true;
            }
            zedGraph.AxisChange();
            zedGraph.Refresh();

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
    }
}
