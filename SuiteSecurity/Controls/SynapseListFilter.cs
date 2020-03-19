using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using SynapseAdvancedControls;
using System.Text.RegularExpressions;
namespace SynapseCore.Controls
{
    public partial class SynapseListFilter : ToolStrip
    {
        public SynapseListFilter()
        {
            InitializeComponent();
        }

        private ObjectListView _List;
        private ObjectListView _FooterList;

        ToolStripTextBox txt_filter = new ToolStripTextBox();
        ToolStripDropDownButton filter = new ToolStripDropDownButton();

        public ObjectListView ListView
        {
            get { return _List; }
            set { _List = value; }
        }
        public ObjectListView FooterListView
        {
            get { return _FooterList; }
            set { _FooterList = value; }
        }

        private string _ListID;
        public string ListID
        {
            get
            {
                if (_ListID != null && _ListID != string.Empty && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                    return _ListID;
                else
                    if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && _List != null)
                    {
                        return _List.FindForm().Name + "#" + _List.Name;
                    }

                return "Unable to find rertun listID on form";
            }
            set { _ListID = value; }
        }

        private string _FooterListID;
        public string FooterListID
        {
            get
            {
                if (_FooterListID != null && _FooterListID != string.Empty && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                    return _FooterListID;
                else
                    if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && _FooterList != null)
                    {
                        return _FooterList.FindForm().Name + "#" + _FooterList.Name;
                    }

                return "Unable to find _FooterListID on form";
            }
            set { _FooterListID = value; }
        }

        private int _TitleFontSize = 22;

        public int TitleFontSize
        {
            get { return _TitleFontSize; }
            set { _TitleFontSize = value; }
        }

        private bool _UseBackgroundColor = false;

        public bool UseBackgroundColor
        {
            get { return _UseBackgroundColor; }
            set { _UseBackgroundColor = value; }
        }

        private bool _FilterOnTheFly = true;

        public bool FilterOnTheFly
        {
            get { return _FilterOnTheFly; }
            set { _FilterOnTheFly = value; }
        }

        private bool _HideFilter = false;

        public bool HideFilter
        {
            get { return _HideFilter; }
            set { _HideFilter = value; }
        }
        private bool _HideSearch = false;

        public bool HideSearch
        {
            get { return _HideSearch; }
            set { _HideSearch = value; }
        }
        private bool _HideExport = false;

        public bool HideExport
        {
            get { return _HideExport; }
            set { _HideExport = value; }
        }
        private bool _HidePrint = false;

        public bool HidePrint
        {
            get { return _HidePrint; }
            set { _HidePrint = value; }
        }

        private bool _HideSaveConfig = true;

        public bool HideSaveConfig
        {
            get { return _HideSaveConfig; }
            set { _HideSaveConfig = value; }
        }
        private bool printFinished = false;

