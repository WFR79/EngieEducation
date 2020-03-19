namespace Module_Education
{
    partial class UC_Authentification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.LabelAuthentification = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.labelengieID = new System.Windows.Forms.Label();
            this.labelpwd = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Username
            // 
            this.tb_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Username.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Username.Location = new System.Drawing.Point(338, 127);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(231, 25);
            this.tb_Username.TabIndex = 1;
            // 
            // LabelAuthentification
            // 
            this.LabelAuthentification.AutoSize = true;
            this.LabelAuthentification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.LabelAuthentification.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAuthentification.Location = new System.Drawing.Point(373, 30);
            this.LabelAuthentification.Name = "LabelAuthentification";
            this.LabelAuthentification.Size = new System.Drawing.Size(169, 24);
            this.LabelAuthentification.TabIndex = 2;
            this.LabelAuthentification.Text = "Authentification";
            // 
            // tb_Password
            // 
            this.tb_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Password.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.Location = new System.Drawing.Point(338, 176);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(231, 25);
            this.tb_Password.TabIndex = 3;
            // 
            // labelengieID
            // 
            this.labelengieID.AutoSize = true;
            this.labelengieID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.labelengieID.Location = new System.Drawing.Point(338, 108);
            this.labelengieID.Name = "labelengieID";
            this.labelengieID.Size = new System.Drawing.Size(48, 13);
            this.labelengieID.TabIndex = 4;
            this.labelengieID.Text = "Engie ID";
            // 
            // labelpwd
            // 
            this.labelpwd.AutoSize = true;
            this.labelpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.labelpwd.Location = new System.Drawing.Point(338, 160);
            this.labelpwd.Margin = new System.Windows.Forms.Padding(0);
            this.labelpwd.Name = "labelpwd";
            this.labelpwd.Size = new System.Drawing.Size(71, 13);
            this.labelpwd.TabIndex = 5;
            this.labelpwd.Text = "Mot de passe";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(940, 619);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // UC_Authentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.labelpwd);
            this.Controls.Add(this.labelengieID);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.LabelAuthentification);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UC_Authentification";
            this.Size = new System.Drawing.Size(930, 618);
            this.Load += new System.EventHandler(this.UC_Authentification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Label LabelAuthentification;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label labelengieID;
        private System.Windows.Forms.Label labelpwd;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
