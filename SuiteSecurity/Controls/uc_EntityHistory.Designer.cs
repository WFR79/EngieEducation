namespace SynapseCore.Controls
{
    partial class uc_EntityHistory
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
            this.treeListView1 = new SynapseAdvancedControls.TreeListView();
            this.col_object = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Field = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_OldValue = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_NewValue = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.col_object);
            this.treeListView1.AllColumns.Add(this.col_Field);
            this.treeListView1.AllColumns.Add(this.col_OldValue);
            this.treeListView1.AllColumns.Add(this.col_NewValue);
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_object,
            this.col_Field,
            this.col_OldValue,
            this.col_NewValue});
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(660, 284);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // col_object
            // 
            this.col_object.AspectName = "";
            this.col_object.CellPadding = null;
            this.col_object.Text = "Object";
            this.col_object.Width = 350;
            // 
            // col_Field
            // 
            this.col_Field.AspectName = "";
            this.col_Field.CellPadding = null;
            this.col_Field.Text = "Field";
            this.col_Field.Width = 100;
            // 
            // col_OldValue
            // 
            this.col_OldValue.AspectName = "";
            this.col_OldValue.CellPadding = null;
            this.col_OldValue.Text = "Old value";
            this.col_OldValue.Width = 100;
            // 
            // col_NewValue
            // 
            this.col_NewValue.AspectName = "";
            this.col_NewValue.CellPadding = null;
            this.col_NewValue.Text = "New value";
            this.col_NewValue.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeListView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(660, 284);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(660, 309);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // uc_EntityHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "uc_EntityHistory";
            this.Size = new System.Drawing.Size(660, 309);
            this.Load += new System.EventHandler(this.uc_EntityHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.TreeListView treeListView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private SynapseAdvancedControls.OLVColumn col_object;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private SynapseAdvancedControls.OLVColumn col_Field;
        private SynapseAdvancedControls.OLVColumn col_OldValue;
        private SynapseAdvancedControls.OLVColumn col_NewValue;
    }
}
