using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace SynapseStatistics
{
    public class StatReport_TableSize:IReport
    {
        public void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            GraphPane myPane = graph.GraphPane;

            myPane.Fill = new Fill(Color.FromArgb(210, 210, 210), Color.FromArgb(240, 250, 240));
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);
            myPane.Legend.Position = ZedGraph.LegendPos.Right;
            myPane.Legend.FontSpec.Size = 7;

            myPane.Title.Text = "Table Size report";
            myPane.XAxis.Title.Text = "Table";
            myPane.YAxis.Title.Text = "Size in MB";

            graph.AxisChange();

            IList<E_Label_Value> List = E_Label_Value.LoadFromQuery("SELECT [TableName] as Label ,[TotalSpaceMB] as Value FROM [SYNAPSE].[dbo].[V_Synapse_DB_USAGE] order by Label");

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

            myPane.XAxis.Scale.FontSpec.Angle = 90;
            myPane.XAxis.Scale.FontSpec.Size = 5;

            myCurve.Bar.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.Legend.IsVisible = false;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            graph.AxisChange();
        }
    }
}
