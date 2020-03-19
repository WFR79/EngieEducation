namespace SynapseReport.Forms
{
    partial class frmColorize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColorize));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gbFieldColor = new System.Windows.Forms.GroupBox();
            this.lblColorValue = new System.Windows.Forms.Label();
            this.txValue = new System.Windows.Forms.TextBox();
            this.lblColorConvert = new System.Windows.Forms.Label();
            this.cbConvertTo = new System.Windows.Forms.ComboBox();
            this.lblColorCondition = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.lblColorChoose = new System.Windows.Forms.Label();
            this.btColorChoose = new System.Windows.Forms.Label();
            this.lblColorWhat = new System.Windows.Forms.Label();
            this.cbColorWhat = new System.Windows.Forms.ComboBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.cbDateAdd = new System.Windows.Forms.ComboBox();
            this.txDateAddValue = new System.Windows.Forms.TextBox();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gbFieldColor.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlValue.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(633, 31);
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
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(150, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(36, 28);
            this.btOk.TabIndex = 24;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(192, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(36, 28);
            this.btCancel.TabIndex = 28;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // gbFieldColor
            // 
            this.gbFieldColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFieldColor.Controls.Add(this.pnlDate);
            this.gbFieldColor.Controls.Add(this.pnlValue);
            this.gbFieldColor.Controls.Add(this.lblColorConvert);
            this.gbFieldColor.Controls.Add(this.cbConvertTo);
            this.gbFieldColor.Controls.Add(this.lblColorCondition);
            this.gbFieldColor.Controls.Add(this.cbCondition);
            this.gbFieldColor.Controls.Add(this.lblColorChoose);
            this.gbFieldColor.Controls.Add(this.btColorChoose);
            this.gbFieldColor.Controls.Add(this.lblColorWhat);
            this.gbFieldColor.Controls.Add(this.cbColorWhat);
            this.gbFieldColor.Location = new System.Drawing.Point(12, 34);
            this.gbFieldColor.Name = "gbFieldColor";
            this.gbFieldColor.Size = new System.Drawing.Size(609, 80);
            this.gbFieldColor.TabIndex = 29;
            this.gbFieldColor.TabStop = false;
            this.gbFieldColor.Text = "Colorize";
            // 
            // lblColorValue
            // 
            this.lblColorValue.AutoSize = true;
            this.lblColorValue.Location = new System.Drawing.Point(0, 8);
            this.lblColorValue.Name = "lblColorValue";
            this.lblColorValue.Size = new System.Drawing.Size(34, 13);
            this.lblColorValue.TabIndex = 52;
            this.lblColorValue.Text = "Value";
            // 
            // txValue
            // 
            this.txValue.Location = new System.Drawing.Point(3, 22);
            this.txValue.Name = "txValue";
            this.txValue.Size = new System.Drawing.Size(263, 20);
            this.txValue.TabIndex = 51;
            // 
            // lblColorConvert
            // 
            this.lblColorConvert.AutoSize = true;
            this.lblColorConvert.Location = new System.Drawing.Point(133, 27);
            this.lblColorConvert.Name = "lblColorConvert";
            this.lblColorConvert.Size = new System.Drawing.Size(56, 13);
            this.lblColorConvert.TabIndex = 50;
            this.lblColorConvert.Text = "Field Type";
            // 
            // cbConvertTo
            // 
            this.cbConvertTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvertTo.FormattingEnabled = true;
            this.cbConvertTo.Items.AddRange(new object[] {
            "",
            "ASC",
            "DESC"});
            this.cbConvertTo.Location = new System.Drawing.Point(136, 43);
            this.cbConvertTo.Name = "cbConvertTo";
            this.cbConvertTo.Size = new System.Drawing.Size(116, 21);
            this.cbConvertTo.TabIndex = 49;
            this.cbConvertTo.SelectedIndexChanged += new System.EventHandler(this.cbConvertTo_SelectedIndexChanged);
            // 
            // lblColorCondition
            // 
            this.lblColorCondition.AutoSize = true;
            this.lblColorCondition.Location = new System.Drawing.Point(255, 27);
            this.lblColorCondition.Name = "lblColorCondition";
            this.lblColorCondition.Size = new System.Drawing.Size(51, 13);
            this.lblColorCondition.TabIndex = 48;
            this.lblColorCondition.Text = "Condition";
            // 
            // cbCondition
            // 
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "",
            "ASC",
            "DESC"});
            this.cbCondition.Location = new System.Drawing.Point(258, 43);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(70, 21);
            this.cbCondition.TabIndex = 47;
            // 
            // lblColorChoose
            // 
            this.lblColorChoose.AutoSize = true;
            this.lblColorChoose.Location = new System.Drawing.Point(79, 27);
            this.lblColorChoose.Name = "lblColorChoose";
            this.lblColorChoose.Size = new System.Drawing.Size(31, 13);
            this.lblColorChoose.TabIndex = 46;
            this.lblColorChoose.Text = "Color";
            // 
            // btColorChoose
            // 
            this.btColorChoose.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btColorChoose.Location = new System.Drawing.Point(82, 43);
            this.btColorChoose.Name = "btColorChoose";
            this.btColorChoose.Size = new System.Drawing.Size(48, 21);
            this.btColorChoose.TabIndex = 45;
            this.btColorChoose.Click += new System.EventHandler(this.btColorChoose_Click);
            // 
            // lblColorWhat
            // 
            this.lblColorWhat.AutoSize = true;
            this.lblColorWhat.Location = new System.Drawing.Point(6, 27);
            this.lblColorWhat.Name = "lblColorWhat";
            this.lblColorWhat.Size = new System.Drawing.Size(33, 13);
            this.lblColorWhat.TabIndex = 44;
            this.lblColorWhat.Text = "What";
            // 
            // cbColorWhat
            // 
            this.cbColorWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWhat.FormattingEnabled = true;
            this.cbColorWhat.Items.AddRange(new object[] {
            "",
            "ASC",
            "DESC"});
            this.cbColorWhat.Location = new System.Drawing.Point(6, 43);
            this.cbColorWhat.Name = "cbColorWhat";
            this.cbColorWhat.Size = new System.Drawing.Size(70, 21);
            this.cbColorWhat.TabIndex = 43;
            this.cbColorWhat.SelectedIndexChanged += new System.EventHandler(this.cbColorWhat_SelectedIndexChanged);
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.txDateAddValue);
            this.pnlDate.Controls.Add(this.cbDateAdd);
            this.pnlDate.Controls.Add(this.lblDate1);
            this.pnlDate.Location = new System.Drawing.Point(331, 80);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(269, 45);
            this.pnlDate.TabIndex = 53;
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Location = new System.Drawing.Point(3, 25);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(81, 13);
            this.lblDate1.TabIndex = 53;
            this.lblDate1.Text = "DateTime.Now.";
            // 
            // cbDateAdd
            // 
            this.cbDateAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateAdd.FormattingEnabled = true;
            this.cbDateAdd.Items.AddRange(new object[] {
            "",
            "ASC",
            "DESC"});
            this.cbDateAdd.Location = new System.Drawing.Point(83, 22);
            this.cbDateAdd.Name = "cbDateAdd";
            this.cbDateAdd.Size = new System.Drawing.Size(99, 21);
            this.cbDateAdd.TabIndex = 54;
            // 
            // txDateAddValue
            // 
            this.txDateAddValue.Location = new System.Drawing.Point(188, 22);
            this.txDateAddValue.MaxLength = 5;
            this.txDateAddValue.Name = "txDateAddValue";
            this.txDateAddValue.Size = new System.Drawing.Size(78, 20);
            this.txDateAddValue.TabIndex = 56;
            // 
            // pnlValue
            // 
            this.pnlValue.Controls.Add(this.txValue);
            this.pnlValue.Controls.Add(this.lblColorValue);
            this.pnlValue.Location = new System.Drawing.Point(331, 19);
            this.pnlValue.Name = "pnlValue";
            this.pnlValue.Size = new System.Drawing.Size(269, 45);
            this.pnlValue.TabIndex = 54;
            // 
            // frmColorize
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(633, 126);
            this.ControlBox = false;
            this.Controls.Add(this.gbFieldColor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 2;
            this.Name = "frmColorize";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmColorize";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frmColorize_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbFieldColor.ResumeLayout(false);
            this.gbFieldColor.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlValue.ResumeLayout(false);
            this.pnlValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox gbFieldColor;
        private System.Windows.Forms.Label lblColorValue;
        private System.Windows.Forms.TextBox txValue;
        private System.Windows.Forms.Label lblColorConvert;
        private System.Windows.Forms.ComboBox cbConvertTo;
        private System.Windows.Forms.Label lblColorCondition;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label lblColorChoose;
        private System.Windows.Forms.Label btColorChoose;
        private System.Windows.Forms.Label lblColorWhat;
        private System.Windows.Forms.ComboBox cbColorWhat;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.TextBox txDateAddValue;
        private System.Windows.Forms.ComboBox cbDateAdd;
        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Panel pnlValue;
    }
}