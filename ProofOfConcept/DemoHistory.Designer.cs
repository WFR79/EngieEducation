namespace ProofOfConcept
{
    partial class DemoHistory
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
            this.uc_EntityHistory1 = new SynapseCore.Controls.uc_EntityHistory();
            this.SuspendLayout();
            // 
            // uc_EntityHistory1
            // 
            this.uc_EntityHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_EntityHistory1.Location = new System.Drawing.Point(0, 0);
            this.uc_EntityHistory1.Name = "uc_EntityHistory1";
            this.uc_EntityHistory1.Size = new System.Drawing.Size(656, 482);
            this.uc_EntityHistory1.TabIndex = 0;
            // 
            // DemoHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 482);
            this.Controls.Add(this.uc_EntityHistory1);
            this.Name = "DemoHistory";
            this.Text = "DemoHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseCore.Controls.uc_EntityHistory uc_EntityHistory1;
    }
}