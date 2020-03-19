using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Module_Gaziview.Entities;

namespace Module_Gaziview
{
    public partial class frm_GasEmissionDetails : Form
    {
        public frm_GasEmissionDetails(o_GasEmission obj)
        {
            InitializeComponent();
            txt_EncodedBy.Text = obj.EncodedBy!=null?SynapseCore.Entities.SynapseUser.LoadByUserID(obj.EncodedBy).ToString() + " ("+obj.EncodedBy+")":"---";
            txt_EncodedDate.Text = obj.EncodedDate!=null?obj.EncodedDate.ToString("dd/MM/yyyy HH:mm"):"---";
            txt_ValidatedBy.Text = obj.ValidationBy!=null? SynapseCore.Entities.SynapseUser.LoadByUserID(obj.ValidationBy).ToString() + " (" + obj.ValidationBy + ")":"---";
            txt_ValidatedDate.Text = obj.ValidationDate!=null?obj.ValidationDate.ToString("dd/MM/yyyy HH:mm"):"---";
        }

        private void frm_GasEmissionDetails_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_EncodedBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_EncodedDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
