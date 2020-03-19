namespace SynapseReport.UserControls
{
    partial class missingTag
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
            this.lbTag = new System.Windows.Forms.Label();
            this.txTagValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbTag
            // 
            this.lbTag.AutoSize = true;
            this.lbTag.Location = new System.Drawing.Point(3, 6);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(35, 13);
            this.lbTag.TabIndex = 0;
            this.lbTag.Text = "label1";
            // 
            // txTagValue
            // 
            this.txTagValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTagValue.Location = new System.Drawing.Point(126, 3);
            this.txTagValue.Name = "txTagValue";
            this.txTagValue.Size = new System.Drawing.Size(275, 20);
            this.txTagValue.TabIndex = 1;
            // 
            // missingTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txTagValue);
            this.Controls.Add(this.lbTag);
            this.Name = "missingTag";
            this.Size = new System.Drawing.Size(404, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbTag;
        public System.Windows.Forms.TextBox txTagValue;

    }
}
