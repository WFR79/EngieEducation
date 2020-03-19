namespace SynapseReport.Forms
{
    partial class frmReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportList));
            this.gbReportList = new System.Windows.Forms.GroupBox();
            this.olvReport = new SynapseAdvancedControls.ObjectListView();
            this.colCat = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colRep = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colAva = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.gbReportList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvReport)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReportList
            // 
            this.gbReportList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReportList.Controls.Add(this.olvReport);
            this.gbReportList.Location = new System.Drawing.Point(12, 34);
            this.gbReportList.Name = "gbReportList";
            this.gbReportList.Size = new System.Drawing.Size(771, 285);
            this.gbReportList.TabIndex = 1;
            this.gbReportList.TabStop = false;
            this.gbReportList.Text = "Report List";
            // 
            // olvReport
            // 
            this.olvReport.AllColumns.Add(this.colCat);
            this.olvReport.AllColumns.Add(this.colRep);
            this.olvReport.AllColumns.Add(this.colAva);
            this.olvReport.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCat,
            this.colRep,
            this.colAva});
            this.olvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvReport.FullRowSelect = true;
            this.olvReport.GridLines = true;
            this.olvReport.HeaderWordWrap = true;
            this.olvReport.HideSelection = false;
            this.olvReport.Location = new System.Drawing.Point(6, 19);
            this.olvReport.MultiSelect = false;
            this.olvReport.Name = "olvReport";
            this.olvReport.OwnerDraw = true;
            this.olvReport.ShowCommandMenuOnRightClick = true;
            this.olvReport.ShowGroups = false;
            this.olvReport.Size = new System.Drawing.Size(759, 260);
            this.olvReport.TabIndex = 0;
            this.olvReport.UseAlternatingBackColors = true;
            this.olvReport.UseCompatibleStateImageBehavior = false;
            this.olvReport.UseFiltering = true;
            this.olvReport.View = System.Windows.Forms.View.Details;
            this.olvReport.SelectedIndexChanged += new System.EventHandler(this.olvReport_SelectedIndexChanged);
            this.olvReport.DoubleClick += new System.EventHandler(this.Edit_Report);
            // 
            // colCat
            // 
            this.colCat.AspectName = "";
            this.colCat.CellPadding = null;
            this.colCat.IsEditable = false;
            this.colCat.Text = "Category";
            this.colCat.Width = 250;
            // 
            // colRep
            // 
            this.colRep.AspectName = "";
            this.colRep.AspectToStringFormat = "";
            this.colRep.CellPadding = null;
            this.colRep.IsEditable = false;
            this.colRep.Text = "Report";
            this.colRep.Width = 400;
            // 
            // colAva
            // 
            this.colAva.AspectName = "";
            this.colAva.CellPadding = null;
            this.colAva.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAva.IsEditable = false;
            this.colAva.Searchable = false;
            this.colAva.Text = "Available";
            this.colAva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAva.Width = 80;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator5,
            this.tsbNew,
            this.tsbOpen,
            this.tsbDelete,
            this.tsbCopy,
            this.toolStripSeparator1,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(28, 28);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.ExitForm);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(28, 28);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.New_Report);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(28, 28);
            this.tsbOpen.Text = "Edit";
            this.tsbOpen.Click += new System.EventHandler(this.Edit_Report);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.delete_Report);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(28, 28);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.png");
            this.imageList.Images.SetKeyName(1, "NotOK.png");
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(28, 28);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // frmReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 331);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbReportList);
            this.ModuleID = 2;
            this.Name = "frmReportList";
            this.ShowMenu = false;
            this.Text = "frmReportList";
            this.UpdateControls = true;
            this.gbReportList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvReport)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReportList;
        private SynapseAdvancedControls.ObjectListView olvReport;
        private SynapseAdvancedControls.OLVColumn colCat;
        private SynapseAdvancedControls.OLVColumn colRep;
        private SynapseAdvancedControls.OLVColumn colAva;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton tsbCopy;
    }
}