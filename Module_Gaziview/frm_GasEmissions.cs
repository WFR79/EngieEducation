using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Module_Gaziview.Entities;
using SynapseCore.Controls;
using SynapseCore.Graph;
using System.Globalization;

namespace Module_Gaziview
{
    public partial class frm_GasEmissions : SynapseForm
    {
        DateTime lastdata;
        IList<o_GasEmission> WeekEmissions;
        int currentweeknr = 0;
        public frm_GasEmissions()
        {
            InitializeComponent();
            col_Day.AspectGetter = delegate(object x)
            {
                return (SynapseForm.GetLabel("labels."+((o_GasEmission)x).Date.DayOfWeek.ToString()) + " " + ((o_GasEmission)x).Date.ToString("dd/MM/yyyy"));
            };
            col_Date.AspectGetter= delegate(object x)
            {
                return  ((o_GasEmission)x).Date.AddDays(1).ToString("dd/MM/yyyy");
            };
            col_Dirty.AspectGetter = delegate(object x)
            {
                return "";// (((o_GasEmission)x).GasVolume != 0 || ((o_GasEmission)x).GasEmission != 0) ? ((o_GasEmission)x).IsDirty : false;
            };
            col_Dirty.ImageGetter = delegate(object x)
            {
                o_GasEmission item = (o_GasEmission)x;
                string state = "st_empty";
                if (item.GasEmission != 0 || item.GasEmission != 0)
                {
                    state = "st_data";

                    if (item.Valid)
                        state = "st_valid";
                    if (item.IsDirty)
                        state = "st_edit";
                }
                return state;
                
            };
            col_GazDischarge.AspectGetter = delegate(object x)
            {
                return ((o_GasEmission)x).GasEmission.ToString("0.000E+00");
            };
            col_GazDischarge.AspectPutter = delegate(object x, object newval)
            {
                double t;
                if (double.TryParse(newval.ToString(), out t))
                    ((o_GasEmission)x).GasEmission = t;
            };
            col_GazVolume.AspectGetter = delegate(object x)
            {
                return ((o_GasEmission)x).GasVolume.ToString("0.000E+00");
            };
            col_GazVolume.AspectPutter = delegate(object x, object newval)
            {
                double t;
                if (double.TryParse(newval.ToString(), out t))
                    ((o_GasEmission)x).GasVolume = t;
            };
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            //olv_Data.CellEditActivation = SynapseAdvancedControls.ObjectListView.CellEditActivateMode.None;

            //monthCalendar1.FirstDayOfWeek= (Day)(Helper.WeekStartDay-1);
            
            col_BackgroundNoise.IsEditable = false;
            col_BackNoiseDischarge.IsEditable = false;
            col_Date.IsEditable = false;
            col_Day.IsEditable = false;
            col_Decision.IsEditable = false;
            col_Dirty.IsEditable = false;
            col_DischargeDecl.IsEditable = false;
            col_MinDecl.IsEditable = false;
            col_MinDischargeDecl.IsEditable = false;
            col_NetDischarge.IsEditable = false;
 
        }

        private void frm_GazDischarge_Load(object sender, EventArgs e)
        {
            monthCalendar1.DateChanged -= monthCalendar1_newDateChanged;
            //monthCalendar1.DateChanged -= monthCalendar1_DateChanged;

            int weeknr = Helper.GetWeekNr(DateTime.Now);
            DateTime firstdate = Helper.FirstDateOfWeek(DateTime.Now.Year, weeknr);
            monthCalendar1.ViewStart = monthCalendar1.SelectionStart;
            monthCalendar1.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));
            //monthCalendar1.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));
            
            monthCalendar1.DateChanged += monthCalendar1_newDateChanged;
            //monthCalendar1.DateChanged += monthCalendar1_DateChanged;


