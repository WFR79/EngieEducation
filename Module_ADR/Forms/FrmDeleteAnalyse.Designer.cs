namespace Module_ADR.Forms
{
    partial class FrmDeleteAnalyse
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
            this.oblvAnalysis = new SynapseAdvancedControls.ObjectListView();
            this.olvOrderNbs = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCriticality = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvWorkCenter = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvPreparator = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvRevision = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCreationDate = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.cbWorkCenter = new System.Windows.Forms.ComboBox();
            this.btnSerarch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.oblvAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // oblvAnalysis
            // 
            this.oblvAnalysis.AllColumns.Add(this.olvOrderNbs);
            this.oblvAnalysis.AllColumns.Add(this.olvCriticality);
            this.oblvAnalysis.AllColumns.Add(this.olvWorkCenter);
            this.oblvAnalysis.AllColumns.Add(this.olvPreparator);
            this.oblvAnalysis.AllColumns.Add(this.olvRevision);
            this.oblvAnalysis.AllColumns.Add(this.olvCreationDate);
            this.oblvAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oblvAnalysis.BackColor = System.Drawing.Color.AliceBlue;
            this.oblvAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvOrderNbs,
            this.olvCriticality,
            this.olvWorkCenter,
            this.olvPreparator,
            this.olvRevision,
            this.olvCreationDate});
            this.oblvAnalysis.FullRowSelect = true;
            this.oblvAnalysis.Location = new System.Drawing.Point(12, 92);
            this.oblvAnalysis.Name = "oblvAnalysis";
            this.oblvAnalysis.Size = new System.Drawing.Size(776, 346);
            this.oblvAnalysis.TabIndex = 0;
            this.oblvAnalysis.UseCompatibleStateImageBehavior = false;
            this.oblvAnalysis.View = System.Windows.Forms.View.Details;
            this.oblvAnalysis.Click += new System.EventHandler(this.oblvAnalysis_Click);
            // 
            // olvOrderNbs
            // 
            this.olvOrderNbs.AspectName = "OrderNbs";
            this.olvOrderNbs.CellPadding = null;
            this.olvOrderNbs.Text = "Numéro d\'ordre";
            this.olvOrderNbs.Width = 120;
            // 
            // olvCriticality
            // 
            this.olvCriticality.AspectName = "Criticality";
            this.olvCriticality.CellPadding = null;
            this.olvCriticality.DisplayIndex = 5;
            this.olvCriticality.Text = "Criticité";
            // 
            // olvWorkCenter
            // 
            this.olvWorkCenter.AspectName = "WorkCenter";
            this.olvWorkCenter.CellPadding = null;
            this.olvWorkCenter.DisplayIndex = 1;
            this.olvWorkCenter.Text = "Poste responsable";
            this.olvWorkCenter.Width = 150;
            // 
            // olvPreparator
            // 
            this.olvPreparator.AspectName = "Preparator";
            this.olvPreparator.CellPadding = null;
            this.olvPreparator.Text = "Préparateur";
            this.olvPreparator.Width = 120;
            // 
            // olvRevision
            // 
            this.olvRevision.AspectName = "RevisionPhase";
            this.olvRevision.CellPadding = null;
            this.olvRevision.DisplayIndex = 2;
            this.olvRevision.Text = "Phase de révision";
            this.olvRevision.Width = 120;
            // 
            // olvCreationDate
            // 
            this.olvCreationDate.AspectName = "CreationDate";
            this.olvCreationDate.CellPadding = null;
            this.olvCreationDate.DisplayIndex = 4;
            this.olvCreationDate.Text = "Date de création";
            this.olvCreationDate.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numéro d\'ordre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Poste responsable";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(123, 6);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(121, 20);
            this.txtOrderNumber.TabIndex = 3;
            // 
            // cbWorkCenter
            // 
            this.cbWorkCenter.FormattingEnabled = true;
            this.cbWorkCenter.Location = new System.Drawing.Point(123, 32);
            this.cbWorkCenter.Name = "cbWorkCenter";
            this.cbWorkCenter.Size = new System.Drawing.Size(121, 21);
            this.cbWorkCenter.TabIndex = 4;
            // 
            // btnSerarch
            // 
            this.btnSerarch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerarch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnSerarch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSerarch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnSerarch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerarch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerarch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSerarch.Location = new System.Drawing.Point(666, 6);
            this.btnSerarch.Name = "btnSerarch";
            this.btnSerarch.Size = new System.Drawing.Size(122, 23);
            this.btnSerarch.TabIndex = 5;
            this.btnSerarch.Text = "Rechercher";
            this.btnSerarch.UseVisualStyleBackColor = false;
            this.btnSerarch.Visible = false;
            this.btnSerarch.Click += new System.EventHandler(this.btnSerarch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(666, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.btnDelete_EnabledChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filtre";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(123, 62);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(121, 20);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // FrmDeleteAnalyse
            // 
            this.AcceptButton = this.btnSerarch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSerarch);
            this.Controls.Add(this.cbWorkCenter);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oblvAnalysis);
            this.ModuleID = 52;
            this.Name = "FrmDeleteAnalyse";
            this.Text = "FrmDeleteAnalyse";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.FrmDeleteAnalyse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oblvAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView oblvAnalysis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.ComboBox cbWorkCenter;
        private System.Windows.Forms.Button btnSerarch;
        private System.Windows.Forms.Button btnDelete;
        private SynapseAdvancedControls.OLVColumn olvOrderNbs;
        private SynapseAdvancedControls.OLVColumn olvCriticality;
        private SynapseAdvancedControls.OLVColumn olvWorkCenter;
        private SynapseAdvancedControls.OLVColumn olvPreparator;
        private SynapseAdvancedControls.OLVColumn olvRevision;
        private SynapseAdvancedControls.OLVColumn olvCreationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
    }
}