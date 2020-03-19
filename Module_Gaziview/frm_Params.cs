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
using System.Globalization;

namespace Module_Gaziview
{
    public partial class frm_Params : SynapseForm
    {
        IList<o_Unit> Units;
        IList<o_Chain> Chains;

        o_Constant Constant;
        o_Constant UnvalidatedConstant;
        public frm_Params()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            gb_Params.Visible = false;
            int totalheight = (gb_Params.Visible ? gb_Params.Height+20 : 0) + (gb_Constant.Visible ? gb_Constant.Height+20 : 0) + (gb_Validate.Visible ? gb_Validate.Height+20 : 0)+15;
            this.Height = totalheight;
            pnl_waitingvalidation.Visible = false;
        }

        private void frm_Params_Load(object sender, EventArgs e)
        {
            Units = o_Unit.Load();
            cb_Tranche.DisplayMember = "Name";
            cb_Tranche.ValueMember = "ID";
            cb_Tranche.DataSource = Units;


        }

        private void cb_Tranche_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Chaine.Text = "";
            Chains = o_Chain.Load("where UnitID="+cb_Tranche.SelectedValue);
            cb_Chaine.DisplayMember = "Name";
            cb_Chaine.ValueMember = "ID";
            cb_Chaine.DataSource = Chains;


        }

        private void cb_Chaine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Constant = o_Constant.Load("where ChainID=" + cb_Chaine.SelectedValue + " AND DateFrom<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND DateTo>='" + DateTime.Now.ToString("yyyy-MM-dd")+"'").FirstOrDefault();
            if (Constant == null)
                Constant= new o_Constant();

            lb_DateFrom.Text = "Actif depuis le "+ Constant.DateFrom.ToString("dd/MM/yyyy");
            txt_OldBackNoise.Text = Constant.BackgroundNoise.ToString("0.000E+00");
            txt_OldDetectionLimit.Text = Constant.DetectionLimit.ToString("0.000E+00");

                string olduserencode = "inconnu";
                string olduservalid = "inconnu";

                try {olduserencode=SynapseCore.Entities.SynapseUser.LoadByUserID(Constant.EncodedBy).ToString(); }
                catch (Exception) { }
                try {olduservalid=SynapseCore.Entities.SynapseUser.LoadByUserID(Constant.ValidationBy).ToString(); }
                catch (Exception) { }

                lb_oldvalid.Text = string.Format(SynapseForm.GetLabel("messages.encodedmessage"), Constant.EncodedDate.ToString("dd/MM/yyyy HH:mm"),olduserencode, Constant.ValidationDate.ToString("dd/MM/yyyy HH:mm"), olduservalid);
            

            UnvalidatedConstant = o_Constant.Load("where ChainID=" + cb_Chaine.SelectedValue + " AND DateFrom='" + DateTime.MaxValue.ToString("yyyy-MM-dd") + "' AND DateTo='" + DateTime.MaxValue.ToString("yyyy-MM-dd") + "'").FirstOrDefault();
            
            if (UnvalidatedConstant != null)
            {
                txt_NewBackNoise.Text = UnvalidatedConstant.BackgroundNoise.ToString("0.000E+00");
                txt_NewDetectionLimit.Text = UnvalidatedConstant.DetectionLimit.ToString("0.000E+00");
                gb_Validate.Enabled = true;
                pnl_waitingvalidation.Visible = true;
                btn_ApplyC.Enabled = false;

                string newuserencode = "";

                try { newuserencode = SynapseCore.Entities.SynapseUser.LoadByUserID(UnvalidatedConstant.EncodedBy).ToString(); }
                catch (Exception) { }

                lb_newvalid.Text = string.Format(SynapseForm.GetLabel("messages.encodedmessage"), UnvalidatedConstant.EncodedDate.ToString("dd/MM/yyyy HH:mm"), newuserencode, "", "");
            }
            else
            {
                txt_NewBackNoise.Text = "";
                txt_NewDetectionLimit.Text = "";
                gb_Validate.Enabled = false;
                pnl_waitingvalidation.Visible = false;
                lb_newvalid.Text = "";
                btn_ApplyC.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_Tranche.SelectedValue != null && cb_Chaine.SelectedValue != null)
            {
                if (UnvalidatedConstant == null)
                    UnvalidatedConstant = new o_Constant();

                UnvalidatedConstant.ChainID = (Int64)cb_Chaine.SelectedValue;

                UnvalidatedConstant.BackgroundNoise = double.Parse(txt_NewBackNoise.Text.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)));
                UnvalidatedConstant.DetectionLimit = double.Parse(txt_NewDetectionLimit.Text.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)));

                UnvalidatedConstant.EncodedBy = SynapseForm.FormUser.UserID;
                UnvalidatedConstant.EncodedDate = DateTime.Now;

                UnvalidatedConstant.DateFrom = DateTime.MaxValue;
                UnvalidatedConstant.DateTo = DateTime.MaxValue;
                UnvalidatedConstant.save();

                cb_Chaine_SelectedIndexChanged(this, e);
            }
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (UnvalidatedConstant != null && UnvalidatedConstant.DetectionLimit != 0 && UnvalidatedConstant.BackgroundNoise != 0)
            {
                if (UnvalidatedConstant.EncodedBy.ToUpper() != SynapseForm.FormUser.UserID.ToUpper())
                {
                    o_Constant LastValidConstant = o_Constant.Load("where ChainID=" + cb_Chaine.SelectedValue + " and DateTo='" + DateTime.MaxValue.ToString("yyyy-MM-dd") + "' AND DateFrom<>'" + DateTime.MaxValue.ToString("yyyy-MM-dd") + "'").FirstOrDefault();
                    if (LastValidConstant != null)
                    {
                        if (LastValidConstant.DateFrom >= dtp_ValidFrom.Value.AddDays(-1))
                        {
                            MessageBox.Show(SynapseForm.GetLabel("messages.errorconstantdateerror"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        LastValidConstant.DateTo = dtp_ValidFrom.Value.AddDays(-1);
                        LastValidConstant.save();
                    }
                    UnvalidatedConstant.ValidationBy = SynapseForm.FormUser.UserID;
                    UnvalidatedConstant.ValidationDate = DateTime.Now;
                    UnvalidatedConstant.DateFrom = dtp_ValidFrom.Value;
                    UnvalidatedConstant.save();
                    cb_Chaine_SelectedIndexChanged(this, e);
                }
                else
                    MessageBox.Show(SynapseForm.GetLabel("messages.errordoublevalidation"), SynapseForm.GetLabel("messages.errordoublevalidationtitle"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
            }
            else
                MessageBox.Show("no constant to validate");
        }

        private void btn_Refuse_Click(object sender, EventArgs e)
        {
            if (UnvalidatedConstant != null)
            {
                UnvalidatedConstant.delete();
                cb_Chaine_SelectedIndexChanged(this, e);
            }
            else
                MessageBox.Show("no constant to refuse");
        }

        
    }
}
