using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;
using SynapseCore.Entities;
using SynapseReport.Entities;
using System.Data;
namespace SynapseReport.GraphTemplates
{
    class BarGraph_Template : IGraph
    {
        public void Generate(ref ZedGraph.ZedGraphControl graph, String _query, Definition _report, List<Field> _fields)
        {
            GraphPane myPane = graph.GraphPane;

            myPane.Fill = new Fill(Color.FromArgb(210, 210, 210), Color.FromArgb(240, 250, 240));
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), -45F);
            myPane.Legend.Position = ZedGraph.LegendPos.Right;
            myPane.Legend.FontSpec.Size = 7;

            myPane.Title.Text = _report.LABEL.ToString();
            myPane.XAxis.Title.Text = ((Field)_fields[0]).ALIAS.ToString();
            myPane.YAxis.Title.Text = ((Field)_fields[1]).ALIAS.ToString();

            DataTable DT = new DataTable();
            DT = SynapseCore.Database.DBFunction.GetTableFromQuery(_query);

            double[] y = new double[DT.Rows.Count];
            string[] x = new string[DT.Rows.Count];

            int i = 0;
            foreach (DataRow dr in DT.Rows)
            { 
                x[i]=dr[0].ToString();
                y[i] = double.Parse(dr[1].ToString());
                i++;
            }

            BarItem myCurve = myPane.AddBar("Curve 1", null, y, Color.White);
            myPane.XAxis.Scale.TextLabels = x;

            myPane.XAxis.Scale.FontSpec.Angle = 90;
            myPane.XAxis.Scale.FontSpec.Size = 8;

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
