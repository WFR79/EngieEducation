namespace SynapseReport.UserControls
{
    partial class reportPeriod
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
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.yearFrom = new System.Windows.Forms.ComboBox();
            this.monthFrom = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.yearTo = new System.Windows.Forms.ComboBox();
            this.monthTo = new System.Windows.Forms.ComboBox();
            this.lbLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComboBox
            // 
            this.ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(0, 26);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(127, 21);
            this.ComboBox.TabIndex = 10;
            this.ComboBox.SelectedValueChanged += new System.EventHandler(this.ComboBox_SelectedValueChanged);
            // 
            // yearFrom
            // 
            this.yearFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.yearFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.yearFrom.FormattingEnabled = true;
            this.yearFrom.Location = new System.Drawing.Point(133, 26);
            this.yearFrom.Name = "yearFrom";
            this.yearFrom.Size = new System.Drawing.Size(64, 21);
            this.yearFrom.TabIndex = 11;
            // 
            // monthFrom
            // 
            this.monthFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.monthFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.monthFrom.FormattingEnabled = true;
            this.monthFrom.Location = new System.Drawing.Point(203, 26);
            this.monthFrom.Name = "monthFrom";
            this.monthFrom.Size = new System.Drawing.Size(44, 21);
            this.monthFrom.TabIndex = 12;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.BackColor = System.Drawing.Color.White;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl2.Location = new System.Drawing.Point(0, 50);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(127, 21);
            this.lbl2.TabIndex = 15;
            this.lbl2.Text = "et";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yearTo
            // 
            this.yearTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.yearTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.yearTo.FormattingEnabled = true;
            this.yearTo.Location = new System.Drawing.Point(133, 50);
            this.yearTo.Name = "yearTo";
            this.yearTo.Size = new System.Drawing.Size(64, 21);
            this.yearTo.TabIndex = 16;
            // 
            // monthTo
            // 
            this.monthTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.monthTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.monthTo.FormattingEnabled = true;
            this.monthTo.Location = new System.Drawing.Point(203, 51);
            this.monthTo.Name = "monthTo";
            this.monthTo.Size = new System.Drawing.Size(44, 21);
            this.monthTo.TabIndex = 17;
            // 
            // lbLabel
            // 
            this.lbLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbLabel.Location = new System.Drawing.Point(0, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(250, 23);
            this.lbLabel.TabIndex = 18;
            this.lbLabel.Text = "label1";
            this.lbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.monthTo);
            this.Controls.Add(this.yearTo);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.monthFrom);
            this.Controls.Add(this.yearFrom);
            this.Controls.Add(this.ComboBox);
            this.Name = "reportPeriod";
            this.Size = new System.Drawing.Size(250, 78);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox ComboBox;
        internal System.Windows.Forms.ComboBox yearFrom;
        internal System.Windows.Forms.ComboBox monthFrom;
        internal System.Windows.Forms.Label lbl2;
        internal System.Windows.Forms.ComboBox yearTo;
        internal System.Windows.Forms.ComboBox monthTo;
        public System.Windows.Forms.Label lbLabel;
    }
}
