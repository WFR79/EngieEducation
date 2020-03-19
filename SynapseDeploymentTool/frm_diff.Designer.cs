namespace SynapseDeploymentTool
{
    partial class frm_diff
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
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.objectListView2 = new SynapseAdvancedControls.ObjectListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.col_acc = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_prd = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.col_acc);
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.Silver;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_acc});
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(296, 366);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // objectListView2
            // 
            this.objectListView2.AllColumns.Add(this.col_prd);
            this.objectListView2.AlternateRowBackColor = System.Drawing.Color.Silver;
            this.objectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_prd});
            this.objectListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView2.Location = new System.Drawing.Point(0, 0);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.ShowGroups = false;
            this.objectListView2.Size = new System.Drawing.Size(292, 366);
            this.objectListView2.TabIndex = 2;
            this.objectListView2.UseAlternatingBackColors = true;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.objectListView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.objectListView2);
            this.splitContainer1.Size = new System.Drawing.Size(592, 366);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 3;
            // 
            // col_acc
            // 
            this.col_acc.CellPadding = null;
            this.col_acc.FillsFreeSpace = true;
            this.col_acc.Text = "Object only in Acc";
            this.col_acc.Width = 280;
            // 
            // col_prd
            // 
            this.col_prd.CellPadding = null;
            this.col_prd.FillsFreeSpace = true;
            this.col_prd.Text = "Object only in Prd";
            this.col_prd.Width = 280;
            // 
            // frm_diff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frm_diff";
            this.Text = "frm_diff";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView objectListView1;
        private SynapseAdvancedControls.ObjectListView objectListView2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SynapseAdvancedControls.OLVColumn col_acc;
        private SynapseAdvancedControls.OLVColumn col_prd;
    }
}