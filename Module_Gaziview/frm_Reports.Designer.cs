namespace Module_Gaziview
{
    partial class frm_Reports
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Reports));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gb_Filter = new System.Windows.Forms.GroupBox();
            this.cb_Unit = new System.Windows.Forms.ComboBox();
            this.btn_Graph = new System.Windows.Forms.Button();
            this.il_buttons = new System.Windows.Forms.ImageList(this.components);
            this.monthCalendar2 = new CustomControls.MonthCalendar();
            this.o_GasEmissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gb_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.o_GasEmissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "Data";
            reportDataSource1.Value = this.o_GasEmissionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.Location = new System.Drawing.Point(216, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(665, 270);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // gb_Filter
            // 
            this.gb_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Filter.Controls.Add(this.monthCalendar2);
            this.gb_Filter.Controls.Add(this.cb_Unit);
            this.gb_Filter.Controls.Add(this.btn_Graph);
            this.gb_Filter.Location = new System.Drawing.Point(5, 5);
            this.gb_Filter.Name = "gb_Filter";
            this.gb_Filter.Size = new System.Drawing.Size(205, 265);
            this.gb_Filter.TabIndex = 1;
            this.gb_Filter.TabStop = false;
            this.gb_Filter.Text = "Filtres";
            // 
            // cb_Unit
            // 
            this.cb_Unit.FormattingEnabled = true;
            this.cb_Unit.Location = new System.Drawing.Point(11, 20);
            this.cb_Unit.Name = "cb_Unit";
            this.cb_Unit.Size = new System.Drawing.Size(184, 21);
            this.cb_Unit.TabIndex = 14;
            this.cb_Unit.SelectedIndexChanged += new System.EventHandler(this.cb_Unit_SelectedIndexChanged);
            // 
            // btn_Graph
            // 
            this.btn_Graph.ImageKey = "notebook_edit.png";
            this.btn_Graph.ImageList = this.il_buttons;
            this.btn_Graph.Location = new System.Drawing.Point(10, 224);
            this.btn_Graph.Name = "btn_Graph";
            this.btn_Graph.Size = new System.Drawing.Size(185, 28);
            this.btn_Graph.TabIndex = 13;
            this.btn_Graph.Text = "Générer";
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
            // monthCalendar2
            // 
            this.monthCalendar2.ColorTable.DayActiveGradientBegin = System.Drawing.Color.Bisque;
            this.monthCalendar2.ColorTable.DayActiveGradientEnd = System.Drawing.Color.Gold;
            this.monthCalendar2.ColorTable.DayHeaderText = System.Drawing.Color.MediumBlue;
            this.monthCalendar2.ColorTable.DayTextBold = System.Drawing.Color.DarkBlue;
            this.monthCalendar2.ColorTable.FooterActiveGradientBegin = System.Drawing.Color.Transparent;
            this.monthCalendar2.ColorTable.FooterActiveGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.monthCalendar2.ColorTable.FooterActiveText = System.Drawing.Color.DarkRed;
            this.monthCalendar2.ColorTable.HeaderActiveArrow = System.Drawing.Color.MidnightBlue;
            this.monthCalendar2.ColorTable.HeaderActiveGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.monthCalendar2.ColorTable.HeaderGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(177)))), ((int)(((byte)(255)))));
            this.monthCalendar2.Culture = new System.Globalization.CultureInfo("fr-BE");
            this.monthCalendar2.Location = new System.Drawing.Point(12, 47);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.ShowWeekHeader = false;
            this.monthCalendar2.TabIndex = 15;
            this.monthCalendar2.DateSelected += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.monthCalendar1_DateChanged);
            this.monthCalendar2.DateChanged += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.monthCalendar1_DateChanged);
            // 
            // o_GasEmissionBindingSource
            // 
            this.o_GasEmissionBindingSource.DataSource = typeof(Module_Gaziview.Entities.o_EmissionReport);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Module_Gaziview.Entities.o_EmissionReport);
            // 
            // frm_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 274);
            this.Controls.Add(this.gb_Filter);
            this.Controls.Add(this.reportViewer1);
            this.Debug = true;
            this.ModuleID = 28;
            this.Name = "frm_Reports";
            this.Text = "frm_Reports";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_Reports_Load);
            this.gb_Filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.o_GasEmissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource o_GasEmissionBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox gb_Filter;
        private System.Windows.Forms.Button btn_Graph;
        private System.Windows.Forms.ImageList il_buttons;
        private System.Windows.Forms.ComboBox cb_Unit;
        public CustomControls.MonthCalendar monthCalendar2;
    }
}