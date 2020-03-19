namespace Module_ADR.Forms
{
    partial class FrmHistorique
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
            this.oblvHistorique = new SynapseAdvancedControls.ObjectListView();
            this.olvDate = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUserId = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvAction = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvOrigine = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvDestination = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oblvHistorique)).BeginInit();
            this.SuspendLayout();
            // 
            // oblvHistorique
            // 
            this.oblvHistorique.AllColumns.Add(this.olvDate);
            this.oblvHistorique.AllColumns.Add(this.olvUserId);
            this.oblvHistorique.AllColumns.Add(this.olvAction);
            this.oblvHistorique.AllColumns.Add(this.olvOrigine);
            this.oblvHistorique.AllColumns.Add(this.olvDestination);
            this.oblvHistorique.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.oblvHistorique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oblvHistorique.AutoArrange = false;
            this.oblvHistorique.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDate,
            this.olvUserId,
            this.olvAction,
            this.olvOrigine,
            this.olvDestination});
            this.oblvHistorique.FullRowSelect = true;
            this.oblvHistorique.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.oblvHistorique.HighlightForegroundColor = System.Drawing.Color.White;
            this.oblvHistorique.Location = new System.Drawing.Point(14, 46);
            this.oblvHistorique.Margin = new System.Windows.Forms.Padding(4);
            this.oblvHistorique.Name = "oblvHistorique";
            this.oblvHistorique.OwnerDraw = true;
            this.oblvHistorique.OwnerDrawnHeader = true;
            this.oblvHistorique.Size = new System.Drawing.Size(904, 459);
            this.oblvHistorique.TabIndex = 0;
            this.oblvHistorique.UnfocusedHighlightForegroundColor = System.Drawing.Color.Black;
            this.oblvHistorique.UseAlternatingBackColors = true;
            this.oblvHistorique.UseCompatibleStateImageBehavior = false;
            this.oblvHistorique.UseCustomSelectionColors = true;
            this.oblvHistorique.View = System.Windows.Forms.View.Details;
            // 
            // olvDate
            // 
            this.olvDate.AspectName = "Date";
            this.olvDate.CellPadding = null;
            this.olvDate.Text = "Date";
            this.olvDate.Width = 150;
            // 
            // olvUserId
            // 
            this.olvUserId.AspectName = "UserId";
            this.olvUserId.CellPadding = null;
            this.olvUserId.Text = "UserId";
            this.olvUserId.Width = 100;
            // 
            // olvAction
            // 
            this.olvAction.AspectName = "TypeAction";
            this.olvAction.CellPadding = null;
            this.olvAction.Text = "Action";
            this.olvAction.Width = 200;
            // 
            // olvOrigine
            // 
            this.olvOrigine.AspectName = "Origine";
            this.olvOrigine.CellPadding = null;
            this.olvOrigine.Text = "De";
            this.olvOrigine.Width = 300;
            // 
            // olvDestination
            // 
            this.olvDestination.AspectName = "Destination";
            this.olvDestination.CellPadding = null;
            this.olvDestination.Text = "Vers";
            this.olvDestination.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserId";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(60, 12);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(116, 21);
            this.txtUserId.TabIndex = 2;
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserId_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(823, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 27);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Rechercher";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmHistorique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(934, 519);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oblvHistorique);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.ModuleID = 52;
            this.Name = "FrmHistorique";
            this.Text = "FrmHistorique";
            ((System.ComponentModel.ISupportInitialize)(this.oblvHistorique)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView oblvHistorique;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserId;
        private SynapseAdvancedControls.OLVColumn olvDate;
        private SynapseAdvancedControls.OLVColumn olvUserId;
        private SynapseAdvancedControls.OLVColumn olvAction;
        private SynapseAdvancedControls.OLVColumn olvOrigine;
        private SynapseAdvancedControls.OLVColumn olvDestination;
        private System.Windows.Forms.Button btnSearch;
    }
}