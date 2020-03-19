namespace SynapseRoomPicker.Controls
{
    partial class RoomPickerTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPickerTree));
            this.ctxRoomPicker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNewEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNewBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNewRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeList = new SynapseAdvancedControls.TreeListView();
            this.colCode = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxRoomPicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxRoomPicker
            // 
            this.ctxRoomPicker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNewEntity,
            this.ctxNewBuilding,
            this.ctxNewRoom});
            this.ctxRoomPicker.Name = "ctxRoomPicker";
            this.ctxRoomPicker.Size = new System.Drawing.Size(144, 70);
            this.ctxRoomPicker.Opening += new System.ComponentModel.CancelEventHandler(this.ctxRoomPicker_Opening);
            // 
            // ctxNewEntity
            // 
            this.ctxNewEntity.Name = "ctxNewEntity";
            this.ctxNewEntity.Size = new System.Drawing.Size(143, 22);
            this.ctxNewEntity.Text = "Add Entity";
            this.ctxNewEntity.Click += new System.EventHandler(this.ctxNewEntity_Click);
            // 
            // ctxNewBuilding
            // 
            this.ctxNewBuilding.Name = "ctxNewBuilding";
            this.ctxNewBuilding.Size = new System.Drawing.Size(143, 22);
            this.ctxNewBuilding.Text = "Add Building";
            this.ctxNewBuilding.Click += new System.EventHandler(this.ctxNewBuilding_Click);
            // 
            // ctxNewRoom
            // 
            this.ctxNewRoom.Name = "ctxNewRoom";
            this.ctxNewRoom.Size = new System.Drawing.Size(143, 22);
            this.ctxNewRoom.Text = "Add Room";
            this.ctxNewRoom.Click += new System.EventHandler(this.ctxNewRoom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "room");
            this.imageList1.Images.SetKeyName(1, "building");
            this.imageList1.Images.SetKeyName(2, "entity");
            this.imageList1.Images.SetKeyName(3, "room1");
            this.imageList1.Images.SetKeyName(4, "room2");
            // 
            // treeList
            // 
            this.treeList.AllColumns.Add(this.colCode);
            this.treeList.AllColumns.Add(this.colName);
            this.treeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName});
            this.treeList.ContextMenuStrip = this.ctxRoomPicker;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.FullRowSelect = true;
            this.treeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.treeList.HideSelection = false;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.MultiSelect = false;
            this.treeList.Name = "treeList";
            this.treeList.OwnerDraw = true;
            this.treeList.ShowGroups = false;
            this.treeList.Size = new System.Drawing.Size(222, 253);
            this.treeList.SmallImageList = this.imageList1;
            this.treeList.TabIndex = 0;
            this.treeList.UseCompatibleStateImageBehavior = false;
            this.treeList.View = System.Windows.Forms.View.Details;
            this.treeList.VirtualMode = true;
            this.treeList.SelectedIndexChanged += new System.EventHandler(this.treeList_SelectedIndexChanged);
            this.treeList.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.AspectName = "CODE";
            this.colCode.CellPadding = null;
            this.colCode.Text = "Code";
            this.colCode.Width = 120;
            // 
            // colName
            // 
            this.colName.AspectName = "NAME";
            this.colName.CellPadding = null;
            this.colName.FillsFreeSpace = true;
            this.colName.Text = "Name";
            // 
            // RoomPickerTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Name = "RoomPickerTree";
            this.Size = new System.Drawing.Size(222, 253);
            this.ctxRoomPicker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.TreeListView treeList;
        private SynapseAdvancedControls.OLVColumn colCode;
        private SynapseAdvancedControls.OLVColumn colName;
        private System.Windows.Forms.ContextMenuStrip ctxRoomPicker;
        private System.Windows.Forms.ToolStripMenuItem ctxNewEntity;
        private System.Windows.Forms.ToolStripMenuItem ctxNewBuilding;
        private System.Windows.Forms.ToolStripMenuItem ctxNewRoom;
        private System.Windows.Forms.ImageList imageList1;
    }
}
