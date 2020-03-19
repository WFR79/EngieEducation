namespace SynapseStatistics
{
    partial class StartupForm
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
            this.cb_Modules = new System.Windows.Forms.ComboBox();
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.olvColumn1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_SumUsers = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.lb_UserCount = new System.Windows.Forms.Label();
            this.objectListView2 = new SynapseAdvancedControls.ObjectListView();
            this.col_FormName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.Col_FormTime = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.objectListView3 = new SynapseAdvancedControls.ObjectListView();
            this.col_UserName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_UserLast = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_UserActivity = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.btn_UserReport = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView3)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Modules
            // 
            this.cb_Modules.FormattingEnabled = true;
            this.cb_Modules.Location = new System.Drawing.Point(12, 40);
            this.cb_Modules.Name = "cb_Modules";
            this.cb_Modules.Size = new System.Drawing.Size(778, 21);
            this.cb_Modules.TabIndex = 0;
            this.cb_Modules.SelectedIndexChanged += new System.EventHandler(this.cb_Modules_SelectedIndexChanged);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.col_SumUsers);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.col_SumUsers});
            this.objectListView1.Location = new System.Drawing.Point(13, 80);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(287, 345);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "TECHNICALNAME";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 200;
            // 
            // col_SumUsers
            // 
            this.col_SumUsers.CellPadding = null;
            this.col_SumUsers.Text = "Count";
            // 
            // lb_UserCount
            // 
            this.lb_UserCount.AutoSize = true;
            this.lb_UserCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UserCount.Location = new System.Drawing.Point(12, 64);
            this.lb_UserCount.Name = "lb_UserCount";
            this.lb_UserCount.Size = new System.Drawing.Size(19, 13);
            this.lb_UserCount.TabIndex = 2;
            this.lb_UserCount.Text = "...";
            // 
            // objectListView2
            // 
            this.objectListView2.AllColumns.Add(this.col_FormName);
            this.objectListView2.AllColumns.Add(this.Col_FormTime);
            this.objectListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_FormName,
            this.Col_FormTime});
            this.objectListView2.Location = new System.Drawing.Point(306, 80);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.ShowGroups = false;
            this.objectListView2.Size = new System.Drawing.Size(340, 345);
            this.objectListView2.TabIndex = 3;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            // 
            // col_FormName
            // 
            this.col_FormName.AspectName = "";
            this.col_FormName.AspectToStringFormat = "";
            this.col_FormName.CellPadding = null;
            this.col_FormName.Text = "Name";
            this.col_FormName.Width = 200;
            // 
            // Col_FormTime
            // 
            this.Col_FormTime.AspectToStringFormat = "{0:F2} H";
            this.Col_FormTime.CellPadding = null;
            this.Col_FormTime.Text = "Time";
            this.Col_FormTime.Width = 100;
            // 
            // objectListView3
            // 
            this.objectListView3.AllColumns.Add(this.col_UserName);
            this.objectListView3.AllColumns.Add(this.col_UserLast);
            this.objectListView3.AllColumns.Add(this.col_UserActivity);
            this.objectListView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_UserName,
            this.col_UserLast,
            this.col_UserActivity});
            this.objectListView3.Location = new System.Drawing.Point(652, 80);
            this.objectListView3.Name = "objectListView3";
            this.objectListView3.ShowGroups = false;
            this.objectListView3.Size = new System.Drawing.Size(367, 345);
            this.objectListView3.TabIndex = 4;
            this.objectListView3.UseCompatibleStateImageBehavior = false;
            this.objectListView3.View = System.Windows.Forms.View.Details;
            // 
            // col_UserName
            // 
            this.col_UserName.CellPadding = null;
            this.col_UserName.Text = "Name";
            this.col_UserName.Width = 150;
            // 
            // col_UserLast
            // 
            this.col_UserLast.CellPadding = null;
            this.col_UserLast.Text = "Last connection";
            this.col_UserLast.Width = 120;
            // 
            // col_UserActivity
            // 
            this.col_UserActivity.AspectToStringFormat = "{0:F2} H";
            this.col_UserActivity.CellPadding = null;
            this.col_UserActivity.Text = "Activity";
            // 
            // btn_UserReport
            // 
            this.btn_UserReport.Location = new System.Drawing.Point(806, 38);
            this.btn_UserReport.Name = "btn_UserReport";
            this.btn_UserReport.Size = new System.Drawing.Size(75, 23);
            this.btn_UserReport.TabIndex = 5;
            this.btn_UserReport.Text = "Users";
            this.btn_UserReport.UseVisualStyleBackColor = true;
            this.btn_UserReport.Click += new System.EventHandler(this.btn_UserReport_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ACC",
            "PRD"});
            this.comboBox1.Location = new System.Drawing.Point(15, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "ACC";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(887, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Graphs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 437);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_UserReport);
            this.Controls.Add(this.objectListView3);
            this.Controls.Add(this.objectListView2);
            this.Controls.Add(this.lb_UserCount);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.cb_Modules);
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartupForm";
            this.Load += new System.EventHandler(this.StartupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Modules;
        private SynapseAdvancedControls.ObjectListView objectListView1;
        private SynapseAdvancedControls.OLVColumn olvColumn1;
        private SynapseAdvancedControls.OLVColumn col_SumUsers;
        private System.Windows.Forms.Label lb_UserCount;
        private SynapseAdvancedControls.ObjectListView objectListView2;
        private SynapseAdvancedControls.OLVColumn col_FormName;
        private SynapseAdvancedControls.OLVColumn Col_FormTime;
        private SynapseAdvancedControls.ObjectListView objectListView3;
        private SynapseAdvancedControls.OLVColumn col_UserName;
        private SynapseAdvancedControls.OLVColumn col_UserLast;
        private SynapseAdvancedControls.OLVColumn col_UserActivity;
        private System.Windows.Forms.Button btn_UserReport;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}