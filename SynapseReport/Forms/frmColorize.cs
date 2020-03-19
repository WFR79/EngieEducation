using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
namespace SynapseReport.Forms
{
    public partial class frmColorize : SynapseForm
    {
        public string ColorWhat="NONE";
        public string ColorColor=null;
        public string ColorCondition = string.Empty;
        public string ColorConvertTo = string.Empty;
        public string ColorValue = string.Empty;

        public frmColorize()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            pnlDate.Top = pnlValue.Top;
            pnlValue.Visible = false;
            pnlDate.Visible = false;

            fillColorWhat();
            fillColorConvertTo();
            fillColorCondition();
            fillDateAdd();

            if (ColorWhat != null)
                cbColorWhat.SelectedValue = ColorWhat;
            if (ColorColor != null)
                btColorChoose.BackColor = Color.FromArgb(int.Parse(ColorColor));
            if (ColorConvertTo != null)
            {
                cbConvertTo.SelectedValue = ColorConvertTo;

                if (ColorConvertTo != "DATE")
                    txValue.Text = ColorValue;
                else
                {
                    cbDateAdd.SelectedValue = ColorValue.Split('#')[0];
                    txDateAddValue.Text = ColorValue.Split('#')[1];
                }
            }
            if (ColorCondition != null)
                cbCondition.SelectedValue = ColorCondition;
        }

        private void frmColorize_Load(object sender, EventArgs e)
        {
        }

        private void fillColorWhat()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COLORWHAT");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["COLORWHAT"].NewRow();
            _row["VALUE"] = "NONE";
            _row["DISPLAY"] = "None";
            _data.Tables["COLORWHAT"].Rows.Add(_row);

            _row = _data.Tables["COLORWHAT"].NewRow();
            _row["VALUE"] = "CELL";
            _row["DISPLAY"] = "The Cell";
            _data.Tables["COLORWHAT"].Rows.Add(_row);

            _row = _data.Tables["COLORWHAT"].NewRow();
            _row["VALUE"] = "ROW";
            _row["DISPLAY"] = "The Row";
            _data.Tables["COLORWHAT"].Rows.Add(_row);

