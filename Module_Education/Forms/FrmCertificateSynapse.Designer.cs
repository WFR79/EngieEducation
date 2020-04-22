namespace Module_Education.Forms
{
    partial class FrmCertificateSynapse
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
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.lblTitleTypePassport = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveCertification = new System.Windows.Forms.Button();
            this.synapseErrorProvider2 = new SynapseCore.Controls.SynapseErrorProvider();
            this.synapseErrorProvider3 = new SynapseCore.Controls.SynapseErrorProvider();
            this.lblTitlePassport = new System.Windows.Forms.Label();
            this.comboTitlePassport = new System.Windows.Forms.ComboBox();
            this.cbCertified = new System.Windows.Forms.CheckBox();
            this.richTextBoxRemarks = new System.Windows.Forms.RichTextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.datePickSending = new System.Windows.Forms.DateTimePicker();
            this.datePickReturn = new System.Windows.Forms.DateTimePicker();
            this.lblSendingDate = new System.Windows.Forms.Label();
            this.tbRemarksPay = new System.Windows.Forms.RichTextBox();
            this.lblRemarksPayment = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // lblTitleTypePassport
            // 
            this.lblTitleTypePassport.AutoSize = true;
            this.lblTitleTypePassport.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitleTypePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitleTypePassport.Location = new System.Drawing.Point(12, 20);
            this.lblTitleTypePassport.Name = "lblTitleTypePassport";
            this.lblTitleTypePassport.Size = new System.Drawing.Size(71, 26);
            this.lblTitleTypePassport.TabIndex = 8;
            this.lblTitleTypePassport.Text = "label1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveCertification
            // 
            this.btnSaveCertification.Location = new System.Drawing.Point(66, 476);
            this.btnSaveCertification.Name = "btnSaveCertification";
            this.btnSaveCertification.Size = new System.Drawing.Size(135, 23);
            this.btnSaveCertification.TabIndex = 6;
            this.btnSaveCertification.Text = "Enregistrer";
            this.btnSaveCertification.UseVisualStyleBackColor = true;
            this.btnSaveCertification.Click += new System.EventHandler(this.btnSaveCertification_Click);
            // 
            // synapseErrorProvider2
            // 
            this.synapseErrorProvider2.ContainerControl = this;
            this.synapseErrorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider2.Icon")));
            this.synapseErrorProvider2.ShowMessageBox = true;
            // 
            // synapseErrorProvider3
            // 
            this.synapseErrorProvider3.ContainerControl = this;
            this.synapseErrorProvider3.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider3.Icon")));
            this.synapseErrorProvider3.ShowMessageBox = true;
            // 
            // lblTitlePassport
            // 
            this.lblTitlePassport.AutoSize = true;
            this.lblTitlePassport.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblTitlePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitlePassport.Location = new System.Drawing.Point(27, 77);
            this.lblTitlePassport.Name = "lblTitlePassport";
            this.lblTitlePassport.Size = new System.Drawing.Size(86, 16);
            this.lblTitlePassport.TabIndex = 114;
            this.lblTitlePassport.Text = "Title passport";
            // 
            // comboTitlePassport
            // 
            this.comboTitlePassport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTitlePassport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTitlePassport.FormattingEnabled = true;
            this.comboTitlePassport.Location = new System.Drawing.Point(30, 93);
            this.comboTitlePassport.Name = "comboTitlePassport";
            this.comboTitlePassport.Size = new System.Drawing.Size(185, 21);
            this.comboTitlePassport.TabIndex = 112;
            // 
            // cbCertified
            // 
            this.cbCertified.AutoSize = true;
            this.cbCertified.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbCertified.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbCertified.Location = new System.Drawing.Point(25, 248);
            this.cbCertified.Name = "cbCertified";
            this.cbCertified.Size = new System.Drawing.Size(155, 20);
            this.cbCertified.TabIndex = 116;
            this.cbCertified.Text = "Certification hiérarchie";
            this.cbCertified.UseVisualStyleBackColor = true;
            // 
            // richTextBoxRemarks
            // 
            this.richTextBoxRemarks.AutoWordSelection = true;
            this.richTextBoxRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.richTextBoxRemarks.Font = new System.Drawing.Font("Arial", 8.25F);
            this.richTextBoxRemarks.Location = new System.Drawing.Point(26, 302);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(377, 49);
            this.richTextBoxRemarks.TabIndex = 118;
            this.richTextBoxRemarks.Text = "";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRemarks.Location = new System.Drawing.Point(24, 281);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(81, 16);
            this.lblRemarks.TabIndex = 117;
            this.lblRemarks.Text = "Remarques";
            // 
            // datePickSending
            // 
            this.datePickSending.Location = new System.Drawing.Point(30, 149);
            this.datePickSending.Name = "datePickSending";
            this.datePickSending.Size = new System.Drawing.Size(200, 20);
            this.datePickSending.TabIndex = 119;
            // 
            // datePickReturn
            // 
            this.datePickReturn.Location = new System.Drawing.Point(30, 199);
            this.datePickReturn.Name = "datePickReturn";
            this.datePickReturn.Size = new System.Drawing.Size(200, 20);
            this.datePickReturn.TabIndex = 120;
            // 
            // lblSendingDate
            // 
            this.lblSendingDate.AutoSize = true;
            this.lblSendingDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblSendingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSendingDate.Location = new System.Drawing.Point(27, 130);
            this.lblSendingDate.Name = "lblSendingDate";
            this.lblSendingDate.Size = new System.Drawing.Size(77, 16);
            this.lblSendingDate.TabIndex = 121;
            this.lblSendingDate.Text = "Date d\'envoi";
            // 
            // tbRemarksPay
            // 
            this.tbRemarksPay.AutoWordSelection = true;
            this.tbRemarksPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.tbRemarksPay.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbRemarksPay.Location = new System.Drawing.Point(25, 388);
            this.tbRemarksPay.Name = "tbRemarksPay";
            this.tbRemarksPay.Size = new System.Drawing.Size(377, 49);
            this.tbRemarksPay.TabIndex = 123;
            this.tbRemarksPay.Text = "";
            // 
            // lblRemarksPayment
            // 
            this.lblRemarksPayment.AutoSize = true;
            this.lblRemarksPayment.Font = new System.Drawing.Font("Arial", 10F);
            this.lblRemarksPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRemarksPayment.Location = new System.Drawing.Point(23, 367);
            this.lblRemarksPayment.Name = "lblRemarksPayment";
            this.lblRemarksPayment.Size = new System.Drawing.Size(143, 16);
            this.lblRemarksPayment.TabIndex = 122;
            this.lblRemarksPayment.Text = "Remarques paiement";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblReturnDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblReturnDate.Location = new System.Drawing.Point(27, 180);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(77, 16);
            this.lblReturnDate.TabIndex = 124;
            this.lblReturnDate.Text = "Date Retour";
            // 
            // FrmCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 511);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.tbRemarksPay);
            this.Controls.Add(this.lblRemarksPayment);
            this.Controls.Add(this.lblSendingDate);
            this.Controls.Add(this.datePickReturn);
            this.Controls.Add(this.datePickSending);
            this.Controls.Add(this.richTextBoxRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.cbCertified);
            this.Controls.Add(this.lblTitlePassport);
            this.Controls.Add(this.comboTitlePassport);
            this.Controls.Add(this.lblTitleTypePassport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveCertification);
            this.Name = "FrmCertificate";
            this.Text = "FrmCertificate";
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
        private System.Windows.Forms.Label lblTitleTypePassport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveCertification;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider2;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider3;
        private System.Windows.Forms.Label lblTitlePassport;
        private System.Windows.Forms.ComboBox comboTitlePassport;
        private System.Windows.Forms.CheckBox cbCertified;
        private System.Windows.Forms.RichTextBox richTextBoxRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblSendingDate;
        private System.Windows.Forms.DateTimePicker datePickReturn;
        private System.Windows.Forms.DateTimePicker datePickSending;
        private System.Windows.Forms.RichTextBox tbRemarksPay;
        private System.Windows.Forms.Label lblRemarksPayment;
        private System.Windows.Forms.Label lblReturnDate;
    }
}