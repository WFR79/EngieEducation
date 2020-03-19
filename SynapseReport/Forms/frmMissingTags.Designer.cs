namespace SynapseReport.Forms
{
    partial class frmMissingTags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMissingTags));
            this.pnlMissingTags = new System.Windows.Forms.FlowLayoutPanel();
            this.btOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlMissingTags
            // 
            this.pnlMissingTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMissingTags.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlMissingTags.Location = new System.Drawing.Point(12, 12);
            this.pnlMissingTags.Name = "pnlMissingTags";
            this.pnlMissingTags.Size = new System.Drawing.Size(435, 247);
            this.pnlMissingTags.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(178, 265);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(103, 42);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ok";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // frmMissingTags
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 312);
            this.ControlBox = false;
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.pnlMissingTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 2;
            this.Name = "frmMissingTags";
            this.ShowMenu = false;
            this.Text = "frmMissingTags";
            this.UpdateControls = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        public System.Windows.Forms.FlowLayoutPanel pnlMissingTags;
    }
}