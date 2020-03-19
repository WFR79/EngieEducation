namespace Module_ADR.Forms
{
    partial class FrmMesureParade
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
            this.gbMesureParade = new System.Windows.Forms.GroupBox();
            this.lblCurrentLength = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.tvRisk = new System.Windows.Forms.TreeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblMesureParde = new System.Windows.Forms.Label();
            this.txtMesureParade = new System.Windows.Forms.TextBox();
            this.gbMesureParade.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMesureParade
            // 
            this.gbMesureParade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMesureParade.BackColor = System.Drawing.Color.AliceBlue;
            this.gbMesureParade.Controls.Add(this.lblCurrentLength);
            this.gbMesureParade.Controls.Add(this.lblLength);
            this.gbMesureParade.Controls.Add(this.tvRisk);
            this.gbMesureParade.Controls.Add(this.btnDelete);
            this.gbMesureParade.Controls.Add(this.btnAdd);
            this.gbMesureParade.Controls.Add(this.lblMesureParde);
            this.gbMesureParade.Controls.Add(this.txtMesureParade);
            this.gbMesureParade.Location = new System.Drawing.Point(9, 10);
            this.gbMesureParade.Name = "gbMesureParade";
            this.gbMesureParade.Size = new System.Drawing.Size(586, 523);
            this.gbMesureParade.TabIndex = 0;
            this.gbMesureParade.TabStop = false;
            this.gbMesureParade.Text = "Mesures et parades";
            // 
            // lblCurrentLength
            // 
            this.lblCurrentLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentLength.AutoSize = true;
            this.lblCurrentLength.Location = new System.Drawing.Point(553, 254);
            this.lblCurrentLength.Name = "lblCurrentLength";
            this.lblCurrentLength.Size = new System.Drawing.Size(25, 13);
            this.lblCurrentLength.TabIndex = 8;
            this.lblCurrentLength.Text = "250";
            this.lblCurrentLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLength
            // 
            this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(389, 254);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(158, 13);
            this.lblLength.TabIndex = 7;
            this.lblLength.Text = "Nombre de caractères restants :";
            // 
            // tvRisk
            // 
            this.tvRisk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRisk.Location = new System.Drawing.Point(8, 19);
            this.tvRisk.Name = "tvRisk";
            this.tvRisk.Size = new System.Drawing.Size(570, 232);
            this.tvRisk.TabIndex = 6;
            this.tvRisk.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvRiskSelectedNode);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(458, 494);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(13, 494);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMesureParde
            // 
            this.lblMesureParde.AutoSize = true;
            this.lblMesureParde.Location = new System.Drawing.Point(10, 254);
            this.lblMesureParde.Name = "lblMesureParde";
            this.lblMesureParde.Size = new System.Drawing.Size(180, 13);
            this.lblMesureParde.TabIndex = 3;
            this.lblMesureParde.Text = "Ajout/Modification Mesure et Parade";
            // 
            // txtMesureParade
            // 
            this.txtMesureParade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesureParade.Location = new System.Drawing.Point(8, 270);
            this.txtMesureParade.MaxLength = 251;
            this.txtMesureParade.Multiline = true;
            this.txtMesureParade.Name = "txtMesureParade";
            this.txtMesureParade.Size = new System.Drawing.Size(570, 218);
            this.txtMesureParade.TabIndex = 2;
            this.txtMesureParade.TextChanged += new System.EventHandler(this.txtMesureParade_TextChanged);
            // 
            // FrmMesureParade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(601, 547);
            this.Controls.Add(this.gbMesureParade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ModuleID = 52;
            this.Name = "FrmMesureParade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des mesures et parades";
            this.gbMesureParade.ResumeLayout(false);
            this.gbMesureParade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMesureParade;
        private System.Windows.Forms.Label lblMesureParde;
        private System.Windows.Forms.TextBox txtMesureParade;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TreeView tvRisk;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblCurrentLength;
    }
}