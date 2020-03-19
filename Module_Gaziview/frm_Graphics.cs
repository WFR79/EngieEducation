using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Module_Gaziview.Entities;
using SynapseCore.Graph;
using SynapseCore.Controls;
using ZedGraph;

namespace Module_Gaziview
{
    public partial class frm_Graphics : SynapseForm
    {
        public frm_Graphics(DateTime date)
        {
            InitializeComponent();
            dtp_SelectedDate.Value = date;
        }

        private void frm_Graphics_Load(object sender, EventArgs e)
        {
            cb_Unit.DisplayMember = "Name";
            cb_Unit.ValueMember = "ID";
            cb_Unit.DataSource = o_Unit.Load();

            synapseGraphic1.Graph.Title = string.Empty;
        }

        public void btn_Draw_Click(object sender, EventArgs e)
        {
            synapseGraphic1.Clear();
            string datewhereclause = cb_Type.Text.Contains("14") ? "Date BETWEEN '" + dtp_SelectedDate.Value.AddDays(-14).ToString("yyyy-MM-dd") + "' AND '" + dtp_SelectedDate.Value.ToString("yyyy-MM-dd") + "'" : "Date BETWEEN '" + Helper.FirstDateOfWeek(dtp_SelectedDate.Value.Year, 1).ToString("yyyy-MM-dd") + "' AND '" + (Helper.FirstDateOfWeek(dtp_SelectedDate.Value.Year + 1, 1).AddDays(-1)).ToString("yyyy-MM-dd") + "'";
            // "Date BETWEEN '"+dtp_SelectedDate.Value.Year+"-01-01' AND '"+dtp_SelectedDate.Value.Year+"-12-31'";
            string unitclause = "UnitID=" + cb_Unit.SelectedValue;
            string query = "SELECT dbo.Gaziview_VW_GasEmission.*, dbo.Gaziview_Chain.UnitID " +
                            "FROM         dbo.Gaziview_VW_GasEmission INNER JOIN " +
                            "dbo.Gaziview_Chain ON dbo.Gaziview_VW_GasEmission.ChainID = dbo.Gaziview_Chain.ID WHERE "+datewhereclause+" AND "+unitclause+" ORDER BY Date";
            
            IList<o_GasEmission> Data = o_GasEmission.LoadFromQuery(query);
            
            IList<o_Chain> Chains = o_Chain.Load("WHERE " + unitclause);
            int ChainIndex =0;
            foreach(o_Chain Chain in Chains)
            {
                IList<SynapseGraphPoint> Points = new List<SynapseGraphPoint>();
                if (cb_Type.Text.Contains("14"))
                {
                    foreach (o_GasEmission GE in Data.Where(ge => ge.ChainID == Chain.ID).OrderBy(ge=>ge.Date))
                    {
                        Points.Add(new SynapseGraphPoint() { Date = GE.Date, y = (float)GE.EmissionDecl / 1000000000, label = GE.Date.ToString("dd/MM/yyyy"), Tag = ((float)GE.EmissionDecl / 1000000000).ToString() });
                    }
                    synapseGraphic1.Graph.XAxisType = XAxisType.Dates;
                    synapseGraphic1.Graph.AddTace(Chain.Name, Points.OrderBy(p => p.Date).ToList(), TraceType.Curve, Helper.colors[ChainIndex], Helper.symbols[ChainIndex++], null, XAxisType.Dates);
                    synapseGraphic1.Graph.XAxisAngle = 90;
                    synapseGraphic1.Graph.TextValueFormat = "0.00E+00";
                    synapseGraphic1.Graph.Title = String.Format("Rejets {0}", ((o_Unit)cb_Unit.SelectedItem).Name);
                    synapseGraphic1.Graph.Y_Axis_Title = "GBq";

                    synapseGraphic1.Draw();

                    synapseGraphic1.Graph.AddTextValue = chk_Values.Checked;
                    synapseGraphic1.Graph.MyPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;
                    synapseGraphic1.Graph.MyPane.Legend.IsVisible = true;

                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Min = new XDate(dtp_SelectedDate.Value.AddDays(-15));
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Max = new XDate(dtp_SelectedDate.Value);

                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Day;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorStep = 1;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Day;
                    synapseGraphic1.Graph.MyPane.AxisChange();
                    synapseGraphic1.Refresh();
                }
                else
                {
                    Points = (from d in Data.Where(ge => ge.ChainID == Chain.ID) group d by d.WeekNr into g select new SynapseGraphPoint() { x = g.Key, y = (float)g.Sum(s => s.EmissionDecl) / 1000000000, Tag = ((float)g.Sum(s => s.EmissionDecl) / 1000000000).ToString() }).ToList();
                    synapseGraphic1.Graph.XAxisType = XAxisType.Values;
                    synapseGraphic1.Graph.AddTace(Chain.Name, Points.OrderBy(p => p.label).ToList(), TraceType.Curve, Helper.colors[ChainIndex], Helper.symbols[ChainIndex++], null, XAxisType.Values);
                    synapseGraphic1.Graph.TextValueFormat = "0.00E+00";
                    synapseGraphic1.Graph.Title = String.Format("Rejets {0} - {1}", ((o_Unit)cb_Unit.SelectedItem).Name, dtp_SelectedDate.Value.Year);
                    synapseGraphic1.Graph.Y_Axis_Title = "GBq";
                    synapseGraphic1.Graph.X_Axis_Title = "n° de la semaine";

                    synapseGraphic1.Draw();

                    synapseGraphic1.Graph.AddTextValue = chk_Values.Checked;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Min = 0;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Max = Helper.GetNumbersOfWeek(dtp_SelectedDate.Value.Year) + 1;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorStep = 2;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);

                    synapseGraphic1.Graph.MyPane.AxisChange();
                    synapseGraphic1.Refresh();
                }


                
            }

           
            synapseGraphic1.Graph.MyPane.AxisChange();
            
            synapseGraphic1.Refresh();
            

        }
    }
}
