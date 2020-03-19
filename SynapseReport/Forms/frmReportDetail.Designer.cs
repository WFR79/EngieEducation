namespace SynapseReport.Forms
{
    partial class frmReportDetail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportDetail));
            this.gbReportDefinition = new System.Windows.Forms.GroupBox();
            this.ckAddCategory = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.btReportName = new System.Windows.Forms.Button();
            this.lbReport = new System.Windows.Forms.Label();
            this.txReport = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAvailableFields = new System.Windows.Forms.Label();
            this.lbSelectedTables = new System.Windows.Forms.Label();
            this.lbAvailableTables = new System.Windows.Forms.Label();
            this.olvFields = new SynapseAdvancedControls.ObjectListView();
            this.colField = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.olvTables = new SynapseAdvancedControls.ObjectListView();
            this.colTable = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.treeTable = new SynapseAdvancedControls.TreeListView();
            this.colName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bgSelect = new System.Windows.Forms.GroupBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.btColor = new System.Windows.Forms.Button();
            this.lbSortingOrder = new System.Windows.Forms.Label();
            this.txSortingOrder = new SynapseCore.Controls.SynapseTextBox();
            this.cbSorting = new System.Windows.Forms.ComboBox();
            this.lbSorting = new System.Windows.Forms.Label();
            this.lbFieldWidth = new System.Windows.Forms.Label();
            this.txFieldWidth = new System.Windows.Forms.TextBox();
            this.lbFormat = new System.Windows.Forms.Label();
            this.txFormat = new System.Windows.Forms.TextBox();
            this.btAlias = new System.Windows.Forms.Button();
            this.lblFielAlias = new System.Windows.Forms.Label();
            this.txAlias = new System.Windows.Forms.TextBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.txFieldName = new System.Windows.Forms.TextBox();
            this.olvSelectedFields = new SynapseAdvancedControls.ObjectListView();
            this.olvCol1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol7 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol2 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol4 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol3 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol5 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvCol6 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.txGroup = new System.Windows.Forms.TextBox();
            this.gbWhere = new System.Windows.Forms.GroupBox();
            this.txWhere = new System.Windows.Forms.TextBox();
            this.gbFrom = new System.Windows.Forms.GroupBox();
            this.txFrom = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.olvFilters = new SynapseAdvancedControls.ObjectListView();
            this.colFilterName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFilterLabel = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFilterType = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFilterField = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFilterWidth = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbAddFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbEditFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbDownFilter = new System.Windows.Forms.ToolStripButton();
            this.gbFilterDetail = new System.Windows.Forms.GroupBox();
            this.ckAddToReportTitle = new System.Windows.Forms.CheckBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbCancelFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveFilter = new System.Windows.Forms.ToolStripButton();
            this.gbFilterQuery = new System.Windows.Forms.GroupBox();
            this.cbLinkedField = new System.Windows.Forms.ComboBox();
            this.lbLinkedEqual = new System.Windows.Forms.Label();
            this.txLinkedFilterField = new System.Windows.Forms.TextBox();
            this.lbLinkedOn = new System.Windows.Forms.Label();
            this.cbLinkedFilter = new System.Windows.Forms.ComboBox();
            this.lbLinkedFilter = new System.Windows.Forms.Label();
            this.ckLinked = new System.Windows.Forms.CheckBox();
            this.txQueryData = new System.Windows.Forms.TextBox();
            this.cbDisplayData = new System.Windows.Forms.ComboBox();
            this.lbDisplayData = new System.Windows.Forms.Label();
            this.cbValueData = new System.Windows.Forms.ComboBox();
            this.lbValueData = new System.Windows.Forms.Label();
            this.cbTableData = new System.Windows.Forms.ComboBox();
            this.lbTableData = new System.Windows.Forms.Label();
            this.gbFilterControl = new System.Windows.Forms.GroupBox();
            this.cbControlType = new System.Windows.Forms.ComboBox();
            this.txFilterField = new System.Windows.Forms.TextBox();
            this.cbFields = new System.Windows.Forms.ComboBox();
            this.lbFilterField = new System.Windows.Forms.Label();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.lbFilterTable = new System.Windows.Forms.Label();
            this.lbFilterWidth = new System.Windows.Forms.Label();
            this.txWidth = new System.Windows.Forms.TextBox();
            this.cbFilterType = new System.Windows.Forms.ComboBox();
            this.lbFilterType = new System.Windows.Forms.Label();
            this.btFilter = new System.Windows.Forms.Button();
            this.lbFilterLabel = new System.Windows.Forms.Label();
            this.txFilterLabel = new System.Windows.Forms.TextBox();
            this.lbFilterName = new System.Windows.Forms.Label();
            this.txFilterName = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.gbExtraLines = new System.Windows.Forms.GroupBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbNewLine = new System.Windows.Forms.ToolStripButton();
            this.tsbEditLine = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLineUp = new System.Windows.Forms.ToolStripButton();
            this.tsbLineDown = new System.Windows.Forms.ToolStripButton();
            this.olvExtraLine = new SynapseAdvancedControls.ObjectListView();
            this.colLineName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colLineLabel = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.gbExtraLineFields = new System.Windows.Forms.GroupBox();
            this.txFieldFormat = new System.Windows.Forms.TextBox();
            this.btLineLabel = new System.Windows.Forms.Button();
            this.cbFieldFunction = new System.Windows.Forms.ComboBox();
            this.txLineLabel = new System.Windows.Forms.TextBox();
            this.lbLineLabel = new System.Windows.Forms.Label();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.tsbCancelLine = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLineFieldUp = new System.Windows.Forms.ToolStripButton();
            this.tsbLineFieldDown = new System.Windows.Forms.ToolStripButton();
            this.lbFieldFormat = new System.Windows.Forms.Label();
            this.lbLineName = new System.Windows.Forms.Label();
            this.lbFieldFunction = new System.Windows.Forms.Label();
            this.txLineName = new System.Windows.Forms.TextBox();
            this.olvLineFields = new SynapseAdvancedControls.ObjectListView();
            this.colFieldColumn = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFieldFunction = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colFieldFormat = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.reportControl1 = new SynapseReport.UserControls.reportControl();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.txQuery = new System.Windows.Forms.TextBox();
            this.ckAvailable = new System.Windows.Forms.CheckBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbChangeTags = new System.Windows.Forms.ToolStripButton();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.gbReportDefinition.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.bgSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvSelectedFields)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gbGroup.SuspendLayout();
            this.gbWhere.SuspendLayout();
            this.gbFrom.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFilters)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.gbFilterDetail.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.gbFilterQuery.SuspendLayout();
            this.gbFilterControl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.gbExtraLines.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvExtraLine)).BeginInit();
            this.gbExtraLineFields.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvLineFields)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbReportDefinition
            // 
            this.gbReportDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReportDefinition.Controls.Add(this.ckAddCategory);
            this.gbReportDefinition.Controls.Add(this.cbType);
            this.gbReportDefinition.Controls.Add(this.lbType);
            this.gbReportDefinition.Controls.Add(this.btReportName);
            this.gbReportDefinition.Controls.Add(this.lbReport);
            this.gbReportDefinition.Controls.Add(this.txReport);
            this.gbReportDefinition.Controls.Add(this.tabControl1);
            this.gbReportDefinition.Controls.Add(this.ckAvailable);
            this.gbReportDefinition.Controls.Add(this.cbCategory);
            this.gbReportDefinition.Controls.Add(this.lbCategory);
            this.gbReportDefinition.Location = new System.Drawing.Point(12, 34);
            this.gbReportDefinition.Name = "gbReportDefinition";
            this.gbReportDefinition.Size = new System.Drawing.Size(1015, 544);
            this.gbReportDefinition.TabIndex = 27;
            this.gbReportDefinition.TabStop = false;
            this.gbReportDefinition.Text = "Report Definition";
            // 
            // ckAddCategory
            // 
            this.ckAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAddCategory.Location = new System.Drawing.Point(746, 44);
            this.ckAddCategory.Name = "ckAddCategory";
            this.ckAddCategory.Size = new System.Drawing.Size(263, 17);
            this.ckAddCategory.TabIndex = 34;
            this.ckAddCategory.Text = "Add Category to Report Title";
            this.ckAddCategory.UseVisualStyleBackColor = true;
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbType, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbType.Location = new System.Drawing.Point(507, 17);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(152, 21);
            this.cbType.TabIndex = 32;
            // 
            // lbType
            // 
            this.lbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(452, 21);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(31, 13);
            this.lbType.TabIndex = 33;
            this.lbType.Text = "Type";
            // 
            // btReportName
            // 
            this.btReportName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReportName.Location = new System.Drawing.Point(420, 17);
            this.btReportName.Name = "btReportName";
            this.btReportName.Size = new System.Drawing.Size(26, 21);
            this.btReportName.TabIndex = 30;
            this.btReportName.Text = "...";
            this.btReportName.UseVisualStyleBackColor = true;
            this.btReportName.Click += new System.EventHandler(this.btReportName_Click);
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(3, 20);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(70, 13);
            this.lbReport.TabIndex = 31;
            this.lbReport.Text = "Report Name";
            // 
            // txReport
            // 
            this.txReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txReport.BackColor = System.Drawing.Color.White;
            this.synapseErrorProvider1.SetIconAlignment(this.txReport, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txReport.Location = new System.Drawing.Point(101, 17);
            this.txReport.Name = "txReport";
            this.txReport.ReadOnly = true;
            this.txReport.Size = new System.Drawing.Size(313, 20);
            this.txReport.TabIndex = 29;
            this.txReport.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 468);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tables and Fields";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(989, 436);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbAvailableFields);
            this.groupBox1.Controls.Add(this.lbSelectedTables);
            this.groupBox1.Controls.Add(this.lbAvailableTables);
            this.groupBox1.Controls.Add(this.olvFields);
            this.groupBox1.Controls.Add(this.olvTables);
            this.groupBox1.Controls.Add(this.treeTable);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables and Fields Selection";
            // 
            // lbAvailableFields
            // 
            this.lbAvailableFields.AutoSize = true;
            this.lbAvailableFields.Location = new System.Drawing.Point(608, 16);
            this.lbAvailableFields.Name = "lbAvailableFields";
            this.lbAvailableFields.Size = new System.Drawing.Size(80, 13);
            this.lbAvailableFields.TabIndex = 36;
            this.lbAvailableFields.Text = "Available Fields";
            // 
            // lbSelectedTables
            // 
            this.lbSelectedTables.AutoSize = true;
            this.lbSelectedTables.Location = new System.Drawing.Point(333, 16);
            this.lbSelectedTables.Name = "lbSelectedTables";
            this.lbSelectedTables.Size = new System.Drawing.Size(136, 13);
            this.lbSelectedTables.TabIndex = 35;
            this.lbSelectedTables.Text = "Selected Tables and Views";
            // 
            // lbAvailableTables
            // 
            this.lbAvailableTables.AutoSize = true;
            this.lbAvailableTables.Location = new System.Drawing.Point(3, 16);
            this.lbAvailableTables.Name = "lbAvailableTables";
            this.lbAvailableTables.Size = new System.Drawing.Size(137, 13);
            this.lbAvailableTables.TabIndex = 34;
            this.lbAvailableTables.Text = "Available Tables and Views";
            // 
            // olvFields
            // 
            this.olvFields.AllColumns.Add(this.colField);
            this.olvFields.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colField});
            this.olvFields.FullRowSelect = true;
            this.olvFields.GridLines = true;
            this.olvFields.Location = new System.Drawing.Point(611, 32);
            this.olvFields.MultiSelect = false;
            this.olvFields.Name = "olvFields";
            this.olvFields.ShowCommandMenuOnRightClick = true;
            this.olvFields.ShowGroups = false;
            this.olvFields.Size = new System.Drawing.Size(363, 121);
            this.olvFields.SmallImageList = this.imageList1;
            this.olvFields.TabIndex = 4;
            this.olvFields.TileSize = new System.Drawing.Size(168, 25);
            this.olvFields.UseAlternatingBackColors = true;
            this.olvFields.UseCompatibleStateImageBehavior = false;
            this.olvFields.View = System.Windows.Forms.View.Details;
            this.olvFields.DoubleClick += new System.EventHandler(this.addField);
            // 
            // colField
            // 
            this.colField.AspectName = "FIELDNAME";
            this.colField.CellPadding = null;
            this.colField.Text = "Name";
            this.colField.Width = 280;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "view");
            this.imageList1.Images.SetKeyName(1, "table");
            this.imageList1.Images.SetKeyName(2, "boolean");
            this.imageList1.Images.SetKeyName(3, "datetime");
            this.imageList1.Images.SetKeyName(4, "default");
            this.imageList1.Images.SetKeyName(5, "numeric");
            this.imageList1.Images.SetKeyName(6, "string");
            this.imageList1.Images.SetKeyName(7, "ok");
            this.imageList1.Images.SetKeyName(8, "notok");
            // 
            // olvTables
            // 
            this.olvTables.AllColumns.Add(this.colTable);
            this.olvTables.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.olvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTable});
            this.olvTables.FullRowSelect = true;
            this.olvTables.GridLines = true;
            this.olvTables.LargeImageList = this.imageList1;
            this.olvTables.Location = new System.Drawing.Point(336, 32);
            this.olvTables.MultiSelect = false;
            this.olvTables.Name = "olvTables";
            this.olvTables.ShowCommandMenuOnRightClick = true;
            this.olvTables.ShowGroups = false;
            this.olvTables.Size = new System.Drawing.Size(269, 121);
            this.olvTables.SmallImageList = this.imageList1;
            this.olvTables.TabIndex = 3;
            this.olvTables.TileSize = new System.Drawing.Size(168, 25);
            this.olvTables.UseAlternatingBackColors = true;
            this.olvTables.UseCompatibleStateImageBehavior = false;
            this.olvTables.View = System.Windows.Forms.View.Details;
            this.olvTables.SelectedIndexChanged += new System.EventHandler(this.olvTables_SelectedIndexChanged);
            this.olvTables.DoubleClick += new System.EventHandler(this.removeTable);
            // 
            // colTable
            // 
            this.colTable.AspectName = "TABLENAME";
            this.colTable.CellPadding = null;
            this.colTable.Text = "Name";
            this.colTable.Width = 239;
            // 
            // treeTable
            // 
            this.treeTable.AllColumns.Add(this.colName);
            this.treeTable.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.treeTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeTable.CausesValidation = false;
            this.treeTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.treeTable.FullRowSelect = true;
            this.treeTable.GridLines = true;
            this.treeTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treeTable.LargeImageList = this.imageList1;
            this.treeTable.Location = new System.Drawing.Point(6, 32);
            this.treeTable.MultiSelect = false;
            this.treeTable.Name = "treeTable";
            this.treeTable.OwnerDraw = true;
            this.treeTable.SelectColumnsOnRightClick = false;
            this.treeTable.SelectColumnsOnRightClickBehaviour = SynapseAdvancedControls.ObjectListView.ColumnSelectBehaviour.None;
            this.treeTable.ShowGroups = false;
            this.treeTable.ShowHeaderInAllViews = false;
            this.treeTable.Size = new System.Drawing.Size(324, 121);
            this.treeTable.SmallImageList = this.imageList1;
            this.treeTable.StateImageList = this.imageList1;
            this.treeTable.TabIndex = 2;
            this.treeTable.UseAlternatingBackColors = true;
            this.treeTable.UseCompatibleStateImageBehavior = false;
            this.treeTable.UseOverlays = false;
            this.treeTable.View = System.Windows.Forms.View.Details;
            this.treeTable.VirtualMode = true;
            this.treeTable.DoubleClick += new System.EventHandler(this.treeTable_DoubleClick);
            // 
            // colName
            // 
            this.colName.AspectName = "";
            this.colName.CellPadding = null;
            this.colName.IsEditable = false;
            this.colName.Text = "Name";
            this.colName.Width = 290;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.bgSelect);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbGroup);
            this.splitContainer2.Panel2.Controls.Add(this.gbWhere);
            this.splitContainer2.Panel2.Controls.Add(this.gbFrom);
            this.splitContainer2.Size = new System.Drawing.Size(989, 267);
            this.splitContainer2.SplitterDistance = 157;
            this.splitContainer2.TabIndex = 0;
            // 
            // bgSelect
            // 
            this.bgSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bgSelect.Controls.Add(this.lblColor);
            this.bgSelect.Controls.Add(this.btColor);
            this.bgSelect.Controls.Add(this.lbSortingOrder);
            this.bgSelect.Controls.Add(this.txSortingOrder);
            this.bgSelect.Controls.Add(this.cbSorting);
            this.bgSelect.Controls.Add(this.lbSorting);
            this.bgSelect.Controls.Add(this.lbFieldWidth);
            this.bgSelect.Controls.Add(this.txFieldWidth);
            this.bgSelect.Controls.Add(this.lbFormat);
            this.bgSelect.Controls.Add(this.txFormat);
            this.bgSelect.Controls.Add(this.btAlias);
            this.bgSelect.Controls.Add(this.lblFielAlias);
            this.bgSelect.Controls.Add(this.txAlias);
            this.bgSelect.Controls.Add(this.lblFieldName);
            this.bgSelect.Controls.Add(this.txFieldName);
            this.bgSelect.Controls.Add(this.olvSelectedFields);
            this.bgSelect.Controls.Add(this.toolStrip1);
            this.bgSelect.Location = new System.Drawing.Point(6, 3);
            this.bgSelect.Name = "bgSelect";
            this.bgSelect.Size = new System.Drawing.Size(980, 151);
            this.bgSelect.TabIndex = 0;
            this.bgSelect.TabStop = false;
            this.bgSelect.Text = "SELECT";
            // 
            // lblColor
            // 
            this.lblColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(330, 109);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 46;
            this.lblColor.Text = "Color";
            // 
            // btColor
            // 
            this.btColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btColor.Location = new System.Drawing.Point(333, 125);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(29, 21);
            this.btColor.TabIndex = 45;
            this.btColor.Text = "...";
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // lbSortingOrder
            // 
            this.lbSortingOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSortingOrder.AutoSize = true;
            this.lbSortingOrder.Location = new System.Drawing.Point(909, 109);
            this.lbSortingOrder.Name = "lbSortingOrder";
            this.lbSortingOrder.Size = new System.Drawing.Size(55, 13);
            this.lbSortingOrder.TabIndex = 44;
            this.lbSortingOrder.Text = "Sort Order";
            // 
            // txSortingOrder
            // 
            this.txSortingOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txSortingOrder.CurrentErrorProvider = null;
            this.txSortingOrder.Location = new System.Drawing.Point(912, 125);
            this.txSortingOrder.Mandatory = false;
            this.txSortingOrder.MandatoryErrorMessage = "Mandatory field";
            this.txSortingOrder.MaxLength = 2;
            this.txSortingOrder.MinLength = 0;
            this.txSortingOrder.Name = "txSortingOrder";
            this.txSortingOrder.NotMatchErrorMessage = "Not Valid";
            this.txSortingOrder.NumberOfDecimal = 0;
            this.txSortingOrder.RegularExpression = null;
            this.txSortingOrder.Size = new System.Drawing.Size(62, 20);
            this.txSortingOrder.TabIndex = 43;
            this.txSortingOrder.TooLongErrorMessage = "Too long";
            this.txSortingOrder.Validate = false;
            this.txSortingOrder.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Number;
            this.txSortingOrder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateField);
            // 
            // cbSorting
            // 
            this.cbSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorting.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbSorting, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbSorting.Items.AddRange(new object[] {
            "",
            "ASC",
            "DESC"});
            this.cbSorting.Location = new System.Drawing.Point(849, 125);
            this.cbSorting.Name = "cbSorting";
            this.cbSorting.Size = new System.Drawing.Size(57, 21);
            this.cbSorting.TabIndex = 42;
            this.cbSorting.SelectedIndexChanged += new System.EventHandler(this.cbSorting_SelectedIndexChanged);
            // 
            // lbSorting
            // 
            this.lbSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSorting.AutoSize = true;
            this.lbSorting.Location = new System.Drawing.Point(846, 109);
            this.lbSorting.Name = "lbSorting";
            this.lbSorting.Size = new System.Drawing.Size(40, 13);
            this.lbSorting.TabIndex = 41;
            this.lbSorting.Text = "Sorting";
            // 
            // lbFieldWidth
            // 
            this.lbFieldWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFieldWidth.AutoSize = true;
            this.lbFieldWidth.Location = new System.Drawing.Point(594, 109);
            this.lbFieldWidth.Name = "lbFieldWidth";
            this.lbFieldWidth.Size = new System.Drawing.Size(35, 13);
            this.lbFieldWidth.TabIndex = 40;
            this.lbFieldWidth.Text = "Width";
            // 
            // txFieldWidth
            // 
            this.txFieldWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txFieldWidth.BackColor = System.Drawing.Color.White;
            this.txFieldWidth.Location = new System.Drawing.Point(597, 125);
            this.txFieldWidth.Name = "txFieldWidth";
            this.txFieldWidth.ReadOnly = true;
            this.txFieldWidth.Size = new System.Drawing.Size(102, 20);
            this.txFieldWidth.TabIndex = 39;
            this.txFieldWidth.TabStop = false;
            this.txFieldWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateField);
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFormat.AutoSize = true;
            this.lbFormat.Location = new System.Drawing.Point(702, 109);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(80, 13);
            this.lbFormat.TabIndex = 38;
            this.lbFormat.Text = "Specific Format";
            // 
            // txFormat
            // 
            this.txFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txFormat.BackColor = System.Drawing.Color.White;
            this.txFormat.Location = new System.Drawing.Point(705, 125);
            this.txFormat.Name = "txFormat";
            this.txFormat.ReadOnly = true;
            this.txFormat.Size = new System.Drawing.Size(138, 20);
            this.txFormat.TabIndex = 37;
            this.txFormat.TabStop = false;
            this.txFormat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateField);
            // 
            // btAlias
            // 
            this.btAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAlias.Location = new System.Drawing.Point(565, 124);
            this.btAlias.Name = "btAlias";
            this.btAlias.Size = new System.Drawing.Size(26, 21);
            this.btAlias.TabIndex = 35;
            this.btAlias.Text = "...";
            this.btAlias.UseVisualStyleBackColor = true;
            this.btAlias.Click += new System.EventHandler(this.btAlias_Click);
            // 
            // lblFielAlias
            // 
            this.lblFielAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFielAlias.AutoSize = true;
            this.lblFielAlias.Location = new System.Drawing.Point(365, 109);
            this.lblFielAlias.Name = "lblFielAlias";
            this.lblFielAlias.Size = new System.Drawing.Size(29, 13);
            this.lblFielAlias.TabIndex = 36;
            this.lblFielAlias.Text = "Alias";
            // 
            // txAlias
            // 
            this.txAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txAlias.BackColor = System.Drawing.Color.White;
            this.txAlias.Location = new System.Drawing.Point(368, 125);
            this.txAlias.Name = "txAlias";
            this.txAlias.ReadOnly = true;
            this.txAlias.Size = new System.Drawing.Size(191, 20);
            this.txAlias.TabIndex = 34;
            this.txAlias.TabStop = false;
            // 
            // lblFieldName
            // 
            this.lblFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(3, 109);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(35, 13);
            this.lblFieldName.TabIndex = 33;
            this.lblFieldName.Text = "Name";
            // 
            // txFieldName
            // 
            this.txFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFieldName.BackColor = System.Drawing.Color.White;
            this.txFieldName.Location = new System.Drawing.Point(6, 125);
            this.txFieldName.Name = "txFieldName";
            this.txFieldName.Size = new System.Drawing.Size(321, 20);
            this.txFieldName.TabIndex = 32;
            this.txFieldName.TabStop = false;
            this.txFieldName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateField);
            // 
            // olvSelectedFields
            // 
            this.olvSelectedFields.AllColumns.Add(this.olvCol1);
            this.olvSelectedFields.AllColumns.Add(this.olvCol7);
            this.olvSelectedFields.AllColumns.Add(this.olvCol2);
            this.olvSelectedFields.AllColumns.Add(this.olvCol4);
            this.olvSelectedFields.AllColumns.Add(this.olvCol3);
            this.olvSelectedFields.AllColumns.Add(this.olvCol5);
            this.olvSelectedFields.AllColumns.Add(this.olvCol6);
            this.olvSelectedFields.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvSelectedFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvSelectedFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCol1,
            this.olvCol7,
            this.olvCol2,
            this.olvCol4,
            this.olvCol3,
            this.olvCol5,
            this.olvCol6});
            this.olvSelectedFields.FullRowSelect = true;
            this.olvSelectedFields.GridLines = true;
            this.olvSelectedFields.Location = new System.Drawing.Point(6, 50);
            this.olvSelectedFields.MultiSelect = false;
            this.olvSelectedFields.Name = "olvSelectedFields";
            this.olvSelectedFields.ShowCommandMenuOnRightClick = true;
            this.olvSelectedFields.ShowGroups = false;
            this.olvSelectedFields.Size = new System.Drawing.Size(968, 56);
            this.olvSelectedFields.SmallImageList = this.imageList1;
            this.olvSelectedFields.TabIndex = 5;
            this.olvSelectedFields.TileSize = new System.Drawing.Size(168, 25);
            this.olvSelectedFields.UseAlternatingBackColors = true;
            this.olvSelectedFields.UseCellFormatEvents = true;
            this.olvSelectedFields.UseCompatibleStateImageBehavior = false;
            this.olvSelectedFields.View = System.Windows.Forms.View.Details;
            this.olvSelectedFields.FormatCell += new System.EventHandler<SynapseAdvancedControls.FormatCellEventArgs>(this.olvSelectedFields_FormatCell);
            this.olvSelectedFields.SelectedIndexChanged += new System.EventHandler(this.olvSelectedFields_SelectedIndexChanged);
            this.olvSelectedFields.DoubleClick += new System.EventHandler(this.btAlias_Click);
            // 
            // olvCol1
            // 
            this.olvCol1.AspectName = "FIELDNAME";
            this.olvCol1.CellPadding = null;
            this.olvCol1.FillsFreeSpace = true;
            this.olvCol1.MinimumWidth = 300;
            this.olvCol1.Text = "Name";
            this.olvCol1.Width = 341;
            // 
            // olvCol7
            // 
            this.olvCol7.AspectName = "COLORWHAT";
            this.olvCol7.CellPadding = null;
            this.olvCol7.Text = "Color";
            this.olvCol7.Width = 39;
            // 
            // olvCol2
            // 
            this.olvCol2.AspectName = "ALIAS";
            this.olvCol2.CellPadding = null;
            this.olvCol2.Text = "Alias";
            this.olvCol2.Width = 237;
            // 
            // olvCol4
            // 
            this.olvCol4.AspectName = "WIDTH";
            this.olvCol4.CellPadding = null;
            this.olvCol4.Text = "Width";
            this.olvCol4.Width = 104;
            // 
            // olvCol3
            // 
            this.olvCol3.AspectName = "FORMAT";
            this.olvCol3.CellPadding = null;
            this.olvCol3.Text = "Format";
            this.olvCol3.Width = 138;
            // 
            // olvCol5
            // 
            this.olvCol5.AspectName = "SORTING";
            this.olvCol5.CellPadding = null;
            this.olvCol5.Text = "Sorting";
            this.olvCol5.Width = 65;
            // 
            // olvCol6
            // 
            this.olvCol6.AspectName = "SORTING_ORDER";
            this.olvCol6.CellPadding = null;
            this.olvCol6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCol6.Text = "Sort Order";
            this.olvCol6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCol6.Width = 65;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbUp,
            this.tsbDown});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.deleteField);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbUp.Image")));
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(28, 28);
            this.tsbUp.Text = "Up";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbDown.Image")));
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(28, 28);
            this.tsbDown.Text = "Down";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // gbGroup
            // 
            this.gbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGroup.Controls.Add(this.txGroup);
            this.gbGroup.Location = new System.Drawing.Point(733, 3);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Size = new System.Drawing.Size(247, 100);
            this.gbGroup.TabIndex = 2;
            this.gbGroup.TabStop = false;
            this.gbGroup.Text = "GROUP BY";
            // 
            // txGroup
            // 
            this.txGroup.AcceptsReturn = true;
            this.txGroup.AcceptsTab = true;
            this.txGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txGroup.Location = new System.Drawing.Point(6, 19);
            this.txGroup.Multiline = true;
            this.txGroup.Name = "txGroup";
            this.txGroup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txGroup.Size = new System.Drawing.Size(235, 75);
            this.txGroup.TabIndex = 0;
            // 
            // gbWhere
            // 
            this.gbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWhere.Controls.Add(this.txWhere);
            this.gbWhere.Location = new System.Drawing.Point(394, 3);
            this.gbWhere.Name = "gbWhere";
            this.gbWhere.Size = new System.Drawing.Size(333, 100);
            this.gbWhere.TabIndex = 1;
            this.gbWhere.TabStop = false;
            this.gbWhere.Text = "WHERE";
            // 
            // txWhere
            // 
            this.txWhere.AcceptsReturn = true;
            this.txWhere.AcceptsTab = true;
            this.txWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txWhere.Location = new System.Drawing.Point(6, 19);
            this.txWhere.Multiline = true;
            this.txWhere.Name = "txWhere";
            this.txWhere.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txWhere.Size = new System.Drawing.Size(321, 75);
            this.txWhere.TabIndex = 0;
            // 
            // gbFrom
            // 
            this.gbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFrom.Controls.Add(this.txFrom);
            this.gbFrom.Location = new System.Drawing.Point(6, 3);
            this.gbFrom.Name = "gbFrom";
            this.gbFrom.Size = new System.Drawing.Size(382, 100);
            this.gbFrom.TabIndex = 0;
            this.gbFrom.TabStop = false;
            this.gbFrom.Text = "FROM + RELATION";
            // 
            // txFrom
            // 
            this.txFrom.AcceptsReturn = true;
            this.txFrom.AcceptsTab = true;
            this.txFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFrom.Location = new System.Drawing.Point(6, 19);
            this.txFrom.Multiline = true;
            this.txFrom.Name = "txFrom";
            this.txFrom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txFrom.Size = new System.Drawing.Size(370, 75);
            this.txFrom.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(995, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filters";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gbFilter);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gbFilterDetail);
            this.splitContainer3.Size = new System.Drawing.Size(989, 436);
            this.splitContainer3.SplitterDistance = 136;
            this.splitContainer3.TabIndex = 2;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.olvFilters);
            this.gbFilter.Controls.Add(this.toolStrip3);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(977, 130);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filters";
            // 
            // olvFilters
            // 
            this.olvFilters.AllColumns.Add(this.colFilterName);
            this.olvFilters.AllColumns.Add(this.colFilterLabel);
            this.olvFilters.AllColumns.Add(this.colFilterType);
            this.olvFilters.AllColumns.Add(this.colFilterField);
            this.olvFilters.AllColumns.Add(this.colFilterWidth);
            this.olvFilters.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilterName,
            this.colFilterLabel,
            this.colFilterType,
            this.colFilterField,
            this.colFilterWidth});
            this.olvFilters.FullRowSelect = true;
            this.olvFilters.GridLines = true;
            this.olvFilters.Location = new System.Drawing.Point(3, 50);
            this.olvFilters.MultiSelect = false;
            this.olvFilters.Name = "olvFilters";
            this.olvFilters.ShowCommandMenuOnRightClick = true;
            this.olvFilters.ShowGroups = false;
            this.olvFilters.Size = new System.Drawing.Size(968, 74);
            this.olvFilters.TabIndex = 5;
            this.olvFilters.TileSize = new System.Drawing.Size(168, 25);
            this.olvFilters.UseAlternatingBackColors = true;
            this.olvFilters.UseCompatibleStateImageBehavior = false;
            this.olvFilters.View = System.Windows.Forms.View.Details;
            this.olvFilters.SelectedIndexChanged += new System.EventHandler(this.olvFilters_SelectedIndexChanged);
            this.olvFilters.DoubleClick += new System.EventHandler(this.Edit_Filter);
            // 
            // colFilterName
            // 
            this.colFilterName.AspectName = "NAME";
            this.colFilterName.CellPadding = null;
            this.colFilterName.Text = "Name";
            this.colFilterName.Width = 200;
            // 
            // colFilterLabel
            // 
            this.colFilterLabel.AspectName = "LABEL";
            this.colFilterLabel.CellPadding = null;
            this.colFilterLabel.Text = "Alias";
            this.colFilterLabel.Width = 200;
            // 
            // colFilterType
            // 
            this.colFilterType.AspectName = "TYPE";
            this.colFilterType.CellPadding = null;
            this.colFilterType.Text = "Type";
            this.colFilterType.Width = 150;
            // 
            // colFilterField
            // 
            this.colFilterField.AspectName = "CTRL_CUSTOM";
            this.colFilterField.CellPadding = null;
            this.colFilterField.Text = "Field to Control";
            this.colFilterField.Width = 200;
            // 
            // colFilterWidth
            // 
            this.colFilterWidth.AspectName = "WIDTH";
            this.colFilterWidth.CellPadding = null;
            this.colFilterWidth.Text = "Width";
            this.colFilterWidth.Width = 100;
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddFilter,
            this.tsbEditFilter,
            this.tsbDeleteFilter,
            this.toolStripSeparator3,
            this.tsbUpFilter,
            this.tsbDownFilter});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(971, 31);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbAddFilter
            // 
            this.tsbAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFilter.Image")));
            this.tsbAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddFilter.Name = "tsbAddFilter";
            this.tsbAddFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbAddFilter.Text = "New";
            this.tsbAddFilter.Click += new System.EventHandler(this.New_Filter);
            // 
            // tsbEditFilter
            // 
            this.tsbEditFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditFilter.Image")));
            this.tsbEditFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditFilter.Name = "tsbEditFilter";
            this.tsbEditFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbEditFilter.Text = "Edit";
            this.tsbEditFilter.Click += new System.EventHandler(this.Edit_Filter);
            // 
            // tsbDeleteFilter
            // 
            this.tsbDeleteFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteFilter.Image")));
            this.tsbDeleteFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteFilter.Name = "tsbDeleteFilter";
            this.tsbDeleteFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteFilter.Text = "Delete";
            this.tsbDeleteFilter.Click += new System.EventHandler(this.deleteFilter);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbUpFilter
            // 
            this.tsbUpFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpFilter.Image")));
            this.tsbUpFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpFilter.Name = "tsbUpFilter";
            this.tsbUpFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbUpFilter.Text = "Up";
            this.tsbUpFilter.Click += new System.EventHandler(this.tsbUpFilter_Click);
            // 
            // tsbDownFilter
            // 
            this.tsbDownFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDownFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbDownFilter.Image")));
            this.tsbDownFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownFilter.Name = "tsbDownFilter";
            this.tsbDownFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbDownFilter.Text = "Down";
            this.tsbDownFilter.Click += new System.EventHandler(this.tsbDownFilter_Click);
            // 
            // gbFilterDetail
            // 
            this.gbFilterDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilterDetail.Controls.Add(this.ckAddToReportTitle);
            this.gbFilterDetail.Controls.Add(this.toolStrip4);
            this.gbFilterDetail.Controls.Add(this.gbFilterQuery);
            this.gbFilterDetail.Controls.Add(this.gbFilterControl);
            this.gbFilterDetail.Controls.Add(this.lbFilterWidth);
            this.gbFilterDetail.Controls.Add(this.txWidth);
            this.gbFilterDetail.Controls.Add(this.cbFilterType);
            this.gbFilterDetail.Controls.Add(this.lbFilterType);
            this.gbFilterDetail.Controls.Add(this.btFilter);
            this.gbFilterDetail.Controls.Add(this.lbFilterLabel);
            this.gbFilterDetail.Controls.Add(this.txFilterLabel);
            this.gbFilterDetail.Controls.Add(this.lbFilterName);
            this.gbFilterDetail.Controls.Add(this.txFilterName);
            this.gbFilterDetail.Location = new System.Drawing.Point(3, 3);
            this.gbFilterDetail.Name = "gbFilterDetail";
            this.gbFilterDetail.Size = new System.Drawing.Size(977, 290);
            this.gbFilterDetail.TabIndex = 0;
            this.gbFilterDetail.TabStop = false;
            this.gbFilterDetail.Text = "Filter\'s Detail";
            // 
            // ckAddToReportTitle
            // 
            this.ckAddToReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAddToReportTitle.Location = new System.Drawing.Point(585, 78);
            this.ckAddToReportTitle.Name = "ckAddToReportTitle";
            this.ckAddToReportTitle.Size = new System.Drawing.Size(380, 17);
            this.ckAddToReportTitle.TabIndex = 49;
            this.ckAddToReportTitle.Text = "Add to Report Title";
            this.ckAddToReportTitle.UseVisualStyleBackColor = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCancelFilter,
            this.toolStripSeparator4,
            this.tsbSaveFilter});
            this.toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(971, 31);
            this.toolStrip4.TabIndex = 48;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsbCancelFilter
            // 
            this.tsbCancelFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelFilter.Image")));
            this.tsbCancelFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelFilter.Name = "tsbCancelFilter";
            this.tsbCancelFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbCancelFilter.Text = "Cancel";
            this.tsbCancelFilter.Click += new System.EventHandler(this.tsbCancelFilter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSaveFilter
            // 
            this.tsbSaveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveFilter.Image")));
            this.tsbSaveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFilter.Name = "tsbSaveFilter";
            this.tsbSaveFilter.Size = new System.Drawing.Size(28, 28);
            this.tsbSaveFilter.Text = "Save";
            this.tsbSaveFilter.Click += new System.EventHandler(this.tsbSaveFilter_Click);
            // 
            // gbFilterQuery
            // 
            this.gbFilterQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilterQuery.Controls.Add(this.cbLinkedField);
            this.gbFilterQuery.Controls.Add(this.lbLinkedEqual);
            this.gbFilterQuery.Controls.Add(this.txLinkedFilterField);
            this.gbFilterQuery.Controls.Add(this.lbLinkedOn);
            this.gbFilterQuery.Controls.Add(this.cbLinkedFilter);
            this.gbFilterQuery.Controls.Add(this.lbLinkedFilter);
            this.gbFilterQuery.Controls.Add(this.ckLinked);
            this.gbFilterQuery.Controls.Add(this.txQueryData);
            this.gbFilterQuery.Controls.Add(this.cbDisplayData);
            this.gbFilterQuery.Controls.Add(this.lbDisplayData);
            this.gbFilterQuery.Controls.Add(this.cbValueData);
            this.gbFilterQuery.Controls.Add(this.lbValueData);
            this.gbFilterQuery.Controls.Add(this.cbTableData);
            this.gbFilterQuery.Controls.Add(this.lbTableData);
            this.gbFilterQuery.Location = new System.Drawing.Point(9, 157);
            this.gbFilterQuery.Name = "gbFilterQuery";
            this.gbFilterQuery.Size = new System.Drawing.Size(962, 127);
            this.gbFilterQuery.TabIndex = 47;
            this.gbFilterQuery.TabStop = false;
            this.gbFilterQuery.Text = "Filter Data";
            // 
            // cbLinkedField
            // 
            this.cbLinkedField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLinkedField.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbLinkedField, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbLinkedField.Location = new System.Drawing.Point(499, 98);
            this.cbLinkedField.Name = "cbLinkedField";
            this.cbLinkedField.Size = new System.Drawing.Size(245, 21);
            this.cbLinkedField.Sorted = true;
            this.cbLinkedField.TabIndex = 58;
            // 
            // lbLinkedEqual
            // 
            this.lbLinkedEqual.AutoSize = true;
            this.lbLinkedEqual.Location = new System.Drawing.Point(750, 101);
            this.lbLinkedEqual.Name = "lbLinkedEqual";
            this.lbLinkedEqual.Size = new System.Drawing.Size(13, 13);
            this.lbLinkedEqual.TabIndex = 57;
            this.lbLinkedEqual.Text = "=";
            // 
            // txLinkedFilterField
            // 
            this.txLinkedFilterField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txLinkedFilterField.BackColor = System.Drawing.Color.White;
            this.txLinkedFilterField.Location = new System.Drawing.Point(769, 98);
            this.txLinkedFilterField.Name = "txLinkedFilterField";
            this.txLinkedFilterField.ReadOnly = true;
            this.txLinkedFilterField.Size = new System.Drawing.Size(187, 20);
            this.txLinkedFilterField.TabIndex = 56;
            this.txLinkedFilterField.TabStop = false;
            // 
            // lbLinkedOn
            // 
            this.lbLinkedOn.AutoSize = true;
            this.lbLinkedOn.Location = new System.Drawing.Point(457, 101);
            this.lbLinkedOn.Name = "lbLinkedOn";
            this.lbLinkedOn.Size = new System.Drawing.Size(21, 13);
            this.lbLinkedOn.TabIndex = 55;
            this.lbLinkedOn.Text = "On";
            // 
            // cbLinkedFilter
            // 
            this.cbLinkedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLinkedFilter.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbLinkedFilter, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbLinkedFilter.Location = new System.Drawing.Point(268, 98);
            this.cbLinkedFilter.Name = "cbLinkedFilter";
            this.cbLinkedFilter.Size = new System.Drawing.Size(183, 21);
            this.cbLinkedFilter.Sorted = true;
            this.cbLinkedFilter.TabIndex = 53;
            this.cbLinkedFilter.SelectedIndexChanged += new System.EventHandler(this.cbLinkedFilter_SelectedIndexChanged);
            // 
            // lbLinkedFilter
            // 
            this.lbLinkedFilter.AutoSize = true;
            this.lbLinkedFilter.Location = new System.Drawing.Point(225, 101);
            this.lbLinkedFilter.Name = "lbLinkedFilter";
            this.lbLinkedFilter.Size = new System.Drawing.Size(29, 13);
            this.lbLinkedFilter.TabIndex = 54;
            this.lbLinkedFilter.Text = "Filter";
            // 
            // ckLinked
            // 
            this.ckLinked.AutoSize = true;
            this.ckLinked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckLinked.Location = new System.Drawing.Point(6, 100);
            this.ckLinked.Name = "ckLinked";
            this.ckLinked.Size = new System.Drawing.Size(141, 17);
            this.ckLinked.TabIndex = 52;
            this.ckLinked.Text = "Is linked to another Filter";
            this.ckLinked.UseVisualStyleBackColor = true;
            this.ckLinked.CheckedChanged += new System.EventHandler(this.ckLinked_CheckedChanged);
            // 
            // txQueryData
            // 
            this.txQueryData.AcceptsReturn = true;
            this.txQueryData.AcceptsTab = true;
            this.txQueryData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txQueryData.Location = new System.Drawing.Point(268, 19);
            this.txQueryData.Multiline = true;
            this.txQueryData.Name = "txQueryData";
            this.txQueryData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txQueryData.Size = new System.Drawing.Size(688, 75);
            this.txQueryData.TabIndex = 10;
            // 
            // cbDisplayData
            // 
            this.cbDisplayData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisplayData.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbDisplayData, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbDisplayData.Location = new System.Drawing.Point(76, 73);
            this.cbDisplayData.Name = "cbDisplayData";
            this.cbDisplayData.Size = new System.Drawing.Size(183, 21);
            this.cbDisplayData.Sorted = true;
            this.cbDisplayData.TabIndex = 9;
            this.cbDisplayData.SelectedIndexChanged += new System.EventHandler(this.cbDisplayData_SelectedIndexChanged);
            // 
            // lbDisplayData
            // 
            this.lbDisplayData.AutoSize = true;
            this.lbDisplayData.Location = new System.Drawing.Point(6, 76);
            this.lbDisplayData.Name = "lbDisplayData";
            this.lbDisplayData.Size = new System.Drawing.Size(41, 13);
            this.lbDisplayData.TabIndex = 51;
            this.lbDisplayData.Text = "Display";
            // 
            // cbValueData
            // 
            this.cbValueData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueData.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbValueData, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbValueData.Location = new System.Drawing.Point(76, 46);
            this.cbValueData.Name = "cbValueData";
            this.cbValueData.Size = new System.Drawing.Size(183, 21);
            this.cbValueData.Sorted = true;
            this.cbValueData.TabIndex = 8;
            this.cbValueData.SelectedIndexChanged += new System.EventHandler(this.cbValueData_SelectedIndexChanged);
            // 
            // lbValueData
            // 
            this.lbValueData.AutoSize = true;
            this.lbValueData.Location = new System.Drawing.Point(6, 49);
            this.lbValueData.Name = "lbValueData";
            this.lbValueData.Size = new System.Drawing.Size(34, 13);
            this.lbValueData.TabIndex = 49;
            this.lbValueData.Text = "Value";
            // 
            // cbTableData
            // 
            this.cbTableData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableData.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbTableData, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbTableData.Location = new System.Drawing.Point(76, 19);
            this.cbTableData.Name = "cbTableData";
            this.cbTableData.Size = new System.Drawing.Size(183, 21);
            this.cbTableData.Sorted = true;
            this.cbTableData.TabIndex = 7;
            this.cbTableData.SelectedIndexChanged += new System.EventHandler(this.cbTableData_SelectedIndexChanged);
            // 
            // lbTableData
            // 
            this.lbTableData.AutoSize = true;
            this.lbTableData.Location = new System.Drawing.Point(6, 22);
            this.lbTableData.Name = "lbTableData";
            this.lbTableData.Size = new System.Drawing.Size(34, 13);
            this.lbTableData.TabIndex = 47;
            this.lbTableData.Text = "Table";
            // 
            // gbFilterControl
            // 
            this.gbFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilterControl.Controls.Add(this.cbControlType);
            this.gbFilterControl.Controls.Add(this.txFilterField);
            this.gbFilterControl.Controls.Add(this.cbFields);
            this.gbFilterControl.Controls.Add(this.lbFilterField);
            this.gbFilterControl.Controls.Add(this.cbTables);
            this.gbFilterControl.Controls.Add(this.lbFilterTable);
            this.gbFilterControl.Location = new System.Drawing.Point(9, 103);
            this.gbFilterControl.Name = "gbFilterControl";
            this.gbFilterControl.Size = new System.Drawing.Size(962, 48);
            this.gbFilterControl.TabIndex = 46;
            this.gbFilterControl.TabStop = false;
            this.gbFilterControl.Text = "Field to Control";
            // 
            // cbControlType
            // 
            this.cbControlType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbControlType.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbControlType, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbControlType.Location = new System.Drawing.Point(856, 19);
            this.cbControlType.Name = "cbControlType";
            this.cbControlType.Size = new System.Drawing.Size(100, 21);
            this.cbControlType.TabIndex = 48;
            // 
            // txFilterField
            // 
            this.txFilterField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFilterField.BackColor = System.Drawing.Color.White;
            this.txFilterField.Location = new System.Drawing.Point(516, 19);
            this.txFilterField.Name = "txFilterField";
            this.txFilterField.Size = new System.Drawing.Size(334, 20);
            this.txFilterField.TabIndex = 6;
            // 
            // cbFields
            // 
            this.cbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFields.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbFields, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbFields.Location = new System.Drawing.Point(327, 19);
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new System.Drawing.Size(183, 21);
            this.cbFields.Sorted = true;
            this.cbFields.TabIndex = 5;
            this.cbFields.SelectedIndexChanged += new System.EventHandler(this.cbFields_SelectedIndexChanged);
            // 
            // lbFilterField
            // 
            this.lbFilterField.AutoSize = true;
            this.lbFilterField.Location = new System.Drawing.Point(265, 22);
            this.lbFilterField.Name = "lbFilterField";
            this.lbFilterField.Size = new System.Drawing.Size(29, 13);
            this.lbFilterField.TabIndex = 47;
            this.lbFilterField.Text = "Field";
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbTables, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbTables.Location = new System.Drawing.Point(76, 19);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(183, 21);
            this.cbTables.Sorted = true;
            this.cbTables.TabIndex = 4;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // lbFilterTable
            // 
            this.lbFilterTable.AutoSize = true;
            this.lbFilterTable.Location = new System.Drawing.Point(6, 22);
            this.lbFilterTable.Name = "lbFilterTable";
            this.lbFilterTable.Size = new System.Drawing.Size(34, 13);
            this.lbFilterTable.TabIndex = 45;
            this.lbFilterTable.Text = "Table";
            // 
            // lbFilterWidth
            // 
            this.lbFilterWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilterWidth.AutoSize = true;
            this.lbFilterWidth.Location = new System.Drawing.Point(582, 53);
            this.lbFilterWidth.Name = "lbFilterWidth";
            this.lbFilterWidth.Size = new System.Drawing.Size(35, 13);
            this.lbFilterWidth.TabIndex = 45;
            this.lbFilterWidth.Text = "Width";
            // 
            // txWidth
            // 
            this.txWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txWidth.BackColor = System.Drawing.Color.White;
            this.txWidth.Location = new System.Drawing.Point(652, 50);
            this.txWidth.Name = "txWidth";
            this.txWidth.Size = new System.Drawing.Size(313, 20);
            this.txWidth.TabIndex = 3;
            // 
            // cbFilterType
            // 
            this.cbFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterType.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbFilterType, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbFilterType.Location = new System.Drawing.Point(320, 50);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.Size = new System.Drawing.Size(256, 21);
            this.cbFilterType.Sorted = true;
            this.cbFilterType.TabIndex = 1;
            this.cbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbFilterType_SelectedIndexChanged);
            // 
            // lbFilterType
            // 
            this.lbFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilterType.AutoSize = true;
            this.lbFilterType.Location = new System.Drawing.Point(258, 53);
            this.lbFilterType.Name = "lbFilterType";
            this.lbFilterType.Size = new System.Drawing.Size(31, 13);
            this.lbFilterType.TabIndex = 43;
            this.lbFilterType.Text = "Type";
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFilter.Location = new System.Drawing.Point(550, 75);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(26, 21);
            this.btFilter.TabIndex = 2;
            this.btFilter.Text = "...";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // lbFilterLabel
            // 
            this.lbFilterLabel.AutoSize = true;
            this.lbFilterLabel.Location = new System.Drawing.Point(6, 79);
            this.lbFilterLabel.Name = "lbFilterLabel";
            this.lbFilterLabel.Size = new System.Drawing.Size(33, 13);
            this.lbFilterLabel.TabIndex = 41;
            this.lbFilterLabel.Text = "Label";
            // 
            // txFilterLabel
            // 
            this.txFilterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFilterLabel.BackColor = System.Drawing.Color.White;
            this.txFilterLabel.Location = new System.Drawing.Point(85, 76);
            this.txFilterLabel.Name = "txFilterLabel";
            this.txFilterLabel.ReadOnly = true;
            this.txFilterLabel.Size = new System.Drawing.Size(459, 20);
            this.txFilterLabel.TabIndex = 39;
            this.txFilterLabel.TabStop = false;
            // 
            // lbFilterName
            // 
            this.lbFilterName.AutoSize = true;
            this.lbFilterName.Location = new System.Drawing.Point(6, 53);
            this.lbFilterName.Name = "lbFilterName";
            this.lbFilterName.Size = new System.Drawing.Size(35, 13);
            this.lbFilterName.TabIndex = 38;
            this.lbFilterName.Text = "Name";
            // 
            // txFilterName
            // 
            this.txFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFilterName.BackColor = System.Drawing.Color.White;
            this.txFilterName.Location = new System.Drawing.Point(85, 50);
            this.txFilterName.Name = "txFilterName";
            this.txFilterName.Size = new System.Drawing.Size(167, 20);
            this.txFilterName.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(995, 442);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Extra Lines";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.gbExtraLines);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.gbExtraLineFields);
            this.splitContainer5.Size = new System.Drawing.Size(995, 442);
            this.splitContainer5.SplitterDistance = 160;
            this.splitContainer5.TabIndex = 1;
            // 
            // gbExtraLines
            // 
            this.gbExtraLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExtraLines.Controls.Add(this.toolStrip5);
            this.gbExtraLines.Controls.Add(this.olvExtraLine);
            this.gbExtraLines.Location = new System.Drawing.Point(6, 3);
            this.gbExtraLines.Name = "gbExtraLines";
            this.gbExtraLines.Size = new System.Drawing.Size(986, 154);
            this.gbExtraLines.TabIndex = 0;
            this.gbExtraLines.TabStop = false;
            this.gbExtraLines.Text = "Extra Lines";
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewLine,
            this.tsbEditLine,
            this.tsbDeleteLine,
            this.toolStripSeparator6,
            this.tsbLineUp,
            this.tsbLineDown});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(980, 31);
            this.toolStrip5.TabIndex = 45;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tsbNewLine
            // 
            this.tsbNewLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewLine.Image")));
            this.tsbNewLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewLine.Name = "tsbNewLine";
            this.tsbNewLine.Size = new System.Drawing.Size(28, 28);
            this.tsbNewLine.Text = "New";
            this.tsbNewLine.Click += new System.EventHandler(this.New_ExtraLine);
            // 
            // tsbEditLine
            // 
            this.tsbEditLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditLine.Image")));
            this.tsbEditLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditLine.Name = "tsbEditLine";
            this.tsbEditLine.Size = new System.Drawing.Size(28, 28);
            this.tsbEditLine.Text = "Edit";
            this.tsbEditLine.Click += new System.EventHandler(this.Edit_ExtraLine);
            // 
            // tsbDeleteLine
            // 
            this.tsbDeleteLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteLine.Image")));
            this.tsbDeleteLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteLine.Name = "tsbDeleteLine";
            this.tsbDeleteLine.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteLine.Text = "Delete";
            this.tsbDeleteLine.Click += new System.EventHandler(this.deleteExtraLine);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLineUp
            // 
            this.tsbLineUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLineUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbLineUp.Image")));
            this.tsbLineUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLineUp.Name = "tsbLineUp";
            this.tsbLineUp.Size = new System.Drawing.Size(28, 28);
            this.tsbLineUp.Text = "Up";
            this.tsbLineUp.Click += new System.EventHandler(this.tsbUpExtraLine_Click);
            // 
            // tsbLineDown
            // 
            this.tsbLineDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLineDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbLineDown.Image")));
            this.tsbLineDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLineDown.Name = "tsbLineDown";
            this.tsbLineDown.Size = new System.Drawing.Size(28, 28);
            this.tsbLineDown.Text = "Down";
            this.tsbLineDown.Click += new System.EventHandler(this.tsbDownExtraLine_Click);
            // 
            // olvExtraLine
            // 
            this.olvExtraLine.AllColumns.Add(this.colLineName);
            this.olvExtraLine.AllColumns.Add(this.colLineLabel);
            this.olvExtraLine.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvExtraLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvExtraLine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLineName,
            this.colLineLabel});
            this.olvExtraLine.FullRowSelect = true;
            this.olvExtraLine.GridLines = true;
            this.olvExtraLine.Location = new System.Drawing.Point(6, 50);
            this.olvExtraLine.MultiSelect = false;
            this.olvExtraLine.Name = "olvExtraLine";
            this.olvExtraLine.ShowCommandMenuOnRightClick = true;
            this.olvExtraLine.ShowGroups = false;
            this.olvExtraLine.Size = new System.Drawing.Size(974, 98);
            this.olvExtraLine.SmallImageList = this.imageList1;
            this.olvExtraLine.TabIndex = 5;
            this.olvExtraLine.TileSize = new System.Drawing.Size(168, 25);
            this.olvExtraLine.UseAlternatingBackColors = true;
            this.olvExtraLine.UseCompatibleStateImageBehavior = false;
            this.olvExtraLine.View = System.Windows.Forms.View.Details;
            this.olvExtraLine.SelectedIndexChanged += new System.EventHandler(this.olvExtraLine_SelectedIndexChanged);
            this.olvExtraLine.DoubleClick += new System.EventHandler(this.Edit_ExtraLine);
            // 
            // colLineName
            // 
            this.colLineName.AspectName = "NAME";
            this.colLineName.CellPadding = null;
            this.colLineName.MinimumWidth = 0;
            this.colLineName.Text = "Name";
            this.colLineName.Width = 300;
            // 
            // colLineLabel
            // 
            this.colLineLabel.AspectName = "LABEL";
            this.colLineLabel.CellPadding = null;
            this.colLineLabel.FillsFreeSpace = true;
            this.colLineLabel.Text = "Label";
            this.colLineLabel.Width = 237;
            // 
            // gbExtraLineFields
            // 
            this.gbExtraLineFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExtraLineFields.Controls.Add(this.txFieldFormat);
            this.gbExtraLineFields.Controls.Add(this.btLineLabel);
            this.gbExtraLineFields.Controls.Add(this.cbFieldFunction);
            this.gbExtraLineFields.Controls.Add(this.txLineLabel);
            this.gbExtraLineFields.Controls.Add(this.lbLineLabel);
            this.gbExtraLineFields.Controls.Add(this.toolStrip6);
            this.gbExtraLineFields.Controls.Add(this.lbFieldFormat);
            this.gbExtraLineFields.Controls.Add(this.lbLineName);
            this.gbExtraLineFields.Controls.Add(this.lbFieldFunction);
            this.gbExtraLineFields.Controls.Add(this.txLineName);
            this.gbExtraLineFields.Controls.Add(this.olvLineFields);
            this.gbExtraLineFields.Location = new System.Drawing.Point(4, 8);
            this.gbExtraLineFields.Name = "gbExtraLineFields";
            this.gbExtraLineFields.Size = new System.Drawing.Size(986, 262);
            this.gbExtraLineFields.TabIndex = 1;
            this.gbExtraLineFields.TabStop = false;
            this.gbExtraLineFields.Text = "Extra Lines Fields";
            // 
            // txFieldFormat
            // 
            this.txFieldFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFieldFormat.BackColor = System.Drawing.Color.White;
            this.txFieldFormat.Location = new System.Drawing.Point(349, 236);
            this.txFieldFormat.Name = "txFieldFormat";
            this.txFieldFormat.Size = new System.Drawing.Size(631, 20);
            this.txFieldFormat.TabIndex = 47;
            this.txFieldFormat.TabStop = false;
            this.txFieldFormat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateLineField);
            // 
            // btLineLabel
            // 
            this.btLineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLineLabel.Location = new System.Drawing.Point(954, 49);
            this.btLineLabel.Name = "btLineLabel";
            this.btLineLabel.Size = new System.Drawing.Size(26, 21);
            this.btLineLabel.TabIndex = 35;
            this.btLineLabel.Text = "...";
            this.btLineLabel.UseVisualStyleBackColor = true;
            this.btLineLabel.Click += new System.EventHandler(this.btLineLabel_Click);
            // 
            // cbFieldFunction
            // 
            this.cbFieldFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFieldFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFieldFunction.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbFieldFunction, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbFieldFunction.Location = new System.Drawing.Point(87, 236);
            this.cbFieldFunction.Name = "cbFieldFunction";
            this.cbFieldFunction.Size = new System.Drawing.Size(196, 21);
            this.cbFieldFunction.TabIndex = 46;
            this.cbFieldFunction.SelectedIndexChanged += new System.EventHandler(this.cbFieldFunction_SelectedIndexChanged);
            // 
            // txLineLabel
            // 
            this.txLineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txLineLabel.BackColor = System.Drawing.Color.White;
            this.txLineLabel.Location = new System.Drawing.Point(349, 50);
            this.txLineLabel.Name = "txLineLabel";
            this.txLineLabel.ReadOnly = true;
            this.txLineLabel.Size = new System.Drawing.Size(599, 20);
            this.txLineLabel.TabIndex = 34;
            this.txLineLabel.TabStop = false;
            // 
            // lbLineLabel
            // 
            this.lbLineLabel.AutoSize = true;
            this.lbLineLabel.Location = new System.Drawing.Point(289, 53);
            this.lbLineLabel.Name = "lbLineLabel";
            this.lbLineLabel.Size = new System.Drawing.Size(33, 13);
            this.lbLineLabel.TabIndex = 36;
            this.lbLineLabel.Text = "Label";
            // 
            // toolStrip6
            // 
            this.toolStrip6.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCancelLine,
            this.tsbSaveLine,
            this.toolStripSeparator7,
            this.tsbLineFieldUp,
            this.tsbLineFieldDown});
            this.toolStrip6.Location = new System.Drawing.Point(3, 16);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(980, 31);
            this.toolStrip6.TabIndex = 45;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // tsbCancelLine
            // 
            this.tsbCancelLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelLine.Image")));
            this.tsbCancelLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelLine.Name = "tsbCancelLine";
            this.tsbCancelLine.Size = new System.Drawing.Size(28, 28);
            this.tsbCancelLine.Text = "Cancel";
            this.tsbCancelLine.Click += new System.EventHandler(this.tsbCancelLine_Click);
            // 
            // tsbSaveLine
            // 
            this.tsbSaveLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveLine.Image")));
            this.tsbSaveLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveLine.Name = "tsbSaveLine";
            this.tsbSaveLine.Size = new System.Drawing.Size(28, 28);
            this.tsbSaveLine.Text = "Save";
            this.tsbSaveLine.Click += new System.EventHandler(this.tsbSaveExtraLine_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLineFieldUp
            // 
            this.tsbLineFieldUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLineFieldUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbLineFieldUp.Image")));
            this.tsbLineFieldUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLineFieldUp.Name = "tsbLineFieldUp";
            this.tsbLineFieldUp.Size = new System.Drawing.Size(28, 28);
            this.tsbLineFieldUp.Text = "Up";
            // 
            // tsbLineFieldDown
            // 
            this.tsbLineFieldDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLineFieldDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbLineFieldDown.Image")));
            this.tsbLineFieldDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLineFieldDown.Name = "tsbLineFieldDown";
            this.tsbLineFieldDown.Size = new System.Drawing.Size(28, 28);
            this.tsbLineFieldDown.Text = "Down";
            // 
            // lbFieldFormat
            // 
            this.lbFieldFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFieldFormat.AutoSize = true;
            this.lbFieldFormat.Location = new System.Drawing.Point(289, 239);
            this.lbFieldFormat.Name = "lbFieldFormat";
            this.lbFieldFormat.Size = new System.Drawing.Size(39, 13);
            this.lbFieldFormat.TabIndex = 36;
            this.lbFieldFormat.Text = "Format";
            // 
            // lbLineName
            // 
            this.lbLineName.AutoSize = true;
            this.lbLineName.Location = new System.Drawing.Point(5, 53);
            this.lbLineName.Name = "lbLineName";
            this.lbLineName.Size = new System.Drawing.Size(35, 13);
            this.lbLineName.TabIndex = 33;
            this.lbLineName.Text = "Name";
            // 
            // lbFieldFunction
            // 
            this.lbFieldFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFieldFunction.AutoSize = true;
            this.lbFieldFunction.Location = new System.Drawing.Point(3, 239);
            this.lbFieldFunction.Name = "lbFieldFunction";
            this.lbFieldFunction.Size = new System.Drawing.Size(48, 13);
            this.lbFieldFunction.TabIndex = 33;
            this.lbFieldFunction.Text = "Function";
            // 
            // txLineName
            // 
            this.txLineName.BackColor = System.Drawing.Color.White;
            this.txLineName.Location = new System.Drawing.Point(46, 50);
            this.txLineName.Name = "txLineName";
            this.txLineName.Size = new System.Drawing.Size(237, 20);
            this.txLineName.TabIndex = 32;
            this.txLineName.TabStop = false;
            // 
            // olvLineFields
            // 
            this.olvLineFields.AllColumns.Add(this.colFieldColumn);
            this.olvLineFields.AllColumns.Add(this.colFieldFunction);
            this.olvLineFields.AllColumns.Add(this.colFieldFormat);
            this.olvLineFields.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvLineFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvLineFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFieldColumn,
            this.colFieldFunction,
            this.colFieldFormat});
            this.olvLineFields.FullRowSelect = true;
            this.olvLineFields.GridLines = true;
            this.olvLineFields.Location = new System.Drawing.Point(6, 76);
            this.olvLineFields.MultiSelect = false;
            this.olvLineFields.Name = "olvLineFields";
            this.olvLineFields.ShowCommandMenuOnRightClick = true;
            this.olvLineFields.ShowGroups = false;
            this.olvLineFields.Size = new System.Drawing.Size(974, 154);
            this.olvLineFields.SmallImageList = this.imageList1;
            this.olvLineFields.TabIndex = 5;
            this.olvLineFields.TileSize = new System.Drawing.Size(168, 25);
            this.olvLineFields.UseAlternatingBackColors = true;
            this.olvLineFields.UseCompatibleStateImageBehavior = false;
            this.olvLineFields.View = System.Windows.Forms.View.Details;
            this.olvLineFields.SelectedIndexChanged += new System.EventHandler(this.olvLineField_SelectedIndexChanged);
            // 
            // colFieldColumn
            // 
            this.colFieldColumn.AspectName = "POSITION";
            this.colFieldColumn.CellPadding = null;
            this.colFieldColumn.MinimumWidth = 0;
            this.colFieldColumn.Text = "Column";
            this.colFieldColumn.Width = 80;
            // 
            // colFieldFunction
            // 
            this.colFieldFunction.AspectName = "";
            this.colFieldFunction.CellPadding = null;
            this.colFieldFunction.Text = "Function";
            this.colFieldFunction.Width = 201;
            // 
            // colFieldFormat
            // 
            this.colFieldFormat.AspectName = "FORMAT";
            this.colFieldFormat.CellPadding = null;
            this.colFieldFormat.FillsFreeSpace = true;
            this.colFieldFormat.Text = "Format";
            this.colFieldFormat.Width = 150;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(995, 442);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Preview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.reportControl1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gbQuery);
            this.splitContainer4.Size = new System.Drawing.Size(989, 436);
            this.splitContainer4.SplitterDistance = 327;
            this.splitContainer4.TabIndex = 1;
            // 
            // reportControl1
            // 
            this.reportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportControl1.IsForDesign = true;
            this.reportControl1.Location = new System.Drawing.Point(0, 0);
            this.reportControl1.Name = "reportControl1";
            this.reportControl1.ReportId = ((long)(0));
            this.reportControl1.Size = new System.Drawing.Size(989, 327);
            this.reportControl1.TabIndex = 0;
            this.reportControl1.QueryChanged += new SynapseReport.UserControls.QueryEventHandler(this.reportControl1_QueryChanged);
            // 
            // gbQuery
            // 
            this.gbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuery.Controls.Add(this.txQuery);
            this.gbQuery.Location = new System.Drawing.Point(0, 0);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(989, 105);
            this.gbQuery.TabIndex = 1012;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Query";
            // 
            // txQuery
            // 
            this.txQuery.AcceptsReturn = true;
            this.txQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txQuery.Location = new System.Drawing.Point(6, 19);
            this.txQuery.MaxLength = 500;
            this.txQuery.Multiline = true;
            this.txQuery.Name = "txQuery";
            this.txQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txQuery.Size = new System.Drawing.Size(977, 80);
            this.txQuery.TabIndex = 1010;
            this.txQuery.WordWrap = false;
            // 
            // ckAvailable
            // 
            this.ckAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAvailable.AutoSize = true;
            this.ckAvailable.Location = new System.Drawing.Point(940, 19);
            this.ckAvailable.Name = "ckAvailable";
            this.ckAvailable.Size = new System.Drawing.Size(69, 17);
            this.ckAvailable.TabIndex = 28;
            this.ckAvailable.Text = "Available";
            this.ckAvailable.UseVisualStyleBackColor = true;
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbCategory, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbCategory.Location = new System.Drawing.Point(746, 17);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(164, 21);
            this.cbCategory.TabIndex = 12;
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(665, 20);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 13;
            this.lbCategory.Text = "Category";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator2,
            this.tsbSave,
            this.toolStripSeparator5,
            this.tsbChangeTags});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1039, 31);
            this.toolStrip2.TabIndex = 28;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(28, 28);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(28, 28);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.saveReport);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbChangeTags
            // 
            this.tsbChangeTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbChangeTags.Image = ((System.Drawing.Image)(resources.GetObject("tsbChangeTags.Image")));
            this.tsbChangeTags.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChangeTags.Name = "tsbChangeTags";
            this.tsbChangeTags.Size = new System.Drawing.Size(28, 28);
            this.tsbChangeTags.Text = "Change Tags Value";
            this.tsbChangeTags.Click += new System.EventHandler(this.tsbChangeTags_Click);
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // frmReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 590);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.gbReportDefinition);
            this.ModuleID = 2;
            this.Name = "frmReportDetail";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReportDetail";
            this.UpdateControls = true;
            this.gbReportDefinition.ResumeLayout(false);
            this.gbReportDefinition.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTable)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.bgSelect.ResumeLayout(false);
            this.bgSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvSelectedFields)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbGroup.ResumeLayout(false);
            this.gbGroup.PerformLayout();
            this.gbWhere.ResumeLayout(false);
            this.gbWhere.PerformLayout();
            this.gbFrom.ResumeLayout(false);
            this.gbFrom.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFilters)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.gbFilterDetail.ResumeLayout(false);
            this.gbFilterDetail.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.gbFilterQuery.ResumeLayout(false);
            this.gbFilterQuery.PerformLayout();
            this.gbFilterControl.ResumeLayout(false);
            this.gbFilterControl.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.gbExtraLines.ResumeLayout(false);
            this.gbExtraLines.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvExtraLine)).EndInit();
            this.gbExtraLineFields.ResumeLayout(false);
            this.gbExtraLineFields.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvLineFields)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReportDefinition;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox ckAvailable;
        private System.Windows.Forms.TextBox txReport;
        private System.Windows.Forms.Button btReportName;
        private System.Windows.Forms.Label lbReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private SynapseAdvancedControls.TreeListView treeTable;
        private SynapseAdvancedControls.OLVColumn colName;
        private System.Windows.Forms.ImageList imageList1;
        private SynapseAdvancedControls.ObjectListView olvTables;
        private SynapseAdvancedControls.OLVColumn colTable;
        private SynapseAdvancedControls.ObjectListView olvFields;
        private SynapseAdvancedControls.OLVColumn colField;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbFrom;
        private System.Windows.Forms.TextBox txFrom;
        private System.Windows.Forms.GroupBox gbGroup;
        private System.Windows.Forms.TextBox txGroup;
        private System.Windows.Forms.GroupBox gbWhere;
        private System.Windows.Forms.TextBox txWhere;
        private System.Windows.Forms.GroupBox bgSelect;
        private SynapseAdvancedControls.ObjectListView olvSelectedFields;
        private SynapseAdvancedControls.OLVColumn olvCol1;
        private SynapseAdvancedControls.OLVColumn olvCol2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Button btAlias;
        private System.Windows.Forms.Label lblFielAlias;
        private System.Windows.Forms.TextBox txAlias;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.TextBox txFieldName;
        private System.Windows.Forms.Label lbAvailableFields;
        private System.Windows.Forms.Label lbSelectedTables;
        private System.Windows.Forms.Label lbAvailableTables;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
        private System.Windows.Forms.GroupBox gbFilter;
        private SynapseAdvancedControls.ObjectListView olvFilters;
        private SynapseAdvancedControls.OLVColumn colFilterName;
        private SynapseAdvancedControls.OLVColumn colFilterLabel;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbAddFilter;
        private System.Windows.Forms.ToolStripButton tsbEditFilter;
        private System.Windows.Forms.ToolStripButton tsbDeleteFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbUpFilter;
        private System.Windows.Forms.ToolStripButton tsbDownFilter;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private SynapseAdvancedControls.OLVColumn colFilterType;
        private SynapseAdvancedControls.OLVColumn colFilterField;
        private SynapseAdvancedControls.OLVColumn colFilterWidth;
        private System.Windows.Forms.GroupBox gbFilterDetail;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.Label lbFilterLabel;
        private System.Windows.Forms.TextBox txFilterLabel;
        private System.Windows.Forms.Label lbFilterName;
        private System.Windows.Forms.TextBox txFilterName;
        private System.Windows.Forms.Label lbFilterWidth;
        private System.Windows.Forms.TextBox txWidth;
        private System.Windows.Forms.ComboBox cbFilterType;
        private System.Windows.Forms.Label lbFilterType;
        private System.Windows.Forms.GroupBox gbFilterQuery;
        private System.Windows.Forms.GroupBox gbFilterControl;
        private System.Windows.Forms.TextBox txFilterField;
        private System.Windows.Forms.ComboBox cbFields;
        private System.Windows.Forms.Label lbFilterField;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Label lbFilterTable;
        private System.Windows.Forms.TextBox txQueryData;
        private System.Windows.Forms.ComboBox cbDisplayData;
        private System.Windows.Forms.Label lbDisplayData;
        private System.Windows.Forms.ComboBox cbValueData;
        private System.Windows.Forms.Label lbValueData;
        private System.Windows.Forms.ComboBox cbTableData;
        private System.Windows.Forms.Label lbTableData;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbCancelFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSaveFilter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        internal System.Windows.Forms.GroupBox gbQuery;
        public System.Windows.Forms.TextBox txQuery;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.TextBox txFormat;
        private SynapseAdvancedControls.OLVColumn olvCol3;
        private System.Windows.Forms.Label lbFieldWidth;
        private System.Windows.Forms.TextBox txFieldWidth;
        private SynapseAdvancedControls.OLVColumn olvCol4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox cbLinkedFilter;
        private System.Windows.Forms.Label lbLinkedFilter;
        private System.Windows.Forms.CheckBox ckLinked;
        private System.Windows.Forms.ComboBox cbLinkedField;
        private System.Windows.Forms.Label lbLinkedEqual;
        private System.Windows.Forms.TextBox txLinkedFilterField;
        private System.Windows.Forms.Label lbLinkedOn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbChangeTags;
        private System.Windows.Forms.ComboBox cbControlType;
        private System.Windows.Forms.CheckBox ckAddCategory;
        private System.Windows.Forms.CheckBox ckAddToReportTitle;
        private System.Windows.Forms.ComboBox cbSorting;
        private System.Windows.Forms.Label lbSorting;
        private SynapseAdvancedControls.OLVColumn olvCol5;
        private SynapseCore.Controls.SynapseTextBox txSortingOrder;
        private System.Windows.Forms.Label lbSortingOrder;
        private SynapseAdvancedControls.OLVColumn olvCol6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox gbExtraLines;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tsbNewLine;
        private System.Windows.Forms.ToolStripButton tsbEditLine;
        private System.Windows.Forms.ToolStripButton tsbDeleteLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbLineUp;
        private System.Windows.Forms.ToolStripButton tsbLineDown;
        private System.Windows.Forms.Button btLineLabel;
        private System.Windows.Forms.Label lbLineLabel;
        private System.Windows.Forms.TextBox txLineLabel;
        private System.Windows.Forms.Label lbLineName;
        private System.Windows.Forms.TextBox txLineName;
        private SynapseAdvancedControls.ObjectListView olvExtraLine;
        private SynapseAdvancedControls.OLVColumn colLineName;
        private SynapseAdvancedControls.OLVColumn colLineLabel;
        private System.Windows.Forms.GroupBox gbExtraLineFields;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tsbLineFieldUp;
        private System.Windows.Forms.ToolStripButton tsbLineFieldDown;
        private System.Windows.Forms.Label lbFieldFormat;
        private System.Windows.Forms.Label lbFieldFunction;
        private SynapseAdvancedControls.ObjectListView olvLineFields;
        private SynapseAdvancedControls.OLVColumn colFieldColumn;
        private SynapseAdvancedControls.OLVColumn colFieldFunction;
        private SynapseAdvancedControls.OLVColumn colFieldFormat;
        private System.Windows.Forms.ComboBox cbFieldFunction;
        private System.Windows.Forms.TextBox txFieldFormat;
        private System.Windows.Forms.ToolStripButton tsbSaveLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbCancelLine;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btColor;
        private SynapseAdvancedControls.OLVColumn olvCol7;
        private UserControls.reportControl reportControl1;
    }
}