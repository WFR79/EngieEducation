namespace Module_ADR.Forms
{
    partial class FrmImportSap
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
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.oblvAdd = new SynapseAdvancedControls.ObjectListView();
            this.OrderAddNbs = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.OrderAddDesc = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.OrderRisk = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.gbExclude = new System.Windows.Forms.GroupBox();
            this.oblvExclude = new SynapseAdvancedControls.ObjectListView();
            this.OrderExNbs = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.OrderExDesc = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.OrderExRisk = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.gbAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oblvAdd)).BeginInit();
            this.gbExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oblvExclude)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAdd
            // 
            this.gbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAdd.BackColor = System.Drawing.Color.AliceBlue;
            this.gbAdd.Controls.Add(this.oblvAdd);
            this.gbAdd.Location = new System.Drawing.Point(12, 12);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(649, 243);
            this.gbAdd.TabIndex = 0;
            this.gbAdd.TabStop = false;
            this.gbAdd.Text = "Ordres importés";
            // 
            // oblvAdd
            // 
            this.oblvAdd.AllColumns.Add(this.OrderAddNbs);
            this.oblvAdd.AllColumns.Add(this.OrderAddDesc);
            this.oblvAdd.AllColumns.Add(this.OrderRisk);
            this.oblvAdd.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.oblvAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oblvAdd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderAddNbs,
            this.OrderAddDesc,
            this.OrderRisk});
            this.oblvAdd.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.oblvAdd.HighlightForegroundColor = System.Drawing.Color.White;
            this.oblvAdd.Location = new System.Drawing.Point(6, 19);
            this.oblvAdd.Name = "oblvAdd";
            this.oblvAdd.OwnerDraw = true;
            this.oblvAdd.OwnerDrawnHeader = true;
            this.oblvAdd.Size = new System.Drawing.Size(637, 218);
            this.oblvAdd.TabIndex = 0;
            this.oblvAdd.UnfocusedHighlightForegroundColor = System.Drawing.Color.Black;
            this.oblvAdd.UseAlternatingBackColors = true;
            this.oblvAdd.UseCompatibleStateImageBehavior = false;
            this.oblvAdd.UseCustomSelectionColors = true;
            this.oblvAdd.View = System.Windows.Forms.View.Details;
            // 
            // OrderAddNbs
            // 
            this.OrderAddNbs.AspectName = "OrderNbs";
            this.OrderAddNbs.CellPadding = null;
            this.OrderAddNbs.Text = "Numéro d\'ordre";
            this.OrderAddNbs.Width = 250;
            // 
            // OrderAddDesc
            // 
            this.OrderAddDesc.AspectName = "OrderShortDesc";
            this.OrderAddDesc.CellPadding = null;
            this.OrderAddDesc.Text = "Description";
            this.OrderAddDesc.Width = 250;
            // 
            // OrderRisk
            // 
            this.OrderRisk.AspectName = "Criticality";
            this.OrderRisk.CellPadding = null;
            this.OrderRisk.Text = "Criticité";
            // 
            // gbExclude
            // 
            this.gbExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExclude.BackColor = System.Drawing.Color.AliceBlue;
            this.gbExclude.Controls.Add(this.oblvExclude);
            this.gbExclude.Location = new System.Drawing.Point(12, 261);
            this.gbExclude.Name = "gbExclude";
            this.gbExclude.Size = new System.Drawing.Size(649, 244);
            this.gbExclude.TabIndex = 1;
            this.gbExclude.TabStop = false;
            this.gbExclude.Text = "Ordres non importés";
            // 
            // oblvExclude
            // 
            this.oblvExclude.AllColumns.Add(this.OrderExNbs);
            this.oblvExclude.AllColumns.Add(this.OrderExDesc);
            this.oblvExclude.AllColumns.Add(this.OrderExRisk);
            this.oblvExclude.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.oblvExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oblvExclude.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderExNbs,
            this.OrderExDesc,
            this.OrderExRisk});
            this.oblvExclude.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.oblvExclude.HighlightForegroundColor = System.Drawing.Color.White;
            this.oblvExclude.Location = new System.Drawing.Point(6, 19);
            this.oblvExclude.Name = "oblvExclude";
            this.oblvExclude.OwnerDraw = true;
            this.oblvExclude.OwnerDrawnHeader = true;
            this.oblvExclude.Size = new System.Drawing.Size(637, 219);
            this.oblvExclude.TabIndex = 1;
            this.oblvExclude.UnfocusedHighlightForegroundColor = System.Drawing.Color.Black;
            this.oblvExclude.UseAlternatingBackColors = true;
            this.oblvExclude.UseCompatibleStateImageBehavior = false;
            this.oblvExclude.UseCustomSelectionColors = true;
            this.oblvExclude.View = System.Windows.Forms.View.Details;
            // 
            // OrderExNbs
            // 
            this.OrderExNbs.AspectName = "OrderNbs";
            this.OrderExNbs.CellPadding = null;
            this.OrderExNbs.Text = "Numéro d\'ordre";
            this.OrderExNbs.Width = 250;
            // 
            // OrderExDesc
            // 
            this.OrderExDesc.AspectName = "OrderShortDesc";
            this.OrderExDesc.CellPadding = null;
            this.OrderExDesc.Text = "Decritpion";
            this.OrderExDesc.Width = 250;
            // 
            // OrderExRisk
            // 
            this.OrderExRisk.AspectName = "Criticality";
            this.OrderExRisk.CellPadding = null;
            this.OrderExRisk.Text = "Criticité";
            // 
            // FrmImportSap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(673, 517);
            this.Controls.Add(this.gbExclude);
            this.Controls.Add(this.gbAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ModuleID = 52;
            this.Name = "FrmImportSap";
            this.Text = "Import Sap";
            this.gbAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oblvAdd)).EndInit();
            this.gbExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oblvExclude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.GroupBox gbExclude;
        private SynapseAdvancedControls.ObjectListView oblvAdd;
        private SynapseAdvancedControls.ObjectListView oblvExclude;
        private SynapseAdvancedControls.OLVColumn OrderAddNbs;
        private SynapseAdvancedControls.OLVColumn OrderAddDesc;
        private SynapseAdvancedControls.OLVColumn OrderExNbs;
        private SynapseAdvancedControls.OLVColumn OrderExDesc;
        private SynapseAdvancedControls.OLVColumn OrderRisk;
        private SynapseAdvancedControls.OLVColumn OrderExRisk;
    }
}