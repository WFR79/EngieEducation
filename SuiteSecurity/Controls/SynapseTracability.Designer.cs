namespace SynapseCore.Controls
{
    partial class SynapseTracability
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynapseTracability));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbTracability = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbExpand = new System.Windows.Forms.ToolStripButton();
            this.tsbCollapse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.txFreeText = new System.Windows.Forms.TextBox();
            this.lbFreeText = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.btApply = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.lbObject = new System.Windows.Forms.Label();
            this.cbObject = new System.Windows.Forms.ComboBox();
            this.lbDateTo = new System.Windows.Forms.Label();
            this.lbDateFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.treeLog = new SynapseAdvancedControls.TreeListView();
            this.colObjectName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colObjectValue = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colAction = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colWho = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colWhen = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colOld = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colNew = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.gbTracability.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeLog)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "new");
            this.imageList1.Images.SetKeyName(1, "edit");
            this.imageList1.Images.SetKeyName(2, "delete");
            this.imageList1.Images.SetKeyName(3, "apply");
            this.imageList1.Images.SetKeyName(4, "reset");
            // 
            // gbTracability
            // 
            this.gbTracability.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTracability.Controls.Add(this.toolStrip2);
            this.gbTracability.Controls.Add(this.treeLog);
            this.gbTracability.Location = new System.Drawing.Point(0, 117);
            this.gbTracability.Name = "gbTracability";
            this.gbTracability.Size = new System.Drawing.Size(1078, 218);
            this.gbTracability.TabIndex = 45;
            this.gbTracability.TabStop = false;
            this.gbTracability.Text = "Trace List";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExpand,
            this.tsbCollapse,
            this.toolStripSeparator4,
            this.tsbPrint});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1072, 31);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 44;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbExpand
            // 
            this.tsbExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExpand.Image = ((System.Drawing.Image)(resources.GetObject("tsbExpand.Image")));
            this.tsbExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpand.Name = "tsbExpand";
            this.tsbExpand.Size = new System.Drawing.Size(28, 28);
            this.tsbExpand.Text = "Expand";
            this.tsbExpand.Click += new System.EventHandler(this.tsbExpand_Click);
            // 
            // tsbCollapse
            // 
            this.tsbCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCollapse.Image = ((System.Drawing.Image)(resources.GetObject("tsbCollapse.Image")));
            this.tsbCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCollapse.Name = "tsbCollapse";
            this.tsbCollapse.Size = new System.Drawing.Size(28, 28);
            this.tsbCollapse.Text = "Collapse";
            this.tsbCollapse.Click += new System.EventHandler(this.tsbCollapse_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(28, 28);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.txFreeText);
            this.gbFilter.Controls.Add(this.lbFreeText);
            this.gbFilter.Controls.Add(this.lbValue);
            this.gbFilter.Controls.Add(this.cbValue);
            this.gbFilter.Controls.Add(this.btApply);
            this.gbFilter.Controls.Add(this.btReset);
            this.gbFilter.Controls.Add(this.lbObject);
            this.gbFilter.Controls.Add(this.cbObject);
            this.gbFilter.Controls.Add(this.lbDateTo);
            this.gbFilter.Controls.Add(this.lbDateFrom);
            this.gbFilter.Controls.Add(this.dtTo);
            this.gbFilter.Controls.Add(this.dtFrom);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilter.Location = new System.Drawing.Point(0, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1078, 111);
            this.gbFilter.TabIndex = 46;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filters";
            // 
            // txFreeText
            // 
            this.txFreeText.Location = new System.Drawing.Point(618, 20);
            this.txFreeText.Name = "txFreeText";
            this.txFreeText.Size = new System.Drawing.Size(193, 20);
            this.txFreeText.TabIndex = 4;
            this.txFreeText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // lbFreeText
            // 
            this.lbFreeText.AutoSize = true;
            this.lbFreeText.Location = new System.Drawing.Point(521, 23);
            this.lbFreeText.Name = "lbFreeText";
            this.lbFreeText.Size = new System.Drawing.Size(52, 13);
            this.lbFreeText.TabIndex = 10;
            this.lbFreeText.Text = "Free Text";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Location = new System.Drawing.Point(197, 49);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(68, 13);
            this.lbValue.TabIndex = 9;
            this.lbValue.Text = "Object Value";
            // 
            // cbValue
            // 
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(322, 46);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(193, 21);
            this.cbValue.Sorted = true;
            this.cbValue.TabIndex = 3;
            this.cbValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // btApply
            // 
            this.btApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btApply.ImageKey = "apply";
            this.btApply.ImageList = this.imageList1;
            this.btApply.Location = new System.Drawing.Point(9, 71);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(92, 31);
            this.btApply.TabIndex = 5;
            this.btApply.Text = "Apply";
            this.btApply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            this.btApply.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // btReset
            // 
            this.btReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReset.ImageKey = "reset";
            this.btReset.ImageList = this.imageList1;
            this.btReset.Location = new System.Drawing.Point(107, 71);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(92, 31);
            this.btReset.TabIndex = 6;
            this.btReset.Text = "Reset";
            this.btReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            this.btReset.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // lbObject
            // 
            this.lbObject.AutoSize = true;
            this.lbObject.Location = new System.Drawing.Point(197, 23);
            this.lbObject.Name = "lbObject";
            this.lbObject.Size = new System.Drawing.Size(69, 13);
            this.lbObject.TabIndex = 7;
            this.lbObject.Text = "Object Name";
            // 
            // cbObject
            // 
            this.cbObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObject.FormattingEnabled = true;
            this.cbObject.Location = new System.Drawing.Point(322, 20);
            this.cbObject.Name = "cbObject";
            this.cbObject.Size = new System.Drawing.Size(193, 21);
            this.cbObject.Sorted = true;
            this.cbObject.TabIndex = 2;
            this.cbObject.SelectedIndexChanged += new System.EventHandler(this.cbObject_SelectedIndexChanged);
            this.cbObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // lbDateTo
            // 
            this.lbDateTo.AutoSize = true;
            this.lbDateTo.Location = new System.Drawing.Point(6, 49);
            this.lbDateTo.Name = "lbDateTo";
            this.lbDateTo.Size = new System.Drawing.Size(46, 13);
            this.lbDateTo.TabIndex = 3;
            this.lbDateTo.Text = "Date To";
            // 
            // lbDateFrom
            // 
            this.lbDateFrom.AutoSize = true;
            this.lbDateFrom.Location = new System.Drawing.Point(6, 23);
            this.lbDateFrom.Name = "lbDateFrom";
            this.lbDateFrom.Size = new System.Drawing.Size(56, 13);
            this.lbDateFrom.TabIndex = 2;
            this.lbDateFrom.Text = "Date From";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = " ";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(98, 45);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(93, 20);
            this.dtTo.TabIndex = 1;
            this.dtTo.Value = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.dtTo.ValueChanged += new System.EventHandler(this.Date_Format);
            this.dtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Date_KeyDown);
            this.dtTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = " ";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(98, 19);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(93, 20);
            this.dtFrom.TabIndex = 0;
            this.dtFrom.Value = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.Date_Format);
            this.dtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Date_KeyDown);
            this.dtFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            // 
            // treeLog
            // 
            this.treeLog.AllColumns.Add(this.colObjectName);
            this.treeLog.AllColumns.Add(this.colObjectValue);
            this.treeLog.AllColumns.Add(this.colAction);
            this.treeLog.AllColumns.Add(this.colWho);
            this.treeLog.AllColumns.Add(this.colWhen);
            this.treeLog.AllColumns.Add(this.colOld);
            this.treeLog.AllColumns.Add(this.colNew);
            this.treeLog.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.treeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLog.CausesValidation = false;
            this.treeLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colObjectName,
            this.colObjectValue,
            this.colAction,
            this.colWho,
            this.colWhen,
            this.colOld,
            this.colNew});
            this.treeLog.EmptyListMsg = "Pas de Résultat pour ces Critères";
            this.treeLog.FullRowSelect = true;
            this.treeLog.GridLines = true;
            this.treeLog.HeaderUsesThemes = false;
            this.treeLog.LargeImageList = this.imageList1;
            this.treeLog.Location = new System.Drawing.Point(6, 50);
            this.treeLog.MultiSelect = false;
            this.treeLog.Name = "treeLog";
            this.treeLog.OwnerDraw = true;
            this.treeLog.SelectColumnsOnRightClick = false;
            this.treeLog.SelectColumnsOnRightClickBehaviour = SynapseAdvancedControls.ObjectListView.ColumnSelectBehaviour.None;
            this.treeLog.ShowCommandMenuOnRightClick = true;
            this.treeLog.ShowFilterMenuOnRightClick = false;
            this.treeLog.ShowGroups = false;
            this.treeLog.Size = new System.Drawing.Size(1066, 162);
            this.treeLog.SmallImageList = this.imageList1;
            this.treeLog.TabIndex = 1;
            this.treeLog.UseAlternatingBackColors = true;
            this.treeLog.UseCompatibleStateImageBehavior = false;
            this.treeLog.UseFilterIndicator = true;
            this.treeLog.UseFiltering = true;
            this.treeLog.UseOverlays = false;
            this.treeLog.View = System.Windows.Forms.View.Details;
            this.treeLog.VirtualMode = true;
            this.treeLog.DoubleClick += new System.EventHandler(this.treeLog_DoubleClick);
            // 
            // colObjectName
            // 
            this.colObjectName.AspectName = "OBJECT_NAME";
            this.colObjectName.CellPadding = null;
            this.colObjectName.Text = "Object Name";
            this.colObjectName.Width = 221;
            // 
            // colObjectValue
            // 
            this.colObjectValue.AspectName = "OBJECT_VALUE";
            this.colObjectValue.CellPadding = null;
            this.colObjectValue.Text = "Object Value";
            this.colObjectValue.Width = 154;
            // 
            // colAction
            // 
            this.colAction.AspectName = "ACTION_CODE";
            this.colAction.CellPadding = null;
            this.colAction.Text = "Action";
            this.colAction.Width = 100;
            // 
            // colWho
            // 
            this.colWho.AspectName = "USERID";
            this.colWho.CellPadding = null;
            this.colWho.Text = "Who";
            this.colWho.Width = 120;
            // 
            // colWhen
            // 
            this.colWhen.AspectName = "TIMESTAMP";
            this.colWhen.CellPadding = null;
            this.colWhen.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colWhen.Text = "When";
            this.colWhen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colWhen.Width = 150;
            // 
            // colOld
            // 
            this.colOld.AspectName = "OLD_VALUE";
            this.colOld.CellPadding = null;
            this.colOld.Text = "Old Value";
            this.colOld.Width = 150;
            // 
            // colNew
            // 
            this.colNew.AspectName = "NEW_VALUE";
            this.colNew.CellPadding = null;
            this.colNew.Text = "New Value";
            this.colNew.Width = 150;
            // 
            // SynapseTracability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gbTracability);
            this.Name = "SynapseTracability";
            this.Size = new System.Drawing.Size(1078, 335);
            this.Load += new System.EventHandler(this.SynapseTracability_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynapseTracability_KeyUp);
            this.gbTracability.ResumeLayout(false);
            this.gbTracability.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gbTracability;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbExpand;
        private System.Windows.Forms.ToolStripButton tsbCollapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private SynapseAdvancedControls.TreeListView treeLog;
        private SynapseAdvancedControls.OLVColumn colObjectName;
        private SynapseAdvancedControls.OLVColumn colObjectValue;
        private SynapseAdvancedControls.OLVColumn colAction;
        private SynapseAdvancedControls.OLVColumn colWho;
        private SynapseAdvancedControls.OLVColumn colWhen;
        private SynapseAdvancedControls.OLVColumn colOld;
        private SynapseAdvancedControls.OLVColumn colNew;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txFreeText;
        private System.Windows.Forms.Label lbFreeText;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Label lbObject;
        private System.Windows.Forms.ComboBox cbObject;
        private System.Windows.Forms.Label lbDateTo;
        private System.Windows.Forms.Label lbDateFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
    }
}
