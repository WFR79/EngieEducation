using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SynapseReport.UserControls
{
    public partial class reportNumeric : UserControl
    {
        public reportNumeric()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COMPARE1");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = "";
            _row["DISPLAY"] = "*";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = "=";
            _row["DISPLAY"] = "=";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = ">";
            _row["DISPLAY"] = ">";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = "<";
            _row["DISPLAY"] = "<";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = ">=";
            _row["DISPLAY"] = ">=";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            _row = _data.Tables["COMPARE1"].NewRow();
            _row["VALUE"] = "<=";
            _row["DISPLAY"] = "<=";
            _data.Tables["COMPARE1"].Rows.Add(_row);

            ComboBox1.DataSource = _data;
            ComboBox1.ValueMember = "COMPARE1.VALUE";
            ComboBox1.DisplayMember = "COMPARE1.DISPLAY";

            _tbl = new DataTable("COMPARE2");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            _row = _data.Tables["COMPARE2"].NewRow();
            _row["VALUE"] = "";
            _row["DISPLAY"] = "*";
            _data.Tables["COMPARE2"].Rows.Add(_row);

            _row = _data.Tables["COMPARE2"].NewRow();
            _row["VALUE"] = "<";
            _row["DISPLAY"] = "<";
            _data.Tables["COMPARE2"].Rows.Add(_row);

            _row = _data.Tables["COMPARE2"].NewRow();
            _row["VALUE"] = "<=";
            _row["DISPLAY"] = "<=";
            _data.Tables["COMPARE2"].Rows.Add(_row);

            ComboBox2.DataSource = _data;
            ComboBox2.ValueMember = "COMPARE2.VALUE";
            ComboBox2.DisplayMember = "COMPARE2.DISPLAY";

            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;

            UpDown1.Value = 0;
            UpDown2.Value = 0;

            UpDown1.Visible = false;
            ComboBox2.Visible = false;
            UpDown2.Visible = false;
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBox1.SelectedValue.ToString())
            {
                case "":
                    UpDown1.Visible = false;
                    ComboBox2.SelectedIndex = 0;
                    ComboBox2.Visible = false;
                    UpDown2.Visible = false;
                    break;
                case "=":
                case "<":
                case "<=":
                    UpDown1.Visible = true;
                    ComboBox2.SelectedIndex = 0;
                    ComboBox2.Visible = false;
                    UpDown2.Visible = false;
                    break;
                default:
                    UpDown1.Visible = true;
                    ComboBox2.Visible = true;
                    UpDown2.Visible = false;
                    break;
            }
        }

        private void ComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ComboBox2.SelectedValue.ToString())
            {
                case "":
                    UpDown2.Visible = false;
                    break;
                default:
                    UpDown2.Visible = true;
                    break;
            }
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Apply_Filter(null, null);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Reset_Filter(null, null);
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                switch (sender.GetType().ToString())
                { 
                    case "System.Windows.Forms.ComboBox":
                        ((ComboBox)sender).SelectedIndex = 0;
                        break;
                    case "System.Windows.Forms.NumericUpDown":
                        ((NumericUpDown)sender).Value = 0;
                        break;
                }
                return;
            }
        }

        private void UpDown_Enter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
        }
    }
}
