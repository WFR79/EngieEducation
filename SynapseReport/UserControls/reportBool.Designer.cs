namespace SynapseReport.UserControls
{
    partial class reportBool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportBool));
            this.lbLabel = new System.Windows.Forms.Label();
            this.ckBoolean = new System.Windows.Forms.CheckBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(0, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(147, 23);
            this.lbLabel.TabIndex = 3;
            this.lbLabel.Text = "label1";
            this.lbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckBoolean
            // 
            this.ckBoolean.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBoolean.Checked = true;
            this.ckBoolean.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckBoolean.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckBoolean.ImageKey = "(none)";
            this.ckBoolean.ImageList = this.imageList;
            this.ckBoolean.Location = new System.Drawing.Point(3, 26);
            this.ckBoolean.Name = "ckBoolean";
            this.ckBoolean.Size = new System.Drawing.Size(147, 24);
            this.ckBoolean.TabIndex = 4;
            this.ckBoolean.Text = "Indeterminate";
            this.ckBoolean.ThreeState = true;
            this.ckBoolean.UseVisualStyleBackColor = true;
            this.ckBoolean.CheckStateChanged += new System.EventHandler(this.ckBoolean_CheckStateChanged);
            this.ckBoolean.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ckBoolean_KeyUp);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "True");
            this.imageList.Images.SetKeyName(1, "False");
            // 
            // reportBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckBoolean);
            this.Controls.Add(this.lbLabel);
            this.Name = "reportBool";
            this.Size = new System.Drawing.Size(150, 51);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbLabel;
        public System.Windows.Forms.CheckBox ckBoolean;
        private System.Windows.Forms.ImageList imageList;
    }
}
