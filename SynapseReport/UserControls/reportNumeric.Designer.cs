namespace SynapseReport.UserControls
{
    partial class reportNumeric
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
            this.lbLabel = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.UpDown1 = new System.Windows.Forms.NumericUpDown();
            this.UpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(0, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(119, 23);
            this.lbLabel.TabIndex = 16;
            this.lbLabel.Text = "label1";
            this.lbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBox1
            // 
            this.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(0, 26);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(50, 21);
            this.ComboBox1.TabIndex = 0;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            this.ComboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // ComboBox2
            // 
            this.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(0, 53);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(50, 21);
            this.ComboBox2.TabIndex = 2;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedValueChanged);
            this.ComboBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // UpDown1
            // 
            this.UpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDown1.Location = new System.Drawing.Point(56, 27);
            this.UpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.UpDown1.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.UpDown1.Name = "UpDown1";
            this.UpDown1.Size = new System.Drawing.Size(63, 20);
            this.UpDown1.TabIndex = 1;
            this.UpDown1.Enter += new System.EventHandler(this.UpDown_Enter);
            this.UpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // UpDown2
            // 
            this.UpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDown2.Location = new System.Drawing.Point(56, 54);
            this.UpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.UpDown2.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.UpDown2.Name = "UpDown2";
            this.UpDown2.Size = new System.Drawing.Size(63, 20);
            this.UpDown2.TabIndex = 3;
            this.UpDown2.Enter += new System.EventHandler(this.UpDown_Enter);
            this.UpDown2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // reportNumeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpDown2);
            this.Controls.Add(this.UpDown1);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.lbLabel);
            this.Name = "reportNumeric";
            this.Size = new System.Drawing.Size(119, 78);
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbLabel;
        public System.Windows.Forms.ComboBox ComboBox1;
        public System.Windows.Forms.ComboBox ComboBox2;
        public System.Windows.Forms.NumericUpDown UpDown1;
        public System.Windows.Forms.NumericUpDown UpDown2;
    }
}
