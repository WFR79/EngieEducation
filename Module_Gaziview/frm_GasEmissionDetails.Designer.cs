namespace Module_Gaziview
{
    partial class frm_GasEmissionDetails
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
            this.lb_EncodedBy = new System.Windows.Forms.Label();
            this.txt_EncodedBy = new System.Windows.Forms.TextBox();
            this.txt_EncodedDate = new System.Windows.Forms.TextBox();
            this.lb_EncodedDate = new System.Windows.Forms.Label();
            this.txt_ValidatedBy = new System.Windows.Forms.TextBox();
            this.lb_ValidatedBy = new System.Windows.Forms.Label();
            this.txt_ValidatedDate = new System.Windows.Forms.TextBox();
            this.lb_ValidatedDate = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_EncodedBy
            // 
            this.lb_EncodedBy.AutoSize = true;
            this.lb_EncodedBy.Location = new System.Drawing.Point(13, 13);
            this.lb_EncodedBy.Name = "lb_EncodedBy";
            this.lb_EncodedBy.Size = new System.Drawing.Size(62, 13);
            this.lb_EncodedBy.TabIndex = 0;
            this.lb_EncodedBy.Text = "Encodé par";
            // 
            // txt_EncodedBy
            // 
            this.txt_EncodedBy.Enabled = false;
            this.txt_EncodedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EncodedBy.Location = new System.Drawing.Point(16, 30);
            this.txt_EncodedBy.Name = "txt_EncodedBy";
            this.txt_EncodedBy.ReadOnly = true;
            this.txt_EncodedBy.Size = new System.Drawing.Size(256, 20);
            this.txt_EncodedBy.TabIndex = 1;
            this.txt_EncodedBy.TextChanged += new System.EventHandler(this.txt_EncodedBy_TextChanged);
            // 
            // txt_EncodedDate
            // 
            this.txt_EncodedDate.Enabled = false;
            this.txt_EncodedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EncodedDate.Location = new System.Drawing.Point(16, 70);
            this.txt_EncodedDate.Name = "txt_EncodedDate";
            this.txt_EncodedDate.ReadOnly = true;
            this.txt_EncodedDate.Size = new System.Drawing.Size(256, 20);
            this.txt_EncodedDate.TabIndex = 3;
            this.txt_EncodedDate.TextChanged += new System.EventHandler(this.txt_EncodedDate_TextChanged);
            // 
            // lb_EncodedDate
            // 
            this.lb_EncodedDate.AutoSize = true;
            this.lb_EncodedDate.Location = new System.Drawing.Point(13, 53);
            this.lb_EncodedDate.Name = "lb_EncodedDate";
            this.lb_EncodedDate.Size = new System.Drawing.Size(55, 13);
            this.lb_EncodedDate.TabIndex = 2;
            this.lb_EncodedDate.Text = "Encodé le";
            // 
            // txt_ValidatedBy
            // 
            this.txt_ValidatedBy.Enabled = false;
            this.txt_ValidatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValidatedBy.Location = new System.Drawing.Point(16, 110);
            this.txt_ValidatedBy.Name = "txt_ValidatedBy";
            this.txt_ValidatedBy.ReadOnly = true;
            this.txt_ValidatedBy.Size = new System.Drawing.Size(256, 20);
            this.txt_ValidatedBy.TabIndex = 5;
            this.txt_ValidatedBy.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // lb_ValidatedBy
            // 
            this.lb_ValidatedBy.AutoSize = true;
            this.lb_ValidatedBy.Location = new System.Drawing.Point(13, 93);
            this.lb_ValidatedBy.Name = "lb_ValidatedBy";
            this.lb_ValidatedBy.Size = new System.Drawing.Size(54, 13);
            this.lb_ValidatedBy.TabIndex = 4;
            this.lb_ValidatedBy.Text = "Validé par";
            // 
            // txt_ValidatedDate
            // 
            this.txt_ValidatedDate.Enabled = false;
            this.txt_ValidatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValidatedDate.Location = new System.Drawing.Point(16, 150);
            this.txt_ValidatedDate.Name = "txt_ValidatedDate";
            this.txt_ValidatedDate.ReadOnly = true;
            this.txt_ValidatedDate.Size = new System.Drawing.Size(256, 20);
            this.txt_ValidatedDate.TabIndex = 7;
            // 
            // lb_ValidatedDate
            // 
            this.lb_ValidatedDate.AutoSize = true;
            this.lb_ValidatedDate.Location = new System.Drawing.Point(13, 133);
            this.lb_ValidatedDate.Name = "lb_ValidatedDate";
            this.lb_ValidatedDate.Size = new System.Drawing.Size(47, 13);
            this.lb_ValidatedDate.TabIndex = 6;
            this.lb_ValidatedDate.Text = "Validé le";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(197, 176);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_GasEmissionDetails
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 207);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_ValidatedDate);
            this.Controls.Add(this.lb_ValidatedDate);
            this.Controls.Add(this.txt_ValidatedBy);
            this.Controls.Add(this.lb_ValidatedBy);
            this.Controls.Add(this.txt_EncodedDate);
            this.Controls.Add(this.lb_EncodedDate);
            this.Controls.Add(this.txt_EncodedBy);
            this.Controls.Add(this.lb_EncodedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_GasEmissionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Détails";
            this.Load += new System.EventHandler(this.frm_GasEmissionDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_EncodedBy;
        private System.Windows.Forms.TextBox txt_EncodedBy;
        private System.Windows.Forms.TextBox txt_EncodedDate;
        private System.Windows.Forms.Label lb_EncodedDate;
        private System.Windows.Forms.TextBox txt_ValidatedBy;
        private System.Windows.Forms.Label lb_ValidatedBy;
        private System.Windows.Forms.TextBox txt_ValidatedDate;
        private System.Windows.Forms.Label lb_ValidatedDate;
        private System.Windows.Forms.Button btn_OK;
    }
}