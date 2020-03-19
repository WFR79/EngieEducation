namespace Module_ADR.Forms
{
    partial class FrmChoosCriticality
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
            this.lblCriticalityValue = new System.Windows.Forms.Label();
            this.lblCriticalityHelp = new System.Windows.Forms.Label();
            this.txtCriticalityLevel = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCriticalityValue
            // 
            this.lblCriticalityValue.AutoSize = true;
            this.lblCriticalityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriticalityValue.Location = new System.Drawing.Point(12, 18);
            this.lblCriticalityValue.Name = "lblCriticalityValue";
            this.lblCriticalityValue.Size = new System.Drawing.Size(249, 18);
            this.lblCriticalityValue.TabIndex = 0;
            this.lblCriticalityValue.Text = "Merci de choisir un niveau de criticité";
            // 
            // lblCriticalityHelp
            // 
            this.lblCriticalityHelp.AutoSize = true;
            this.lblCriticalityHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriticalityHelp.ForeColor = System.Drawing.Color.Red;
            this.lblCriticalityHelp.Location = new System.Drawing.Point(72, 36);
            this.lblCriticalityHelp.Name = "lblCriticalityHelp";
            this.lblCriticalityHelp.Size = new System.Drawing.Size(120, 13);
            this.lblCriticalityHelp.TabIndex = 1;
            this.lblCriticalityHelp.Text = "Criticité entre 2 et 4";
            // 
            // txtCriticalityLevel
            // 
            this.txtCriticalityLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCriticalityLevel.Location = new System.Drawing.Point(75, 77);
            this.txtCriticalityLevel.MaxLength = 1;
            this.txtCriticalityLevel.Name = "txtCriticalityLevel";
            this.txtCriticalityLevel.Size = new System.Drawing.Size(117, 23);
            this.txtCriticalityLevel.TabIndex = 2;
            this.txtCriticalityLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCriticalityLevel.TextChanged += new System.EventHandler(this.txtCriticalityLevel_TextChanged);
            // 
            // btnValidate
            // 
            this.btnValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnValidate.Location = new System.Drawing.Point(95, 130);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = true;
            // 
            // FrmChoosCriticality
            // 
            this.AcceptButton = this.btnValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 166);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtCriticalityLevel);
            this.Controls.Add(this.lblCriticalityHelp);
            this.Controls.Add(this.lblCriticalityValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ModuleID = 52;
            this.Name = "FrmChoosCriticality";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Niveau de criticité";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriticalityValue;
        private System.Windows.Forms.Label lblCriticalityHelp;
        private System.Windows.Forms.TextBox txtCriticalityLevel;
        private System.Windows.Forms.Button btnValidate;
    }
}