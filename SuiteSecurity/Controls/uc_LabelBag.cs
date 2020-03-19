using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace SynapseCore.Controls
{
    public partial class uc_LabelBag : UserControl
    {
        private string _FieldName;
        private bool _enabled;
        private LabelBag _lblBag;


        public LabelBag LblBag
        {
            get { return _lblBag; }
            set { _lblBag = value;
            flowLayoutPanel1.Controls.Clear();
            foreach (SynapseLabel l in _lblBag.Labels)
            {
                uc_Field field = new uc_Field();
                field.FieldName = l.LANGUAGE;
                field.DisplayName = ((IList< SynapseLanguage>)SynapseLanguage.Load("WHERE CODE='" + l.LANGUAGE + "'"))[0].LABEL;
                field.FieldValue = l.TEXT;

                flowLayoutPanel1.Controls.Add(field);
            }
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                groupBox1.Enabled = _enabled;
            }
        }

        public string FieldName
        {
            set
            {
                _FieldName = value;
                groupBox1.Text = _FieldName;
            }
        }

        public uc_LabelBag()
        {
            InitializeComponent();
        }

        private void uc_LabelBag_Load(object sender, EventArgs e)
        {

        }
        public void Save()
        {
            List<uc_Field> c = flowLayoutPanel1.Controls.OfType<uc_Field>().Cast<uc_Field>().ToList();
            foreach (uc_Field field in c)
            {
                SynapseLabel lbl = _lblBag.GetLabel(field.FieldName);
                lbl.TEXT = field.FieldValue.ToString();
                lbl.save();
            }
        }

        public void Refresh()
        {
            List<uc_Field> c = flowLayoutPanel1.Controls.OfType<uc_Field>().Cast<uc_Field>().ToList();
            foreach (uc_Field field in c)
            {
                SynapseLabel lbl = _lblBag.GetLabel(field.FieldName);
                lbl.TEXT = field.FieldValue.ToString();
            }
        }
    }
}
