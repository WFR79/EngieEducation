namespace SynapseRoomPickerDemo
{
    partial class frmPickerDemo
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminEntity = new SynapseRoomPicker.Controls.AdminEntityMenu();
            this.mnuAdminBuilding = new SynapseRoomPicker.Controls.AdminBuildingMenu();
            this.mnuAdminRoom = new SynapseRoomPicker.Controls.AdminRoomMenu();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckNameMandatory = new System.Windows.Forms.CheckBox();
            this.ckImage = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txEmptyLabel = new System.Windows.Forms.TextBox();
            this.ckAvailable = new System.Windows.Forms.CheckBox();
            this.ckSelectNew = new System.Windows.Forms.CheckBox();
            this.rbRoom = new System.Windows.Forms.RadioButton();
            this.rbBuilding = new System.Windows.Forms.RadioButton();
            this.rbEntity = new System.Windows.Forms.RadioButton();
            this.ckNewEntity = new System.Windows.Forms.CheckBox();
            this.ckNewBuilding = new System.Windows.Forms.CheckBox();
            this.ckNewRoom = new System.Windows.Forms.CheckBox();
            this.txModuleID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btSyncRoomTree = new System.Windows.Forms.Button();
            this.btSyncBuildingTree = new System.Windows.Forms.Button();
            this.tbSyncEntityTree = new System.Windows.Forms.Button();
            this.btErrorRoom = new System.Windows.Forms.Button();
            this.txMsgRoom = new System.Windows.Forms.TextBox();
            this.btErrorBuilding = new System.Windows.Forms.Button();
            this.txMsgBuilding = new System.Windows.Forms.TextBox();
            this.btErrorEntity = new System.Windows.Forms.Button();
            this.txMsgEntity = new System.Windows.Forms.TextBox();
            this.btResetError = new System.Windows.Forms.Button();
            this.btSyncRoomCombo = new System.Windows.Forms.Button();
            this.btSyncBuildingCombo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txSiteCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.txSyncRoom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btSyncEntityCombo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txSyncBuilding = new System.Windows.Forms.TextBox();
            this.txSyncEntity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txEntityObject = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txEntity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txBuilding = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txRoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txBuildingObject = new System.Windows.Forms.TextBox();
            this.txRoomObject = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.roomPickerCombo = new SynapseRoomPicker.Controls.RoomPickerCombo();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.roomPickerTree = new SynapseRoomPicker.Controls.RoomPickerTree();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btGetRoomID = new System.Windows.Forms.Button();
            this.roomPickerFree = new SynapseRoomPicker.Controls.RoomPickerFree();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(106, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdminEntity,
            this.mnuAdminBuilding,
            this.mnuAdminRoom});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // mnuAdminEntity
            // 
            this.mnuAdminEntity.AllowDelete = false;
            this.mnuAdminEntity.ModuleID = 15;
            this.mnuAdminEntity.Name = "mnuAdminEntity";
            this.mnuAdminEntity.SiteCode = "KCD";
            this.mnuAdminEntity.Size = new System.Drawing.Size(189, 22);
            this.mnuAdminEntity.Text = "adminEntityMenu1";
            // 
            // mnuAdminBuilding
            // 
            this.mnuAdminBuilding.AllowDelete = false;
            this.mnuAdminBuilding.ModuleID = 15;
            this.mnuAdminBuilding.Name = "mnuAdminBuilding";
            this.mnuAdminBuilding.SiteCode = "KCD";
            this.mnuAdminBuilding.Size = new System.Drawing.Size(189, 22);
            this.mnuAdminBuilding.Text = "adminBuildingMenu1";
            // 
            // mnuAdminRoom
            // 
            this.mnuAdminRoom.AllowDelete = false;
            this.mnuAdminRoom.ModuleID = 15;
            this.mnuAdminRoom.Name = "mnuAdminRoom";
            this.mnuAdminRoom.RoomNameMandatory = true;
            this.mnuAdminRoom.SiteCode = "KCD";
            this.mnuAdminRoom.Size = new System.Drawing.Size(189, 22);
            this.mnuAdminRoom.Text = "adminRoomMenu1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.ckNameMandatory);
            this.groupBox2.Controls.Add(this.ckImage);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txEmptyLabel);
            this.groupBox2.Controls.Add(this.ckAvailable);
            this.groupBox2.Controls.Add(this.ckSelectNew);
            this.groupBox2.Controls.Add(this.rbRoom);
            this.groupBox2.Controls.Add(this.rbBuilding);
            this.groupBox2.Controls.Add(this.rbEntity);
            this.groupBox2.Controls.Add(this.ckNewEntity);
            this.groupBox2.Controls.Add(this.ckNewBuilding);
            this.groupBox2.Controls.Add(this.ckNewRoom);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 493);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read-Write Properties";
            // 
            // ckNameMandatory
            // 
            this.ckNameMandatory.AutoSize = true;
            this.ckNameMandatory.Location = new System.Drawing.Point(17, 161);
            this.ckNameMandatory.Name = "ckNameMandatory";
            this.ckNameMandatory.Size = new System.Drawing.Size(117, 17);
            this.ckNameMandatory.TabIndex = 40;
            this.ckNameMandatory.Text = "Name is Mandatory";
            this.ckNameMandatory.UseVisualStyleBackColor = true;
            this.ckNameMandatory.CheckedChanged += new System.EventHandler(this.ckNameMandatory_CheckedChanged);
            // 
            // ckImage
            // 
            this.ckImage.AutoSize = true;
            this.ckImage.Location = new System.Drawing.Point(6, 250);
            this.ckImage.Name = "ckImage";
            this.ckImage.Size = new System.Drawing.Size(124, 17);
            this.ckImage.TabIndex = 39;
            this.ckImage.Text = "Show image on Tree";
            this.ckImage.UseVisualStyleBackColor = true;
            this.ckImage.CheckedChanged += new System.EventHandler(this.ckImage_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbName);
            this.panel1.Controls.Add(this.rbCode);
            this.panel1.Location = new System.Drawing.Point(6, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 51);
            this.panel1.TabIndex = 34;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(0, 26);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(90, 17);
            this.rbName.TabIndex = 25;
            this.rbName.TabStop = true;
            this.rbName.Text = "Display Name";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Location = new System.Drawing.Point(0, 3);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(87, 17);
            this.rbCode.TabIndex = 24;
            this.rbCode.TabStop = true;
            this.rbCode.Text = "Display Code";
            this.rbCode.UseVisualStyleBackColor = true;
            this.rbCode.CheckedChanged += new System.EventHandler(this.DisplayChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Empty Member Label";
            // 
            // txEmptyLabel
            // 
            this.txEmptyLabel.Location = new System.Drawing.Point(6, 303);
            this.txEmptyLabel.Name = "txEmptyLabel";
            this.txEmptyLabel.Size = new System.Drawing.Size(126, 20);
            this.txEmptyLabel.TabIndex = 29;
            this.txEmptyLabel.TextChanged += new System.EventHandler(this.txEmptyLabel_TextChanged);
            // 
            // ckAvailable
            // 
            this.ckAvailable.AutoSize = true;
            this.ckAvailable.Location = new System.Drawing.Point(6, 227);
            this.ckAvailable.Name = "ckAvailable";
            this.ckAvailable.Size = new System.Drawing.Size(93, 17);
            this.ckAvailable.TabIndex = 27;
            this.ckAvailable.Text = "Only Available";
            this.ckAvailable.UseVisualStyleBackColor = true;
            this.ckAvailable.CheckedChanged += new System.EventHandler(this.ckAvailable_CheckedChanged);
            // 
            // ckSelectNew
            // 
            this.ckSelectNew.AutoSize = true;
            this.ckSelectNew.Location = new System.Drawing.Point(6, 204);
            this.ckSelectNew.Name = "ckSelectNew";
            this.ckSelectNew.Size = new System.Drawing.Size(106, 17);
            this.ckSelectNew.TabIndex = 26;
            this.ckSelectNew.Text = "Auto Select New";
            this.ckSelectNew.UseVisualStyleBackColor = true;
            this.ckSelectNew.CheckedChanged += new System.EventHandler(this.ckSelectNew_CheckedChanged);
            // 
            // rbRoom
            // 
            this.rbRoom.AutoSize = true;
            this.rbRoom.Checked = true;
            this.rbRoom.Location = new System.Drawing.Point(6, 69);
            this.rbRoom.Name = "rbRoom";
            this.rbRoom.Size = new System.Drawing.Size(86, 17);
            this.rbRoom.TabIndex = 25;
            this.rbRoom.TabStop = true;
            this.rbRoom.Text = "Room Picker";
            this.rbRoom.UseVisualStyleBackColor = true;
            this.rbRoom.CheckedChanged += new System.EventHandler(this.PickerTypeChanged);
            // 
            // rbBuilding
            // 
            this.rbBuilding.AutoSize = true;
            this.rbBuilding.Location = new System.Drawing.Point(6, 46);
            this.rbBuilding.Name = "rbBuilding";
            this.rbBuilding.Size = new System.Drawing.Size(95, 17);
            this.rbBuilding.TabIndex = 24;
            this.rbBuilding.TabStop = true;
            this.rbBuilding.Text = "Building Picker";
            this.rbBuilding.UseVisualStyleBackColor = true;
            this.rbBuilding.CheckedChanged += new System.EventHandler(this.PickerTypeChanged);
            // 
            // rbEntity
            // 
            this.rbEntity.AutoSize = true;
            this.rbEntity.Location = new System.Drawing.Point(6, 23);
            this.rbEntity.Name = "rbEntity";
            this.rbEntity.Size = new System.Drawing.Size(84, 17);
            this.rbEntity.TabIndex = 23;
            this.rbEntity.TabStop = true;
            this.rbEntity.Text = "Entity Picker";
            this.rbEntity.UseVisualStyleBackColor = true;
            this.rbEntity.CheckedChanged += new System.EventHandler(this.PickerTypeChanged);
            // 
            // ckNewEntity
            // 
            this.ckNewEntity.AutoSize = true;
            this.ckNewEntity.Location = new System.Drawing.Point(6, 92);
            this.ckNewEntity.Name = "ckNewEntity";
            this.ckNewEntity.Size = new System.Drawing.Size(105, 17);
            this.ckNewEntity.TabIndex = 10;
            this.ckNewEntity.Text = "Allow New Entity";
            this.ckNewEntity.UseVisualStyleBackColor = true;
            this.ckNewEntity.CheckedChanged += new System.EventHandler(this.ckNewEntity_CheckedChanged);
            // 
            // ckNewBuilding
            // 
            this.ckNewBuilding.AutoSize = true;
            this.ckNewBuilding.Location = new System.Drawing.Point(6, 115);
            this.ckNewBuilding.Name = "ckNewBuilding";
            this.ckNewBuilding.Size = new System.Drawing.Size(116, 17);
            this.ckNewBuilding.TabIndex = 11;
            this.ckNewBuilding.Text = "Allow New Building";
            this.ckNewBuilding.UseVisualStyleBackColor = true;
            this.ckNewBuilding.CheckedChanged += new System.EventHandler(this.ckNewBuilding_CheckedChanged);
            // 
            // ckNewRoom
            // 
            this.ckNewRoom.AutoSize = true;
            this.ckNewRoom.Location = new System.Drawing.Point(6, 138);
            this.ckNewRoom.Name = "ckNewRoom";
            this.ckNewRoom.Size = new System.Drawing.Size(107, 17);
            this.ckNewRoom.TabIndex = 12;
            this.ckNewRoom.Text = "Allow New Room";
            this.ckNewRoom.UseVisualStyleBackColor = true;
            this.ckNewRoom.CheckedChanged += new System.EventHandler(this.ckNewRoom_CheckedChanged);
            // 
            // txModuleID
            // 
            this.txModuleID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txModuleID.Location = new System.Drawing.Point(77, 40);
            this.txModuleID.Name = "txModuleID";
            this.txModuleID.Size = new System.Drawing.Size(60, 20);
            this.txModuleID.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(74, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Module ID";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btSyncRoomTree);
            this.groupBox3.Controls.Add(this.btSyncBuildingTree);
            this.groupBox3.Controls.Add(this.tbSyncEntityTree);
            this.groupBox3.Controls.Add(this.btErrorRoom);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txModuleID);
            this.groupBox3.Controls.Add(this.txMsgRoom);
            this.groupBox3.Controls.Add(this.btErrorBuilding);
            this.groupBox3.Controls.Add(this.txMsgBuilding);
            this.groupBox3.Controls.Add(this.btErrorEntity);
            this.groupBox3.Controls.Add(this.txMsgEntity);
            this.groupBox3.Controls.Add(this.btResetError);
            this.groupBox3.Controls.Add(this.btSyncRoomCombo);
            this.groupBox3.Controls.Add(this.btSyncBuildingCombo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txSiteCode);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btReset);
            this.groupBox3.Controls.Add(this.txSyncRoom);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btSyncEntityCombo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txSyncBuilding);
            this.groupBox3.Controls.Add(this.txSyncEntity);
            this.groupBox3.Location = new System.Drawing.Point(156, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 493);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Methods";
            // 
            // btSyncRoomTree
            // 
            this.btSyncRoomTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncRoomTree.Location = new System.Drawing.Point(178, 225);
            this.btSyncRoomTree.Name = "btSyncRoomTree";
            this.btSyncRoomTree.Size = new System.Drawing.Size(82, 23);
            this.btSyncRoomTree.TabIndex = 36;
            this.btSyncRoomTree.Text = "Sync Tree";
            this.btSyncRoomTree.UseVisualStyleBackColor = true;
            this.btSyncRoomTree.Click += new System.EventHandler(this.btSyncRoomTree_Click);
            // 
            // btSyncBuildingTree
            // 
            this.btSyncBuildingTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncBuildingTree.Location = new System.Drawing.Point(178, 183);
            this.btSyncBuildingTree.Name = "btSyncBuildingTree";
            this.btSyncBuildingTree.Size = new System.Drawing.Size(82, 23);
            this.btSyncBuildingTree.TabIndex = 35;
            this.btSyncBuildingTree.Text = "Sync Tree";
            this.btSyncBuildingTree.UseVisualStyleBackColor = true;
            this.btSyncBuildingTree.Click += new System.EventHandler(this.btSyncBuildingTree_Click);
            // 
            // tbSyncEntityTree
            // 
            this.tbSyncEntityTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSyncEntityTree.Location = new System.Drawing.Point(178, 141);
            this.tbSyncEntityTree.Name = "tbSyncEntityTree";
            this.tbSyncEntityTree.Size = new System.Drawing.Size(82, 23);
            this.tbSyncEntityTree.TabIndex = 34;
            this.tbSyncEntityTree.Text = "Sync Tree";
            this.tbSyncEntityTree.UseVisualStyleBackColor = true;
            this.tbSyncEntityTree.Click += new System.EventHandler(this.tbSyncEntityTree_Click);
            // 
            // btErrorRoom
            // 
            this.btErrorRoom.Location = new System.Drawing.Point(105, 359);
            this.btErrorRoom.Name = "btErrorRoom";
            this.btErrorRoom.Size = new System.Drawing.Size(155, 23);
            this.btErrorRoom.TabIndex = 33;
            this.btErrorRoom.Text = "Set Error on Room (MSG)";
            this.btErrorRoom.UseVisualStyleBackColor = true;
            this.btErrorRoom.Click += new System.EventHandler(this.btErrorRoom_Click);
            // 
            // txMsgRoom
            // 
            this.txMsgRoom.Location = new System.Drawing.Point(11, 361);
            this.txMsgRoom.Name = "txMsgRoom";
            this.txMsgRoom.Size = new System.Drawing.Size(88, 20);
            this.txMsgRoom.TabIndex = 32;
            // 
            // btErrorBuilding
            // 
            this.btErrorBuilding.Location = new System.Drawing.Point(105, 330);
            this.btErrorBuilding.Name = "btErrorBuilding";
            this.btErrorBuilding.Size = new System.Drawing.Size(155, 23);
            this.btErrorBuilding.TabIndex = 31;
            this.btErrorBuilding.Text = "Set Error on Building (MSG)";
            this.btErrorBuilding.UseVisualStyleBackColor = true;
            this.btErrorBuilding.Click += new System.EventHandler(this.btErrorBuilding_Click);
            // 
            // txMsgBuilding
            // 
            this.txMsgBuilding.Location = new System.Drawing.Point(11, 332);
            this.txMsgBuilding.Name = "txMsgBuilding";
            this.txMsgBuilding.Size = new System.Drawing.Size(88, 20);
            this.txMsgBuilding.TabIndex = 30;
            // 
            // btErrorEntity
            // 
            this.btErrorEntity.Location = new System.Drawing.Point(105, 301);
            this.btErrorEntity.Name = "btErrorEntity";
            this.btErrorEntity.Size = new System.Drawing.Size(155, 23);
            this.btErrorEntity.TabIndex = 29;
            this.btErrorEntity.Text = "Set Error on Entity (MSG)";
            this.btErrorEntity.UseVisualStyleBackColor = true;
            this.btErrorEntity.Click += new System.EventHandler(this.btErrorEntity_Click);
            // 
            // txMsgEntity
            // 
            this.txMsgEntity.Location = new System.Drawing.Point(11, 303);
            this.txMsgEntity.Name = "txMsgEntity";
            this.txMsgEntity.Size = new System.Drawing.Size(88, 20);
            this.txMsgEntity.TabIndex = 28;
            // 
            // btResetError
            // 
            this.btResetError.Location = new System.Drawing.Point(105, 388);
            this.btResetError.Name = "btResetError";
            this.btResetError.Size = new System.Drawing.Size(155, 23);
            this.btResetError.TabIndex = 27;
            this.btResetError.Text = "Reset Error";
            this.btResetError.UseVisualStyleBackColor = true;
            this.btResetError.Click += new System.EventHandler(this.btResetError_Click);
            // 
            // btSyncRoomCombo
            // 
            this.btSyncRoomCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncRoomCombo.Location = new System.Drawing.Point(77, 225);
            this.btSyncRoomCombo.Name = "btSyncRoomCombo";
            this.btSyncRoomCombo.Size = new System.Drawing.Size(82, 23);
            this.btSyncRoomCombo.TabIndex = 26;
            this.btSyncRoomCombo.Text = "Sync Combo";
            this.btSyncRoomCombo.UseVisualStyleBackColor = true;
            this.btSyncRoomCombo.Click += new System.EventHandler(this.btSyncRoom_Click);
            // 
            // btSyncBuildingCombo
            // 
            this.btSyncBuildingCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncBuildingCombo.Location = new System.Drawing.Point(77, 183);
            this.btSyncBuildingCombo.Name = "btSyncBuildingCombo";
            this.btSyncBuildingCombo.Size = new System.Drawing.Size(82, 23);
            this.btSyncBuildingCombo.TabIndex = 25;
            this.btSyncBuildingCombo.Text = "Sync Combo";
            this.btSyncBuildingCombo.UseVisualStyleBackColor = true;
            this.btSyncBuildingCombo.Click += new System.EventHandler(this.btSyncBuilding_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Site Code";
            // 
            // txSiteCode
            // 
            this.txSiteCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txSiteCode.Location = new System.Drawing.Point(11, 40);
            this.txSiteCode.Name = "txSiteCode";
            this.txSiteCode.Size = new System.Drawing.Size(60, 20);
            this.txSiteCode.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Initialize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(11, 92);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(60, 23);
            this.btReset.TabIndex = 13;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // txSyncRoom
            // 
            this.txSyncRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txSyncRoom.Location = new System.Drawing.Point(11, 227);
            this.txSyncRoom.Name = "txSyncRoom";
            this.txSyncRoom.Size = new System.Drawing.Size(60, 20);
            this.txSyncRoom.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Entity ID";
            // 
            // btSyncEntityCombo
            // 
            this.btSyncEntityCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncEntityCombo.Location = new System.Drawing.Point(77, 141);
            this.btSyncEntityCombo.Name = "btSyncEntityCombo";
            this.btSyncEntityCombo.Size = new System.Drawing.Size(82, 23);
            this.btSyncEntityCombo.TabIndex = 14;
            this.btSyncEntityCombo.Text = "Sync Combo";
            this.btSyncEntityCombo.UseVisualStyleBackColor = true;
            this.btSyncEntityCombo.Click += new System.EventHandler(this.btSyncEntity_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Room ID";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Building ID";
            // 
            // txSyncBuilding
            // 
            this.txSyncBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txSyncBuilding.Location = new System.Drawing.Point(11, 185);
            this.txSyncBuilding.Name = "txSyncBuilding";
            this.txSyncBuilding.Size = new System.Drawing.Size(60, 20);
            this.txSyncBuilding.TabIndex = 19;
            // 
            // txSyncEntity
            // 
            this.txSyncEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txSyncEntity.Location = new System.Drawing.Point(11, 143);
            this.txSyncEntity.Name = "txSyncEntity";
            this.txSyncEntity.Size = new System.Drawing.Size(60, 20);
            this.txSyncEntity.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txEntityObject);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txEntity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txBuilding);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txRoom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txBuildingObject);
            this.groupBox1.Controls.Add(this.txRoomObject);
            this.groupBox1.Location = new System.Drawing.Point(428, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 493);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read Properties (after SelectionChanged Event)";
            // 
            // txEntityObject
            // 
            this.txEntityObject.Location = new System.Drawing.Point(75, 43);
            this.txEntityObject.Multiline = true;
            this.txEntityObject.Name = "txEntityObject";
            this.txEntityObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txEntityObject.Size = new System.Drawing.Size(329, 120);
            this.txEntityObject.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Room";
            // 
            // txEntity
            // 
            this.txEntity.Location = new System.Drawing.Point(75, 17);
            this.txEntity.Name = "txEntity";
            this.txEntity.Size = new System.Drawing.Size(60, 20);
            this.txEntity.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Building";
            // 
            // txBuilding
            // 
            this.txBuilding.Location = new System.Drawing.Point(75, 169);
            this.txBuilding.Name = "txBuilding";
            this.txBuilding.Size = new System.Drawing.Size(60, 20);
            this.txBuilding.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Entity";
            // 
            // txRoom
            // 
            this.txRoom.Location = new System.Drawing.Point(75, 321);
            this.txRoom.Name = "txRoom";
            this.txRoom.Size = new System.Drawing.Size(60, 20);
            this.txRoom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EntityID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BuildingID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "RoomID";
            // 
            // txBuildingObject
            // 
            this.txBuildingObject.Location = new System.Drawing.Point(75, 195);
            this.txBuildingObject.Multiline = true;
            this.txBuildingObject.Name = "txBuildingObject";
            this.txBuildingObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBuildingObject.Size = new System.Drawing.Size(329, 120);
            this.txBuildingObject.TabIndex = 8;
            // 
            // txRoomObject
            // 
            this.txRoomObject.Location = new System.Drawing.Point(75, 347);
            this.txRoomObject.Multiline = true;
            this.txRoomObject.Name = "txRoomObject";
            this.txRoomObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txRoomObject.Size = new System.Drawing.Size(329, 120);
            this.txRoomObject.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.roomPickerCombo);
            this.groupBox4.Location = new System.Drawing.Point(850, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 102);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Combo Room Picker Control";
            // 
            // roomPickerCombo
            // 
            this.roomPickerCombo.AllowNewBuilding = true;
            this.roomPickerCombo.AllowNewEntity = true;
            this.roomPickerCombo.AllowNewRoom = true;
            this.roomPickerCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomPickerCombo.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Code;
            this.roomPickerCombo.EmptyMemberLabel = "";
            this.roomPickerCombo.Location = new System.Drawing.Point(4, 16);
            this.roomPickerCombo.Margin = new System.Windows.Forms.Padding(0);
            this.roomPickerCombo.ModuleID = 15;
            this.roomPickerCombo.Name = "roomPickerCombo";
            this.roomPickerCombo.OnlyAvailable = true;
            this.roomPickerCombo.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
            this.roomPickerCombo.RoomNameMandatory = true;
            this.roomPickerCombo.SelectNewAfterCreation = true;
            this.roomPickerCombo.SiteCode = null;
            this.roomPickerCombo.Size = new System.Drawing.Size(300, 73);
            this.roomPickerCombo.TabIndex = 0;
            this.roomPickerCombo.SelectionChanged += new System.EventHandler(this.roomPicker_SelectionChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.roomPickerTree);
            this.groupBox5.Location = new System.Drawing.Point(850, 266);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(310, 254);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tree Room Picker Control";
            // 
            // roomPickerTree
            // 
            this.roomPickerTree.AllowNewBuilding = true;
            this.roomPickerTree.AllowNewEntity = true;
            this.roomPickerTree.AllowNewRoom = true;
            this.roomPickerTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomPickerTree.Location = new System.Drawing.Point(6, 19);
            this.roomPickerTree.ModuleID = 15;
            this.roomPickerTree.Name = "roomPickerTree";
            this.roomPickerTree.OnlyAvailable = true;
            this.roomPickerTree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
            this.roomPickerTree.RoomNameMandatory = true;
            this.roomPickerTree.SelectNewAfterCreation = true;
            this.roomPickerTree.ShowImage = true;
            this.roomPickerTree.SiteCode = "";
            this.roomPickerTree.Size = new System.Drawing.Size(298, 229);
            this.roomPickerTree.TabIndex = 0;
            this.roomPickerTree.SelectionChanged += new System.EventHandler(this.roomPickerTree_SelectionChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.btGetRoomID);
            this.groupBox6.Controls.Add(this.roomPickerFree);
            this.groupBox6.Location = new System.Drawing.Point(850, 133);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(310, 127);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Free Room Picker Control";
            // 
            // btGetRoomID
            // 
            this.btGetRoomID.Location = new System.Drawing.Point(87, 98);
            this.btGetRoomID.Name = "btGetRoomID";
            this.btGetRoomID.Size = new System.Drawing.Size(84, 23);
            this.btGetRoomID.TabIndex = 37;
            this.btGetRoomID.Text = "Get Room ID";
            this.btGetRoomID.UseVisualStyleBackColor = true;
            this.btGetRoomID.Click += new System.EventHandler(this.btGetRoomID_Click);
            // 
            // roomPickerFree
            // 
            this.roomPickerFree.AllowNewBuilding = true;
            this.roomPickerFree.AllowNewEntity = true;
            this.roomPickerFree.AllowNewRoom = true;
            this.roomPickerFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomPickerFree.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Code;
            this.roomPickerFree.EmptyMemberLabel = "";
            this.roomPickerFree.Location = new System.Drawing.Point(6, 19);
            this.roomPickerFree.ModuleID = 15;
            this.roomPickerFree.Name = "roomPickerFree";
            this.roomPickerFree.OnlyAvailable = true;
            this.roomPickerFree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
            this.roomPickerFree.RoomNameMandatory = true;
            this.roomPickerFree.SelectNewAfterCreation = true;
            this.roomPickerFree.SiteCode = "";
            this.roomPickerFree.Size = new System.Drawing.Size(298, 73);
            this.roomPickerFree.TabIndex = 0;
            this.roomPickerFree.SelectionChanged += new System.EventHandler(this.roomPickerFree_SelectionChanged);
            // 
            // frmPickerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 532);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.ModuleID = 15;
            this.Name = "frmPickerDemo";
            this.SecurityEnabled = false;
            this.ShowMenu = false;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private SynapseRoomPicker.Controls.AdminEntityMenu mnuAdminEntity;
        private SynapseRoomPicker.Controls.AdminBuildingMenu mnuAdminBuilding;
        private SynapseRoomPicker.Controls.AdminRoomMenu mnuAdminRoom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckNameMandatory;
        private System.Windows.Forms.CheckBox ckImage;
        private System.Windows.Forms.TextBox txModuleID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txEmptyLabel;
        private System.Windows.Forms.CheckBox ckAvailable;
        private System.Windows.Forms.CheckBox ckSelectNew;
        private System.Windows.Forms.RadioButton rbRoom;
        private System.Windows.Forms.RadioButton rbBuilding;
        private System.Windows.Forms.RadioButton rbEntity;
        private System.Windows.Forms.CheckBox ckNewEntity;
        private System.Windows.Forms.CheckBox ckNewBuilding;
        private System.Windows.Forms.CheckBox ckNewRoom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSyncRoomTree;
        private System.Windows.Forms.Button btSyncBuildingTree;
        private System.Windows.Forms.Button tbSyncEntityTree;
        private System.Windows.Forms.Button btErrorRoom;
        private System.Windows.Forms.TextBox txMsgRoom;
        private System.Windows.Forms.Button btErrorBuilding;
        private System.Windows.Forms.TextBox txMsgBuilding;
        private System.Windows.Forms.Button btErrorEntity;
        private System.Windows.Forms.TextBox txMsgEntity;
        private System.Windows.Forms.Button btResetError;
        private System.Windows.Forms.Button btSyncRoomCombo;
        private System.Windows.Forms.Button btSyncBuildingCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txSiteCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.TextBox txSyncRoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSyncEntityCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txSyncBuilding;
        private System.Windows.Forms.TextBox txSyncEntity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txEntityObject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txEntity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txBuilding;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txBuildingObject;
        private System.Windows.Forms.TextBox txRoomObject;
        private System.Windows.Forms.GroupBox groupBox4;
        private SynapseRoomPicker.Controls.RoomPickerCombo roomPickerCombo;
        private System.Windows.Forms.GroupBox groupBox5;
        private SynapseRoomPicker.Controls.RoomPickerTree roomPickerTree;
        private System.Windows.Forms.GroupBox groupBox6;
        private SynapseRoomPicker.Controls.RoomPickerFree roomPickerFree;
        private System.Windows.Forms.Button btGetRoomID;
    }
}