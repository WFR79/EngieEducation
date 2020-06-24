namespace Module_Education
{
    partial class FrmError
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
            this.rTbStackTrace = new System.Windows.Forms.RichTextBox();
            this.rTbMsg = new System.Windows.Forms.RichTextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.lblSendError = new System.Windows.Forms.Label();
            this.buttonCopyError = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rTbStackTrace
            // 
            this.rTbStackTrace.Location = new System.Drawing.Point(40, 182);
            this.rTbStackTrace.Name = "rTbStackTrace";
            this.rTbStackTrace.ReadOnly = true;
            this.rTbStackTrace.Size = new System.Drawing.Size(843, 280);
            this.rTbStackTrace.TabIndex = 0;
            this.rTbStackTrace.Text = "";
            // 
            // rTbMsg
            // 
            this.rTbMsg.Location = new System.Drawing.Point(40, 80);
            this.rTbMsg.Name = "rTbMsg";
            this.rTbMsg.ReadOnly = true;
            this.rTbMsg.Size = new System.Drawing.Size(843, 77);
            this.rTbMsg.TabIndex = 1;
            this.rTbMsg.Text = "";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(796, 479);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(87, 27);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Fermer";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblSendError
            // 
            this.lblSendError.AutoSize = true;
            this.lblSendError.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblSendError.ForeColor = System.Drawing.Color.Red;
            this.lblSendError.Location = new System.Drawing.Point(36, 30);
            this.lblSendError.Name = "lblSendError";
            this.lblSendError.Size = new System.Drawing.Size(320, 16);
            this.lblSendError.TabIndex = 3;
            this.lblSendError.Text = "Veuillez envoyer l\'erreur à un administrateur";
            // 
            // buttonCopyError
            // 
            this.buttonCopyError.Location = new System.Drawing.Point(703, 479);
            this.buttonCopyError.Name = "buttonCopyError";
            this.buttonCopyError.Size = new System.Drawing.Size(87, 27);
            this.buttonCopyError.TabIndex = 4;
            this.buttonCopyError.Text = "Copier Tout";
            this.buttonCopyError.UseVisualStyleBackColor = true;
            this.buttonCopyError.Click += new System.EventHandler(this.buttonCopyError_Click);
            // 
            // FrmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.buttonCopyError);
            this.Controls.Add(this.lblSendError);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.rTbMsg);
            this.Controls.Add(this.rTbStackTrace);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Erreur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTbStackTrace;
        private System.Windows.Forms.RichTextBox rTbMsg;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label lblSendError;
        private System.Windows.Forms.Button buttonCopyError;
    }
}