        public void RedrawControls()
        {
            this.Items.Clear();
            if (!_HideFilter)
            {
                filter.Image = Properties.Resources.FilterAdd;
                this.Items.Add(filter);

                ToolStripButton clearfilter = new ToolStripButton();
                clearfilter.Click += new EventHandler(clearfilter_Click);
                clearfilter.Image = Properties.Resources.FilterDelete;
                clearfilter.Text = SynapseForm.GetLabel("SynapseListFilter.Clear");
                clearfilter.DisplayStyle = ToolStripItemDisplayStyle.Image;
                this.Items.Add(clearfilter);

                ToolStripSeparator sb1 = new ToolStripSeparator();
                sb1.Margin = new Padding(5, 0, 5, 0);
                this.Items.Add(sb1);


            }

            if (!_HideSearch)
            {
                ToolStripLabel icon = new ToolStripLabel();
                icon.Image = Properties.Resources.search2;
                icon.Margin = new System.Windows.Forms.Padding(0, 1, 0, 2);
                icon.ToolTipText = SynapseForm.GetLabel("SynapseListFilter.Search");

                txt_filter.TextChanged += new EventHandler(txt_filter_TextChanged);
                txt_filter.KeyUp += new KeyEventHandler(txt_filter_KeyUp);
                txt_filter.BorderStyle = BorderStyle.FixedSingle;
                this.Items.Add(icon);
                this.Items.Add(txt_filter);
                if (!FilterOnTheFly)
                {
                    ToolStripButton btn_OK = new ToolStripButton();
                    btn_OK.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    btn_OK.Text = SynapseForm.GetLabel("SynapseListFilter.Filter");
                    btn_OK.Click += new EventHandler(btn_OK_Click);
                    this.Items.Add(btn_OK);
                }
            }
            if (!_HideExport)
            {
                ToolStripSeparator sb2 = new ToolStripSeparator();
                sb2.Margin = new Padding(5, 0, 5, 0);
                this.Items.Add(sb2);

                ToolStripButton Excel = new ToolStripButton();
                Excel.Click += new EventHandler(Excel_Click);
                Excel.Image = Properties.Resources.excel;
                Excel.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Excel.Text = SynapseForm.GetLabel("SynapseListFilter.Excel");
                this.Items.Add(Excel);
            }
            if (!_HidePrint)
            {
                ToolStripSeparator sb3 = new ToolStripSeparator();
                sb3.Margin = new Padding(5, 0, 5, 0);
                this.Items.Add(sb3);

                ToolStripButton Preview = new ToolStripButton();
                Preview.Image = Properties.Resources.preview;
                Preview.Click += new EventHandler(Preview_Click);
                Preview.Text = SynapseForm.GetLabel("SynapseListFilter.Preview");
                Preview.DisplayStyle = ToolStripItemDisplayStyle.Image;
                this.Items.Add(Preview);

                ToolStripButton Print = new ToolStripButton();
                Print.Image = Properties.Resources.Print_Grid_32;
                Print.Click += new EventHandler(Print_Click);
                Print.Text = SynapseForm.GetLabel("SynapseListFilter.Print");
                Print.DisplayStyle = ToolStripItemDisplayStyle.Image;
                this.Items.Add(Print);
            }
            if (!_HideSaveConfig)
            {
                ToolStripSeparator sb4 = new ToolStripSeparator();
                sb4.Margin = new Padding(5, 0, 5, 0);
                this.Items.Add(sb4);

                ToolStripButton tsb_saveconfig = new ToolStripButton();
                tsb_saveconfig.Image = Properties.Resources.ViewSave;
                tsb_saveconfig.Click += new EventHandler(tsb_saveconfig_Click);
                tsb_saveconfig.Text = SynapseForm.GetLabel("SynapseListFilter.SaveConfig");
                tsb_saveconfig.DisplayStyle = ToolStripItemDisplayStyle.Image;
                this.Items.Add(tsb_saveconfig);

                ToolStripButton tsb_restoreconfig = new ToolStripButton();
                tsb_restoreconfig.Image = Properties.Resources.ViewRestore;
                tsb_restoreconfig.Click += new EventHandler(tsb_restoreconfig_Click);
                tsb_restoreconfig.Text = SynapseForm.GetLabel("SynapseListFilter.RestoreConfig");
                tsb_restoreconfig.DisplayStyle = ToolStripItemDisplayStyle.Image;
                this.Items.Add(tsb_restoreconfig);
            }
            if (!HideFilter)
            {
                ToolStripSeparator sb5 = new ToolStripSeparator();
                sb5.Margin = new Padding(5, 0, 5, 0);
                this.Items.Add(sb5);
                if (_List != null)
                {
                    FormatFilterMenu(_List, filter);
                    _List.AfterSorting += new EventHandler<AfterSortingEventArgs>(_List_AfterSorting);
                    foreach (OLVColumn col in _List.AllColumns)
                    {
                        CheckBox chk = new CheckBox();
                        chk.Text = col.Text;
                        chk.BackColor = Color.Transparent;
                        chk.Checked = col.Searchable;
                        chk.Tag = col;
                        chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
                        if (col.Searchable)
                        {
                            ToolStripControlHost host = new ToolStripControlHost(chk);
                            this.Items.Add(host);
                        }
                    }
                }
            }
        }

