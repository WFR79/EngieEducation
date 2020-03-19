namespace ProofOfConcept
{
    partial class frm_history
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
            this.uc_EntityHistory1 = new SynapseCore.Controls.uc_EntityHistory();
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uc_EntityHistory1
            // 
            this.uc_EntityHistory1.Location = new System.Drawing.Point(23, 12);
            this.uc_EntityHistory1.Name = "uc_EntityHistory1";
            this.uc_EntityHistory1.Size = new System.Drawing.Size(150, 150);
            this.uc_EntityHistory1.TabIndex = 0;
            // 
            // objectListView1
            // 
            this.objectListView1.Location = new System.Drawing.Point(179, 12);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(499, 283);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(670, 12);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(40, 283);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Value = 10;
            // 
            // frm_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 307);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.uc_EntityHistory1);
            this.Name = "frm_history";
            this.Text = "frm_history";
            this.Load += new System.EventHandler(this.frm_history_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseCore.Controls.uc_EntityHistory uc_EntityHistory1;
        private SynapseAdvancedControls.ObjectListView objectListView1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}