            cb_Unit.DisplayMember = "Name";
            cb_Unit.ValueMember = "ID";
            cb_Unit.DataSource = o_Unit.Load();
        
        }

        void LoadData()
        {
            //MessageBox.Show("Event:Load data");
            currentweeknr = Helper.GetWeekNr(monthCalendar1.SelectionStart);
            zg_Graph.MasterPane.PaneList.Clear();

            if (IsCollectionModified() && MessageBox.Show(SynapseForm.GetLabel("messages.savebefore"), SynapseForm.GetLabel("messages.savebeforetitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveWeek();
            }

            gb_Data.Text = string.Format(SynapseForm.GetLabel("frm_GasEmissions.gbweekformat"), Helper.GetWeekNr(monthCalendar1.SelectionStart), monthCalendar1.SelectionStart.Year);
       
            int Year = monthCalendar1.SelectionStart.Year;
            int WeekNr = Helper.GetWeekNr(monthCalendar1.SelectionStart);
            DateTime firstdate = Helper.FirstDateOfWeek(Year, WeekNr);

            WeekEmissions = o_GasEmission.Load("where ChainID="+cb_Chain.SelectedValue+" AND Date BETWEEN '"+firstdate.ToString("yyyy/MM/dd")+"' AND '"+firstdate.AddDays(6).ToString("yyyy/MM/dd")+"'");
            lastdata = Helper.GetLastDate((Int64)cb_Chain.SelectedValue);
            
            for (int shift = 0; shift <= 6; shift++)
            {
                if (WeekEmissions.Where(We => We.Date == firstdate.AddDays(shift)).Count() == 0)
                {
                    WeekEmissions.Add(new o_GasEmission() { Date = firstdate.AddDays(shift), ChainID = (Int64)cb_Chain.SelectedValue });
                }
            }
            
            SynapseGraph SG = new SynapseGraph();
            SG.AddTace("", (from w in WeekEmissions select new SynapseGraphPoint() { label = SynapseForm.GetLabel("labels."+w.Date.DayOfWeek.ToString()), y = (float)w.EmissionDecl }).ToList(), TraceType.Curve, Color.Blue);
            SG.XAxisType = XAxisType.Labels;
            SG.Title = gb_Data.Text;
            
            SG.DrawGraph(ref zg_Graph);
            zg_Graph.MasterPane.PaneList.ForEach(p => p.XAxis.Scale.FontSpec.Size = 20);
            zg_Graph.MasterPane.PaneList.ForEach(p => p.Title.FontSpec.Size = 20);
            zg_Graph.MasterPane.PaneList.ForEach(p => p.YAxis.Scale.FontSpec.Size = 20);
            zg_Graph.MasterPane.PaneList.ForEach(p => p.YAxis.Title.FontSpec.Size = 20);

            zg_Graph.MasterPane.PaneList.ForEach(p => p.YAxis.Title.Text = "Bq");
            zg_Graph.AxisChange();
            zg_Graph.Refresh();
            olv_Data.SetObjects(WeekEmissions.OrderBy(W => W.Date));
            ComputeSums();
        }

        void ComputeSums()
        {
            progressBar1.SetState(1);
            txt_SumVolume.Text = WeekEmissions.Sum(w => w.GasVolume).ToString("0.000E+00");
            if ((WeekEmissions.Sum(w => w.EmissionDecl) / 1000000000)>0.01)
            txt_EmissionDecl.Text = (WeekEmissions.Sum(w => w.EmissionDecl)/1000000000).ToString("F1");
            else
                txt_EmissionDecl.Text = (WeekEmissions.Sum(w => w.EmissionDecl) / 1000000000).ToString("0.0E+00");
            
            progressBar1.Value = WeekEmissions.Where(w => w.GasVolume > 0).Count() * 10;
            if (progressBar1.Value == 70)
                progressBar1.SetState(1);
            else
                if (progressBar1.Value == 0)
                    progressBar1.SetState(2);
                else
                    progressBar1.SetState(3);



        }

        bool IsCollectionModified()
        {
            if (WeekEmissions != null)
            {
                bool result = false;
                foreach (o_GasEmission e in WeekEmissions)
                {
                    result = result | ((e.GasVolume != 0 || e.GasEmission != 0) ? e.IsDirty : false);
                }
                return result;
            }
            else
                return false;
        }

        void SaveWeek()
        {
            //MessageBox.Show("Event:Save changed");
            try
            {
                WeekEmissions.Where(e => ((e.GasVolume != 0 || e.GasEmission != 0) && e.IsDirty)).ToList().ForEach(e => e.save());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, SynapseForm.GetLabel("messages.errorsave"));
            }

            LoadData();
        }

        private void oldmonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show("Event:Date changed");
            monthCalendar1.DateChanged -= oldmonthCalendar1_DateChanged;
            int weeknr = Helper.GetWeekNr(monthCalendar1.SelectionStart);
            DateTime firstdate = Helper.FirstDateOfWeek(monthCalendar1.SelectionStart.Year, weeknr);
            monthCalendar1.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));
            if (weeknr!=currentweeknr)
                LoadData();
            monthCalendar1.DateChanged += oldmonthCalendar1_DateChanged;
        }

        private void olv_Data_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void olv_Data_FormatCell(object sender, SynapseAdvancedControls.FormatCellEventArgs e)
        {
            if (!e.Column.IsEditable)
            {
                if (((o_GasEmission)e.Model).Date > lastdata)
                    e.SubItem.BackColor = Color.LightPink;
                //else
                  //  e.SubItem.BackColor = Color.LightGray;
            }
        }

        private void olv_Data_CellEditStarting(object sender, SynapseAdvancedControls.CellEditEventArgs e)
        {
            if (((o_GasEmission)e.RowObject).Valid == true)
            {
                e.Cancel = true;
            }
            if (((o_GasEmission)e.RowObject).Date > lastdata.AddDays(1))
            {
                MessageBox.Show(SynapseForm.GetLabel("messages.errorcannotedit"));
                e.Cancel = true;
            }
            if (e.Value!=null && e.Value.ToString() == (0).ToString("0.000E+00"))
            {
                e.Control.Text = "";
            }
            if (((e.Column == col_GazVolume) ||
                (e.Column == col_GazDischarge) ||
                (e.Column == col_Remarque)) && ((o_GasEmission)e.RowObject).HS == true)
            {
                if (MessageBox.Show(SynapseForm.GetLabel("messages.errorcannotediths"), SynapseForm.GetLabel("messages.errorcannotedithstitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void olv_Data_FormatRow(object sender, SynapseAdvancedControls.FormatRowEventArgs e)
        {
            if (((o_GasEmission)e.Model).GasVolume > 0 || ((o_GasEmission)e.Model).Date < lastdata.AddDays(1))
            {
                if (((o_GasEmission)e.Model).Date.DayOfYear % 2 == 0)
                    if (((o_GasEmission)e.Model).Valid)
                        e.Item.BackColor = Color.FromArgb(150, 240, 150);
                    else
                        e.Item.BackColor = Color.FromArgb(255, 201, 41);
                else
                {
                    if (((o_GasEmission)e.Model).Valid)
                        e.Item.BackColor = Color.FromArgb(200, 240, 200);
                    else
                        e.Item.BackColor = Color.FromArgb(255, 224, 133);
                }
            }
            if (!((o_GasEmission)e.Model).LoadSuccessful)
                e.Item.BackColor = Color.Red;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void olv_Data_CellEditFinishing(object sender, SynapseAdvancedControls.CellEditEventArgs e)
        {
            try
            {
                if (e.Column == col_GazVolume && (double)e.NewValue.AsScientific() != 0)
                    if (((o_GasEmission)e.RowObject).Date>lastdata)
                        lastdata = ((o_GasEmission)e.RowObject).Date;
                if (e.Column == col_GazDischarge && (double)e.NewValue.AsScientific() != 0)
                    if (((o_GasEmission)e.RowObject).Date > lastdata)
                        lastdata = ((o_GasEmission)e.RowObject).Date;
////ici
//                if (((e.Column == col_GazVolume && e.Value.AsScientific() != e.NewValue.AsScientific()) ||
//    (e.Column == col_GazDischarge && e.Value.AsScientific() != e.NewValue.AsScientific()) ||
//    (e.Column == col_Remarque && e.Value != e.NewValue)) && ((o_GasEmission)e.RowObject).HS == true)
//                {
//                    if (MessageBox.Show(SynapseForm.GetLabel("messages.errorcannotediths"), SynapseForm.GetLabel("messages.errorcannotedithstitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.No)
//                        e.Cancel = true;
//                }
                if (e.Column == col_GazDischarge && e.Value.AsScientific()!=e.NewValue.AsScientific())
                {
                    double EmissionAvg = Helper.LastDaysEmissionAvg(((o_GasEmission)e.RowObject).Date, ((o_GasEmission)e.RowObject).ChainID);
                    double prc=(Math.Abs(e.NewValue.AsScientific()-EmissionAvg)/EmissionAvg);
                    if(prc>Helper.ToleranceWarning)
                        MessageBox.Show(SynapseForm.GetLabel("messages.farfromavg")+" "+(prc).ToString("0.00 %"));
                    UpdateEncoder(e.RowObject);
                }
                if (e.Column == col_GazVolume && e.Value.AsScientific() != e.NewValue.AsScientific())
                {
                    double VolumeAvg = Helper.LastDaysVolumeAvg(((o_GasEmission)e.RowObject).Date, ((o_GasEmission)e.RowObject).ChainID);
                    double prc = (Math.Abs(e.NewValue.AsScientific() - VolumeAvg) / VolumeAvg);
                    if (prc > Helper.ToleranceWarning)
                        MessageBox.Show(SynapseForm.GetLabel("messages.farfromavg")+" " + (prc).ToString("0.00 %"));
                    UpdateEncoder(e.RowObject);
                }
                if (e.Column == col_Remarque && e.Value != e.NewValue)
                {
                    UpdateEncoder(e.RowObject);
                }
                if (e.Column == col_OtherChainHS && e.Value != e.NewValue)
                {
                    UpdateEncoder(e.RowObject);
                }
                

            }
            catch (InvalidScienitficException)
            {
                MessageBox.Show(SynapseForm.GetLabel("messages.errorinvalidformat"));
                e.Cancel = true;
            }


            //MessageBox.Show("cell edit finishing");
            //e.ListViewItem
        }

        private void UpdateEncoder(object x)
        {
            ((o_GasEmission)x).EncodedBy = SynapseForm.FormUser.UserID;
            ((o_GasEmission)x).EncodedDate = DateTime.Now;
        }
        private void UpdateValidator(object x)
        {
            ((o_GasEmission)x).ValidationBy = SynapseForm.FormUser.UserID;
            ((o_GasEmission)x).ValidationDate = DateTime.Now;
        }

        private void btn_PreviousWeek_Click(object sender, EventArgs e)
        {
         
            //monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(-7));
            monthCalendar1.SelectionStart= monthCalendar1.SelectionStart.AddDays(-7);
            monthCalendar1.ViewStart = monthCalendar1.SelectionStart;
            monthCalendar1_newDateChanged(this, new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd));
          
        }

        private void btn_NextWeek_Click(object sender, EventArgs e)
        {

            //monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(7));
            monthCalendar1.SelectionStart = monthCalendar1.SelectionStart.AddDays(7);
            monthCalendar1.ViewStart = monthCalendar1.SelectionStart;
            monthCalendar1_newDateChanged(this, new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd));
        }

        private void btn_LastData_Click(object sender, EventArgs e)
        {
            //monthCalendar1.SetDate(lastdata);
            monthCalendar1.SelectionStart = lastdata;
            monthCalendar1.SelectionEnd = lastdata;
            monthCalendar1.ViewStart = lastdata;
            //monthCalendar1.ViewEnd = lastdata;
            monthCalendar1_newDateChanged(this, new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd));
        }

        private void olv_Data_CellEditValidating(object sender, SynapseAdvancedControls.CellEditEventArgs e)
        {
            //MessageBox.Show("edit validated");
            e.Control.Text = e.Control.Text.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            e.NewValue = e.Control.Text;
            
        }

        private void olv_Data_ItemsChanged(object sender, SynapseAdvancedControls.ItemsChangedEventArgs e)
        {
            //if (((o_GasEmission)e.).GasVolume > 0)
            //    lastdata = ((o_GasEmission)e.RowObject).Date;


            //ComputeSums();
            //MessageBox.Show("Edit finished");
        }

        private void olv_Data_SubItemChecking(object sender, SynapseAdvancedControls.SubItemCheckingEventArgs e)
        {
            if (((o_GasEmission)e.RowObject).Valid == true && e.Column != col_Approved)
            {
                e.Canceled = true;
                return;
            }
            //MessageBox.Show("subitem checking");
            if (((o_GasEmission)e.RowObject).Date > lastdata.AddDays(1))
            {
                MessageBox.Show(SynapseForm.GetLabel("messages.errorcannotedit"));
                e.Canceled = true;
            }
            if (e.Column == col_OtherChainHS && e.CurrentValue != e.NewValue)
            {
                UpdateEncoder(e.RowObject);
            }
            if (e.Column == col_OtherChainHS && e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                if (MessageBox.Show(SynapseForm.GetLabel("messages.errorcannotediths"), SynapseForm.GetLabel("messages.errorcannotedithstitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    ((o_GasEmission)e.RowObject).Remarque = "";
                    ((o_GasEmission)e.RowObject).HSChainID = 0;
                    ((o_GasEmission)e.RowObject).GasVolume = 0;
                    ((o_GasEmission)e.RowObject).GasEmission = 0;
                }
                else
                {
                    e.Canceled = true;
                }
            }
            if (e.Column == col_Approved && e.CurrentValue != e.NewValue)
            {
                if ((e.NewValue) == CheckState.Checked)
                    if (SynapseForm.FormUser.UserID.ToUpper() == ((o_GasEmission)e.RowObject).EncodedBy.ToUpper())
                    {
                        e.Canceled=true;
                        MessageBox.Show(SynapseForm.GetLabel("messages.errordoublevalidation"), SynapseForm.GetLabel("messages.errordoublevalidationtitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        UpdateValidator(e.RowObject);
                else
                {
                    if (((o_GasEmission)e.RowObject).ValidationBy.ToUpper() == SynapseForm.FormUser.UserID.ToUpper())
                    {
                        ((o_GasEmission)e.RowObject).ValidationBy = "";
                        ((o_GasEmission)e.RowObject).ValidationDate = DateTime.MaxValue;
                    }
                    else
                    {
                        e.Canceled = true;

                    }

                }

            }
            olv_Data.RefreshObject(e.RowObject);
            //olv_Data.Refresh();
        }

        private void cb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Chain.Text = "";
            cb_Chain.DisplayMember = "Name";
            cb_Chain.ValueMember = "ID";
            cb_Chain.DataSource = o_Chain.Load("where UnitID="+cb_Unit.SelectedValue);
            
        }

        private void cb_Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Event:chain changed");
            LoadData();
        }

        private void synapseGraphic1_Load(object sender, EventArgs e)
        {
     
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveWeek();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Graph_Click(object sender, EventArgs e)
        {
            frm_Graphics f_graph = new frm_Graphics(monthCalendar1.SelectionEnd);
            f_graph.MdiParent = this.MdiParent;
            f_graph.Show();
            f_graph.btn_Draw_Click(this, e);
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            frm_Reports f_reports = new frm_Reports();
            f_reports.SetDate(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            f_reports.SetUnitID((Int64)cb_Unit.SelectedValue);
            f_reports.MdiParent = this.MdiParent;
            f_reports.Show();
            f_reports.btn_Graph_Click(this, e);

        }

        private void voirLesDétailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (olv_Data.SelectedObject != null)
            {
                frm_GasEmissionDetails f_details = new frm_GasEmissionDetails((o_GasEmission)olv_Data.SelectedObject);
                f_details.ShowDialog();
            }
        }

        private void ctx_Grip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
         
        }

        private void monthCalendar1_ActiveDateChanged(object sender, CustomControls.ActiveDateChangedEventArgs e)
        {

        }

        private void monthCalendar1_newDateChanged(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show("Event:Date changed");
            monthCalendar1.DateChanged -= monthCalendar1_newDateChanged;
            int weeknr = Helper.GetWeekNr(monthCalendar1.SelectionStart);
            DateTime firstdate = Helper.FirstDateOfWeek(monthCalendar1.SelectionStart.Year, weeknr);
            monthCalendar1.SelectionRange = new SelectionRange(firstdate, firstdate.AddDays(6));
            if (weeknr != currentweeknr)
                LoadData();
            monthCalendar1.DateChanged += monthCalendar1_newDateChanged;
        }
    }
}
