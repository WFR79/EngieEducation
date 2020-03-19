namespace Synapse
{
    partial class frmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.txLevel = new SynapseCore.Controls.SynapseTextBox();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.lbLevel = new System.Windows.Forms.Label();
            this.ckOwner = new System.Windows.Forms.CheckBox();
            this.cbModule = new System.Windows.Forms.ComboBox();
            this.txTechnicalName = new SynapseCore.Controls.SynapseTextBox();
            this.lbModule = new System.Windows.Forms.Label();
            this.lbTechnicalName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.txLevel);
            this.gbDetails.Controls.Add(this.lbLevel);
            this.gbDetails.Controls.Add(this.ckOwner);
            this.gbDetails.Controls.Add(this.cbModule);
            this.gbDetails.Controls.Add(this.txTechnicalName);
            this.gbDetails.Controls.Add(this.lbModule);
            this.gbDetails.Controls.Add(this.lbTechnicalName);
            this.gbDetails.Location = new System.Drawing.Point(12, 34);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(310, 126);
            this.gbDetails.TabIndex = 0;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Group\'s Details";
            // 
            // txLevel
            // 
            this.txLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txLevel.CurrentErrorProvider = this.synapseErrorProvider1;
            this.txLevel.Location = new System.Drawing.Point(139, 71);
            this.txLevel.Mandatory = true;
            this.txLevel.MandatoryErrorMessage = "Mandatory field";
            this.txLevel.MaxLength = 3;
            this.txLevel.MinLength = 0;
            this.txLevel.Name = "txLevel";
            this.txLevel.NotMatchErrorMessage = "Not Valid";
            this.txLevel.NumberOfDecimal = 0;
            this.txLevel.RegularExpression = "";
            this.txLevel.Size = new System.Drawing.Size(151, 20);
            this.txLevel.TabIndex = 3;
            this.txLevel.TooLongErrorMessage = "Too long";
            this.txLevel.Validate = false;
            this.txLevel.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Decimal;
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Location = new System.Drawing.Point(6, 74);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(33, 13);
            this.lbLevel.TabIndex = 13;
            this.lbLevel.Text = "Level";
            // 
            // ckOwner
            // 
            this.ckOwner.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckOwner.Location = new System.Drawing.Point(6, 97);
            this.ckOwner.Name = "ckOwner";
            this.ckOwner.Size = new System.Drawing.Size(148, 20);
            this.ckOwner.TabIndex = 4;
            this.ckOwner.Text = "Is Owner";
            this.ckOwner.UseVisualStyleBackColor = true;
            // 
            // cbModule
            // 
            this.cbModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModule.FormattingEnabled = true;
            this.cbModule.Location = new System.Drawing.Point(139, 18);
            this.cbModule.Name = "cbModule";
            this.cbModule.Size = new System.Drawing.Size(151, 21);
            this.cbModule.TabIndex = 1;
            // 
            // txTechnicalName
            // 
            this.txTechnicalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTechnicalName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txTechnicalName.CurrentErrorProvider = this.synapseErrorProvider1;
            this.txTechnicalName.Location = new System.Drawing.Point(139, 45);
            this.txTechnicalName.Mandatory = true;
            this.txTechnicalName.MandatoryErrorMessage = "Mandatory field";
            this.txTechnicalName.MaxLength = 50;
            this.txTechnicalName.MinLength = 0;
            this.txTechnicalName.Name = "txTechnicalName";
            this.txTechnicalName.NotMatchErrorMessage = "Not Valid";
            this.txTechnicalName.NumberOfDecimal = 2;
            this.txTechnicalName.RegularExpression = null;
            this.txTechnicalName.Size = new System.Drawing.Size(151, 20);
            this.txTechnicalName.TabIndex = 2;
            this.txTechnicalName.TooLongErrorMessage = "Too long";
            this.txTechnicalName.Validate = false;
            this.txTechnicalName.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // lbModule
            // 
            this.lbModule.AutoSize = true;
            this.lbModule.Location = new System.Drawing.Point(6, 21);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(42, 13);
            this.lbModule.TabIndex = 6;
            this.lbModule.Text = "Module";
            // 
            // lbTechnicalName
            // 
            this.lbTechnicalName.AutoSize = true;
            this.lbTechnicalName.Location = new System.Drawing.Point(6, 48);
            this.lbTechnicalName.Name = "lbTechnicalName";
            this.lbTechnicalName.Size = new System.Drawing.Size(85, 13);
            this.lbTechnicalName.TabIndex = 2;
            this.lbTechnicalName.Text = "Technical Name";
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
            this.toolStrip1.Size = new System.Drawing.Size(334, 31);
            this.toolStrip1.TabIndex = 34;
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
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(316, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(27, 19);
            this.btOk.TabIndex = 35;
            this.btOk.TabStop = false;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(349, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(27, 19);
            this.btCancel.TabIndex = 36;
            this.btCancel.TabStop = false;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 163);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 23);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // frmGroup
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(334, 195);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 1;
            this.Name = "frmGroup";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Access Group";
            this.UpdateControls = true;
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.ComboBox cbModule;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private SynapseCore.Controls.SynapseTextBox txTechnicalName;
        private System.Windows.Forms.Label lbModule;
        private System.Windows.Forms.Label lbTechnicalName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox ckOwner;
        private SynapseCore.Controls.SynapseTextBox txLevel;
        private System.Windows.Forms.Label lbLevel;
    }
}