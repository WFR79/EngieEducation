using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Module_Gaziview.Entities;
using System.Drawing.Imaging;
using SynapseCore.Controls;
using SynapseCore.Graph;
using ZedGraph;

namespace Module_Gaziview
{
    public partial class frm_Reports : SynapseForm
    {
        private Int64 _UnitID;
        private IList<o_Unit> Units = o_Unit.Load();
        public frm_Reports()
        {
            InitializeComponent();
            cb_Unit.ValueMember = "ID";
            cb_Unit.DisplayMember = "Name";
            cb_Unit.DataSource = Units;
            
        }


        public void SetDate(DateTime Startdate, DateTime Enddate)
        { 
            //this.monthCalendar1.SetDate(date);
            this.monthCalendar2.SelectionStart = Startdate;
            this.monthCalendar2.SelectionEnd = Enddate;

            monthCalendar1_DateChanged(null, null);
        }
        public void SetUnitID(Int64 id)
        {
            _UnitID = id;
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            //monthCalendar1.FirstDayOfWeek = (Day)(Helper.WeekStartDay - 1);
            
        }

        private void frm_Reports_Load(object sender, EventArgs e)
        {
            monthCalendar2.DateChanged -= monthCalendar1_DateChanged;
            int weeknr = Helper.GetWeekNr(monthCalendar2.SelectionStart);
            DateTime firstdate = Helper.FirstDateOfWeek(monthCalendar2.SelectionStart.Year, weeknr);
            monthCalendar2.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));

