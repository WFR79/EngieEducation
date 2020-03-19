namespace Module_ADR.Forms
{
    partial class FrmChangeWK
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
            this.gbWorkCenter = new System.Windows.Forms.GroupBox();
            this.txtMessage2 = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.olvUser = new SynapseAdvancedControls.ObjectListView();
            this.olvColumnUserId = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumnWorkCenter = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.lblWorkCenter = new System.Windows.Forms.Label();
            this.cbWorkCenter = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.gbWorkCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gbWorkCenter
            // 
            this.gbWorkCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWorkCenter.BackColor = System.Drawing.Color.AliceBlue;
            this.gbWorkCenter.Controls.Add(this.txtMessage2);
            this.gbWorkCenter.Controls.Add(this.txtMessage);
            this.gbWorkCenter.Controls.Add(this.olvUser);
            this.gbWorkCenter.Controls.Add(this.lblWorkCenter);
            this.gbWorkCenter.Controls.Add(this.cbWorkCenter);
            this.gbWorkCenter.Controls.Add(this.btnRemove);
            this.gbWorkCenter.Controls.Add(this.btnModify);
            this.gbWorkCenter.Location = new System.Drawing.Point(12, 12);
            this.gbWorkCenter.Name = "gbWorkCenter";
            this.gbWorkCenter.Size = new System.Drawing.Size(377, 437);
            this.gbWorkCenter.TabIndex = 0;
            this.gbWorkCenter.TabStop = false;
            this.gbWorkCenter.Text = "Gestion des sections";
            // 
            // txtMessage2
            // 
            this.txtMessage2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMessage2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage2.Location = new System.Drawing.Point(6, 350);
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.ReadOnly = true;
            this.txtMessage2.Size = new System.Drawing.Size(365, 16);
            this.txtMessage2.TabIndex = 8;
            this.txtMessage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(6, 325);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(365, 16);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvUser
            // 
            this.olvUser.AllColumns.Add(this.olvColumnUserId);
            this.olvUser.AllColumns.Add(this.olvColumnWorkCenter);
            this.olvUser.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.olvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvUser.AutoArrange = false;
            this.olvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnUserId,
            this.olvColumnWorkCenter});
            this.olvUser.FullRowSelect = true;
            this.olvUser.HeaderUsesThemes = false;
            this.olvUser.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.olvUser.HighlightForegroundColor = System.Drawing.Color.White;
            this.olvUser.Location = new System.Drawing.Point(9, 19);
            this.olvUser.MultiSelect = false;
            this.olvUser.Name = "olvUser";
            this.olvUser.OwnerDraw = true;
            this.olvUser.OwnerDrawnHeader = true;
            this.olvUser.SelectColumnsOnRightClick = false;
            this.olvUser.SelectColumnsOnRightClickBehaviour = SynapseAdvancedControls.ObjectListView.ColumnSelectBehaviour.None;
            this.olvUser.Size = new System.Drawing.Size(362, 223);
            this.olvUser.TabIndex = 6;
            this.olvUser.UnfocusedHighlightForegroundColor = System.Drawing.Color.Black;
            this.olvUser.UseAlternatingBackColors = true;
            this.olvUser.UseCompatibleStateImageBehavior = false;
            this.olvUser.UseCustomSelectionColors = true;
            this.olvUser.View = System.Windows.Forms.View.Details;
            this.olvUser.Click += new System.EventHandler(this.olvUser_Click);
            // 
            // olvColumnUserId
            // 
            this.olvColumnUserId.AspectName = "User";
            this.olvColumnUserId.CellPadding = null;
            this.olvColumnUserId.Groupable = false;
            this.olvColumnUserId.ShowTextInHeader = false;
            this.olvColumnUserId.Text = "UserId";
            this.olvColumnUserId.Width = 150;
            // 
            // olvColumnWorkCenter
            // 
            this.olvColumnWorkCenter.AspectName = "WorkCenter";
            this.olvColumnWorkCenter.CellPadding = null;
            this.olvColumnWorkCenter.Groupable = false;
            this.olvColumnWorkCenter.ShowTextInHeader = false;
            this.olvColumnWorkCenter.Text = "Section";
            this.olvColumnWorkCenter.Width = 150;
            // 
            // lblWorkCenter
            // 
            this.lblWorkCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWorkCenter.AutoSize = true;
            this.lblWorkCenter.Location = new System.Drawing.Point(6, 273);
            this.lblWorkCenter.Name = "lblWorkCenter";
            this.lblWorkCenter.Size = new System.Drawing.Size(91, 13);
            this.lblWorkCenter.TabIndex = 4;
            this.lblWorkCenter.Text = "Liste des sections";
            // 
            // cbWorkCenter
            // 
            this.cbWorkCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWorkCenter.BackColor = System.Drawing.SystemColors.Window;
            this.cbWorkCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWorkCenter.FormattingEnabled = true;
            this.cbWorkCenter.Location = new System.Drawing.Point(6, 289);
            this.cbWorkCenter.Name = "cbWorkCenter";
            this.cbWorkCenter.Size = new System.Drawing.Size(365, 21);
            this.cbWorkCenter.TabIndex = 3;
            this.cbWorkCenter.SelectedIndexChanged += new System.EventHandler(this.cbWorkCenter_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnRemove.Location = new System.Drawing.Point(263, 397);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Désactiver";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(104)))), ((int)(((byte)(148)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnModify.Location = new System.Drawing.Point(33, 397);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modifier";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // FrmChangeWK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(401, 461);
            this.Controls.Add(this.gbWorkCenter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.ModuleID = 52;
            this.Name = "FrmChangeWK";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changement de section";
            this.gbWorkCenter.ResumeLayout(false);
            this.gbWorkCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWorkCenter;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ComboBox cbWorkCenter;
        private System.Windows.Forms.Label lblWorkCenter;
        private SynapseAdvancedControls.ObjectListView olvUser;
        private SynapseAdvancedControls.OLVColumn olvColumnUserId;
        private SynapseAdvancedControls.OLVColumn olvColumnWorkCenter;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtMessage2;
    }
}