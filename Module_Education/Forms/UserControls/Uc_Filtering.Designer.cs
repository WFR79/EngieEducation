namespace Module_Education.UserControls
{
    partial class Uc_Filtering
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
            this.tbFiltre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFiltre
            // 
            this.tbFiltre.Location = new System.Drawing.Point(0, 3);
            this.tbFiltre.Name = "tbFiltre";
            this.tbFiltre.Size = new System.Drawing.Size(261, 20);
            this.tbFiltre.TabIndex = 0;
            this.tbFiltre.TextChanged += new System.EventHandler(this.FilterChanged);
            // 
            // Uc_Filtering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFiltre);
            this.Name = "Uc_Filtering";
            this.Size = new System.Drawing.Size(267, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFiltre;
    }
}
