namespace Module_Gaziview
{
    partial class frm_GasEmissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GasEmissions));
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle4 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle5 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle6 = new SynapseAdvancedControls.HeaderStateStyle();
            this.gb_Filter = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new CustomControls.MonthCalendar();
            this.btn_Graph = new System.Windows.Forms.Button();
            this.il_buttons = new System.Windows.Forms.ImageList(this.components);
            this.btn_Report = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_LastData = new System.Windows.Forms.Button();
            this.btn_NextWeek = new System.Windows.Forms.Button();
            this.btn_PreviousWeek = new System.Windows.Forms.Button();
            this.cb_Chain = new System.Windows.Forms.ComboBox();
            this.lb_Chain = new System.Windows.Forms.Label();
            this.cb_Unit = new System.Windows.Forms.ComboBox();
            this.lb_Unit = new System.Windows.Forms.Label();
            this.gb_Data = new System.Windows.Forms.GroupBox();
            this.lb_SumEmissionsUnit = new System.Windows.Forms.Label();
            this.lb_SumVolumeUnit = new System.Windows.Forms.Label();
            this.txt_EmissionDecl = new System.Windows.Forms.TextBox();
            this.txt_SumVolume = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.olv_Data = new SynapseAdvancedControls.ObjectListView();
            this.col_Dirty = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Day = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Date = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_GazDischarge = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_GazVolume = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_BackgroundNoise = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_BackNoiseDischarge = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_NetDischarge = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Decision = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_MinDischargeDecl = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_DischargeDecl = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_OtherChainHS = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_MinDecl = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Approved = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col_Remarque = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctx_Grip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.voirLesDétailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerFormatStyle1 = new SynapseAdvancedControls.HeaderFormatStyle();
            this.il_states = new System.Windows.Forms.ImageList(this.components);
            this.zg_Graph = new ZedGraph.ZedGraphControl();
            this.gb_Filter.SuspendLayout();
            this.gb_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv_Data)).BeginInit();
            this.ctx_Grip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Filter
            // 
            this.gb_Filter.Controls.Add(this.monthCalendar1);
            this.gb_Filter.Controls.Add(this.btn_Graph);
            this.gb_Filter.Controls.Add(this.btn_Report);
            this.gb_Filter.Controls.Add(this.btn_Save);
            this.gb_Filter.Controls.Add(this.label3);
            this.gb_Filter.Controls.Add(this.progressBar1);
            this.gb_Filter.Controls.Add(this.btn_LastData);
            this.gb_Filter.Controls.Add(this.btn_NextWeek);
            this.gb_Filter.Controls.Add(this.btn_PreviousWeek);
            this.gb_Filter.Controls.Add(this.cb_Chain);
            this.gb_Filter.Controls.Add(this.lb_Chain);
            this.gb_Filter.Controls.Add(this.cb_Unit);
            this.gb_Filter.Controls.Add(this.lb_Unit);
            this.gb_Filter.Location = new System.Drawing.Point(12, 12);
            this.gb_Filter.Name = "gb_Filter";
            this.gb_Filter.Size = new System.Drawing.Size(648, 195);
            this.gb_Filter.TabIndex = 1;
            this.gb_Filter.TabStop = false;
            this.gb_Filter.Text = "Filtres";
            this.gb_Filter.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.ColorTable.DayActiveGradientBegin = System.Drawing.Color.Bisque;
            this.monthCalendar1.ColorTable.DayActiveGradientEnd = System.Drawing.Color.Gold;
            this.monthCalendar1.ColorTable.DayHeaderText = System.Drawing.Color.MediumBlue;
            this.monthCalendar1.ColorTable.DayTextBold = System.Drawing.Color.DarkBlue;
            this.monthCalendar1.ColorTable.FooterActiveGradientBegin = System.Drawing.Color.Transparent;
            this.monthCalendar1.ColorTable.FooterActiveGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.monthCalendar1.ColorTable.FooterActiveText = System.Drawing.Color.DarkRed;
            this.monthCalendar1.ColorTable.HeaderActiveArrow = System.Drawing.Color.MidnightBlue;
            this.monthCalendar1.ColorTable.HeaderActiveGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.monthCalendar1.ColorTable.HeaderGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(177)))), ((int)(((byte)(255)))));
            this.monthCalendar1.Culture = new System.Globalization.CultureInfo("fr-BE");
            this.monthCalendar1.Location = new System.Drawing.Point(12, 28);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekHeader = false;
            this.monthCalendar1.TabIndex = 13;
            this.monthCalendar1.DateSelected += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.monthCalendar1_newDateChanged);
            this.monthCalendar1.DateChanged += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.monthCalendar1_newDateChanged);
            // 
            // btn_Graph
            // 
            this.btn_Graph.ImageKey = "Graph.png";
            this.btn_Graph.ImageList = this.il_buttons;
            this.btn_Graph.Location = new System.Drawing.Point(483, 112);
            this.btn_Graph.Name = "btn_Graph";
            this.btn_Graph.Size = new System.Drawing.Size(131, 28);
            this.btn_Graph.TabIndex = 12;
            this.btn_Graph.Text = "Graph";
            this.btn_Graph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Graph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Graph.UseVisualStyleBackColor = true;
            this.btn_Graph.Click += new System.EventHandler(this.btn_Graph_Click);
            // 
            // il_buttons
            // 
            this.il_buttons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_buttons.ImageStream")));
            this.il_buttons.TransparentColor = System.Drawing.Color.Transparent;
            this.il_buttons.Images.SetKeyName(0, "calendar.png");
            this.il_buttons.Images.SetKeyName(1, "next.png");
            this.il_buttons.Images.SetKeyName(2, "previous.png");
            this.il_buttons.Images.SetKeyName(3, "Graph.png");
            this.il_buttons.Images.SetKeyName(4, "notebook_edit.png");
            // 
            // btn_Report
            // 
            this.btn_Report.ImageKey = "notebook_edit.png";
            this.btn_Report.ImageList = this.il_buttons;
            this.btn_Report.Location = new System.Drawing.Point(483, 81);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(131, 28);
            this.btn_Report.TabIndex = 11;
            this.btn_Report.Text = "Report";
            this.btn_Report.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Report.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::Module_Gaziview.Properties.Resources.Save;
            this.btn_Save.Location = new System.Drawing.Point(483, 143);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(131, 37);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Sauver";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "% Semaine complété";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(483, 32);
            this.progressBar1.Maximum = 70;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(131, 17);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // btn_LastData
            // 
            this.btn_LastData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LastData.ImageKey = "calendar.png";
            this.btn_LastData.ImageList = this.il_buttons;
            this.btn_LastData.Location = new System.Drawing.Point(233, 152);
            this.btn_LastData.Name = "btn_LastData";
            this.btn_LastData.Size = new System.Drawing.Size(209, 28);
            this.btn_LastData.TabIndex = 7;
            this.btn_LastData.Text = "Dernière date encodée";
            this.btn_LastData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_LastData.UseVisualStyleBackColor = true;
            this.btn_LastData.Click += new System.EventHandler(this.btn_LastData_Click);
            // 
            // btn_NextWeek
            // 
            this.btn_NextWeek.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NextWeek.ImageKey = "next.png";
            this.btn_NextWeek.ImageList = this.il_buttons;
            this.btn_NextWeek.Location = new System.Drawing.Point(233, 123);
            this.btn_NextWeek.Name = "btn_NextWeek";
            this.btn_NextWeek.Size = new System.Drawing.Size(209, 28);
            this.btn_NextWeek.TabIndex = 6;
            this.btn_NextWeek.Text = "Semaine suivante";
            this.btn_NextWeek.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_NextWeek.UseVisualStyleBackColor = true;
            this.btn_NextWeek.Click += new System.EventHandler(this.btn_NextWeek_Click);
            // 
            // btn_PreviousWeek
            // 
            this.btn_PreviousWeek.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PreviousWeek.ImageKey = "previous.png";
            this.btn_PreviousWeek.ImageList = this.il_buttons;
            this.btn_PreviousWeek.Location = new System.Drawing.Point(233, 94);
            this.btn_PreviousWeek.Name = "btn_PreviousWeek";
            this.btn_PreviousWeek.Size = new System.Drawing.Size(209, 28);
            this.btn_PreviousWeek.TabIndex = 5;
            this.btn_PreviousWeek.Text = "Semaine précédente";
            this.btn_PreviousWeek.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PreviousWeek.UseVisualStyleBackColor = true;
            this.btn_PreviousWeek.Click += new System.EventHandler(this.btn_PreviousWeek_Click);
            // 
            // cb_Chain
            // 
            this.cb_Chain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Chain.FormattingEnabled = true;
            this.cb_Chain.Location = new System.Drawing.Point(300, 57);
            this.cb_Chain.Name = "cb_Chain";
            this.cb_Chain.Size = new System.Drawing.Size(142, 24);
            this.cb_Chain.TabIndex = 3;
            this.cb_Chain.SelectedIndexChanged += new System.EventHandler(this.cb_Chain_SelectedIndexChanged);
            // 
            // lb_Chain
            // 
            this.lb_Chain.AutoSize = true;
            this.lb_Chain.Location = new System.Drawing.Point(230, 60);
            this.lb_Chain.Name = "lb_Chain";
            this.lb_Chain.Size = new System.Drawing.Size(40, 13);
            this.lb_Chain.TabIndex = 2;
            this.lb_Chain.Text = "Chaine";
            // 
            // cb_Unit
            // 
            this.cb_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Unit.FormattingEnabled = true;
            this.cb_Unit.Location = new System.Drawing.Point(300, 25);
            this.cb_Unit.Name = "cb_Unit";
            this.cb_Unit.Size = new System.Drawing.Size(142, 24);
            this.cb_Unit.TabIndex = 1;
            this.cb_Unit.SelectedIndexChanged += new System.EventHandler(this.cb_Unit_SelectedIndexChanged);
            // 
            // lb_Unit
            // 
            this.lb_Unit.AutoSize = true;
            this.lb_Unit.Location = new System.Drawing.Point(230, 28);
            this.lb_Unit.Name = "lb_Unit";
            this.lb_Unit.Size = new System.Drawing.Size(47, 13);
            this.lb_Unit.TabIndex = 0;
            this.lb_Unit.Text = "Tranche";
            // 
            // gb_Data
            // 
            this.gb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Data.Controls.Add(this.lb_SumEmissionsUnit);
            this.gb_Data.Controls.Add(this.lb_SumVolumeUnit);
            this.gb_Data.Controls.Add(this.txt_EmissionDecl);
            this.gb_Data.Controls.Add(this.txt_SumVolume);
            this.gb_Data.Controls.Add(this.label2);
            this.gb_Data.Controls.Add(this.olv_Data);
            this.gb_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Data.Location = new System.Drawing.Point(12, 213);
            this.gb_Data.Name = "gb_Data";
            this.gb_Data.Size = new System.Drawing.Size(1190, 347);
            this.gb_Data.TabIndex = 2;
            this.gb_Data.TabStop = false;
            this.gb_Data.Text = "Données";
            // 
            // lb_SumEmissionsUnit
            // 
            this.lb_SumEmissionsUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_SumEmissionsUnit.AutoSize = true;
            this.lb_SumEmissionsUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SumEmissionsUnit.Location = new System.Drawing.Point(979, 305);
            this.lb_SumEmissionsUnit.Name = "lb_SumEmissionsUnit";
            this.lb_SumEmissionsUnit.Size = new System.Drawing.Size(64, 29);
            this.lb_SumEmissionsUnit.TabIndex = 6;
            this.lb_SumEmissionsUnit.Text = "GBq";
            // 
            // lb_SumVolumeUnit
            // 
            this.lb_SumVolumeUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_SumVolumeUnit.AutoSize = true;
            this.lb_SumVolumeUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SumVolumeUnit.Location = new System.Drawing.Point(428, 305);
            this.lb_SumVolumeUnit.Name = "lb_SumVolumeUnit";
            this.lb_SumVolumeUnit.Size = new System.Drawing.Size(42, 29);
            this.lb_SumVolumeUnit.TabIndex = 5;
            this.lb_SumVolumeUnit.Text = "m³";
            // 
            // txt_EmissionDecl
            // 
            this.txt_EmissionDecl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_EmissionDecl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_EmissionDecl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmissionDecl.Location = new System.Drawing.Point(873, 302);
            this.txt_EmissionDecl.Multiline = true;
            this.txt_EmissionDecl.Name = "txt_EmissionDecl";
            this.txt_EmissionDecl.ReadOnly = true;
            this.txt_EmissionDecl.Size = new System.Drawing.Size(100, 32);
            this.txt_EmissionDecl.TabIndex = 4;
            this.txt_EmissionDecl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_SumVolume
            // 
            this.txt_SumVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_SumVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SumVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SumVolume.Location = new System.Drawing.Point(322, 302);
            this.txt_SumVolume.Multiline = true;
            this.txt_SumVolume.Name = "txt_SumVolume";
            this.txt_SumVolume.ReadOnly = true;
            this.txt_SumVolume.Size = new System.Drawing.Size(100, 32);
            this.txt_SumVolume.TabIndex = 3;
            this.txt_SumVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Totaux";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // olv_Data
            // 
            this.olv_Data.AllColumns.Add(this.col_Dirty);
            this.olv_Data.AllColumns.Add(this.col_Day);
            this.olv_Data.AllColumns.Add(this.col_Date);
            this.olv_Data.AllColumns.Add(this.col_GazDischarge);
            this.olv_Data.AllColumns.Add(this.col_GazVolume);
            this.olv_Data.AllColumns.Add(this.col_BackgroundNoise);
            this.olv_Data.AllColumns.Add(this.col_BackNoiseDischarge);
            this.olv_Data.AllColumns.Add(this.col_NetDischarge);
            this.olv_Data.AllColumns.Add(this.col_Decision);
            this.olv_Data.AllColumns.Add(this.col_MinDischargeDecl);
            this.olv_Data.AllColumns.Add(this.col_DischargeDecl);
            this.olv_Data.AllColumns.Add(this.col_OtherChainHS);
            this.olv_Data.AllColumns.Add(this.col_MinDecl);
            this.olv_Data.AllColumns.Add(this.col_Approved);
            this.olv_Data.AllColumns.Add(this.col_Remarque);
            this.olv_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv_Data.CellEditActivation = SynapseAdvancedControls.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olv_Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Dirty,
            this.col_Day,
            this.col_Date,
            this.col_GazDischarge,
            this.col_GazVolume,
            this.col_BackgroundNoise,
            this.col_BackNoiseDischarge,
            this.col_NetDischarge,
            this.col_Decision,
            this.col_MinDischargeDecl,
            this.col_DischargeDecl,
            this.col_OtherChainHS,
            this.col_MinDecl,
            this.col_Approved,
            this.col_Remarque});
            this.olv_Data.ContextMenuStrip = this.ctx_Grip;
            this.olv_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olv_Data.FullRowSelect = true;
            this.olv_Data.GridLines = true;
            this.olv_Data.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olv_Data.HeaderFormatStyle = this.headerFormatStyle1;
            this.olv_Data.HeaderUsesThemes = false;
            this.olv_Data.HeaderWordWrap = true;
            this.olv_Data.LargeImageList = this.il_states;
            this.olv_Data.Location = new System.Drawing.Point(3, 24);
            this.olv_Data.Name = "olv_Data";
            this.olv_Data.OwnerDraw = true;
            this.olv_Data.RowHeight = 40;
            this.olv_Data.ShowGroups = false;
            this.olv_Data.Size = new System.Drawing.Size(1184, 274);
            this.olv_Data.SmallImageList = this.il_states;
            this.olv_Data.TabIndex = 0;
            this.olv_Data.UseCellFormatEvents = true;
            this.olv_Data.UseCompatibleStateImageBehavior = false;
            this.olv_Data.UseFilterIndicator = true;
            this.olv_Data.View = System.Windows.Forms.View.Details;
            this.olv_Data.CellEditFinishing += new SynapseAdvancedControls.CellEditEventHandler(this.olv_Data_CellEditFinishing);
            this.olv_Data.CellEditStarting += new SynapseAdvancedControls.CellEditEventHandler(this.olv_Data_CellEditStarting);
            this.olv_Data.CellEditValidating += new SynapseAdvancedControls.CellEditEventHandler(this.olv_Data_CellEditValidating);
            this.olv_Data.SubItemChecking += new System.EventHandler<SynapseAdvancedControls.SubItemCheckingEventArgs>(this.olv_Data_SubItemChecking);
            this.olv_Data.FormatCell += new System.EventHandler<SynapseAdvancedControls.FormatCellEventArgs>(this.olv_Data_FormatCell);
            this.olv_Data.FormatRow += new System.EventHandler<SynapseAdvancedControls.FormatRowEventArgs>(this.olv_Data_FormatRow);
            this.olv_Data.ItemsChanged += new System.EventHandler<SynapseAdvancedControls.ItemsChangedEventArgs>(this.olv_Data_ItemsChanged);
            this.olv_Data.SelectedIndexChanged += new System.EventHandler(this.olv_Data_SelectedIndexChanged);
            // 
            // col_Dirty
            // 
            this.col_Dirty.AspectName = "";
            this.col_Dirty.CellPadding = null;
            this.col_Dirty.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Dirty.IsEditable = false;
            this.col_Dirty.Text = "Statu";
            this.col_Dirty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Dirty.Width = 50;
            // 
            // col_Day
            // 
            this.col_Day.CellPadding = null;
            this.col_Day.IsEditable = false;
            this.col_Day.Text = "Date du rejet";
            this.col_Day.Width = 80;
            this.col_Day.WordWrap = true;
            // 
            // col_Date
            // 
            this.col_Date.AspectName = "";
            this.col_Date.AspectToStringFormat = "";
            this.col_Date.CellPadding = null;
            this.col_Date.IsEditable = false;
            this.col_Date.Text = "Date du relevé";
            this.col_Date.Width = 80;
            this.col_Date.WordWrap = true;
            // 
            // col_GazDischarge
            // 
            this.col_GazDischarge.AspectName = "";
            this.col_GazDischarge.AspectToStringFormat = "";
            this.col_GazDischarge.AutoCompleteEditor = false;
            this.col_GazDischarge.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.col_GazDischarge.CellPadding = null;
            this.col_GazDischarge.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_GazDischarge.Text = "Rejet Gaz 24h";
            this.col_GazDischarge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_GazDischarge.Width = 100;
            this.col_GazDischarge.WordWrap = true;
            // 
            // col_GazVolume
            // 
            this.col_GazVolume.AspectName = "";
            this.col_GazVolume.AspectToStringFormat = "";
            this.col_GazVolume.AutoCompleteEditor = false;
            this.col_GazVolume.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.col_GazVolume.CellPadding = null;
            this.col_GazVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_GazVolume.Text = "Volume Gaz 24h";
            this.col_GazVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_GazVolume.Width = 100;
            this.col_GazVolume.WordWrap = true;
            // 
            // col_BackgroundNoise
            // 
            this.col_BackgroundNoise.AspectName = "BackgroundNoise";
            this.col_BackgroundNoise.AspectToStringFormat = "{0:0.000E+00}";
            this.col_BackgroundNoise.CellPadding = null;
            this.col_BackgroundNoise.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_BackgroundNoise.IsEditable = false;
            this.col_BackgroundNoise.Text = "BDF";
            this.col_BackgroundNoise.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_BackgroundNoise.Width = 90;
            this.col_BackgroundNoise.WordWrap = true;
            // 
            // col_BackNoiseDischarge
            // 
            this.col_BackNoiseDischarge.AspectName = "BackgroundNoiseEmission";
            this.col_BackNoiseDischarge.AspectToStringFormat = "{0:0.000E+00}";
            this.col_BackNoiseDischarge.CellPadding = null;
            this.col_BackNoiseDischarge.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_BackNoiseDischarge.IsEditable = false;
            this.col_BackNoiseDischarge.Text = "Rejet BDF";
            this.col_BackNoiseDischarge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_BackNoiseDischarge.Width = 90;
            this.col_BackNoiseDischarge.WordWrap = true;
            // 
            // col_NetDischarge
            // 
            this.col_NetDischarge.AspectName = "NetEmission";
            this.col_NetDischarge.AspectToStringFormat = "{0:0.000E+00}";
            this.col_NetDischarge.CellPadding = null;
            this.col_NetDischarge.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_NetDischarge.IsEditable = false;
            this.col_NetDischarge.Text = "Rejet Net";
            this.col_NetDischarge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_NetDischarge.Width = 90;
            this.col_NetDischarge.WordWrap = true;
            // 
            // col_Decision
            // 
            this.col_Decision.AspectName = "Decision";
            this.col_Decision.AspectToStringFormat = "{0:0.000E+00}";
            this.col_Decision.CellPadding = null;
            this.col_Decision.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_Decision.IsEditable = false;
            this.col_Decision.Text = "Seuil de décision";
            this.col_Decision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_Decision.Width = 90;
            this.col_Decision.WordWrap = true;
            // 
            // col_MinDischargeDecl
            // 
            this.col_MinDischargeDecl.AspectName = "MinEmissionDecl";
            this.col_MinDischargeDecl.AspectToStringFormat = "{0:0.000E+00}";
            this.col_MinDischargeDecl.CellPadding = null;
            this.col_MinDischargeDecl.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_MinDischargeDecl.IsEditable = false;
            this.col_MinDischargeDecl.Text = "Rejet min à déclarer";
            this.col_MinDischargeDecl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_MinDischargeDecl.Width = 90;
            this.col_MinDischargeDecl.WordWrap = true;
            // 
            // col_DischargeDecl
            // 
            this.col_DischargeDecl.AspectName = "EmissionDecl";
            this.col_DischargeDecl.AspectToStringFormat = "{0:0.00E+00}";
            this.col_DischargeDecl.CellPadding = null;
            this.col_DischargeDecl.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_DischargeDecl.IsEditable = false;
            this.col_DischargeDecl.Text = "Rejet déclaré";
            this.col_DischargeDecl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col_DischargeDecl.Width = 100;
            this.col_DischargeDecl.WordWrap = true;
            // 
            // col_OtherChainHS
            // 
            this.col_OtherChainHS.AspectName = "HS";
            this.col_OtherChainHS.CellPadding = null;
            this.col_OtherChainHS.CheckBoxes = true;
            this.col_OtherChainHS.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_OtherChainHS.Text = "Autre chaine HS";
            this.col_OtherChainHS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_OtherChainHS.WordWrap = true;
            // 
            // col_MinDecl
            // 
            this.col_MinDecl.AspectName = "MinDecl";
            this.col_MinDecl.CellPadding = null;
            this.col_MinDecl.CheckBoxes = true;
            this.col_MinDecl.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_MinDecl.IsEditable = false;
            this.col_MinDecl.Text = "Minimum déclaré";
            this.col_MinDecl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_MinDecl.Width = 70;
            this.col_MinDecl.WordWrap = true;
            // 
            // col_Approved
            // 
            this.col_Approved.AspectName = "Valid";
            this.col_Approved.CellPadding = null;
            this.col_Approved.CheckBoxes = true;
            this.col_Approved.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Approved.Text = "Validé";
            this.col_Approved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Approved.Width = 55;
            // 
            // col_Remarque
            // 
            this.col_Remarque.AspectName = "Remarque";
            this.col_Remarque.CellPadding = null;
            this.col_Remarque.Text = "Remarque";
            this.col_Remarque.Width = 180;
            // 
            // ctx_Grip
            // 
            this.ctx_Grip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voirLesDétailsToolStripMenuItem});
            this.ctx_Grip.Name = "ctx_Grip";
            this.ctx_Grip.Size = new System.Drawing.Size(150, 26);
            this.ctx_Grip.Opening += new System.ComponentModel.CancelEventHandler(this.ctx_Grip_Opening);
            // 
            // voirLesDétailsToolStripMenuItem
            // 
            this.voirLesDétailsToolStripMenuItem.Name = "voirLesDétailsToolStripMenuItem";
            this.voirLesDétailsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.voirLesDétailsToolStripMenuItem.Text = "Voir les détails";
            this.voirLesDétailsToolStripMenuItem.Click += new System.EventHandler(this.voirLesDétailsToolStripMenuItem_Click);
            // 
            // headerFormatStyle1
            // 
            headerStateStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            headerStateStyle4.ForeColor = System.Drawing.Color.Navy;
            this.headerFormatStyle1.Hot = headerStateStyle4;
            headerStateStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle5.ForeColor = System.Drawing.Color.Navy;
            this.headerFormatStyle1.Normal = headerStateStyle5;
            headerStateStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            headerStateStyle6.ForeColor = System.Drawing.Color.Navy;
            this.headerFormatStyle1.Pressed = headerStateStyle6;
            // 
            // il_states
            // 
            this.il_states.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_states.ImageStream")));
            this.il_states.TransparentColor = System.Drawing.Color.Transparent;
            this.il_states.Images.SetKeyName(0, "st_data");
            this.il_states.Images.SetKeyName(1, "st_edit");
            this.il_states.Images.SetKeyName(2, "st_empty");
            this.il_states.Images.SetKeyName(3, "st_valid");
            // 
            // zg_Graph
            // 
            this.zg_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zg_Graph.Location = new System.Drawing.Point(666, 12);
            this.zg_Graph.Name = "zg_Graph";
            this.zg_Graph.ScrollGrace = 0D;
            this.zg_Graph.ScrollMaxX = 0D;
            this.zg_Graph.ScrollMaxY = 0D;
            this.zg_Graph.ScrollMaxY2 = 0D;
            this.zg_Graph.ScrollMinX = 0D;
            this.zg_Graph.ScrollMinY = 0D;
            this.zg_Graph.ScrollMinY2 = 0D;
            this.zg_Graph.Size = new System.Drawing.Size(536, 195);
            this.zg_Graph.TabIndex = 0;
            // 
            // frm_GasEmissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 572);
            this.Controls.Add(this.zg_Graph);
            this.Controls.Add(this.gb_Data);
            this.Controls.Add(this.gb_Filter);
            this.Debug = true;
            this.ModuleID = 28;
            this.Name = "frm_GasEmissions";
            this.Text = "frm_GazDischarge";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_GazDischarge_Load);
            this.gb_Filter.ResumeLayout(false);
            this.gb_Filter.PerformLayout();
            this.gb_Data.ResumeLayout(false);
            this.gb_Data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv_Data)).EndInit();
            this.ctx_Grip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView olv_Data;
        private System.Windows.Forms.GroupBox gb_Filter;
        private System.Windows.Forms.ComboBox cb_Unit;
        private System.Windows.Forms.Label lb_Unit;
        private System.Windows.Forms.GroupBox gb_Data;
        private System.Windows.Forms.ComboBox cb_Chain;
        private System.Windows.Forms.Label lb_Chain;
        private SynapseAdvancedControls.OLVColumn col_Day;
        private SynapseAdvancedControls.OLVColumn col_Date;
        private SynapseAdvancedControls.OLVColumn col_GazDischarge;
        private SynapseAdvancedControls.OLVColumn col_GazVolume;
        private SynapseAdvancedControls.OLVColumn col_BackgroundNoise;
        private SynapseAdvancedControls.OLVColumn col_BackNoiseDischarge;
        private SynapseAdvancedControls.OLVColumn col_NetDischarge;
        private SynapseAdvancedControls.OLVColumn col_Decision;
        private SynapseAdvancedControls.OLVColumn col_MinDischargeDecl;
        private SynapseAdvancedControls.OLVColumn col_DischargeDecl;
        private SynapseAdvancedControls.OLVColumn col_Remarque;
        private SynapseAdvancedControls.OLVColumn col_OtherChainHS;
        private SynapseAdvancedControls.OLVColumn col_MinDecl;
        private SynapseAdvancedControls.HeaderFormatStyle headerFormatStyle1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SumVolume;
        private System.Windows.Forms.TextBox txt_EmissionDecl;
        private System.Windows.Forms.Button btn_NextWeek;
        private System.Windows.Forms.Button btn_PreviousWeek;
        private System.Windows.Forms.Button btn_LastData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_Save;
        private SynapseAdvancedControls.OLVColumn col_Dirty;
        private ZedGraph.ZedGraphControl zg_Graph;
        private System.Windows.Forms.ImageList il_buttons;
        private System.Windows.Forms.Button btn_Graph;
        private System.Windows.Forms.Button btn_Report;
        private SynapseAdvancedControls.OLVColumn col_Approved;
        private System.Windows.Forms.ImageList il_states;
        private System.Windows.Forms.ContextMenuStrip ctx_Grip;
        private System.Windows.Forms.ToolStripMenuItem voirLesDétailsToolStripMenuItem;
        private System.Windows.Forms.Label lb_SumEmissionsUnit;
        private System.Windows.Forms.Label lb_SumVolumeUnit;
        public CustomControls.MonthCalendar monthCalendar1;
    }
}