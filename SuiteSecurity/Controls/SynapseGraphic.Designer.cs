namespace SynapseCore.Controls
{
    partial class SynapseGraphic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynapseGraphic));
            this.gbGraph = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPage = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tsbDefaultScale = new System.Windows.Forms.ToolStripButton();
            this.tsbCurves = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            this.tsbValues = new System.Windows.Forms.ToolStripButton();
            this.tsbLegend = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.gbGraph.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGraph
            // 
            this.gbGraph.Controls.Add(this.toolStrip1);
            this.gbGraph.Controls.Add(this.panel1);
            this.gbGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGraph.Location = new System.Drawing.Point(0, 0);
            this.gbGraph.Name = "gbGraph";
            this.gbGraph.Padding = new System.Windows.Forms.Padding(10);
            this.gbGraph.Size = new System.Drawing.Size(740, 435);
            this.gbGraph.TabIndex = 5;
            this.gbGraph.TabStop = false;
            this.gbGraph.Text = "Graph";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCopy,
            this.tsbSave,
            this.tsbPage,
            this.tsbPrint,
            this.tsbZoomOut,
            this.tsbReset,
            this.tsbDefaultScale,
            this.tsbCurves,
            this.tsbShowAll,
            this.tsbValues,
            this.tsbLegend});
            this.toolStrip1.Location = new System.Drawing.Point(10, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(28, 28);
            this.tsbSave.Text = "Save As";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbPage
            // 
            this.tsbPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbPage.Image")));
            this.tsbPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPage.Name = "tsbPage";
            this.tsbPage.Size = new System.Drawing.Size(28, 28);
            this.tsbPage.Text = "Page Setup";
            this.tsbPage.Click += new System.EventHandler(this.tsbPage_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(28, 28);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomOut.Image")));
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(28, 28);
            this.tsbZoomOut.Text = "Un-Zoom";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(28, 28);
            this.tsbReset.Text = "Undo All Zoom/Pan";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // tsbDefaultScale
            // 
            this.tsbDefaultScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDefaultScale.Image = ((System.Drawing.Image)(resources.GetObject("tsbDefaultScale.Image")));
            this.tsbDefaultScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDefaultScale.Name = "tsbDefaultScale";
            this.tsbDefaultScale.Size = new System.Drawing.Size(28, 28);
            this.tsbDefaultScale.Text = "Reset Scale to Default";
            this.tsbDefaultScale.Click += new System.EventHandler(this.tsbDefaultScale_Click);
            // 
            // tsbCurves
            // 
            this.tsbCurves.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCurves.Image = ((System.Drawing.Image)(resources.GetObject("tsbCurves.Image")));
            this.tsbCurves.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCurves.Name = "tsbCurves";
            this.tsbCurves.Size = new System.Drawing.Size(37, 28);
            this.tsbCurves.Text = "Curves";
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowAll.Image")));
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Size = new System.Drawing.Size(28, 28);
            this.tsbShowAll.Text = "Show All Curves";
            this.tsbShowAll.Click += new System.EventHandler(this.tsbShowAll_Click);
            // 
            // tsbValues
            // 
            this.tsbValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbValues.Image = ((System.Drawing.Image)(resources.GetObject("tsbValues.Image")));
            this.tsbValues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbValues.Name = "tsbValues";
            this.tsbValues.Size = new System.Drawing.Size(28, 28);
            this.tsbValues.Text = "Show Points Values";
            this.tsbValues.Click += new System.EventHandler(this.tsbValues_Click);
            // 
            // tsbLegend
            // 
            this.tsbLegend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLegend.Image = ((System.Drawing.Image)(resources.GetObject("tsbLegend.Image")));
            this.tsbLegend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLegend.Name = "tsbLegend";
            this.tsbLegend.Size = new System.Drawing.Size(28, 28);
            this.tsbLegend.Text = "Show/Hide Legend";
            this.tsbLegend.Click += new System.EventHandler(this.tsbLegend_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.zedGraph);
            this.panel1.Location = new System.Drawing.Point(10, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 366);
            this.panel1.TabIndex = 2;
            // 
            // zedGraph
            // 
            this.zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.zedGraph.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraph.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.zedGraph.LinkModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraph.Location = new System.Drawing.Point(0, 0);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(717, 366);
            this.zedGraph.TabIndex = 1;
            // 
            // SynapseGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbGraph);
            this.Name = "SynapseGraphic";
            this.Size = new System.Drawing.Size(740, 435);
            this.gbGraph.ResumeLayout(false);
            this.gbGraph.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGraph;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbPage;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripButton tsbDefaultScale;
        private System.Windows.Forms.ToolStripDropDownButton tsbCurves;
        private System.Windows.Forms.ToolStripButton tsbShowAll;
        private System.Windows.Forms.ToolStripButton tsbValues;
        private System.Windows.Forms.ToolStripButton tsbLegend;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedGraph;
    }
}