        protected override void OnCreateControl()
        {
            this.ImageScalingSize = new Size(24, 24);
            base.OnCreateControl();
            RedrawControls();
        }

        void tsb_restoreconfig_Click(object sender, EventArgs e)
        {
            _List.LoadConfigFromDB(this.ListID);
            if (_FooterList != null)
                _FooterList.LoadConfigFromDB(this.FooterListID);
        }

        void tsb_saveconfig_Click(object sender, EventArgs e)
        {
            _List.SaveConfigToDB(this.ListID);

            if (_FooterList != null)
                _FooterList.SaveConfigToDB(this.FooterListID);
        }

        void btn_OK_Click(object sender, EventArgs e)
        {
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt_filter.Text))
                filter = TextMatchFilter.Contains(_List, txt_filter.Text);

            _List.AdditionalFilter = filter;
        }

        void txt_filter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | FilterOnTheFly)
            {
                TextMatchFilter filter = null;
                if (!string.IsNullOrEmpty(txt_filter.Text))
                    filter = TextMatchFilter.Contains(_List, txt_filter.Text);

                _List.AdditionalFilter = filter;
            }
        }

        void Preview_Click(object sender, EventArgs e)
        {
            PrintList(true);
        }

        void Print_Click(object sender, EventArgs e)
        {
            PrintList(false);
        }

        void PrintList(bool WithPreview)
        {
            //Add footer list to the current list to print both on same report
            if (_FooterList != null)
                foreach (System.Data.DataRow obj in _FooterList.Objects)
                    _List.AddObject(obj);
                    

            ListViewPrinter lvp = new ListViewPrinter();
            lvp.ListView = _List;
            lvp.Header = _List.AccessibleName;
            lvp.HeaderFormat.BackgroundBrush = Brushes.Navy;
            lvp.HeaderFormat.TextColor = Color.White;
            lvp.HeaderFormat.Font = new Font(lvp.HeaderFormat.Font.FontFamily.Name, 12);
            lvp.HeaderFormat.CanWrap=true;
            if (_List.AccessibleName != null)
                lvp.HeaderFormat.MinimumTextHeight = 25 + (25 * Regex.Matches(_List.AccessibleName, "\\n").Count);

            lvp.Footer = "By Synapse a generation suite                   Page {0}                  {1}";
            lvp.IsShrinkToFit = true;

            if (WithPreview)
            {
                lvp.PageSetup();
                lvp.PrintPreview();
            }
            else
                lvp.PrintWithDialog();

            //Remove footer list from the current list after print
            if (_FooterList != null)
                foreach (System.Data.DataRow obj in _FooterList.Objects)
                    _List.RemoveObject(obj);

        }

        void Excel_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = _List.AccessibleName.Replace("\n", " - ");

            saveFileDialog1.Filter = "Fichiers Excel (*.xlsx)|*.xlsx|Fichiers Csv (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog1.FileName;
                if (saveFileDialog1.FileName.Contains(".csv"))
                    ExportToCsv(saveFileDialog1.FileName, _List);
                else
                    ExportToExcel(_List.AccessibleName, "Report", saveFileDialog1.FileName, _List, _FooterList, _TitleFontSize, _UseBackgroundColor);
            }
            else
            {
                MessageBox.Show("No valid file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void _List_AfterSorting(object sender, AfterSortingEventArgs e)
        {
            FormatFilterMenu(_List, filter);
        }

        void clearfilter_Click(object sender, EventArgs e)
        {
            _List.ResetColumnFiltering();
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            OLVColumn col = (OLVColumn)((CheckBox)sender).Tag;
            col.Searchable = ((CheckBox)sender).Checked;
        }

        void txt_filter_TextChanged(object sender, EventArgs e)
        {
            // Empty
        }

        public static void FormatFilterMenu(ObjectListView olv, ToolStripDropDownButton btn)
        {
            btn.DropDownItems.Clear();
            foreach (OLVColumn CH in olv.AllColumns)
            {
                if (CH.IsVisible)
                {
                    ToolStripMenuItem tsddb = new ToolStripMenuItem();
                    tsddb.Text = CH.Text;
                    ToolStripMenuItem tsddb_Command = new ToolStripMenuItem();
                    tsddb_Command.Text = "Commandes";

                    ToolStripDropDown tsdd_filter = new ToolStripDropDown();
                    olv.MakeFilteringMenu(tsdd_filter, CH.Index);

                    ToolStripDropDown tsdd_command = new ToolStripDropDown();
                    olv.MakeColumnCommandMenu(tsdd_command, CH.Index);

                    if (tsdd_filter.Items.Count >= 1)
                        tsdd_filter.Items[0].Text = "Filtres";

                    tsddb.DropDown = tsdd_command;

                    tsddb.DropDownItems.AddRange(tsdd_filter.Items);

                    btn.DropDownItems.Add(tsddb);
                }
            }
        }

        public static void ExportToExcel(string ReportName, string feuille, string output, ObjectListView List, ObjectListView FooterList=null, double fontSize=22, bool UseBackColor=false)
        {
            ListView.ColumnHeaderCollection properties = null;
            int CurrentRow = 1;
            int CurrentCol = 1;
            if (List != null && List.Items.Count >= 1)
                properties = (List.Columns);
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(feuille);

            using (workbook)
            {
                // Set Style for Report Title
                using (var titleRange = worksheet.Range(CurrentRow, 1, CurrentRow, properties.Count))
                {
                    titleRange.Merge();
                    var rangeStyle = titleRange.Style;
                    rangeStyle.Font.FontName = "Britannic Bold";
                    rangeStyle.Font.FontSize = fontSize;
                    rangeStyle.Font.Italic = true;
                    rangeStyle.Font.FontColor = XLColor.White;
                    rangeStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.CenterContinuous;
                    rangeStyle.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rangeStyle.Alignment.WrapText = true;
                    rangeStyle.Fill.PatternType = XLFillPatternValues.Solid;
                    rangeStyle.Fill.BackgroundColor = XLColor.FromArgb(23, 55, 93);
                }

                // Set Report Title                
                worksheet.Cell(CurrentRow, 1).Value = ReportName;
                worksheet.Rows(CurrentRow, 1).Height = 75;

                // Fill next row = Header
                CurrentRow++;

                // Set Style for Report Header row
                using (var headerRange = worksheet.Range(CurrentRow, 1, CurrentRow, properties.Count))
                {
                    var rangeStyle = headerRange.Style;
                    rangeStyle.Font.Bold = true;
                    rangeStyle.Font.FontColor = XLColor.White;
                    rangeStyle.Fill.PatternType = XLFillPatternValues.Solid;
                    rangeStyle.Fill.BackgroundColor = XLColor.DarkBlue;
                }

                // Set Column titles
                foreach (OLVColumn p in properties)
                {
                    worksheet.Cell(CurrentRow, CurrentCol).Value = p.Text;
                    CurrentCol++;
                }

                // Fill data rows
                CurrentRow++;
                foreach (ListViewItem o in List.Items)
                {
                    CurrentCol = 1;
                    foreach (OLVColumn p in properties)
                    {
                        worksheet.Cell(CurrentRow, CurrentCol).Value = o.SubItems[CurrentCol - 1].Text;

                        if (UseBackColor)
                            worksheet.Cell(CurrentRow, CurrentCol).AsRange().Style.Fill.BackgroundColor = XLColor.FromColor(o.SubItems[CurrentCol - 1].BackColor);

                        CurrentCol++;
                    }
                    CurrentRow++;
                }

                if (FooterList != null)
                {
                    // Fill footer data rows
                    CurrentRow++;
                    foreach (ListViewItem o in FooterList.Items)
                    {
                        CurrentCol = 1;
                        foreach (OLVColumn p in properties)
                        {
                            worksheet.Cell(CurrentRow, CurrentCol).Value = o.SubItems[CurrentCol - 1].Text;
                            CurrentCol++;
                        }
                        CurrentRow++;
                    }
                }

                // Resize columns to fit contents
                worksheet.Columns(1, properties.Count).AdjustToContents(2);

                // Save Workbook
                workbook.SaveAs(output);
            }
        }

        public static void ExportToCsv(string output, ObjectListView List)
        {
            ListView.ColumnHeaderCollection properties = null;

            if (List != null && List.Items.Count >= 1)
                properties = (List.Columns);

            using (CsvFileWriter writer = new CsvFileWriter(output))
            {
                // Set Column titles
                CsvRow title = new CsvRow();
                foreach (OLVColumn p in properties)
                {
                    title.Add(p.Text);
                }
                writer.WriteRow(title);

                // Fill data rows
                foreach (ListViewItem o in List.Items)
                {
                    CsvRow row = new CsvRow();
                    foreach (OLVColumn p in properties)
                    {
                        row.Add(o.SubItems[properties.IndexOf(p)].Text);
                    }
                    writer.WriteRow(row);
                }

                writer.Close();
            }
        }

        // Next method works with OpenXML
        public static void OLD_ExportToExcel(string ReportName, string feuille, string output, ObjectListView List)
        {
            FileInfo newFile = new FileInfo(output);
            ListView.ColumnHeaderCollection properties = null;
            int CurrentRow = 1;
            int CurrentCol = 1;
            if (List != null && List.Items.Count >= 1)
                properties = (List.Columns);

            using (XLWorkbook excelToExport = new XLWorkbook(newFile.FullName))
            {
                // Delete the worksheet we are going to create
                excelToExport.Worksheets.Delete(feuille);

                // Create worksheet
                IXLWorksheet worksheet = excelToExport.Worksheets.Add(feuille);

                // Set Style for Report Title
                using (var titleRange = worksheet.Range(CurrentRow, 1, CurrentRow, properties.Count))
                {
                    titleRange.Merge();
                    var rangeStyle = titleRange.Style;
                    rangeStyle.Font.FontName = "Britannic Bold";
                    rangeStyle.Font.FontSize = 22;
                    rangeStyle.Font.Italic = true;
                    rangeStyle.Font.FontColor = XLColor.White;
                    rangeStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.CenterContinuous;
                    rangeStyle.Fill.PatternType = XLFillPatternValues.Solid;
                    rangeStyle.Fill.BackgroundColor = XLColor.FromArgb(23, 55, 93);
                }

                // Set Report Title                
                worksheet.Cell(CurrentRow, 1).Value = ReportName;

                // Fill next row = Header
                CurrentRow++;

                // Set Style for Report Header row
                using (var headerRange = worksheet.Range(CurrentRow, 1, CurrentRow, properties.Count))
                {
                    var rangeStyle = headerRange.Style;
                    rangeStyle.Font.Bold = true;
                    rangeStyle.Font.FontColor = XLColor.White;
                    rangeStyle.Fill.PatternType = XLFillPatternValues.Solid;
                    rangeStyle.Fill.BackgroundColor = XLColor.DarkBlue;
                }

                // Set Column titles
                foreach (OLVColumn p in properties)
                {
                    worksheet.Cell(CurrentRow, CurrentCol).Value = p.Text;
                    CurrentCol++;
                }

                // Fill data rows
                CurrentRow++;
                foreach (ListViewItem o in List.Items)
                {
                    CurrentCol = 1;
                    foreach (OLVColumn p in properties)
                    {
                        worksheet.Cell(CurrentRow, CurrentCol).Value = o.SubItems[CurrentCol - 1].Text;
                        CurrentCol++;
                    }
                    CurrentRow++;
                }

                // Resize columns to fit contents
                worksheet.Columns(1, properties.Count).AdjustToContents(2);

                // Save Workbook
                excelToExport.Save();
            }
        }
    }
}
