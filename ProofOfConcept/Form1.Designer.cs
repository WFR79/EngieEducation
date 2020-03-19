namespace ProofOfConcept
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.olvColumn1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn2 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn3 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn4 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn5 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn6 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn7 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn8 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn9 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn10 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.synapseListFilter1 = new SynapseCore.Controls.SynapseListFilter();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxExtended1 = new SynapseCore.Controls.RichTextBoxExtended();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Synapse Connection (Users)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "WSS  Connection (Applications)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dosiview  Connection (Agents)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(207, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(259, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Load...";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn6);
            this.objectListView1.AllColumns.Add(this.olvColumn7);
            this.objectListView1.AllColumns.Add(this.olvColumn8);
            this.objectListView1.AllColumns.Add(this.olvColumn9);
            this.objectListView1.AllColumns.Add(this.olvColumn10);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10});
            this.objectListView1.Location = new System.Drawing.Point(12, 182);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(1060, 206);
            this.objectListView1.TabIndex = 6;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "NUMAGT";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "NUMAGT";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "PRENOM";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Text = "Prénom";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "NOM";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Text = "Nom";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "ADRESSE";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Text = "Adresse";
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "CODPOST";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.Text = "CP";
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "VILLE";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.Text = "Ville";
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "D_NAI";
            this.olvColumn7.CellPadding = null;
            this.olvColumn7.Text = "Date Naissance";
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "SEXE";
            this.olvColumn8.CellPadding = null;
            this.olvColumn8.Text = "Sexe";
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "AGE";
            this.olvColumn9.CellPadding = null;
            this.olvColumn9.Text = "Age";
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "Typ_emp";
            this.olvColumn10.CellPadding = null;
            this.olvColumn10.Text = "Type";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 9);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // synapseListFilter1
            // 
            this.synapseListFilter1.FilterOnTheFly = true;
            this.synapseListFilter1.HideExport = false;
            this.synapseListFilter1.HideFilter = false;
            this.synapseListFilter1.HidePrint = false;
            this.synapseListFilter1.HideSaveConfig = true;
            this.synapseListFilter1.HideSearch = false;
            this.synapseListFilter1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.synapseListFilter1.ListID = "Form1#objectListView1";
            this.synapseListFilter1.ListView = this.objectListView1;
            this.synapseListFilter1.Location = new System.Drawing.Point(0, 24);
            this.synapseListFilter1.Name = "synapseListFilter1";
            this.synapseListFilter1.Size = new System.Drawing.Size(1084, 31);
            this.synapseListFilter1.TabIndex = 7;
            this.synapseListFilter1.Text = "synapseListFilter1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // richTextBoxExtended1
            // 
            this.richTextBoxExtended1.AcceptsTab = false;
            this.richTextBoxExtended1.AutoWordSelection = true;
            this.richTextBoxExtended1.DetectURLs = true;
            this.richTextBoxExtended1.Location = new System.Drawing.Point(584, 64);
            this.richTextBoxExtended1.Name = "richTextBoxExtended1";
            this.richTextBoxExtended1.ReadOnly = false;
            // 
            // 
            // 
            this.richTextBoxExtended1.RichTextBox.AutoWordSelection = true;
            this.richTextBoxExtended1.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExtended1.RichTextBox.Location = new System.Drawing.Point(0, 26);
            this.richTextBoxExtended1.RichTextBox.Name = "rtb1";
            this.richTextBoxExtended1.RichTextBox.Size = new System.Drawing.Size(775, 83);
            this.richTextBoxExtended1.RichTextBox.TabIndex = 1;
            this.richTextBoxExtended1.ShowBold = true;
            this.richTextBoxExtended1.ShowCenterJustify = true;
            this.richTextBoxExtended1.ShowColors = true;
            this.richTextBoxExtended1.ShowCopy = true;
            this.richTextBoxExtended1.ShowCut = true;
            this.richTextBoxExtended1.ShowFont = true;
            this.richTextBoxExtended1.ShowFontSize = true;
            this.richTextBoxExtended1.ShowItalic = true;
            this.richTextBoxExtended1.ShowLeftJustify = true;
            this.richTextBoxExtended1.ShowOpen = true;
            this.richTextBoxExtended1.ShowPaste = true;
            this.richTextBoxExtended1.ShowRedo = true;
            this.richTextBoxExtended1.ShowRightJustify = true;
            this.richTextBoxExtended1.ShowSave = true;
            this.richTextBoxExtended1.ShowStamp = true;
            this.richTextBoxExtended1.ShowStrikeout = true;
            this.richTextBoxExtended1.ShowToolBarText = false;
            this.richTextBoxExtended1.ShowUnderline = true;
            this.richTextBoxExtended1.ShowUndo = true;
            this.richTextBoxExtended1.Size = new System.Drawing.Size(775, 109);
            this.richTextBoxExtended1.StampAction = SynapseCore.Controls.StampActions.EditedBy;
            this.richTextBoxExtended1.StampColor = System.Drawing.Color.Blue;
            this.richTextBoxExtended1.TabIndex = 11;
            // 
            // 
            // 
            this.richTextBoxExtended1.Toolbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.richTextBoxExtended1.Toolbar.ButtonSize = new System.Drawing.Size(16, 16);
            this.richTextBoxExtended1.Toolbar.Divider = false;
            this.richTextBoxExtended1.Toolbar.DropDownArrows = true;
            this.richTextBoxExtended1.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxExtended1.Toolbar.Name = "tb1";
            this.richTextBoxExtended1.Toolbar.ShowToolTips = true;
            this.richTextBoxExtended1.Toolbar.Size = new System.Drawing.Size(775, 26);
            this.richTextBoxExtended1.Toolbar.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Connections list";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(473, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 20);
            this.button4.TabIndex = 14;
            this.button4.Text = "Load";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(473, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 20);
            this.button5.TabIndex = 15;
            this.button5.Text = "Modify";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(473, 110);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 20);
            this.button6.TabIndex = 16;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(473, 133);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 20);
            this.button7.TabIndex = 17;
            this.button7.Text = "Rollback";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(473, 155);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 20);
            this.button8.TabIndex = 18;
            this.button8.Text = "IsDirty";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(617, 122);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 19;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(698, 122);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 413);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBoxExtended1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.synapseListFilter1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 1;
            this.Name = "Form1";
            this.SecurityEnabled = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private SynapseAdvancedControls.ObjectListView objectListView1;
        private SynapseAdvancedControls.OLVColumn olvColumn1;
        private SynapseAdvancedControls.OLVColumn olvColumn2;
        private SynapseAdvancedControls.OLVColumn olvColumn3;
        private SynapseAdvancedControls.OLVColumn olvColumn4;
        private SynapseAdvancedControls.OLVColumn olvColumn5;
        private SynapseAdvancedControls.OLVColumn olvColumn6;
        private SynapseAdvancedControls.OLVColumn olvColumn7;
        private SynapseAdvancedControls.OLVColumn olvColumn8;
        private SynapseAdvancedControls.OLVColumn olvColumn9;
        private SynapseCore.Controls.SynapseListFilter synapseListFilter1;
        private SynapseAdvancedControls.OLVColumn olvColumn10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private SynapseCore.Controls.RichTextBoxExtended richTextBoxExtended1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

