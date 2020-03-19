namespace Synapse
{
    partial class frmModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModule));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.txCategory = new SynapseCore.Controls.SynapseTextBox();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.txVersionDate = new SynapseCore.Controls.SynapseTextBox();
            this.txVersion = new SynapseCore.Controls.SynapseTextBox();
            this.txTechnicalName = new SynapseCore.Controls.SynapseTextBox();
            this.txPath = new SynapseCore.Controls.SynapseTextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbVersionDate = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbTechnicalName = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.txDevSources = new SynapseCore.Controls.SynapseTextBox();
            this.lbDevSources = new System.Windows.Forms.Label();
            this.txProdSources = new SynapseCore.Controls.SynapseTextBox();
            this.lbProdSources = new System.Windows.Forms.Label();
            this.ckActive = new System.Windows.Forms.CheckBox();
            this.ckRequestable = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 298);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(415, 166);
            this.flowLayoutPanel1.TabIndex = 6;
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
            this.toolStrip1.Size = new System.Drawing.Size(439, 31);
            this.toolStrip1.TabIndex = 26;
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
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(365, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(27, 19);
            this.btCancel.TabIndex = 28;
            this.btCancel.TabStop = false;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(332, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(27, 19);
            this.btOk.TabIndex = 27;
            this.btOk.TabStop = false;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.ckRequestable);
            this.gbDetails.Controls.Add(this.ckActive);
            this.gbDetails.Controls.Add(this.txProdSources);
            this.gbDetails.Controls.Add(this.lbProdSources);
            this.gbDetails.Controls.Add(this.txDevSources);
            this.gbDetails.Controls.Add(this.lbDevSources);
            this.gbDetails.Controls.Add(this.txCategory);
            this.gbDetails.Controls.Add(this.txVersionDate);
            this.gbDetails.Controls.Add(this.txVersion);
            this.gbDetails.Controls.Add(this.txTechnicalName);
            this.gbDetails.Controls.Add(this.txPath);
            this.gbDetails.Controls.Add(this.lbCategory);
            this.gbDetails.Controls.Add(this.lbVersionDate);
            this.gbDetails.Controls.Add(this.lbVersion);
            this.gbDetails.Controls.Add(this.lbTechnicalName);
            this.gbDetails.Controls.Add(this.lbPath);
            this.gbDetails.Location = new System.Drawing.Point(12, 34);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(415, 261);
            this.gbDetails.TabIndex = 0;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Module\'s Details";
            // 
            // txCategory
            // 
            this.txCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txCategory.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txCategory, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txCategory, 5);
            this.txCategory.Location = new System.Drawing.Point(159, 125);
            this.txCategory.Mandatory = true;
            this.txCategory.MandatoryErrorMessage = "Mandatory field";
            this.txCategory.MaxLength = 250;
            this.txCategory.MinLength = 0;
            this.txCategory.Name = "txCategory";
            this.txCategory.NotMatchErrorMessage = "Not Valid";
            this.txCategory.NumberOfDecimal = 2;
            this.txCategory.RegularExpression = null;
            this.txCategory.Size = new System.Drawing.Size(236, 20);
            this.txCategory.TabIndex = 13;
            this.txCategory.TooLongErrorMessage = "Too long";
            this.txCategory.Validate = false;
            this.txCategory.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // txVersionDate
            // 
            this.txVersionDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txVersionDate.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txVersionDate, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txVersionDate, 5);
            this.txVersionDate.Location = new System.Drawing.Point(159, 99);
            this.txVersionDate.Mandatory = true;
            this.txVersionDate.MandatoryErrorMessage = "Mandatory field";
            this.txVersionDate.MaxLength = 250;
            this.txVersionDate.MinLength = 0;
            this.txVersionDate.Name = "txVersionDate";
            this.txVersionDate.NotMatchErrorMessage = "Not Valid";
            this.txVersionDate.NumberOfDecimal = 2;
            this.txVersionDate.RegularExpression = null;
            this.txVersionDate.Size = new System.Drawing.Size(236, 20);
            this.txVersionDate.TabIndex = 12;
            this.txVersionDate.TooLongErrorMessage = "Too long";
            this.txVersionDate.Validate = false;
            this.txVersionDate.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // txVersion
            // 
            this.txVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txVersion.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txVersion, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txVersion, 5);
            this.txVersion.Location = new System.Drawing.Point(159, 73);
            this.txVersion.Mandatory = true;
            this.txVersion.MandatoryErrorMessage = "Mandatory field";
            this.txVersion.MaxLength = 250;
            this.txVersion.MinLength = 0;
            this.txVersion.Name = "txVersion";
            this.txVersion.NotMatchErrorMessage = "Not Valid";
            this.txVersion.NumberOfDecimal = 2;
            this.txVersion.RegularExpression = null;
            this.txVersion.Size = new System.Drawing.Size(236, 20);
            this.txVersion.TabIndex = 11;
            this.txVersion.TooLongErrorMessage = "Too long";
            this.txVersion.Validate = false;
            this.txVersion.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // txTechnicalName
            // 
            this.txTechnicalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTechnicalName.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txTechnicalName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txTechnicalName, 5);
            this.txTechnicalName.Location = new System.Drawing.Point(159, 45);
            this.txTechnicalName.Mandatory = true;
            this.txTechnicalName.MandatoryErrorMessage = "Mandatory field";
            this.txTechnicalName.MaxLength = 250;
            this.txTechnicalName.MinLength = 0;
            this.txTechnicalName.Name = "txTechnicalName";
            this.txTechnicalName.NotMatchErrorMessage = "Not Valid";
            this.txTechnicalName.NumberOfDecimal = 2;
            this.txTechnicalName.RegularExpression = null;
            this.txTechnicalName.Size = new System.Drawing.Size(236, 20);
            this.txTechnicalName.TabIndex = 10;
            this.txTechnicalName.TooLongErrorMessage = "Too long";
            this.txTechnicalName.Validate = false;
            this.txTechnicalName.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // txPath
            // 
            this.txPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txPath.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txPath, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txPath, 5);
            this.txPath.Location = new System.Drawing.Point(159, 19);
            this.txPath.Mandatory = true;
            this.txPath.MandatoryErrorMessage = "Mandatory field";
            this.txPath.MaxLength = 250;
            this.txPath.MinLength = 0;
            this.txPath.Name = "txPath";
            this.txPath.NotMatchErrorMessage = "Not Valid";
            this.txPath.NumberOfDecimal = 2;
            this.txPath.RegularExpression = null;
            this.txPath.Size = new System.Drawing.Size(236, 20);
            this.txPath.TabIndex = 9;
            this.txPath.TooLongErrorMessage = "Too long";
            this.txPath.Validate = false;
            this.txPath.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(6, 128);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 8;
            this.lbCategory.Text = "Category";
            // 
            // lbVersionDate
            // 
            this.lbVersionDate.AutoSize = true;
            this.lbVersionDate.Location = new System.Drawing.Point(6, 102);
            this.lbVersionDate.Name = "lbVersionDate";
            this.lbVersionDate.Size = new System.Drawing.Size(68, 13);
            this.lbVersionDate.TabIndex = 6;
            this.lbVersionDate.Text = "Version Date";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(6, 76);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(42, 13);
            this.lbVersion.TabIndex = 4;
            this.lbVersion.Text = "Version";
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
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(6, 22);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(29, 13);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "Path";
            // 
            // txDevSources
            // 
            this.txDevSources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txDevSources.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txDevSources, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txDevSources, 5);
            this.txDevSources.Location = new System.Drawing.Point(159, 151);
            this.txDevSources.Mandatory = false;
            this.txDevSources.MandatoryErrorMessage = "Mandatory field";
            this.txDevSources.MaxLength = 250;
            this.txDevSources.MinLength = 0;
            this.txDevSources.Name = "txDevSources";
            this.txDevSources.NotMatchErrorMessage = "Not Valid";
            this.txDevSources.NumberOfDecimal = 2;
            this.txDevSources.RegularExpression = null;
            this.txDevSources.Size = new System.Drawing.Size(236, 20);
            this.txDevSources.TabIndex = 15;
            this.txDevSources.TooLongErrorMessage = "Too long";
            this.txDevSources.Validate = false;
            this.txDevSources.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // lbDevSources
            // 
            this.lbDevSources.AutoSize = true;
            this.lbDevSources.Location = new System.Drawing.Point(6, 154);
            this.lbDevSources.Name = "lbDevSources";
            this.lbDevSources.Size = new System.Drawing.Size(137, 13);
            this.lbDevSources.TabIndex = 14;
            this.lbDevSources.Text = "Development Sources Path";
            // 
            // txProdSources
            // 
            this.txProdSources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txProdSources.CurrentErrorProvider = this.synapseErrorProvider1;
            this.synapseErrorProvider1.SetIconAlignment(this.txProdSources, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.synapseErrorProvider1.SetIconPadding(this.txProdSources, 5);
            this.txProdSources.Location = new System.Drawing.Point(159, 177);
            this.txProdSources.Mandatory = false;
            this.txProdSources.MandatoryErrorMessage = "Mandatory field";
            this.txProdSources.MaxLength = 250;
            this.txProdSources.MinLength = 0;
            this.txProdSources.Name = "txProdSources";
            this.txProdSources.NotMatchErrorMessage = "Not Valid";
            this.txProdSources.NumberOfDecimal = 2;
            this.txProdSources.RegularExpression = null;
            this.txProdSources.Size = new System.Drawing.Size(236, 20);
            this.txProdSources.TabIndex = 17;
            this.txProdSources.TooLongErrorMessage = "Too long";
            this.txProdSources.Validate = false;
            this.txProdSources.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // lbProdSources
            // 
            this.lbProdSources.AutoSize = true;
            this.lbProdSources.Location = new System.Drawing.Point(6, 180);
            this.lbProdSources.Name = "lbProdSources";
            this.lbProdSources.Size = new System.Drawing.Size(125, 13);
            this.lbProdSources.TabIndex = 16;
            this.lbProdSources.Text = "Production Sources Path";
            // 
            // ckActive
            // 
            this.ckActive.AutoSize = true;
            this.ckActive.Location = new System.Drawing.Point(9, 211);
            this.ckActive.Name = "ckActive";
            this.ckActive.Size = new System.Drawing.Size(67, 17);
            this.ckActive.TabIndex = 18;
            this.ckActive.Text = "Is Active";
            this.ckActive.UseVisualStyleBackColor = true;
            // 
            // ckRequestable
            // 
            this.ckRequestable.AutoSize = true;
            this.ckRequestable.Location = new System.Drawing.Point(9, 234);
            this.ckRequestable.Name = "ckRequestable";
            this.ckRequestable.Size = new System.Drawing.Size(97, 17);
            this.ckRequestable.TabIndex = 19;
            this.ckRequestable.Text = "Is Requestable";
            this.ckRequestable.UseVisualStyleBackColor = true;
            // 
            // frmModule
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(439, 476);
            this.ControlBox = false;
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 1;
            this.Name = "frmModule";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Synapse Module";
            this.UpdateControls = true;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lbTechnicalName;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbVersionDate;
        private System.Windows.Forms.Label lbVersion;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
        private SynapseCore.Controls.SynapseTextBox txCategory;
        private SynapseCore.Controls.SynapseTextBox txVersionDate;
        private SynapseCore.Controls.SynapseTextBox txVersion;
        private SynapseCore.Controls.SynapseTextBox txTechnicalName;
        private SynapseCore.Controls.SynapseTextBox txPath;
        private System.Windows.Forms.CheckBox ckRequestable;
        private System.Windows.Forms.CheckBox ckActive;
        private SynapseCore.Controls.SynapseTextBox txProdSources;
        private System.Windows.Forms.Label lbProdSources;
        private SynapseCore.Controls.SynapseTextBox txDevSources;
        private System.Windows.Forms.Label lbDevSources;
    }
}