            cbColorWhat.DataSource = _data;
            cbColorWhat.DisplayMember = "COLORWHAT.DISPLAY";
            cbColorWhat.ValueMember = "COLORWHAT.VALUE";
        }

        private void fillColorCondition(string Type="")
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COLORCONDITION");
            DataRow _row;

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            switch (Type)
            {
                case "BOOL":
                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "TRUE";
                    _row["DISPLAY"] = "Is True";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "FALSE";
                    _row["DISPLAY"] = "Is False";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);
                    break;
                case "DATE":
                case "NUM":
                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "<";
                    _row["DISPLAY"] = "<";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = ">";
                    _row["DISPLAY"] = ">";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "<>";
                    _row["DISPLAY"] = "<>";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "=";
                    _row["DISPLAY"] = "=";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);
                    break;
                case "STR":
                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "<>";
                    _row["DISPLAY"] = "<>";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "=";
                    _row["DISPLAY"] = "=";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);

                     _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "LIKE";
                    _row["DISPLAY"] = "Contains";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);
                    break;
                default:
                    _row = _data.Tables["COLORCONDITION"].NewRow();
                    _row["VALUE"] = "";
                    _row["DISPLAY"] = "";
                    _data.Tables["COLORCONDITION"].Rows.Add(_row);
                    break;
            }

            cbCondition.DataSource = _data;
            cbCondition.DisplayMember = "COLORCONDITION.DISPLAY";
            cbCondition.ValueMember = "COLORCONDITION.VALUE";

            cbCondition.SelectedIndex = -1;
        }

        private void fillColorConvertTo()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("COLORCONVERT");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["COLORCONVERT"].NewRow();
            _row["VALUE"] = "BOOL";
            _row["DISPLAY"] = "Boolean";
            _data.Tables["COLORCONVERT"].Rows.Add(_row);

            _row = _data.Tables["COLORCONVERT"].NewRow();
            _row["VALUE"] = "DATE";
            _row["DISPLAY"] = "Datetime";
            _data.Tables["COLORCONVERT"].Rows.Add(_row);

            _row = _data.Tables["COLORCONVERT"].NewRow();
            _row["VALUE"] = "NUM";
            _row["DISPLAY"] = "Number";
            _data.Tables["COLORCONVERT"].Rows.Add(_row);

            _row = _data.Tables["COLORCONVERT"].NewRow();
            _row["VALUE"] = "STR";
            _row["DISPLAY"] = "String";
            _data.Tables["COLORCONVERT"].Rows.Add(_row);

            cbConvertTo.DataSource = _data;
            cbConvertTo.DisplayMember = "COLORCONVERT.DISPLAY";
            cbConvertTo.ValueMember = "COLORCONVERT.VALUE";

            cbConvertTo.SelectedIndex = -1;
        }

        private void fillDateAdd()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("DATEADD");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["DATEADD"].NewRow();
            _row["VALUE"] = "DAY";
            _row["DISPLAY"] = "AddDays";
            _data.Tables["DATEADD"].Rows.Add(_row);

            _row = _data.Tables["DATEADD"].NewRow();
            _row["VALUE"] = "MONTH";
            _row["DISPLAY"] = "AddMonths";
            _data.Tables["DATEADD"].Rows.Add(_row);

            _row = _data.Tables["DATEADD"].NewRow();
            _row["VALUE"] = "YEAR";
            _row["DISPLAY"] = "AddYears";
            _data.Tables["DATEADD"].Rows.Add(_row);

            cbDateAdd.DataSource = _data;
            cbDateAdd.DisplayMember = "DATEADD.DISPLAY";
            cbDateAdd.ValueMember = "DATEADD.VALUE";
        }

        private void btColorChoose_Click(object sender, EventArgs e)
        {
            if (ColorColor != null)
                colorDialog1.Color = Color.FromArgb(int.Parse(ColorColor));

            colorDialog1.AllowFullOpen = true;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                btColorChoose.BackColor = colorDialog1.Color;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            ColorWhat = cbColorWhat.SelectedValue.ToString(); 
            ColorColor = btColorChoose.BackColor.ToArgb().ToString();
            ColorCondition = cbCondition.SelectedValue==null ? string.Empty : cbCondition.SelectedValue.ToString();
            ColorConvertTo = cbConvertTo.SelectedValue == null ? string.Empty : cbConvertTo.SelectedValue.ToString();

            if (ColorConvertTo != "DATE")
                ColorValue = txValue.Text.Trim();
            else
                ColorValue = cbDateAdd.SelectedValue == null ? string.Empty : cbDateAdd.SelectedValue.ToString() + "#" + (txDateAddValue.Text.Trim() == string.Empty ? "0" : txDateAddValue.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbColorWhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            btColorChoose.Text = string.Empty;
            cbCondition.SelectedIndex = -1;
            cbConvertTo.SelectedIndex = -1;

            btColorChoose.Enabled = false;
            cbCondition.Enabled = false;
            cbConvertTo.Enabled = false;

            pnlValue.Visible = false;
            pnlDate.Visible = false;

            if (cbColorWhat.SelectedValue != null)
                if (cbColorWhat.SelectedValue.ToString() != "NONE")
                {
                    btColorChoose.Enabled = true;
                    cbCondition.Enabled = true;
                    cbConvertTo.Enabled = true;
                }
        }

        private void cbConvertTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlValue.Visible = false;
            pnlDate.Visible = false;

            if (cbConvertTo.SelectedValue != null)
            {
                fillColorCondition(cbConvertTo.SelectedValue.ToString());

                if (cbConvertTo.SelectedValue != null)
                {
                    if (cbConvertTo.SelectedValue.ToString() != "BOOL" && cbConvertTo.SelectedValue.ToString() != "DATE")
                        pnlValue.Visible = true;
                    if (cbConvertTo.SelectedValue.ToString() == "DATE")
                    {
                        pnlDate.Visible = true;
                    }
                }
            }
        }
    }
}
