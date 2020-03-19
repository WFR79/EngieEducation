namespace SynapseReport.Forms
{
    partial class frmSelectModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectModule));
            this.lbModule = new System.Windows.Forms.Label();
            this.cb_Module = new System.Windows.Forms.ComboBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbSelect = new System.Windows.Forms.GroupBox();
            this.gbSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbModule
            // 
            this.lbModule.AutoSize = true;
            this.lbModule.Location = new System.Drawing.Point(6, 22);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(42, 13);
            this.lbModule.TabIndex = 13;
            this.lbModule.Text = "Module";
            // 
            // cb_Module
            // 
            this.cb_Module.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Module.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Module.FormattingEnabled = true;
            this.cb_Module.Location = new System.Drawing.Point(89, 19);
            this.cb_Module.Name = "cb_Module";
            this.cb_Module.Size = new System.Drawing.Size(313, 21);
            this.cb_Module.Sorted = true;
            this.cb_Module.TabIndex = 12;
            // 
            // btOk
            // 
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(108, 72);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(95, 36);
            this.btOk.TabIndex = 14;
            this.btOk.Text = "Ok";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(209, 72);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(95, 35);
            this.btCancel.TabIndex = 15;
            this.btCancel.Text = "Cancel";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbSelect
            // 
            this.gbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelect.Controls.Add(this.btCancel);
            this.gbSelect.Controls.Add(this.lbModule);
            this.gbSelect.Controls.Add(this.btOk);
            this.gbSelect.Controls.Add(this.cb_Module);
            this.gbSelect.Location = new System.Drawing.Point(7, 5);
            this.gbSelect.Name = "gbSelect";
            this.gbSelect.Size = new System.Drawing.Size(408, 114);
            this.gbSelect.TabIndex = 16;
            this.gbSelect.TabStop = false;
            this.gbSelect.Text = "Select a Module";
            // 
            // frmSelectModule
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(427, 131);
            this.ControlBox = false;
            this.Controls.Add(this.gbSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ModuleID = 2;
            this.Name = "frmSelectModule";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Module Selection";
            this.UpdateControls = true;
            this.gbSelect.ResumeLayout(false);
            this.gbSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbModule;
        private System.Windows.Forms.ComboBox cb_Module;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox gbSelect;
    }
}