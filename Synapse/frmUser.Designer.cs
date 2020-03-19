namespace Synapse
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.cbCulture = new System.Windows.Forms.ComboBox();
            this.txLastName = new SynapseCore.Controls.SynapseTextBox();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            this.txFirstName = new SynapseCore.Controls.SynapseTextBox();
            this.txUserid = new SynapseCore.Controls.SynapseTextBox();
            this.lbCulture = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbUserid = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.cbCulture);
            this.gbDetails.Controls.Add(this.txLastName);
            this.gbDetails.Controls.Add(this.txFirstName);
            this.gbDetails.Controls.Add(this.txUserid);
            this.gbDetails.Controls.Add(this.lbCulture);
            this.gbDetails.Controls.Add(this.lbLastName);
            this.gbDetails.Controls.Add(this.lbFirstName);
            this.gbDetails.Controls.Add(this.lbUserid);
            this.gbDetails.Location = new System.Drawing.Point(12, 34);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(384, 129);
            this.gbDetails.TabIndex = 29;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "User\'s Details";
            // 
            // cbCulture
            // 
            this.cbCulture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCulture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCulture.FormattingEnabled = true;
            this.cbCulture.Location = new System.Drawing.Point(139, 99);
            this.cbCulture.Name = "cbCulture";
            this.cbCulture.Size = new System.Drawing.Size(225, 21);
            this.cbCulture.TabIndex = 12;
            // 
            // txLastName
            // 
            this.txLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txLastName.CurrentErrorProvider = this.synapseErrorProvider1;
            this.txLastName.Location = new System.Drawing.Point(139, 73);
            this.txLastName.Mandatory = true;
            this.txLastName.MandatoryErrorMessage = "Mandatory field";
            this.txLastName.MaxLength = 50;
            this.txLastName.MinLength = 0;
            this.txLastName.Name = "txLastName";
            this.txLastName.NotMatchErrorMessage = "Not Valid";
            this.txLastName.NumberOfDecimal = 2;
            this.txLastName.RegularExpression = null;
            this.txLastName.Size = new System.Drawing.Size(225, 20);
            this.txLastName.TabIndex = 11;
            this.txLastName.TooLongErrorMessage = "Too long";
            this.txLastName.Validate = false;
            this.txLastName.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // txFirstName
            // 
            this.txFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFirstName.CurrentErrorProvider = this.synapseErrorProvider1;
            this.txFirstName.Location = new System.Drawing.Point(139, 45);
            this.txFirstName.Mandatory = true;
            this.txFirstName.MandatoryErrorMessage = "Mandatory field";
            this.txFirstName.MaxLength = 50;
            this.txFirstName.MinLength = 0;
            this.txFirstName.Name = "txFirstName";
            this.txFirstName.NotMatchErrorMessage = "Not Valid";
            this.txFirstName.NumberOfDecimal = 2;
            this.txFirstName.RegularExpression = null;
            this.txFirstName.Size = new System.Drawing.Size(225, 20);
            this.txFirstName.TabIndex = 10;
            this.txFirstName.TooLongErrorMessage = "Too long";
            this.txFirstName.Validate = false;
            this.txFirstName.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // txUserid
            // 
            this.txUserid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txUserid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txUserid.CurrentErrorProvider = this.synapseErrorProvider1;
            this.txUserid.Location = new System.Drawing.Point(139, 19);
            this.txUserid.Mandatory = true;
            this.txUserid.MandatoryErrorMessage = "Mandatory field";
            this.txUserid.MaxLength = 50;
            this.txUserid.MinLength = 0;
            this.txUserid.Name = "txUserid";
            this.txUserid.NotMatchErrorMessage = "Not Valid";
            this.txUserid.NumberOfDecimal = 2;
            this.txUserid.RegularExpression = null;
            this.txUserid.Size = new System.Drawing.Size(225, 20);
            this.txUserid.TabIndex = 9;
            this.txUserid.TooLongErrorMessage = "Too long";
            this.txUserid.Validate = false;
            this.txUserid.Validation = SynapseCore.Controls.SynapseTextBoxValidation.Text;
            // 
            // lbCulture
            // 
            this.lbCulture.AutoSize = true;
            this.lbCulture.Location = new System.Drawing.Point(6, 102);
            this.lbCulture.Name = "lbCulture";
            this.lbCulture.Size = new System.Drawing.Size(40, 13);
            this.lbCulture.TabIndex = 6;
            this.lbCulture.Text = "Culture";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(6, 76);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(58, 13);
            this.lbLastName.TabIndex = 4;
            this.lbLastName.Text = "Last Name";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(6, 48);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(57, 13);
            this.lbFirstName.TabIndex = 2;
            this.lbFirstName.Text = "First Name";
            // 
            // lbUserid
            // 
            this.lbUserid.AutoSize = true;
            this.lbUserid.Location = new System.Drawing.Point(6, 22);
            this.lbUserid.Name = "lbUserid";
            this.lbUserid.Size = new System.Drawing.Size(37, 13);
            this.lbUserid.TabIndex = 0;
            this.lbUserid.Text = "Userid";
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
            this.toolStrip1.Size = new System.Drawing.Size(408, 31);
            this.toolStrip1.TabIndex = 30;
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
            this.btCancel.Location = new System.Drawing.Point(340, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(27, 19);
            this.btCancel.TabIndex = 32;
            this.btCancel.TabStop = false;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(307, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(27, 19);
            this.btOk.TabIndex = 31;
            this.btOk.TabStop = false;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // frmUser
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(408, 172);
            this.ControlBox = false;
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 1;
            this.Name = "frmUser";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
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
        private SynapseCore.Controls.SynapseTextBox txLastName;
        private SynapseCore.Controls.SynapseTextBox txFirstName;
        private SynapseCore.Controls.SynapseTextBox txUserid;
        private System.Windows.Forms.Label lbCulture;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbUserid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ComboBox cbCulture;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
    }
}