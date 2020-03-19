namespace SynapseReport.UserControls
{
    partial class reportDate
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
            this.ckNull = new System.Windows.Forms.CheckBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.lbLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckNull
            // 
            this.ckNull.Location = new System.Drawing.Point(0, 79);
            this.ckNull.Name = "ckNull";
            this.ckNull.Size = new System.Drawing.Size(247, 20);
            this.ckNull.TabIndex = 14;
            this.ckNull.Text = "Include Empty Dates";
            this.ckNull.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.BackColor = System.Drawing.Color.White;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl2.Location = new System.Drawing.Point(0, 53);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(156, 21);
            this.lbl2.TabIndex = 13;
            this.lbl2.Text = "and ";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ComboBox.Size = new System.Drawing.Size(156, 21);
            this.ComboBox.TabIndex = 12;
            this.ComboBox.SelectedValueChanged += new System.EventHandler(this.ComboBox_SelectedValueChanged);
            this.ComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            // 
            // Date2
            // 
            this.Date2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date2.CustomFormat = "dd/MM/yyyy";
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date2.Location = new System.Drawing.Point(162, 53);
            this.Date2.Name = "Date2";
            this.Date2.Size = new System.Drawing.Size(88, 20);
            this.Date2.TabIndex = 11;
            // 
            // Date1
            // 
            this.Date1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date1.CustomFormat = "dd/MM/yyyy";
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Date1.Location = new System.Drawing.Point(162, 27);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(88, 20);
            this.Date1.TabIndex = 10;
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(0, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(250, 23);
            this.lbLabel.TabIndex = 15;
            this.lbLabel.Text = "label1";
            this.lbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.ckNull);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.Date2);
            this.Controls.Add(this.Date1);
            this.Name = "reportDate";
            this.Size = new System.Drawing.Size(250, 98);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox ckNull;
        public System.Windows.Forms.Label lbl2;
        public System.Windows.Forms.ComboBox ComboBox;
        public System.Windows.Forms.DateTimePicker Date2;
        public System.Windows.Forms.DateTimePicker Date1;
        public System.Windows.Forms.Label lbLabel;

    }
}
