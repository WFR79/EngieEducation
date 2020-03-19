using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseAdvancedControls;
using System.Data.Objects;
using SynapseCore.Graph;
using ZedGraph;

namespace SynapseStatistics
{
    public partial class frm_Users : Form
    {
        SynapseStatistics.StatDataEntities db;
        List<Synapse_Security_User> Users;
        DateTime fromdate = DateTime.Now.AddDays(-40);
                
        public frm_Users(string connection)
        {
            InitializeComponent();
            db = new StatDataEntities("name="+connection+"StatDataEntities");
            Users = db.Synapse_Security_User.ToList();
        }

        private void frm_Users_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "TECHNICALNAME";
            comboBox1.DataSource = db.Synapse_Module.ToList();

            

            //objectListView1.SetObjects(Users);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            objectListView1.UseFiltering = true; 
            this.objectListView1.ModelFilter = TextMatchFilter.Contains(this.objectListView1, textBox1.Text);
            
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObject != null)
            {
                string userid = ((Synapse_Security_User)objectListView1.SelectedObject).USERID.ToUpper();
                Int64 moduleid = (Int64)comboBox1.SelectedValue;

                if (!string.IsNullOrEmpty(userid) && moduleid != 0)
                {
                    List<ComputedPeriod> periods = new List<ComputedPeriod>();

                    var brut = db.Synapse_Statistics.Where(s => s.USERID.ToUpper() == userid && s.OPEN_TIME >= fromdate && s.FK_MODULE_ID == moduleid).ToList();

                    foreach (var period in brut.OrderBy(b=>b.OPEN_TIME))
                    {
                        ComputedPeriod cp=null;
                        try
                        {
                             cp = periods.SingleOrDefault(p => (p.start <= period.OPEN_TIME && p.end >= period.OPEN_TIME) || (p.start <= period.CLOSE_TIME && p.end >= period.CLOSE_TIME));
                        }
                        catch (Exception ex)
                        {
                            IEnumerable<ComputedPeriod> more = periods.Where(p => (p.start <= period.OPEN_TIME && p.end >= period.OPEN_TIME) || (p.start <= period.CLOSE_TIME && p.end >= period.CLOSE_TIME));


                        }
                        if (cp == null)
                        {
                            cp = new ComputedPeriod();
                            cp.start = period.OPEN_TIME;
                            cp.end = period.CLOSE_TIME;
                            periods.Add(cp);
                        }
                        else
                        {
                            if (cp.end < period.CLOSE_TIME)
                                cp.end = period.CLOSE_TIME;
                            if (cp.start>period.OPEN_TIME)
                                cp.start=period.OPEN_TIME;

                        }
                    }




                    var forms = (from f in brut group f by new { f.FORMNAME } into gf select new { form = gf.Key.FORMNAME, count = gf.Count() }).ToList();

                    objectListView2.SetObjects(forms);

                    var points3 = (from s in periods group s by new { date = (s.start.Date) } into gs select new { date = gs.Key.date, sum = gs.Sum(q => (q.end-q.start).TotalMinutes) }).ToList();
                    var points = (from s in brut group s by new { date = (s.OPEN_TIME.Date) } into gs select new { date = gs.Key.date, sum = gs.Sum(q => q.OPENED_TIME) }).ToList();
                    var points2 = (from s in brut group s by new { date = (s.OPEN_TIME.Date) } into gs select new { date = gs.Key.date, sum = gs.Sum(q => q.ACTIVITY_TIME) }).ToList();
                    List<SynapseGraphPoint> gpoints = new List<SynapseGraphPoint>();
                    foreach (var p in points)
                    {
                            gpoints.Add(new SynapseGraphPoint() { Date = p.date, y = (float)p.sum/3600 });
                    }
                    List<SynapseGraphPoint> gpoints2 = new List<SynapseGraphPoint>();
                    foreach (var p in points2)
                    {
                            gpoints2.Add(new SynapseGraphPoint() { Date = p.date, y = (float)p.sum/3600 });
                    }
                    List<SynapseGraphPoint> gpoints3 = new List<SynapseGraphPoint>();
                    foreach (var p in points3)
                    {
                            gpoints3.Add(new SynapseGraphPoint() { Date = p.date, y = (float)(p.sum)/60 });
                    }
                    List<SynapseGraphPoint> gpoints4 = new List<SynapseGraphPoint>();
                    foreach (var p in points2)
                    {
                        double factor = points3.SingleOrDefault(p3 => p3.date == p.date).sum / points.SingleOrDefault(p1 => p1.date == p.date).sum;
                        gpoints4.Add(new SynapseGraphPoint() { Date = p.date, y = (float)(p.sum*factor) / (float)(60) });
                    }
                    synapseGraphic1.Clear();

                    synapseGraphic1.Graph.XAxisType = XAxisType.Dates;
                    synapseGraphic1.Graph.AddTace("Open", gpoints, TraceType.Bar, Color.Red, ZedGraph.SymbolType.Circle, null, XAxisType.Dates);
                    synapseGraphic1.Graph.AddTace("Active", gpoints2, TraceType.Bar, Color.Blue, ZedGraph.SymbolType.Circle, null, XAxisType.Dates);
                    synapseGraphic1.Graph.AddTace("Calculated", gpoints3, TraceType.Bar, Color.Yellow, ZedGraph.SymbolType.Circle, null, XAxisType.Dates);
                    synapseGraphic1.Graph.AddTace("Calculated Active", gpoints4, TraceType.Bar, Color.Green, ZedGraph.SymbolType.Circle, null, XAxisType.Dates);

                    synapseGraphic1.Graph.XAxisAngle = 90;
                    synapseGraphic1.Graph.TextValueFormat = "E2";
                    synapseGraphic1.Graph.Title = String.Format("Module usage for {0}", ((Synapse_Security_User)objectListView1.SelectedObject).USERID);
                    synapseGraphic1.Graph.Y_Axis_Title = "Usage in Hours";

                    synapseGraphic1.Draw();

                    //synapseGraphic1.Graph.AddTextValue = true;
                    synapseGraphic1.Graph.MyPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;
                    synapseGraphic1.Graph.MyPane.Legend.IsVisible = true;
                    synapseGraphic1.Graph.MyPane.BarSettings.Type = ZedGraph.BarType.Cluster;
                    synapseGraphic1.Graph.MyPane.BarSettings.MinBarGap = 0.6F;
                    synapseGraphic1.Graph.MyPane.BarSettings.MinClusterGap = 2;
                    //synapseGraphic1.Graph.MyPane.BarSettings.ClusterScaleWidthAuto = true;
                    synapseGraphic1.Graph.MyPane.BarSettings.ClusterScaleWidth = 1.1F;
                    synapseGraphic1.Graph.MyPane.BarSettings.Base = ZedGraph.BarBase.X;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Min = new XDate(fromdate);
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Max = new XDate(DateTime.Now);

                    synapseGraphic1.Graph.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Day;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MajorStep = 1;
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
                    synapseGraphic1.Graph.MyPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Day;

                    synapseGraphic1.Graph.MyPane.AxisChange();
                    synapseGraphic1.Refresh();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           Int64 moduleid = (Int64)comboBox1.SelectedValue;
           List<string> statuserid = db.Synapse_Statistics.Where(s => s.OPEN_TIME > fromdate && s.FK_MODULE_ID == moduleid).Select(s => s.USERID.ToUpper()).Distinct().ToList();

           objectListView1.SetObjects(Users.Where(u => statuserid.Contains(u.USERID.ToUpper())));
        }
    }
}
