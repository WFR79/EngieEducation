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
    public partial class reportDate : UserControl
    {
        public reportDate()
        {
            InitializeComponent();

            InitializeControl();
        }

        private void InitializeControl()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COMPARE");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "";
            _row["DISPLAY"] = "*";
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "=";
            _row["DISPLAY"] =  SynapseForm.GetLabel("FilterDate.Equal");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "<";
            _row["DISPLAY"] = SynapseForm.GetLabel("FilterDate.Before");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = ">";
            _row["DISPLAY"] =  SynapseForm.GetLabel("FilterDate.After");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "<=";
            _row["DISPLAY"] =  SynapseForm.GetLabel("FilterDate.BeforeOrEqual");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = ">=";
            _row["DISPLAY"] =  SynapseForm.GetLabel("FilterDate.AfterOrEqual");
            _data.Tables["COMPARE"].Rows.Add(_row);

            _row = _data.Tables["COMPARE"].NewRow();
            _row["VALUE"] = "BETWEEN";
            _row["DISPLAY"] =  SynapseForm.GetLabel("FilterDate.Between");
            _data.Tables["COMPARE"].Rows.Add(_row);

            ComboBox.DataSource = _data;
            ComboBox.ValueMember = "COMPARE.VALUE";
            ComboBox.DisplayMember = "COMPARE.DISPLAY";

            ComboBox.SelectedIndex = 0;

            lbl2.Text = SynapseForm.GetLabel("FilterDate.And");
            ckNull.Text = SynapseForm.GetLabel("FilterDate.Null");
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedValue.ToString())
            { 
                case "":
                    Date1.Visible = false;
                    lbl2.Visible = false;
                    Date2.Visible = false;
                    ckNull.Visible = false;
                    break;
                case "<":
                case "<=":
                    Date1.Visible = true;
                    lbl2.Visible = false;
                    Date2.Visible = false;
                    ckNull.Visible = true;
                    break;
                case "BETWEEN":
                    Date1.Visible = true;
                    lbl2.Visible = true;
                    Date2.Visible = true;
                    ckNull.Visible = false;
                    ckNull.Checked = false;
                    break;
                default:
                    Date1.Visible = true;
                    lbl2.Visible = false;
                    Date2.Visible = false;
                    ckNull.Visible = false;
                    ckNull.Checked = false;
                    break;
            }
        }

        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.ParentForm.AcceptButton.PerformClick();
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Apply_Filter(null, null);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Reset_Filter(null, null);
                //this.ParentForm.CancelButton.PerformClick();
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                ComboBox.SelectedIndex = 0;
                return;
            }
        }
    }
}
