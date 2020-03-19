namespace Synapse
{
    partial class frmRequest
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Nusacu++",
            "Nuclear Safety Culture - Certificates Management",
            "2.0"}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Rework",
            "Notifications, Orders & Reworks Management",
            "3.1"}, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequest));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvModule = new System.Windows.Forms.ListView();
            this.colModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.smallImages = new System.Windows.Forms.ImageList(this.components);
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txTo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txFor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txReason = new System.Windows.Forms.TextBox();
            this.actionImages = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbSend = new System.Windows.Forms.ToolStripButton();
            this.btSend = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvModule);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module\'s List";
            // 
            // lvModule
            // 
            this.lvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvModule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colModule,
            this.colDescription,
            this.colVersion});
            this.lvModule.FullRowSelect = true;
            this.lvModule.GridLines = true;
            listViewItem1.ToolTipText = "Nuclear Safety Culture - Certificates Management";
            listViewItem2.ToolTipText = "Notifications, Orders & Reworks Management";
            this.lvModule.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvModule.Location = new System.Drawing.Point(6, 19);
            this.lvModule.MultiSelect = false;
            this.lvModule.Name = "lvModule";
            this.lvModule.ShowItemToolTips = true;
            this.lvModule.Size = new System.Drawing.Size(613, 129);
            this.lvModule.SmallImageList = this.smallImages;
            this.lvModule.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvModule.TabIndex = 1;
            this.lvModule.UseCompatibleStateImageBehavior = false;
            this.lvModule.View = System.Windows.Forms.View.Details;
            this.lvModule.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colModule
            // 
            this.colModule.Text = "Name";
            this.colModule.Width = 180;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 350;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // smallImages
            // 
            this.smallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImages.ImageStream")));
            this.smallImages.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImages.Images.SetKeyName(0, "cert01.ico");
            this.smallImages.Images.SetKeyName(1, "worker.ico");
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.txTo);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.txFor);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.txReason);
            this.gbDetail.Location = new System.Drawing.Point(12, 194);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(625, 172);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Request Details";
            // 
            // txTo
            // 
            this.txTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTo.BackColor = System.Drawing.Color.White;
            this.txTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txTo.Location = new System.Drawing.Point(156, 51);
            this.txTo.Name = "txTo";
            this.txTo.Size = new System.Drawing.Size(463, 18);
            this.txTo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sent To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reason";
            // 
            // txFor
            // 
            this.txFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFor.BackColor = System.Drawing.Color.White;
            this.txFor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txFor.Location = new System.Drawing.Point(156, 24);
            this.txFor.Name = "txFor";
            this.txFor.Size = new System.Drawing.Size(463, 18);
            this.txFor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request for";
            // 
            // txReason
            // 
            this.txReason.AcceptsReturn = true;
            this.txReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txReason.Location = new System.Drawing.Point(156, 81);
            this.txReason.Multiline = true;
            this.txReason.Name = "txReason";
            this.txReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txReason.Size = new System.Drawing.Size(463, 85);
            this.txReason.TabIndex = 0;
            // 
            // actionImages
            // 
            this.actionImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("actionImages.ImageStream")));
            this.actionImages.TransparentColor = System.Drawing.Color.Magenta;
            this.actionImages.Images.SetKeyName(0, "Send.bmp");
            this.actionImages.Images.SetKeyName(1, "NoAction.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCancel,
            this.tsbSend});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(649, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(28, 28);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.ExitForm);
            // 
            // tsbSend
            // 
            this.tsbSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSend.Image = ((System.Drawing.Image)(resources.GetObject("tsbSend.Image")));
            this.tsbSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSend.Name = "tsbSend";
            this.tsbSend.Size = new System.Drawing.Size(28, 28);
            this.tsbSend.Text = "Send Mail";
            this.tsbSend.Click += new System.EventHandler(this.SendMail);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(174, 388);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(61, 28);
            this.btSend.TabIndex = 6;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.SendMail);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(241, 388);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(59, 28);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // frmRequest
            // 
            this.AcceptButton = this.btSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(649, 376);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ModuleID = 1;
            this.Name = "frmRequest";
            this.SecurityEnabled = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request for Module";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frmRequest_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvModule;
        private System.Windows.Forms.ColumnHeader colModule;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ImageList smallImages;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label txTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txFor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txReason;
        private System.Windows.Forms.ImageList actionImages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbSend;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btCancel;
    }
}