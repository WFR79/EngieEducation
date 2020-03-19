using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace SynapseStatistics
{
    public class StatReport_TotalUsage:IReport
    {
        public string query="SELECT     cast(sum(cast(dbo.Synapse_Statistics.ACTIVITY_TIME as decimal)/cast(3600 as decimal)) as decimal(18,2)) as Value,  dbo.Synapse_Module.TECHNICALNAME As Label FROM         dbo.Synapse_Statistics INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Statistics.FK_MODULE_ID = dbo.Synapse_Module.ID group by dbo.Synapse_Module.TECHNICALNAME";
        public string title = "Total Usage";
        public string xtitle = "Module";
        public string ytitle = "Time (hours)";
        public int angle = 45;
        public int fontsize = 6;
        public virtual void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            GraphPane myPane = graph.GraphPane;

            myPane.Fill = new Fill(Color.FromArgb(210, 210, 210), Color.FromArgb(240, 250, 240));
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);
            myPane.Legend.Position = ZedGraph.LegendPos.Right;
            myPane.Legend.FontSpec.Size = 7;

            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xtitle;
            myPane.YAxis.Title.Text = ytitle;

            graph.AxisChange();

            IList<E_Label_Value> List = E_Label_Value.LoadFromQuery(query);

            double[] y = new double[List.Count];
            string[] x = new string[List.Count];
            int i = 0;
            foreach (E_Label_Value val in List)
            {
                x[i] = val.Label;
                y[i] = (double)val.Value;
                i++;
            }

            

            BarItem myCurve = myPane.AddBar("Curve 1", null, y, Color.White);
            myPane.XAxis.Scale.TextLabels = x;

            myPane.XAxis.Scale.FontSpec.Angle = angle;
            myPane.XAxis.Scale.FontSpec.Size = fontsize;

            myCurve.Bar.Fill = new Fill(Color.Orange, Color.Red, 45.0f);

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.Legend.IsVisible = false;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            graph.AxisChange();
        }
    }
}
