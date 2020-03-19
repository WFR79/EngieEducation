namespace SynapseReport.UserControls
{
    partial class reportControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportControl));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.splitResult = new System.Windows.Forms.SplitContainer();
            this.olvResult = new SynapseAdvancedControls.ObjectListView();
            this.olvXtraLines = new SynapseAdvancedControls.ObjectListView();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbApply = new System.Windows.Forms.ToolStripButton();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.synapseListFilter1 = new SynapseCore.Controls.SynapseListFilter();
            this.gbFilter.SuspendLayout();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitResult)).BeginInit();
            this.splitResult.Panel1.SuspendLayout();
            this.splitResult.Panel2.SuspendLayout();
            this.splitResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvXtraLines)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.AutoSize = true;
            this.gbFilter.Controls.Add(this.flowLayoutPanel1);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(606, 67);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filtres";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gbResult
            // 
            this.gbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResult.Controls.Add(this.splitResult);
            this.gbResult.Controls.Add(this.lbCount);
            this.gbResult.Controls.Add(this.lbName);
            this.gbResult.Controls.Add(this.zedGraphControl1);
            this.gbResult.Location = new System.Drawing.Point(3, 74);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(606, 415);
            this.gbResult.TabIndex = 19;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Résultats";
            // 
            // splitResult
            // 
            this.splitResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitResult.Location = new System.Drawing.Point(6, 36);
            this.splitResult.Name = "splitResult";
            this.splitResult.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitResult.Panel1
            // 
            this.splitResult.Panel1.Controls.Add(this.olvResult);
            // 
            // splitResult.Panel2
            // 
            this.splitResult.Panel2.Controls.Add(this.olvXtraLines);
            this.splitResult.Size = new System.Drawing.Size(594, 373);
            this.splitResult.SplitterDistance = 265;
            this.splitResult.TabIndex = 1011;
            // 
            // olvResult
            // 
            this.olvResult.AccessibleName = "Label of the Report for Export";
            this.olvResult.AllowColumnReorder = true;
            this.olvResult.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvResult.FullRowSelect = true;
            this.olvResult.GridLines = true;
            this.olvResult.HasCollapsibleGroups = false;
            this.olvResult.IncludeColumnHeadersInCopy = true;
            this.olvResult.Location = new System.Drawing.Point(0, 0);
            this.olvResult.Name = "olvResult";
            this.olvResult.OwnerDraw = true;
            this.olvResult.ShowCommandMenuOnRightClick = true;
            this.olvResult.ShowFilterMenuOnRightClick = false;
            this.olvResult.ShowGroups = false;
            this.olvResult.ShowItemCountOnGroups = true;
            this.olvResult.Size = new System.Drawing.Size(594, 265);
            this.olvResult.TabIndex = 23;
            this.olvResult.UseAlternatingBackColors = true;
            this.olvResult.UseCellFormatEvents = true;
            this.olvResult.UseCompatibleStateImageBehavior = false;
            this.olvResult.View = System.Windows.Forms.View.Details;
            this.olvResult.FormatCell += new System.EventHandler<SynapseAdvancedControls.FormatCellEventArgs>(this.olvResult_FormatCell);
            this.olvResult.FormatRow += new System.EventHandler<SynapseAdvancedControls.FormatRowEventArgs>(this.olvResult_FormatRow);
            this.olvResult.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.olvResult_ColumnReordered);
            this.olvResult.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.olvResult_ColumnWidthChanging);
            // 
            // olvXtraLines
            // 
            this.olvXtraLines.AccessibleName = "Label of the Report for Export";
            this.olvXtraLines.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvXtraLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvXtraLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvXtraLines.GridLines = true;
            this.olvXtraLines.HasCollapsibleGroups = false;
            this.olvXtraLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.olvXtraLines.IncludeColumnHeadersInCopy = true;
            this.olvXtraLines.Location = new System.Drawing.Point(0, 0);
            this.olvXtraLines.Name = "olvXtraLines";
            this.olvXtraLines.OwnerDraw = true;
            this.olvXtraLines.ShowFilterMenuOnRightClick = false;
            this.olvXtraLines.ShowGroups = false;
            this.olvXtraLines.ShowItemCountOnGroups = true;
            this.olvXtraLines.Size = new System.Drawing.Size(594, 104);
            this.olvXtraLines.TabIndex = 1010;
            this.olvXtraLines.UseCompatibleStateImageBehavior = false;
            this.olvXtraLines.View = System.Windows.Forms.View.Details;
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.BackColor = System.Drawing.SystemColors.Control;
            this.lbCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.ForeColor = System.Drawing.Color.Black;
            this.lbCount.Location = new System.Drawing.Point(471, 16);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(129, 17);
            this.lbCount.TabIndex = 1008;
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.BackColor = System.Drawing.Color.White;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Navy;
            this.lbName.Location = new System.Drawing.Point(6, 16);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(459, 17);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Label1";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.BackColor = System.Drawing.Color.Lavender;
            this.zedGraphControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("zedGraphControl1.BackgroundImage")));
            this.zedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 16);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(594, 393);
            this.zedGraphControl1.TabIndex = 1009;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbClose,
            this.toolStripSeparator2,
            this.tsbApply,
            this.tsbReset});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(130, 31);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(28, 28);
            this.tsbRefresh.Text = "Refresh Definition";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(28, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbApply
            // 
            this.tsbApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbApply.Image = ((System.Drawing.Image)(resources.GetObject("tsbApply.Image")));
            this.tsbApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApply.Name = "tsbApply";
            this.tsbApply.Size = new System.Drawing.Size(28, 28);
            this.tsbApply.Text = "Apply Filter";
            this.tsbApply.Click += new System.EventHandler(this.Apply_Filter);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(28, 28);
            this.tsbReset.Text = "Reset Filter";
            this.tsbReset.Click += new System.EventHandler(this.Reset_Filter);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "True");
            this.imageList.Images.SetKeyName(1, "False");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbFilter);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbResult);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(612, 492);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(612, 523);
            this.toolStripContainer1.TabIndex = 23;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.synapseListFilter1);
            // 
            // synapseListFilter1
            // 
            this.synapseListFilter1.Dock = System.Windows.Forms.DockStyle.None;
            this.synapseListFilter1.FilterOnTheFly = false;
            this.synapseListFilter1.FooterListID = "Unable to find _FooterListID on form";
            this.synapseListFilter1.FooterListView = null;
            this.synapseListFilter1.HideExport = false;
            this.synapseListFilter1.HideFilter = true;
            this.synapseListFilter1.HidePrint = false;
            this.synapseListFilter1.HideSaveConfig = false;
            this.synapseListFilter1.HideSearch = true;
            this.synapseListFilter1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.synapseListFilter1.ListID = "Unable to find rertun listID on form";
            this.synapseListFilter1.ListView = null;
            this.synapseListFilter1.Location = new System.Drawing.Point(133, 0);
            this.synapseListFilter1.Name = "synapseListFilter1";
            this.synapseListFilter1.Size = new System.Drawing.Size(231, 31);
            this.synapseListFilter1.TabIndex = 23;
            this.synapseListFilter1.TitleFontSize = 22;
            this.synapseListFilter1.UseBackgroundColor = false;
            // 
            // reportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "reportControl";
            this.Size = new System.Drawing.Size(612, 523);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.splitResult.Panel1.ResumeLayout(false);
            this.splitResult.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitResult)).EndInit();
            this.splitResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvXtraLines)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Label lbCount;
        internal System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbApply;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        public System.Windows.Forms.GroupBox gbFilter;
        public System.Windows.Forms.GroupBox gbResult;
        private SynapseAdvancedControls.ObjectListView olvResult;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private SynapseCore.Controls.SynapseListFilter synapseListFilter1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private SynapseAdvancedControls.ObjectListView olvXtraLines;
        private System.Windows.Forms.SplitContainer splitResult;
    }
}