            monthCalendar2.DateChanged += monthCalendar1_DateChanged;
        }
        
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.DateChanged -= monthCalendar1_DateChanged;
            int weeknr = Helper.GetWeekNr(monthCalendar2.SelectionStart);
            DateTime firstdate = Helper.FirstDateOfWeek(monthCalendar2.SelectionStart.Year, weeknr);
            monthCalendar2.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));

            monthCalendar2.DateChanged += monthCalendar1_DateChanged;
        }

        public void btn_Graph_Click(object sender, EventArgs e)
        {
            int year=monthCalendar2.SelectionStart.Year;

            this.reportViewer1.Clear();
            int WeekNr = Helper.GetWeekNr(monthCalendar2.SelectionEnd);

            if (monthCalendar2.SelectionStart.Year != monthCalendar2.SelectionEnd.Year)
            {
                int day = 0;

                while ((new DateTime(monthCalendar2.SelectionEnd.Year, 01, ++day)).DayOfWeek != DayOfWeek.Thursday) ;

                if (day > monthCalendar2.SelectionEnd.Day)
                    year = monthCalendar2.SelectionStart.Year;
                else
                    year = monthCalendar2.SelectionEnd.Year;
            }

            DateTime firstdate = Helper.FirstDateOfWeek(year, WeekNr).AddDays(-7);
            DateTime lastdate = firstdate.AddDays(13);

            o_Unit unit = o_Unit.LoadByID(_UnitID);

            string datewhereclause7d = "Date BETWEEN '" + firstdate.AddDays(7).ToString("yyyy-MM-dd") + "' AND '" + lastdate.ToString("yyyy-MM-dd") + "'";
            string datewhereclause14d = "Date BETWEEN '" + firstdate.ToString("yyyy-MM-dd") + "' AND '" + lastdate.ToString("yyyy-MM-dd") + "'";
            


            //string datewhereclause1y = "Date BETWEEN '" + DateTime.Now.Year + "-01-01' AND '" + DateTime.Now.Year + "-12-31'";
            string datewhereclause1y = "Date BETWEEN '" + Helper.FirstDateOfWeek(year, 1).ToString("yyyy-MM-dd") + "' AND '" + (Helper.FirstDateOfWeek(year + 1, 1).AddDays(-1)).ToString("yyyy-MM-dd") + "'";

            string unitclause = "UnitID=" + _UnitID;
            string query7d = "SELECT dbo.Gaziview_VW_GasEmission.*, dbo.Gaziview_Chain.UnitID " +
                            "FROM         dbo.Gaziview_VW_GasEmission INNER JOIN " +
                            "dbo.Gaziview_Chain ON dbo.Gaziview_VW_GasEmission.ChainID = dbo.Gaziview_Chain.ID WHERE " + datewhereclause7d + " AND " + unitclause + "[ChainID] ORDER BY Date";
            string query14d = "SELECT dbo.Gaziview_VW_GasEmission.*, dbo.Gaziview_Chain.UnitID " +
                            "FROM         dbo.Gaziview_VW_GasEmission INNER JOIN " +
                            "dbo.Gaziview_Chain ON dbo.Gaziview_VW_GasEmission.ChainID = dbo.Gaziview_Chain.ID WHERE " + datewhereclause14d + " AND " + unitclause + "[ChainID] ORDER BY Date";
            string query1y = "SELECT dbo.Gaziview_VW_GasEmission.*, dbo.Gaziview_Chain.UnitID " +
                            "FROM         dbo.Gaziview_VW_GasEmission INNER JOIN " +
                            "dbo.Gaziview_Chain ON dbo.Gaziview_VW_GasEmission.ChainID = dbo.Gaziview_Chain.ID WHERE " + datewhereclause1y + " AND " + unitclause + "[ChainID] ORDER BY Date";




            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath+ "\\Reports\\EmissionSumary.rdlc";
            o_EmissionReport.LoadChains();
            List<o_EmissionReport> ReportData = (from g in o_GasEmission.LoadFromQuery(query7d.Replace("[ChainID]", "")) select new o_EmissionReport { ChainID = g.ChainID, Date = g.Date, GasEmission = g.GasEmission, GasVolume = g.GasVolume, HS = g.HS, HSChainID = g.HSChainID, ID = g.ID, BackgroundNoise=g.BackgroundNoise, DetectionLimit=g.DetectionLimit, EncodedBy=g.EncodedBy, EncodedDate=g.EncodedDate, LoadSuccessful=g.LoadSuccessful, Remarque=g.Remarque, Valid=g.Valid, ValidationBy=g.ValidationBy, ValidationDate=g.ValidationDate }).ToList();

            if (ReportData.Where(rd => rd.LoadSuccessful == false).Count() > 0)
                MessageBox.Show("Warning some of your data have no valid constants");
            
            this.o_GasEmissionBindingSource.DataSource = ReportData.OrderBy(rd => rd.WeekNr).ThenBy(rd => rd.ChainName);



            SynapseCore.Graph.SynapseGraph graph1 = new SynapseCore.Graph.SynapseGraph();
            graph1.Title = "Rejets Journaliers";
            graph1.XAxisAngle = 65;
            graph1.AddTextValue = false;
            graph1.TextValueFormat = "0.00E+00";
            graph1.TextValueFontSize = 5;

            SynapseCore.Graph.SynapseGraph graph2 = new SynapseCore.Graph.SynapseGraph();
            graph2.Title = "Rejets par semaine - " + year;
            graph2.AddTextValue = false;
            graph2.TextValueFormat = "0.00E+00";
            graph2.TextValueFontSize = 5;

            SynapseCore.Graph.SynapseGraph graph3 = new SynapseCore.Graph.SynapseGraph();
            graph3.Title = "Volumes rejetés";
            graph3.XAxisAngle = 65;
            graph3.AddTextValue = false;
            graph3.TextValueFormat = "0.00E+00";
            graph3.TextValueFontSize = 5;

            int ChainIndex = 0;
            foreach (o_Chain c in o_Chain.Load("where " + unitclause))
            {
                graph1.AddTace(c.Name, (from ge in o_GasEmission.LoadFromQuery(query14d.Replace("[ChainID]", " AND ChainID=" + c.ID.ToString())) select new SynapseGraphPoint() { Date = ge.Date, y = (float)ge.EmissionDecl }).ToList(), TraceType.Curve, Helper.colors[ChainIndex], Helper.symbols[ChainIndex], null, XAxisType.Dates);
                graph2.AddTace(c.Name, (from ge in o_GasEmission.LoadFromQuery(query1y.Replace("[ChainID]", " AND ChainID=" + c.ID.ToString())) group ge by ge.WeekNr into g select new SynapseGraphPoint() { x = g.Key, y = (float)g.Sum(s => s.EmissionDecl) }).ToList(), TraceType.Curve, Helper.colors[ChainIndex], Helper.symbols[ChainIndex], null, XAxisType.Values);
                graph3.AddTace(c.Name, (from ge in o_GasEmission.LoadFromQuery(query14d.Replace("[ChainID]", " AND ChainID=" + c.ID.ToString())) select new SynapseGraphPoint() { Date = ge.Date, y = (float)ge.GasVolume }).ToList(), TraceType.Curve, Helper.colors[ChainIndex], Helper.symbols[ChainIndex++], null, XAxisType.Dates);
            }

            graph1.ConfigPane();
            graph1.DrawPane();
            graph1.DrawValues();
            graph1.MyPane.Legend.IsVisible = true;
            graph1.MyPane.Legend.Position = ZedGraph.LegendPos.TopFlushLeft;
            graph1.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
            graph1.MyPane.XAxis.Scale.Min = new XDate(firstdate.AddDays(-1));
            graph1.MyPane.XAxis.Scale.Max = new XDate(lastdate.AddDays(1));

            graph1.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
            graph1.MyPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Day;
            graph1.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
            graph1.MyPane.XAxis.Scale.MajorStep = 1;
            graph1.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
            graph1.MyPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Day;
            
            graph2.ConfigPane();
            graph2.DrawPane();
            graph2.DrawValues();
            graph2.MyPane.Legend.IsVisible = true;
            graph2.MyPane.Legend.Position = ZedGraph.LegendPos.TopFlushLeft;
            graph2.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
            graph2.MyPane.XAxis.Scale.MajorStep = 2;
            graph2.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
            graph2.MyPane.XAxis.Scale.Min = 0;
            graph2.MyPane.XAxis.Scale.Max = Helper.GetNumbersOfWeek(year) + 1;

            graph3.ConfigPane();
            graph3.DrawPane();
            graph3.DrawValues();
            graph3.MyPane.Legend.IsVisible = true;
            graph3.MyPane.Legend.Position = ZedGraph.LegendPos.TopFlushLeft;
            graph3.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
            graph3.MyPane.XAxis.Scale.Min = new XDate(firstdate.AddDays(-1));
            graph3.MyPane.XAxis.Scale.Max = new XDate(lastdate.AddDays(1));

            graph3.MyPane.XAxis.Scale.Format = "dd/MM/yyyy";
            graph3.MyPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Day;
            graph3.MyPane.XAxis.Scale.IsPreventLabelOverlap = false;
            graph3.MyPane.XAxis.Scale.MajorStep = 1;
            graph3.MyPane.XAxis.Scale.MinorStep = 1;// new XDate(0, 0, 0, 6, 0, 0);
            graph3.MyPane.XAxis.Scale.MinorUnit = ZedGraph.DateUnit.Day;

            graph1.MyPane.AxisChange();
            graph2.MyPane.AxisChange();
            graph3.MyPane.AxisChange();

            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("o_GasEmissionBindingSource", o_GasEmission.Load()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Title", "Bilan des rejets hebdomadaires de la tranche "+unit.Name));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Graph1", Helper.ImageToBase64(graph1.GetImage(1200, 800, 96, false, false), ImageFormat.Png)));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Graph2", Helper.ImageToBase64(graph2.GetImage(1200, 800, 96, false, false), ImageFormat.Png)));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Graph3", Helper.ImageToBase64(graph3.GetImage(1200, 800, 96, false, false), ImageFormat.Png)));
            this.reportViewer1.RefreshReport();
        }

        private void cb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UnitID = (Int64)cb_Unit.SelectedValue;
        }
    }
}
