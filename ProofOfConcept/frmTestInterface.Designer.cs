namespace ProofOfConcept
{
    partial class frmTestInterface
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
            this.gbSelect = new System.Windows.Forms.GroupBox();
            this.lbModule = new System.Windows.Forms.Label();
            this.cbInterface = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.btGet = new System.Windows.Forms.Button();
            this.btSet = new System.Windows.Forms.Button();
            this.txOracleHome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txType = new System.Windows.Forms.TextBox();
            this.gbCheck = new System.Windows.Forms.GroupBox();
            this.txMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btExec = new System.Windows.Forms.Button();
            this.olvResult = new SynapseAdvancedControls.ObjectListView();
            this.txQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbProcesses = new System.Windows.Forms.GroupBox();
            this.txProcesses = new System.Windows.Forms.TextBox();
            this.txRegistry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btSetReg = new System.Windows.Forms.Button();
            this.btGetReg = new System.Windows.Forms.Button();
            this.gbSelect.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.gbCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvResult)).BeginInit();
            this.gbProcesses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelect
            // 
            this.gbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelect.Controls.Add(this.lbModule);
            this.gbSelect.Controls.Add(this.cbInterface);
            this.gbSelect.Controls.Add(this.txType);
            this.gbSelect.Controls.Add(this.label1);
            this.gbSelect.Controls.Add(this.txConnectionString);
            this.gbSelect.Controls.Add(this.label2);
            this.gbSelect.Location = new System.Drawing.Point(12, 12);
            this.gbSelect.Name = "gbSelect";
            this.gbSelect.Size = new System.Drawing.Size(887, 128);
            this.gbSelect.TabIndex = 17;
            this.gbSelect.TabStop = false;
            this.gbSelect.Text = "Select an Interface";
            // 
            // lbModule
            // 
            this.lbModule.AutoSize = true;
            this.lbModule.Location = new System.Drawing.Point(6, 22);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(49, 13);
            this.lbModule.TabIndex = 13;
            this.lbModule.Text = "Interface";
            // 
            // cbInterface
            // 
            this.cbInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterface.FormattingEnabled = true;
            this.cbInterface.Location = new System.Drawing.Point(105, 19);
            this.cbInterface.Name = "cbInterface";
            this.cbInterface.Size = new System.Drawing.Size(776, 21);
            this.cbInterface.Sorted = true;
            this.cbInterface.TabIndex = 12;
            this.cbInterface.SelectedIndexChanged += new System.EventHandler(this.cbInterface_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DB Type";
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.btGetReg);
            this.gbDetail.Controls.Add(this.btSetReg);
            this.gbDetail.Controls.Add(this.txRegistry);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.txPath);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.btGet);
            this.gbDetail.Controls.Add(this.btSet);
            this.gbDetail.Controls.Add(this.txOracleHome);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Location = new System.Drawing.Point(12, 146);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(887, 100);
            this.gbDetail.TabIndex = 19;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Settings";
            // 
            // btGet
            // 
            this.btGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGet.Location = new System.Drawing.Point(823, 20);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(52, 20);
            this.btGet.TabIndex = 26;
            this.btGet.Text = "Get";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // btSet
            // 
            this.btSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSet.Location = new System.Drawing.Point(765, 20);
            this.btSet.Name = "btSet";
            this.btSet.Size = new System.Drawing.Size(52, 20);
            this.btSet.TabIndex = 25;
            this.btSet.Text = "Set";
            this.btSet.UseVisualStyleBackColor = true;
            this.btSet.Click += new System.EventHandler(this.btChange_Click);
            // 
            // txOracleHome
            // 
            this.txOracleHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txOracleHome.Location = new System.Drawing.Point(100, 20);
            this.txOracleHome.Name = "txOracleHome";
            this.txOracleHome.Size = new System.Drawing.Size(659, 20);
            this.txOracleHome.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "ORACLE_HOME";
            // 
            // txConnectionString
            // 
            this.txConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txConnectionString.BackColor = System.Drawing.Color.White;
            this.txConnectionString.Location = new System.Drawing.Point(105, 72);
            this.txConnectionString.Multiline = true;
            this.txConnectionString.Name = "txConnectionString";
            this.txConnectionString.ReadOnly = true;
            this.txConnectionString.Size = new System.Drawing.Size(776, 45);
            this.txConnectionString.TabIndex = 21;
            this.txConnectionString.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Connection String";
            // 
            // txType
            // 
            this.txType.BackColor = System.Drawing.Color.White;
            this.txType.Location = new System.Drawing.Point(105, 46);
            this.txType.Name = "txType";
            this.txType.ReadOnly = true;
            this.txType.Size = new System.Drawing.Size(151, 20);
            this.txType.TabIndex = 19;
            this.txType.TabStop = false;
            // 
            // gbCheck
            // 
            this.gbCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCheck.Controls.Add(this.txMessage);
            this.gbCheck.Controls.Add(this.label4);
            this.gbCheck.Controls.Add(this.btExec);
            this.gbCheck.Controls.Add(this.olvResult);
            this.gbCheck.Controls.Add(this.txQuery);
            this.gbCheck.Controls.Add(this.label3);
            this.gbCheck.Location = new System.Drawing.Point(12, 252);
            this.gbCheck.Name = "gbCheck";
            this.gbCheck.Size = new System.Drawing.Size(716, 343);
            this.gbCheck.TabIndex = 20;
            this.gbCheck.TabStop = false;
            this.gbCheck.Text = "Check Connection";
            // 
            // txMessage
            // 
            this.txMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txMessage.BackColor = System.Drawing.Color.White;
            this.txMessage.Enabled = false;
            this.txMessage.Location = new System.Drawing.Point(105, 39);
            this.txMessage.Name = "txMessage";
            this.txMessage.ReadOnly = true;
            this.txMessage.Size = new System.Drawing.Size(605, 20);
            this.txMessage.TabIndex = 26;
            this.txMessage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Message";
            // 
            // btExec
            // 
            this.btExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExec.Location = new System.Drawing.Point(599, 13);
            this.btExec.Name = "btExec";
            this.btExec.Size = new System.Drawing.Size(111, 20);
            this.btExec.TabIndex = 24;
            this.btExec.Text = "Execute";
            this.btExec.UseVisualStyleBackColor = true;
            this.btExec.Click += new System.EventHandler(this.btExec_Click);
            // 
            // olvResult
            // 
            this.olvResult.AccessibleName = "Label of the Report for Export";
            this.olvResult.AllowColumnReorder = true;
            this.olvResult.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvResult.FullRowSelect = true;
            this.olvResult.GridLines = true;
            this.olvResult.HasCollapsibleGroups = false;
            this.olvResult.IncludeColumnHeadersInCopy = true;
            this.olvResult.Location = new System.Drawing.Point(9, 65);
            this.olvResult.Name = "olvResult";
            this.olvResult.OwnerDraw = true;
            this.olvResult.ShowCommandMenuOnRightClick = true;
            this.olvResult.ShowFilterMenuOnRightClick = false;
            this.olvResult.ShowGroups = false;
            this.olvResult.ShowItemCountOnGroups = true;
            this.olvResult.Size = new System.Drawing.Size(701, 272);
            this.olvResult.TabIndex = 23;
            this.olvResult.TintSortColumn = true;
            this.olvResult.UseAlternatingBackColors = true;
            this.olvResult.UseCompatibleStateImageBehavior = false;
            this.olvResult.View = System.Windows.Forms.View.Details;
            // 
            // txQuery
            // 
            this.txQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txQuery.Location = new System.Drawing.Point(105, 13);
            this.txQuery.Name = "txQuery";
            this.txQuery.Size = new System.Drawing.Size(488, 20);
            this.txQuery.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Query to Execute";
            // 
            // txPath
            // 
            this.txPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txPath.Location = new System.Drawing.Point(100, 46);
            this.txPath.Name = "txPath";
            this.txPath.Size = new System.Drawing.Size(776, 20);
            this.txPath.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "PATH";
            // 
            // gbProcesses
            // 
            this.gbProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProcesses.Controls.Add(this.txProcesses);
            this.gbProcesses.Location = new System.Drawing.Point(734, 252);
            this.gbProcesses.Name = "gbProcesses";
            this.gbProcesses.Size = new System.Drawing.Size(165, 343);
            this.gbProcesses.TabIndex = 21;
            this.gbProcesses.TabStop = false;
            this.gbProcesses.Text = "Oracle Loaded Processes";
            // 
            // txProcesses
            // 
            this.txProcesses.AcceptsReturn = true;
            this.txProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txProcesses.BackColor = System.Drawing.Color.White;
            this.txProcesses.Location = new System.Drawing.Point(6, 19);
            this.txProcesses.Multiline = true;
            this.txProcesses.Name = "txProcesses";
            this.txProcesses.ReadOnly = true;
            this.txProcesses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txProcesses.Size = new System.Drawing.Size(153, 318);
            this.txProcesses.TabIndex = 22;
            this.txProcesses.TabStop = false;
            // 
            // txRegistry
            // 
            this.txRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txRegistry.Location = new System.Drawing.Point(100, 72);
            this.txRegistry.Name = "txRegistry";
            this.txRegistry.Size = new System.Drawing.Size(659, 20);
            this.txRegistry.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "OleDb Registry";
            // 
            // btSetReg
            // 
            this.btSetReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetReg.Location = new System.Drawing.Point(765, 72);
            this.btSetReg.Name = "btSetReg";
            this.btSetReg.Size = new System.Drawing.Size(52, 20);
            this.btSetReg.TabIndex = 31;
            this.btSetReg.Text = "Set";
            this.btSetReg.UseVisualStyleBackColor = true;
            this.btSetReg.Click += new System.EventHandler(this.btSetReg_Click);
            // 
            // btGetReg
            // 
            this.btGetReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGetReg.Location = new System.Drawing.Point(823, 72);
            this.btGetReg.Name = "btGetReg";
            this.btGetReg.Size = new System.Drawing.Size(52, 20);
            this.btGetReg.TabIndex = 32;
            this.btGetReg.Text = "Get";
            this.btGetReg.UseVisualStyleBackColor = true;
            this.btGetReg.Click += new System.EventHandler(this.btGetReg_Click);
            // 
            // frmTestInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 607);
            this.Controls.Add(this.gbProcesses);
            this.Controls.Add(this.gbCheck);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbSelect);
            this.ModuleID = 1;
            this.Name = "frmTestInterface";
            this.SecurityEnabled = false;
            this.ShowMenu = false;
            this.Text = "frmTestInterface";
            this.UpdateControls = true;
            this.gbSelect.ResumeLayout(false);
            this.gbSelect.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbCheck.ResumeLayout(false);
            this.gbCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvResult)).EndInit();
            this.gbProcesses.ResumeLayout(false);
            this.gbProcesses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelect;
        private System.Windows.Forms.Label lbModule;
        private System.Windows.Forms.ComboBox cbInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.TextBox txConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txType;
        private System.Windows.Forms.GroupBox gbCheck;
        private System.Windows.Forms.TextBox txQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btExec;
        private SynapseAdvancedControls.ObjectListView olvResult;
        private System.Windows.Forms.TextBox txMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSet;
        private System.Windows.Forms.TextBox txOracleHome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.TextBox txPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbProcesses;
        private System.Windows.Forms.TextBox txProcesses;
        private System.Windows.Forms.TextBox txRegistry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btGetReg;
        private System.Windows.Forms.Button btSetReg;
    }
}