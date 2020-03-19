using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
namespace SynapseReport.UserControls
{
    public partial class reportPeriod : UserControl
    {
        public reportPeriod()
        {
            InitializeComponent();

            InitializeControl();
        }

        private void InitializeControl()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COMPARE");
            DataSet _dsYearFrom = new DataSet();
            DataSet _dsYearTo = new DataSet();
            DataTable _tblYear = new DataTable("YEAR");
            DataSet _dsMonthFrom = new DataSet();
            DataSet _dsMonthTo = new DataSet();
            DataTable _tblMonth = new DataTable("MONTH");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            _tblYear.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tblYear.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tblYear);

            _tblMonth.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tblMonth.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tblMonth);

            DataRow _row = _data.Tables["COMPARE"].NewRow();
            DataRow _rowYear = _data.Tables["YEAR"].NewRow();
            DataRow _rowMonth = _data.Tables["MONTH"].NewRow();

            _row["VALUE"] = "";
            _row["DISPLAY"] = "*";
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "=";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.Equal");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "<";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.Before");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = ">";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.After");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "<=";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.BeforeOrEqual");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = ">=";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.AfterOrEqual");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "BETWEEN";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.Between");
            _data.Tables["COMPARE"].Rows.Add(_row);

            ComboBox.DataSource = _data.Tables["COMPARE"];
            ComboBox.ValueMember = "VALUE";
            ComboBox.DisplayMember = "DISPLAY";

            for (int x = 0; x > -11; x--)
            {
                string year = DateTime.Now.AddYears(x).Year.ToString();
                _rowYear = _data.Tables["YEAR"].NewRow();
                _rowYear["VALUE"] = year;
                _rowYear["DISPLAY"] = year;
                _data.Tables["YEAR"].Rows.Add(_rowYear);
            }

            yearFrom.DataSource = _data.Tables["YEAR"];
            yearFrom.ValueMember = "VALUE";
            yearFrom.DisplayMember = "DISPLAY";

            //_dsYearTo = _dsYearFrom.Copy();
            yearTo.DataSource = _data.Tables["YEAR"].Copy();
            yearTo.ValueMember = "VALUE";
            yearTo.DisplayMember = "DISPLAY";

            for (int x = 1; x < 13; x++)
            {
                string month = x.ToString().PadLeft(2, '0');
                _rowMonth = _data.Tables["MONTH"].NewRow();
                _rowMonth["VALUE"] = month;
                _rowMonth["DISPLAY"] = month;
                _data.Tables["MONTH"].Rows.Add(_rowMonth);
            }

            monthFrom.DataSource = _data.Tables["MONTH"];
            monthFrom.ValueMember = "VALUE";
            monthFrom.DisplayMember = "DISPLAY";

            //_dsMonthTo = _dsMonthFrom.Copy();
            monthTo.DataSource = _data.Tables["MONTH"].Copy();
            monthTo.ValueMember = "VALUE";
            monthTo.DisplayMember = "DISPLAY";

            lbl2.Text = SynapseForm.GetLabel("FilterDate.And");
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedValue.ToString())
            {
                case "":
                    yearFrom.Visible = false;
                    monthFrom.Visible = false;
                    lbl2.Visible = false;
                    yearTo.Visible = false;
                    monthTo.Visible = false;
                    break;
                case "<":
                case "<=":
                    yearFrom.Visible = true;
                    monthFrom.Visible = true;
                    lbl2.Visible = false;
                    yearTo.Visible = false;
                    monthTo.Visible = false;
                    break;
                case "BETWEEN":
                    yearFrom.Visible = true;
                    monthFrom.Visible = true;
                    lbl2.Visible = true;
                    yearTo.Visible = true;
                    monthTo.Visible = true;
                    break;
                default:
                    yearFrom.Visible = true;
                    monthFrom.Visible = true;
                    lbl2.Visible = false;
                    yearTo.Visible = false;
                    monthTo.Visible = false;
                    break;
            }
        }
    }
}
