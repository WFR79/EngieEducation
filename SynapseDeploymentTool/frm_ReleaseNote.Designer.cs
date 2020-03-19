namespace SynapseDeploymentTool
{
    partial class frm_ReleaseNote
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
            this.txt_UID = new System.Windows.Forms.TextBox();
            this.txt_DATE = new System.Windows.Forms.TextBox();
            this.txt_NOTES = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_VERSION = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_UID
            // 
            this.txt_UID.Enabled = false;
            this.txt_UID.Location = new System.Drawing.Point(93, 13);
            this.txt_UID.Name = "txt_UID";
            this.txt_UID.ReadOnly = true;
            this.txt_UID.Size = new System.Drawing.Size(144, 20);
            this.txt_UID.TabIndex = 0;
            // 
            // txt_DATE
            // 
            this.txt_DATE.Enabled = false;
            this.txt_DATE.Location = new System.Drawing.Point(93, 40);
            this.txt_DATE.Name = "txt_DATE";
            this.txt_DATE.ReadOnly = true;
            this.txt_DATE.Size = new System.Drawing.Size(144, 20);
            this.txt_DATE.TabIndex = 1;
            // 
            // txt_NOTES
            // 
            this.txt_NOTES.Location = new System.Drawing.Point(93, 67);
            this.txt_NOTES.Name = "txt_NOTES";
            this.txt_NOTES.Size = new System.Drawing.Size(642, 20);
            this.txt_NOTES.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Notes";
            // 
            // txt_VERSION
            // 
            this.txt_VERSION.Location = new System.Drawing.Point(634, 13);
            this.txt_VERSION.Name = "txt_VERSION";
            this.txt_VERSION.Size = new System.Drawing.Size(101, 20);
            this.txt_VERSION.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Version";
            // 
            // frm_ReleaseNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 127);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_VERSION);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_NOTES);
            this.Controls.Add(this.txt_DATE);
            this.Controls.Add(this.txt_UID);
            this.Name = "frm_ReleaseNote";
            this.Text = "frm_ReleaseNote";
            this.Load += new System.EventHandler(this.frm_ReleaseNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_UID;
        private System.Windows.Forms.TextBox txt_DATE;
        private System.Windows.Forms.TextBox txt_NOTES;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_VERSION;
        private System.Windows.Forms.Label label4;
    }
}