namespace Module_Education
{
    partial class UC_GrpAgents
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
            this.comboAgents = new System.Windows.Forms.ComboBox();
            this.lblTiteLstFormation = new System.Windows.Forms.Label();
            this.lblNbrRows = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteGrp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboGrpAgents = new System.Windows.Forms.ComboBox();
            this.panelAgents = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbGrpAgentSAP = new System.Windows.Forms.TextBox();
            this.lblCodeSAP = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbGrpAgentName = new System.Windows.Forms.TextBox();
            this.lblGrpAgentNew = new System.Windows.Forms.Label();
            this.lblSelectedGrp = new System.Windows.Forms.Label();
            this.dgGrpAgent = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panelAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrpAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAgents
            // 
            this.comboAgents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboAgents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboAgents.DropDownHeight = 250;
            this.comboAgents.FormattingEnabled = true;
            this.comboAgents.IntegralHeight = false;
            this.comboAgents.Location = new System.Drawing.Point(6, 32);
            this.comboAgents.Name = "comboAgents";
            this.comboAgents.Size = new System.Drawing.Size(180, 21);
            this.comboAgents.TabIndex = 0;
            this.comboAgents.SelectedIndexChanged += new System.EventHandler(this.comboAgents_SelectedIndexChanged);
            // 
            // lblTiteLstFormation
            // 
            this.lblTiteLstFormation.AutoSize = true;
            this.lblTiteLstFormation.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiteLstFormation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTiteLstFormation.Location = new System.Drawing.Point(10, 28);
            this.lblTiteLstFormation.Name = "lblTiteLstFormation";
            this.lblTiteLstFormation.Size = new System.Drawing.Size(190, 24);
            this.lblTiteLstFormation.TabIndex = 28;
            this.lblTiteLstFormation.Text = "Groupes d\'agents";
            // 
            // lblNbrRows
            // 
            this.lblNbrRows.AutoSize = true;
            this.lblNbrRows.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblNbrRows.Location = new System.Drawing.Point(3, 13);
            this.lblNbrRows.Name = "lblNbrRows";
            this.lblNbrRows.Size = new System.Drawing.Size(49, 16);
            this.lblNbrRows.TabIndex = 23;
            this.lblNbrRows.Text = "Agents";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.btnDeleteGrp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboGrpAgents);
            this.panel1.Location = new System.Drawing.Point(286, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 326);
            this.panel1.TabIndex = 31;
            // 
            // btnDeleteGrp
            // 
            this.btnDeleteGrp.AllowDrop = true;
            this.btnDeleteGrp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteGrp.FlatAppearance.BorderSize = 0;
            this.btnDeleteGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGrp.Font = new System.Drawing.Font("Arial", 9F);
            this.btnDeleteGrp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteGrp.Location = new System.Drawing.Point(11, 59);
            this.btnDeleteGrp.Name = "btnDeleteGrp";
            this.btnDeleteGrp.Size = new System.Drawing.Size(117, 29);
            this.btnDeleteGrp.TabIndex = 89;
            this.btnDeleteGrp.Text = "Supprimer groupe";
            this.btnDeleteGrp.UseVisualStyleBackColor = false;
            this.btnDeleteGrp.Click += new System.EventHandler(this.btnDeleteGrp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Groupes";
            // 
            // comboGrpAgents
            // 
            this.comboGrpAgents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboGrpAgents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGrpAgents.DropDownHeight = 250;
            this.comboGrpAgents.FormattingEnabled = true;
            this.comboGrpAgents.IntegralHeight = false;
            this.comboGrpAgents.Location = new System.Drawing.Point(9, 32);
            this.comboGrpAgents.Name = "comboGrpAgents";
            this.comboGrpAgents.Size = new System.Drawing.Size(180, 21);
            this.comboGrpAgents.TabIndex = 0;
            this.comboGrpAgents.SelectedIndexChanged += new System.EventHandler(this.comboGrpAgents_SelectedIndexChanged);
            // 
            // panelAgents
            // 
            this.panelAgents.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelAgents.Controls.Add(this.lblNbrRows);
            this.panelAgents.Controls.Add(this.comboAgents);
            this.panelAgents.Location = new System.Drawing.Point(17, 73);
            this.panelAgents.Name = "panelAgents";
            this.panelAgents.Size = new System.Drawing.Size(200, 326);
            this.panelAgents.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Module_Education.Properties.Resources.baseline_double_arrow_black_18dp;
            this.pictureBox1.Location = new System.Drawing.Point(233, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 40);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.tbGrpAgentSAP);
            this.panel2.Controls.Add(this.lblCodeSAP);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.tbGrpAgentName);
            this.panel2.Controls.Add(this.lblGrpAgentNew);
            this.panel2.Location = new System.Drawing.Point(17, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 118);
            this.panel2.TabIndex = 33;
            // 
            // tbGrpAgentSAP
            // 
            this.tbGrpAgentSAP.Location = new System.Drawing.Point(280, 32);
            this.tbGrpAgentSAP.Name = "tbGrpAgentSAP";
            this.tbGrpAgentSAP.Size = new System.Drawing.Size(178, 20);
            this.tbGrpAgentSAP.TabIndex = 90;
            // 
            // lblCodeSAP
            // 
            this.lblCodeSAP.AutoSize = true;
            this.lblCodeSAP.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblCodeSAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblCodeSAP.Location = new System.Drawing.Point(277, 13);
            this.lblCodeSAP.Name = "lblCodeSAP";
            this.lblCodeSAP.Size = new System.Drawing.Size(69, 16);
            this.lblCodeSAP.TabIndex = 89;
            this.lblCodeSAP.Text = "Code SAP";
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(10, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 88;
            this.button1.Text = "Sauver ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbGrpAgentName
            // 
            this.tbGrpAgentName.Location = new System.Drawing.Point(9, 32);
            this.tbGrpAgentName.Name = "tbGrpAgentName";
            this.tbGrpAgentName.Size = new System.Drawing.Size(178, 20);
            this.tbGrpAgentName.TabIndex = 59;
            // 
            // lblGrpAgentNew
            // 
            this.lblGrpAgentNew.AutoSize = true;
            this.lblGrpAgentNew.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblGrpAgentNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblGrpAgentNew.Location = new System.Drawing.Point(6, 13);
            this.lblGrpAgentNew.Name = "lblGrpAgentNew";
            this.lblGrpAgentNew.Size = new System.Drawing.Size(100, 16);
            this.lblGrpAgentNew.TabIndex = 23;
            this.lblGrpAgentNew.Text = "Nouveau groupe";
            // 
            // lblSelectedGrp
            // 
            this.lblSelectedGrp.AutoSize = true;
            this.lblSelectedGrp.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblSelectedGrp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSelectedGrp.Location = new System.Drawing.Point(512, 54);
            this.lblSelectedGrp.Name = "lblSelectedGrp";
            this.lblSelectedGrp.Size = new System.Drawing.Size(52, 16);
            this.lblSelectedGrp.TabIndex = 34;
            this.lblSelectedGrp.Text = "Agents";
            // 
            // dgGrpAgent
            // 
            this.dgGrpAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgGrpAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGrpAgent.BackgroundColor = System.Drawing.Color.White;
            this.dgGrpAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgGrpAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGrpAgent.FilterAndSortEnabled = true;
            this.dgGrpAgent.Location = new System.Drawing.Point(506, 73);
            this.dgGrpAgent.Name = "dgGrpAgent";
            this.dgGrpAgent.ReadOnly = true;
            this.dgGrpAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGrpAgent.Size = new System.Drawing.Size(587, 472);
            this.dgGrpAgent.TabIndex = 35;
            this.dgGrpAgent.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dgGrpAgent_FilterStringChanged);
            this.dgGrpAgent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgGrpAgent_MouseClick_1);
            // 
            // UC_GrpAgents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgGrpAgent);
            this.Controls.Add(this.lblSelectedGrp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTiteLstFormation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelAgents);
            this.Name = "UC_GrpAgents";
            this.Size = new System.Drawing.Size(1108, 583);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAgents.ResumeLayout(false);
            this.panelAgents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrpAgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAgents;
        private System.Windows.Forms.Label lblTiteLstFormation;
        private System.Windows.Forms.Label lblNbrRows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboGrpAgents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelAgents;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGrpAgentNew;
        private System.Windows.Forms.TextBox tbGrpAgentName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbGrpAgentSAP;
        private System.Windows.Forms.Label lblCodeSAP;
        private System.Windows.Forms.Label lblSelectedGrp;
        private System.Windows.Forms.Button btnDeleteGrp;
        private Zuby.ADGV.AdvancedDataGridView dgGrpAgent;
    }
}
