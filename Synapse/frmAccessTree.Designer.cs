namespace Synapse
{
    partial class frmAccessTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessTree));
            this.treeMain = new SynapseAdvancedControls.TreeListView();
            this.olvColName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSelected = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.olvGroupUsers = new SynapseAdvancedControls.ObjectListView();
            this.olvGroupUsers_USERID = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroupUsers_FIRSTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroupUsers_LASTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.lbEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroupUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMain
            // 
            this.treeMain.AllColumns.Add(this.olvColName);
            this.treeMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeMain.BackColor = System.Drawing.SystemColors.Window;
            this.treeMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColName});
            this.treeMain.FullRowSelect = true;
            this.treeMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treeMain.HideSelection = false;
            this.treeMain.LargeImageList = this.imageList1;
            this.treeMain.Location = new System.Drawing.Point(12, 3);
            this.treeMain.MultiSelect = false;
            this.treeMain.Name = "treeMain";
            this.treeMain.OwnerDraw = true;
            this.treeMain.ShowGroups = false;
            this.treeMain.Size = new System.Drawing.Size(330, 549);
            this.treeMain.SmallImageList = this.imageList1;
            this.treeMain.TabIndex = 0;
            this.treeMain.UseCompatibleStateImageBehavior = false;
            this.treeMain.View = System.Windows.Forms.View.Details;
            this.treeMain.VirtualMode = true;
            this.treeMain.SelectedIndexChanged += new System.EventHandler(this.treeMain_SelectedIndexChanged);
            this.treeMain.DoubleClick += new System.EventHandler(this.treeMain_DoubleClick);
            // 
            // olvColName
            // 
            this.olvColName.FillsFreeSpace = true;
            this.olvColName.Text = "Name";
            this.olvColName.Width = 319;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GROUPS");
            this.imageList1.Images.SetKeyName(1, "USERS");
            this.imageList1.Images.SetKeyName(2, "MODULES");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(955, 564);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lbSelected);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 549);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lbSelected
            // 
            this.lbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelected.Location = new System.Drawing.Point(5, 16);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(580, 35);
            this.lbSelected.TabIndex = 14;
            this.lbSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbEmpty);
            this.panel1.Controls.Add(this.olvGroupUsers);
            this.panel1.Location = new System.Drawing.Point(6, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 489);
            this.panel1.TabIndex = 0;
            // 
            // olvGroupUsers
            // 
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_USERID);
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_FIRSTNAME);
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_LASTNAME);
            this.olvGroupUsers.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvGroupUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvGroupUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvGroupUsers_USERID,
            this.olvGroupUsers_FIRSTNAME,
            this.olvGroupUsers_LASTNAME});
            this.olvGroupUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvGroupUsers.FullRowSelect = true;
            this.olvGroupUsers.GridLines = true;
            this.olvGroupUsers.HideSelection = false;
            this.olvGroupUsers.IsSimpleDropSink = true;
            this.olvGroupUsers.Location = new System.Drawing.Point(13, 12);
            this.olvGroupUsers.MultiSelect = false;
            this.olvGroupUsers.Name = "olvGroupUsers";
            this.olvGroupUsers.ShowCommandMenuOnRightClick = true;
            this.olvGroupUsers.ShowGroups = false;
            this.olvGroupUsers.Size = new System.Drawing.Size(421, 90);
            this.olvGroupUsers.SmallImageList = this.imageList1;
            this.olvGroupUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvGroupUsers.TabIndex = 12;
            this.olvGroupUsers.UseAlternatingBackColors = true;
            this.olvGroupUsers.UseCompatibleStateImageBehavior = false;
            this.olvGroupUsers.UseFiltering = true;
            this.olvGroupUsers.UseHotItem = true;
            this.olvGroupUsers.View = System.Windows.Forms.View.Details;
            // 
            // olvGroupUsers_USERID
            // 
            this.olvGroupUsers_USERID.AspectName = "UserID";
            this.olvGroupUsers_USERID.Text = "Userid";
            this.olvGroupUsers_USERID.Width = 150;
            // 
            // olvGroupUsers_FIRSTNAME
            // 
            this.olvGroupUsers_FIRSTNAME.AspectName = "FIRSTNAME";
            this.olvGroupUsers_FIRSTNAME.Text = "Firstname";
            this.olvGroupUsers_FIRSTNAME.Width = 90;
            // 
            // olvGroupUsers_LASTNAME
            // 
            this.olvGroupUsers_LASTNAME.AspectName = "LASTNAME";
            this.olvGroupUsers_LASTNAME.FillsFreeSpace = true;
            this.olvGroupUsers_LASTNAME.Text = "Lastname";
            this.olvGroupUsers_LASTNAME.Width = 100;
            // 
            // lbEmpty
            // 
            this.lbEmpty.BackColor = System.Drawing.SystemColors.Window;
            this.lbEmpty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbEmpty.Location = new System.Drawing.Point(13, 422);
            this.lbEmpty.Name = "lbEmpty";
            this.lbEmpty.Size = new System.Drawing.Size(168, 52);
            this.lbEmpty.TabIndex = 13;
            this.lbEmpty.Text = "Select Item in the List";
            this.lbEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAccessTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 564);
            this.Controls.Add(this.splitContainer1);
            this.ModuleID = 1;
            this.Name = "frmAccessTree";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAccessTree";
            this.UpdateControls = true;
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvGroupUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.TreeListView treeMain;
        private SynapseAdvancedControls.OLVColumn olvColName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SynapseAdvancedControls.ObjectListView olvGroupUsers;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_USERID;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_FIRSTNAME;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_LASTNAME;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbEmpty;
    }
}