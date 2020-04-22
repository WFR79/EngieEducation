namespace Module_Education.Forms.UserControls
{
    partial class UC_Certification
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
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblNbrRowsFormations = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.tbNbrRows = new System.Windows.Forms.TextBox();
            this.lblNbrRows = new System.Windows.Forms.Label();
            this.lblTiteLstFormation = new System.Windows.Forms.Label();
            this.AdvDg_Certifications = new Zuby.ADGV.AdvancedDataGridView();
            this.picExportExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AdvDg_Certifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMax.AutoSize = true;
            this.lblMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMax.Location = new System.Drawing.Point(487, 536);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(35, 13);
            this.lblMax.TabIndex = 41;
            this.lblMax.Text = "label3";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMin.AutoSize = true;
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMin.Location = new System.Drawing.Point(442, 536);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(35, 13);
            this.lblMin.TabIndex = 40;
            this.lblMin.Text = "label2";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbrRowsFormations
            // 
            this.lblNbrRowsFormations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNbrRowsFormations.AutoSize = true;
            this.lblNbrRowsFormations.Enabled = false;
            this.lblNbrRowsFormations.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRowsFormations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRowsFormations.Location = new System.Drawing.Point(33, 526);
            this.lblNbrRowsFormations.Name = "lblNbrRowsFormations";
            this.lblNbrRowsFormations.Size = new System.Drawing.Size(42, 16);
            this.lblNbrRowsFormations.TabIndex = 39;
            this.lblNbrRowsFormations.Text = "label1";
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Next.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_Next.Location = new System.Drawing.Point(525, 532);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 38;
            this.btn_Next.Text = "Suivant";
            this.btn_Next.UseVisualStyleBackColor = true;
            // 
            // btn_Previous
            // 
            this.btn_Previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Previous.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_Previous.Location = new System.Drawing.Point(365, 532);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(75, 23);
            this.btn_Previous.TabIndex = 37;
            this.btn_Previous.Text = "Précédent";
            this.btn_Previous.UseVisualStyleBackColor = true;
            // 
            // tbNbrRows
            // 
            this.tbNbrRows.Location = new System.Drawing.Point(918, 31);
            this.tbNbrRows.Name = "tbNbrRows";
            this.tbNbrRows.Size = new System.Drawing.Size(36, 20);
            this.tbNbrRows.TabIndex = 36;
            this.tbNbrRows.Text = "50";
            // 
            // lblNbrRows
            // 
            this.lblNbrRows.AutoSize = true;
            this.lblNbrRows.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.lblNbrRows.Location = new System.Drawing.Point(751, 32);
            this.lblNbrRows.Name = "lblNbrRows";
            this.lblNbrRows.Size = new System.Drawing.Size(169, 16);
            this.lblNbrRows.TabIndex = 35;
            this.lblNbrRows.Text = "Nombre de lignes à afficher:";
            // 
            // lblTiteLstFormation
            // 
            this.lblTiteLstFormation.AutoSize = true;
            this.lblTiteLstFormation.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiteLstFormation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTiteLstFormation.Location = new System.Drawing.Point(25, 26);
            this.lblTiteLstFormation.Name = "lblTiteLstFormation";
            this.lblTiteLstFormation.Size = new System.Drawing.Size(238, 24);
            this.lblTiteLstFormation.TabIndex = 33;
            this.lblTiteLstFormation.Text = "Liste des certifications";
            // 
            // AdvDg_Certifications
            // 
            this.AdvDg_Certifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdvDg_Certifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.AdvDg_Certifications.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.AdvDg_Certifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdvDg_Certifications.FilterAndSortEnabled = true;
            this.AdvDg_Certifications.Location = new System.Drawing.Point(29, 63);
            this.AdvDg_Certifications.Name = "AdvDg_Certifications";
            this.AdvDg_Certifications.Size = new System.Drawing.Size(1012, 459);
            this.AdvDg_Certifications.TabIndex = 32;
            this.AdvDg_Certifications.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.AdvDg_Certifications_FilterStringChanged);
            this.AdvDg_Certifications.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AdvDg_Certifications_CellFormatting);
            this.AdvDg_Certifications.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdvDg_Certifications_CellValueChanged);
            this.AdvDg_Certifications.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AdvDg_Certifications_MouseClick);
            // 
            // picExportExcel
            // 
            this.picExportExcel.Image = global::Module_Education.Properties.Resources.Excel_icon;
            this.picExportExcel.Location = new System.Drawing.Point(1009, 21);
            this.picExportExcel.Name = "picExportExcel";
            this.picExportExcel.Size = new System.Drawing.Size(32, 32);
            this.picExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExportExcel.TabIndex = 34;
            this.picExportExcel.TabStop = false;
            // 
            // UC_Certification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblNbrRowsFormations);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.tbNbrRows);
            this.Controls.Add(this.lblNbrRows);
            this.Controls.Add(this.picExportExcel);
            this.Controls.Add(this.lblTiteLstFormation);
            this.Controls.Add(this.AdvDg_Certifications);
            this.Name = "UC_Certification";
            this.Size = new System.Drawing.Size(1067, 576);
            ((System.ComponentModel.ISupportInitialize)(this.AdvDg_Certifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblNbrRowsFormations;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.TextBox tbNbrRows;
        private System.Windows.Forms.Label lblNbrRows;
        private System.Windows.Forms.PictureBox picExportExcel;
        private System.Windows.Forms.Label lblTiteLstFormation;
        private Zuby.ADGV.AdvancedDataGridView AdvDg_Certifications;
    }
}
