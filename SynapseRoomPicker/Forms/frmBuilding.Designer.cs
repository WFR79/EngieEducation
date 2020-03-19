namespace SynapseRoomPicker.Forms
{
    partial class frmBuilding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuilding));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.txName = new System.Windows.Forms.TextBox();
            this.ckAvailable = new System.Windows.Forms.CheckBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbCode = new System.Windows.Forms.Label();
            this.lbEntity = new System.Windows.Forms.Label();
            this.txCode = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.toolStrip1.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCancel,
            this.toolStripSeparator1,
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(354, 31);
            this.toolStrip1.TabIndex = 23;
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
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(28, 28);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.cbEntity);
            this.gbDetail.Controls.Add(this.txName);
            this.gbDetail.Controls.Add(this.ckAvailable);
            this.gbDetail.Controls.Add(this.lbName);
            this.gbDetail.Controls.Add(this.lbCode);
            this.gbDetail.Controls.Add(this.lbEntity);
            this.gbDetail.Controls.Add(this.txCode);
            this.gbDetail.Location = new System.Drawing.Point(10, 34);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(332, 122);
            this.gbDetail.TabIndex = 28;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Building Detail";
            // 
            // cbEntity
            // 
            this.cbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntity.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbEntity, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbEntity.Location = new System.Drawing.Point(107, 14);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(219, 21);
            this.cbEntity.TabIndex = 0;
            // 
            // txName
            // 
            this.txName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.synapseErrorProvider1.SetIconAlignment(this.txName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txName.Location = new System.Drawing.Point(107, 67);
            this.txName.MaxLength = 50;
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(219, 20);
            this.txName.TabIndex = 2;
            // 
            // ckAvailable
            // 
            this.ckAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAvailable.Location = new System.Drawing.Point(107, 97);
            this.ckAvailable.Name = "ckAvailable";
            this.ckAvailable.Size = new System.Drawing.Size(103, 17);
            this.ckAvailable.TabIndex = 3;
            this.ckAvailable.Text = "Available";
            this.ckAvailable.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 70);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(75, 13);
            this.lbName.TabIndex = 13;
            this.lbName.Text = "Building Name";
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Location = new System.Drawing.Point(6, 44);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(72, 13);
            this.lbCode.TabIndex = 12;
            this.lbCode.Text = "Building Code";
            // 
            // lbEntity
            // 
            this.lbEntity.AutoSize = true;
            this.lbEntity.Location = new System.Drawing.Point(6, 22);
            this.lbEntity.Name = "lbEntity";
            this.lbEntity.Size = new System.Drawing.Size(33, 13);
            this.lbEntity.TabIndex = 9;
            this.lbEntity.Text = "Entity";
            // 
            // txCode
            // 
            this.txCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.synapseErrorProvider1.SetIconAlignment(this.txCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txCode.Location = new System.Drawing.Point(107, 41);
            this.txCode.MaxLength = 20;
            this.txCode.Name = "txCode";
            this.txCode.Size = new System.Drawing.Size(219, 20);
            this.txCode.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(165, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(27, 19);
            this.btCancel.TabIndex = 29;
            this.btCancel.TabStop = false;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(198, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(27, 19);
            this.btOk.TabIndex = 30;
            this.btOk.TabStop = false;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // frmBuilding
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(354, 168);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuilding";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBuilding";
            this.UpdateControls = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.CheckBox ckAvailable;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbEntity;
        private System.Windows.Forms.TextBox txCode;
        private System.Windows.Forms.TextBox txName;
        private System.Windows.Forms.ComboBox cbEntity;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
    }
}