using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using Module_Gaziview.Entities;
using ZedGraph;
using SynapseCore.Graph;

namespace Module_Gaziview
{
    public partial class frm_BDFHistory : SynapseForm
    {
        IList<o_Unit> Units;
        IList<o_Chain> Chains;

        public frm_BDFHistory()
        {
            InitializeComponent();
        }

        private void frm_BDFHistory_Load(object sender, EventArgs e)
        {
            Units = o_Unit.Load();
            cb_Unit.DisplayMember = "Name";
            cb_Unit.ValueMember = "ID";
            cb_Unit.DataSource = Units;
        }

        private void cb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Chain.Text = "";
            Chains = o_Chain.Load("where UnitID=" + cb_Unit.SelectedValue);
            cb_Chain.DisplayMember = "Name";
            cb_Chain.ValueMember = "ID";
            cb_Chain.DataSource = Chains;
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            synapseGraphic1.Clear();
            string chainclause = "ChainID=" + cb_Chain.SelectedValue;
            string query = "SELECT * " +
                            "FROM        [Gaziview_Constant] " +
                            "WHERE " + chainclause + " AND DateFrom<>'"+DateTime.MaxValue.ToString("yyyy-MM-dd")+"' ORDER BY [DateFrom]";

            IList<o_Constant> Data = o_Constant.LoadFromQuery(query);



                IList<SynapseGraphPoint> PointsBDF = new List<SynapseGraphPoint>();
                IList<SynapseGraphPoint> PointsDET = new List<SynapseGraphPoint>();

                    foreach (o_Constant c in Data.OrderBy(d=>d.DateFrom))
                    {
                        PointsBDF.Add(new SynapseGraphPoint() { Date = c.DateFrom, y = (float)c.BackgroundNoise, label = c.DateFrom.ToString("dd/MM/yyyy"), Tag = ((float)c.BackgroundNoise).ToString() });
                        PointsDET.Add(new SynapseGraphPoint() { Date = c.DateFrom, y = (float)c.DetectionLimit, label = c.DateFrom.ToString("dd/MM/yyyy"), Tag = ((float)c.DetectionLimit).ToString() });

                    }
                    synapseGraphic1.Graph.XAxisType = XAxisType.Dates;
                    synapseGraphic1.Graph.AddTace("BDF", PointsBDF, TraceType.Line, Helper.colors[0], Helper.symbols[0], null, XAxisType.Dates);
                    synapseGraphic1.Graph.AddTace("Limite de detection", PointsDET, TraceType.Line, Helper.colors[1], Helper.symbols[1], null, XAxisType.Dates);

                    synapseGraphic1.Graph.XAxisAngle = 90;
                    synapseGraphic1.Graph.TextValueFormat = "0.00E+00";
                    synapseGraphic1.Graph.Title = String.Format("Historique {0}", cb_Chain.Text);
                    synapseGraphic1.Graph.Y_Axis_Title = "Bq/m³";

                    synapseGraphic1.Draw();

                    synapseGraphic1.Graph.AddTextValue = false;
                    synapseGraphic1.Graph.MyPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;
                    synapseGraphic1.Graph.MyPane.Legend.IsVisible = true;

                    //synapseGraphic1.Graph.MyPane.XAxis.Scale.Min = new XDate(dtp_SelectedDate.Value.AddDays(-15));
                    //synapseGraphic1.Graph.MyPane.XAxis.Scale.Max = new XDate(dtp_SelectedDate.Value);

                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Month;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorStep = 1;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Month;
                    synapseGraphic1.Graph.MyPane.AxisChange();
                    synapseGraphic1.Refresh();
                



        
            

        }
    }
}
