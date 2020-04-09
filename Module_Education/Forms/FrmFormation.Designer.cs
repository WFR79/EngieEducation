namespace Module_Education.Forms
{
    partial class FrmFormation
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
            this.btnAddFormations = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.l_PopUp = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.l_PopUp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFormations
            // 
            this.btnAddFormations.Location = new System.Drawing.Point(64, 375);
            this.btnAddFormations.Name = "btnAddFormations";
            this.btnAddFormations.Size = new System.Drawing.Size(135, 23);
            this.btnAddFormations.TabIndex = 1;
            this.btnAddFormations.Text = "Ajouter formation(s)";
            this.btnAddFormations.UseVisualStyleBackColor = true;
            this.btnAddFormations.Click += new System.EventHandler(this.btnAddFormations_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // l_PopUp
            // 
            this.l_PopUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.l_PopUp.FilterAndSortEnabled = true;
            this.l_PopUp.Location = new System.Drawing.Point(78, 32);
            this.l_PopUp.Name = "l_PopUp";
            this.l_PopUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.l_PopUp.Size = new System.Drawing.Size(271, 315);
            this.l_PopUp.TabIndex = 3;
            // 
            // FrmFormation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.ControlBox = false;
            this.Controls.Add(this.l_PopUp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFormations);
            this.Name = "FrmFormation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFormation";
            ((System.ComponentModel.ISupportInitialize)(this.l_PopUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddFormations;
        private System.Windows.Forms.Button btnCancel;
        private Zuby.ADGV.AdvancedDataGridView l_PopUp;
    }
}