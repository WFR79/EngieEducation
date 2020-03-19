/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Synapse
{
	partial class frmGroupEdit
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupEdit));
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.lbl_level = new System.Windows.Forms.Label();
            this.chk_Owner = new System.Windows.Forms.CheckBox();
            this.txt_TechName = new System.Windows.Forms.TextBox();
            this.lbl_TechnicalName = new System.Windows.Forms.Label();
            this.cb_Module = new System.Windows.Forms.ComboBox();
            this.lbl_Module = new System.Windows.Forms.Label();
            this.num_Level = new System.Windows.Forms.NumericUpDown();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Level)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.num_Level);
            this.gbDetail.Controls.Add(this.lbl_level);
            this.gbDetail.Controls.Add(this.chk_Owner);
            this.gbDetail.Controls.Add(this.txt_TechName);
            this.gbDetail.Controls.Add(this.lbl_TechnicalName);
            this.gbDetail.Controls.Add(this.cb_Module);
            this.gbDetail.Controls.Add(this.lbl_Module);
            this.gbDetail.Location = new System.Drawing.Point(12, 34);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(395, 130);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "New / Edit Group";
            // 
            // lbl_level
            // 
            this.lbl_level.Location = new System.Drawing.Point(7, 74);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(53, 23);
            this.lbl_level.TabIndex = 6;
            this.lbl_level.Text = "Level";
            // 
            // chk_Owner
            // 
            this.chk_Owner.Location = new System.Drawing.Point(10, 100);
            this.chk_Owner.Name = "chk_Owner";
            this.chk_Owner.Size = new System.Drawing.Size(225, 24);
            this.chk_Owner.TabIndex = 4;
            this.chk_Owner.Text = "Group Owner";
            this.chk_Owner.UseVisualStyleBackColor = true;
            // 
            // txt_TechName
            // 
            this.txt_TechName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TechName.Location = new System.Drawing.Point(154, 46);
            this.txt_TechName.Name = "txt_TechName";
            this.txt_TechName.Size = new System.Drawing.Size(235, 20);
            this.txt_TechName.TabIndex = 3;
            // 
            // lbl_TechnicalName
            // 
            this.lbl_TechnicalName.Location = new System.Drawing.Point(7, 49);
            this.lbl_TechnicalName.Name = "lbl_TechnicalName";
            this.lbl_TechnicalName.Size = new System.Drawing.Size(141, 23);
            this.lbl_TechnicalName.TabIndex = 2;
            this.lbl_TechnicalName.Text = "Technical Name";
            // 
            // cb_Module
            // 
            this.cb_Module.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Module.FormattingEnabled = true;
            this.cb_Module.Location = new System.Drawing.Point(154, 17);
            this.cb_Module.Name = "cb_Module";
            this.cb_Module.Size = new System.Drawing.Size(235, 21);
            this.cb_Module.TabIndex = 1;
            // 
            // lbl_Module
            // 
            this.lbl_Module.Location = new System.Drawing.Point(7, 20);
            this.lbl_Module.Name = "lbl_Module";
            this.lbl_Module.Size = new System.Drawing.Size(141, 23);
            this.lbl_Module.TabIndex = 0;
            this.lbl_Module.Text = "Module";
            // 
            // num_Level
            // 
            this.num_Level.Location = new System.Drawing.Point(154, 72);
            this.num_Level.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Level.Name = "num_Level";
            this.num_Level.Size = new System.Drawing.Size(81, 20);
            this.num_Level.TabIndex = 7;
            this.num_Level.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(420, 31);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "Cancel";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.Btn_OKClick);
            // 
            // frmGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 172);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.gbDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGroupEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmGroupEdit";
            this.Load += new System.EventHandler(this.FrmGroupEditLoad);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Level)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.NumericUpDown num_Level;
        private System.Windows.Forms.TextBox txt_TechName;
		private System.Windows.Forms.Label lbl_Module;
		private System.Windows.Forms.ComboBox cb_Module;
		private System.Windows.Forms.Label lbl_TechnicalName;
		private System.Windows.Forms.CheckBox chk_Owner;
		private System.Windows.Forms.Label lbl_level;
		private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}
