namespace SynapseStatistics
{
    partial class frm_Users
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
            this.col_LastName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_FirstName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.synapseGraphic1 = new SynapseCore.Controls.SynapseGraphic();
            this.objectListView2 = new SynapseAdvancedControls.ObjectListView();
            this.col_FORM = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_FormCount = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.col_LastName);
            this.objectListView1.AllColumns.Add(this.col_FirstName);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_LastName,
            this.col_FirstName});
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(13, 66);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(266, 145);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // col_LastName
            // 
            this.col_LastName.AspectName = "LASTNAME";
            this.col_LastName.CellPadding = null;
            this.col_LastName.Text = "LastName";
            this.col_LastName.Width = 120;
            // 
            // col_FirstName
            // 
            this.col_FirstName.AspectName = "FIRSTNAME";
            this.col_FirstName.CellPadding = null;
            this.col_FirstName.Text = "Firstname";
            this.col_FirstName.Width = 120;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // synapseGraphic1
            // 
            this.synapseGraphic1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.synapseGraphic1.CopyMenu = "copy";
            this.synapseGraphic1.CurveOnlyMenu = "curve only";
            this.synapseGraphic1.CurvesMenu = "curve";
            this.synapseGraphic1.FontSize = 8.25F;
            this.synapseGraphic1.HideCurvesMenu = false;
            this.synapseGraphic1.HideShowAllCurvesMenu = false;
            this.synapseGraphic1.Location = new System.Drawing.Point(285, 13);
            this.synapseGraphic1.Name = "synapseGraphic1";
            this.synapseGraphic1.PageSetupMenu = "page";
            this.synapseGraphic1.PrintMenu = "print";
            this.synapseGraphic1.SaveAsMenu = "save as";
            this.synapseGraphic1.SetDefaultScaleMenu = "set default scale";
            this.synapseGraphic1.ShowAllCurvesMenu = "Show all curves";
            this.synapseGraphic1.ShowHideCurveMenu = "Show/Hide curve";
            this.synapseGraphic1.ShowHideLegendMenu = "Show/Hide legend";
            this.synapseGraphic1.ShowPointValuesMenu = "Show point";
            this.synapseGraphic1.Size = new System.Drawing.Size(600, 430);
            this.synapseGraphic1.TabIndex = 3;
            this.synapseGraphic1.UndoAllZoomMenu = "Undo all zoom";
            this.synapseGraphic1.UnZoomMenu = "Unzoom";
            // 
            // objectListView2
            // 
            this.objectListView2.AllColumns.Add(this.col_FORM);
            this.objectListView2.AllColumns.Add(this.col_FormCount);
            this.objectListView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.objectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_FORM,
            this.col_FormCount});
            this.objectListView2.Location = new System.Drawing.Point(13, 217);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.ShowGroups = false;
            this.objectListView2.Size = new System.Drawing.Size(266, 226);
            this.objectListView2.TabIndex = 4;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            // 
            // col_FORM
            // 
            this.col_FORM.AspectName = "form";
            this.col_FORM.CellPadding = null;
            this.col_FORM.Text = "Form Name";
            this.col_FORM.Width = 180;
            // 
            // col_FormCount
            // 
            this.col_FormCount.AspectName = "count";
            this.col_FormCount.CellPadding = null;
            this.col_FormCount.Text = "Visit";
            // 
            // frm_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 455);
            this.Controls.Add(this.objectListView2);
            this.Controls.Add(this.synapseGraphic1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.objectListView1);
            this.Name = "frm_Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Users";
            this.Load += new System.EventHandler(this.frm_Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView objectListView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private SynapseAdvancedControls.OLVColumn col_LastName;
        private SynapseAdvancedControls.OLVColumn col_FirstName;
        private SynapseCore.Controls.SynapseGraphic synapseGraphic1;
        private SynapseAdvancedControls.ObjectListView objectListView2;
        private SynapseAdvancedControls.OLVColumn col_FORM;
        private SynapseAdvancedControls.OLVColumn col_FormCount;
    }
}