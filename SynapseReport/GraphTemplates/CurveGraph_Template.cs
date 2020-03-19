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
    class CurveGraph_Template : IGraph
    {
        public void Generate(ref ZedGraph.ZedGraphControl graph, String _query, Definition _report, List<Field> _fields)
        {
            GraphPane myPane = graph.GraphPane;

            myPane.Fill = new Fill(Color.FromArgb(210, 210, 210), Color.FromArgb(240, 250, 240));
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), -45F);
            myPane.Legend.Position = ZedGraph.LegendPos.Right;
            myPane.Legend.FontSpec.Size = 12;

            myPane.Title.Text = _report.LABEL.ToString();
            myPane.XAxis.Title.Text = ((Field)_fields[0]).ALIAS.ToString();

            DataTable DT = new DataTable();
            DT = SynapseCore.Database.DBFunction.GetTableFromQuery(_query);
            
            List<PointPairList> allY = new List<PointPairList>();
            for (int y = 1; y < DT.Rows[0].ItemArray.Count(); y++)
            {
                allY.Add(new PointPairList());
            }

            foreach (DataRow dr in DT.Rows)
            {
                for (int y=1; y < dr.ItemArray.Count(); y++)
                {
                    ((PointPairList)allY[y-1]).Add(double.Parse(dr[0].ToString()), double.Parse(dr[y].ToString()));
                }
            }
            Random random = new Random();
            foreach(PointPairList ppl in allY)
            {
                int r = random.Next(0,255);
                int g = random.Next(0, 255);
                int b = random.Next(0, 255);
                string curveTitle = ((Field)_fields[allY.IndexOf(ppl) + 1]).ALIAS.ToString();
                myPane.AddCurve(curveTitle, ppl, Color.FromArgb(r, g, b), SymbolType.Diamond);
            }

            myPane.Legend.IsVisible = true;
            graph.AxisChange();
        }
    }
}
