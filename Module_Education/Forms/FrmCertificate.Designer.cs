namespace Module_Education.Forms
{
    partial class FrmCertificate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCertificate));
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.tbRemarksPay = new System.Windows.Forms.RichTextBox();
            this.lblRemarksPayment = new System.Windows.Forms.Label();
            this.lblSendingDate = new System.Windows.Forms.Label();
            this.datePickReturn = new System.Windows.Forms.DateTimePicker();
            this.datePickSending = new System.Windows.Forms.DateTimePicker();
            this.tbRemarks = new System.Windows.Forms.RichTextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.cbCertified = new System.Windows.Forms.CheckBox();
            this.lblTitlePassport = new System.Windows.Forms.Label();
            this.synapseErrorProvider3 = new SynapseCore.Controls.SynapseErrorProvider();
            this.synapseErrorProvider2 = new SynapseCore.Controls.SynapseErrorProvider();
            this.comboTitlePassport = new System.Windows.Forms.ComboBox();
            this.lblTitleTypePassport = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveCertification = new System.Windows.Forms.Button();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblReturnDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblReturnDate.Location = new System.Drawing.Point(51, 173);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(77, 16);
            this.lblReturnDate.TabIndex = 138;
            this.lblReturnDate.Text = "Date Retour";
            // 
            // tbRemarksPay
            // 
            this.tbRemarksPay.AutoWordSelection = true;
            this.tbRemarksPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.tbRemarksPay.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbRemarksPay.Location = new System.Drawing.Point(49, 381);
            this.tbRemarksPay.Name = "tbRemarksPay";
            this.tbRemarksPay.Size = new System.Drawing.Size(377, 49);
            this.tbRemarksPay.TabIndex = 137;
            this.tbRemarksPay.Text = "";
            this.tbRemarksPay.TextChanged += new System.EventHandler(this.tbRemarksPay_TextChanged);
            // 
            // lblRemarksPayment
            // 
            this.lblRemarksPayment.AutoSize = true;
            this.lblRemarksPayment.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemarksPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRemarksPayment.Location = new System.Drawing.Point(47, 360);
            this.lblRemarksPayment.Name = "lblRemarksPayment";
            this.lblRemarksPayment.Size = new System.Drawing.Size(143, 16);
            this.lblRemarksPayment.TabIndex = 136;
            this.lblRemarksPayment.Text = "Remarques paiement";
            // 
            // lblSendingDate
            // 
            this.lblSendingDate.AutoSize = true;
            this.lblSendingDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblSendingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSendingDate.Location = new System.Drawing.Point(51, 123);
            this.lblSendingDate.Name = "lblSendingDate";
            this.lblSendingDate.Size = new System.Drawing.Size(77, 16);
            this.lblSendingDate.TabIndex = 135;
            this.lblSendingDate.Text = "Date d\'envoi";
            // 
            // datePickReturn
            // 
            this.datePickReturn.Location = new System.Drawing.Point(54, 192);
            this.datePickReturn.Name = "datePickReturn";
            this.datePickReturn.Size = new System.Drawing.Size(200, 20);
            this.datePickReturn.TabIndex = 134;
            this.datePickReturn.ValueChanged += new System.EventHandler(this.datePickReturn_ValueChanged);
            // 
            // datePickSending
            // 
            this.datePickSending.Location = new System.Drawing.Point(54, 142);
            this.datePickSending.Name = "datePickSending";
            this.datePickSending.Size = new System.Drawing.Size(200, 20);
            this.datePickSending.TabIndex = 133;
            this.datePickSending.ValueChanged += new System.EventHandler(this.datePickSending_ValueChanged);
            // 
            // tbRemarks
            // 
            this.tbRemarks.AutoWordSelection = true;
            this.tbRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.tbRemarks.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbRemarks.Location = new System.Drawing.Point(50, 295);
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(377, 49);
            this.tbRemarks.TabIndex = 132;
            this.tbRemarks.Text = "";
            this.tbRemarks.TextChanged += new System.EventHandler(this.richTextBoxRemarks_TextChanged);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRemarks.Location = new System.Drawing.Point(48, 274);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(81, 16);
            this.lblRemarks.TabIndex = 131;
            this.lblRemarks.Text = "Remarques";
            // 
            // cbCertified
            // 
            this.cbCertified.AutoSize = true;
            this.cbCertified.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbCertified.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbCertified.Location = new System.Drawing.Point(49, 241);
            this.cbCertified.Name = "cbCertified";
            this.cbCertified.Size = new System.Drawing.Size(155, 20);
            this.cbCertified.TabIndex = 130;
            this.cbCertified.Text = "Certification hiérarchie";
            this.cbCertified.UseVisualStyleBackColor = true;
            this.cbCertified.CheckedChanged += new System.EventHandler(this.cbCertified_CheckedChanged);
            // 
            // lblTitlePassport
            // 
            this.lblTitlePassport.AutoSize = true;
            this.lblTitlePassport.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblTitlePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitlePassport.Location = new System.Drawing.Point(51, 70);
            this.lblTitlePassport.Name = "lblTitlePassport";
            this.lblTitlePassport.Size = new System.Drawing.Size(86, 16);
            this.lblTitlePassport.TabIndex = 129;
            this.lblTitlePassport.Text = "Title passport";
            // 
            // synapseErrorProvider3
            // 
            this.synapseErrorProvider3.ContainerControl = this;
            this.synapseErrorProvider3.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider3.Icon")));
            this.synapseErrorProvider3.ShowMessageBox = true;
            // 
            // synapseErrorProvider2
            // 
            this.synapseErrorProvider2.ContainerControl = this;
            this.synapseErrorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider2.Icon")));
            this.synapseErrorProvider2.ShowMessageBox = true;
            // 
            // comboTitlePassport
            // 
            this.comboTitlePassport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTitlePassport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTitlePassport.FormattingEnabled = true;
            this.comboTitlePassport.Location = new System.Drawing.Point(54, 86);
            this.comboTitlePassport.Name = "comboTitlePassport";
            this.comboTitlePassport.Size = new System.Drawing.Size(185, 21);
            this.comboTitlePassport.TabIndex = 128;
            this.comboTitlePassport.Leave += new System.EventHandler(this.comboTitlePassport_Leave);
            // 
            // lblTitleTypePassport
            // 
            this.lblTitleTypePassport.AutoSize = true;
            this.lblTitleTypePassport.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitleTypePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitleTypePassport.Location = new System.Drawing.Point(36, 13);
            this.lblTitleTypePassport.Name = "lblTitleTypePassport";
            this.lblTitleTypePassport.Size = new System.Drawing.Size(71, 26);
            this.lblTitleTypePassport.TabIndex = 127;
            this.lblTitleTypePassport.Text = "label1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(247, 469);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 23);
            this.btnCancel.TabIndex = 126;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveCertification
            // 
            this.btnSaveCertification.Location = new System.Drawing.Point(90, 469);
            this.btnSaveCertification.Name = "btnSaveCertification";
            this.btnSaveCertification.Size = new System.Drawing.Size(135, 23);
            this.btnSaveCertification.TabIndex = 125;
            this.btnSaveCertification.Text = "Enregistrer";
            this.btnSaveCertification.UseVisualStyleBackColor = true;
            this.btnSaveCertification.Click += new System.EventHandler(this.btnSaveCertification_Click);
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // FrmCertificate
            // 
            this.ClientSize = new System.Drawing.Size(463, 505);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.tbRemarksPay);
            this.Controls.Add(this.lblRemarksPayment);
            this.Controls.Add(this.lblSendingDate);
            this.Controls.Add(this.datePickReturn);
            this.Controls.Add(this.datePickSending);
            this.Controls.Add(this.tbRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.cbCertified);
            this.Controls.Add(this.lblTitlePassport);
            this.Controls.Add(this.comboTitlePassport);
            this.Controls.Add(this.lblTitleTypePassport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveCertification);
            this.Name = "FrmCertificate";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.RichTextBox tbRemarksPay;
        private System.Windows.Forms.Label lblRemarksPayment;
        private System.Windows.Forms.Label lblSendingDate;
        private System.Windows.Forms.DateTimePicker datePickReturn;
        private System.Windows.Forms.DateTimePicker datePickSending;
        private System.Windows.Forms.RichTextBox tbRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.CheckBox cbCertified;
        private System.Windows.Forms.Label lblTitlePassport;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider3;
        private System.Windows.Forms.ComboBox comboTitlePassport;
        private System.Windows.Forms.Label lblTitleTypePassport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveCertification;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider2;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
    }
}