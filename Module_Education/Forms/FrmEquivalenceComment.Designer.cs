namespace Module_Education.Forms
{
    partial class FrmEquivalenceComment
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddFormations = new System.Windows.Forms.Button();
            this.lblComments = new System.Windows.Forms.Label();
            this.tbCommentEquivalence = new Module_Education.Classes.TextBoxExtensions();
            this.lblFormationEquivalence = new System.Windows.Forms.Label();
            this.l_PopUp = new Module_Education.Classes.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.l_PopUp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(228, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 43);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddFormations
            // 
            this.btnAddFormations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnAddFormations.FlatAppearance.BorderSize = 0;
            this.btnAddFormations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFormations.Font = new System.Drawing.Font("Arial", 10.25F);
            this.btnAddFormations.ForeColor = System.Drawing.Color.White;
            this.btnAddFormations.Location = new System.Drawing.Point(54, 509);
            this.btnAddFormations.Name = "btnAddFormations";
            this.btnAddFormations.Size = new System.Drawing.Size(135, 43);
            this.btnAddFormations.TabIndex = 4;
            this.btnAddFormations.Text = "Enregistrer";
            this.btnAddFormations.UseVisualStyleBackColor = false;
            this.btnAddFormations.Click += new System.EventHandler(this.btnAddFormations_Click);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblComments.Location = new System.Drawing.Point(21, 378);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(179, 16);
            this.lblComments.TabIndex = 8;
            this.lblComments.Text = "Commentaires équivalence";
            // 
            // tbCommentEquivalence
            // 
            this.tbCommentEquivalence.Location = new System.Drawing.Point(33, 405);
            this.tbCommentEquivalence.Multiline = true;
            this.tbCommentEquivalence.Name = "tbCommentEquivalence";
            this.tbCommentEquivalence.Size = new System.Drawing.Size(397, 76);
            this.tbCommentEquivalence.TabIndex = 7;
            this.tbCommentEquivalence.TextChanged += new System.EventHandler(this.tbCommentEquivalence_TextChanged);
            // 
            // lblFormationEquivalence
            // 
            this.lblFormationEquivalence.AutoSize = true;
            this.lblFormationEquivalence.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblFormationEquivalence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblFormationEquivalence.Location = new System.Drawing.Point(30, 23);
            this.lblFormationEquivalence.Name = "lblFormationEquivalence";
            this.lblFormationEquivalence.Size = new System.Drawing.Size(243, 16);
            this.lblFormationEquivalence.TabIndex = 9;
            this.lblFormationEquivalence.Text = "Sélectionnez la formation équivalente";
            // 
            // l_PopUp
            // 
            this.l_PopUp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.l_PopUp.BackgroundColor = System.Drawing.Color.White;
            this.l_PopUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.l_PopUp.FilterAndSortEnabled = true;
            this.l_PopUp.Location = new System.Drawing.Point(33, 42);
            this.l_PopUp.MultiSelect = false;
            this.l_PopUp.Name = "l_PopUp";
            this.l_PopUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.l_PopUp.ShowEditingIcon = false;
            this.l_PopUp.Size = new System.Drawing.Size(388, 331);
            this.l_PopUp.TabIndex = 10;
            // 
            // FrmEquivalenceComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(444, 577);
            this.Controls.Add(this.l_PopUp);
            this.Controls.Add(this.lblFormationEquivalence);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.tbCommentEquivalence);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFormations);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEquivalenceComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmEquivalenceComment";
            ((System.ComponentModel.ISupportInitialize)(this.l_PopUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddFormations;
        private Classes.TextBoxExtensions tbCommentEquivalence;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblFormationEquivalence;
        private Classes.AdvancedDataGridView l_PopUp;
    }
}