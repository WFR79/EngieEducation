namespace SynapseRoomPicker.Controls
{
    partial class RoomPickerCombo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPickerCombo));
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.lbEntity = new System.Windows.Forms.Label();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.lbBuilding = new System.Windows.Forms.Label();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.lbRoom = new System.Windows.Forms.Label();
            this.btNewRoom = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btNewBuilding = new System.Windows.Forms.Button();
            this.btNewEntity = new System.Windows.Forms.Button();
            this.synapseErrorProvider1 = new SynapseCore.Controls.SynapseErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEntity
            // 
            this.cbEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntity.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbEntity, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbEntity.Location = new System.Drawing.Point(80, 0);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(230, 21);
            this.cbEntity.TabIndex = 0;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // lbEntity
            // 
            this.lbEntity.AutoSize = true;
            this.lbEntity.Location = new System.Drawing.Point(-3, 3);
            this.lbEntity.Name = "lbEntity";
            this.lbEntity.Size = new System.Drawing.Size(33, 13);
            this.lbEntity.TabIndex = 1;
            this.lbEntity.Text = "Entity";
            // 
            // cbBuilding
            // 
            this.cbBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuilding.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbBuilding, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbBuilding.Location = new System.Drawing.Point(80, 27);
            this.cbBuilding.Name = "cbBuilding";
            this.cbBuilding.Size = new System.Drawing.Size(230, 21);
            this.cbBuilding.TabIndex = 2;
            this.cbBuilding.SelectedIndexChanged += new System.EventHandler(this.cbBuilding_SelectedIndexChanged);
            // 
            // lbBuilding
            // 
            this.lbBuilding.AutoSize = true;
            this.lbBuilding.Location = new System.Drawing.Point(-3, 30);
            this.lbBuilding.Name = "lbBuilding";
            this.lbBuilding.Size = new System.Drawing.Size(44, 13);
            this.lbBuilding.TabIndex = 3;
            this.lbBuilding.Text = "Building";
            // 
            // cbRoom
            // 
            this.cbRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoom.FormattingEnabled = true;
            this.synapseErrorProvider1.SetIconAlignment(this.cbRoom, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cbRoom.Location = new System.Drawing.Point(80, 52);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(230, 21);
            this.cbRoom.TabIndex = 4;
            this.cbRoom.SelectedIndexChanged += new System.EventHandler(this.cbRoom_SelectedIndexChanged);
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Location = new System.Drawing.Point(-3, 55);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(35, 13);
            this.lbRoom.TabIndex = 5;
            this.lbRoom.Text = "Room";
            // 
            // btNewRoom
            // 
            this.btNewRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewRoom.ImageKey = "New";
            this.btNewRoom.ImageList = this.imageList1;
            this.btNewRoom.Location = new System.Drawing.Point(316, 52);
            this.btNewRoom.Name = "btNewRoom";
            this.btNewRoom.Size = new System.Drawing.Size(29, 21);
            this.btNewRoom.TabIndex = 5;
            this.btNewRoom.UseVisualStyleBackColor = true;
            this.btNewRoom.Click += new System.EventHandler(this.btNewRoom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "New");
            // 
            // btNewBuilding
            // 
            this.btNewBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewBuilding.ImageKey = "New";
            this.btNewBuilding.ImageList = this.imageList1;
            this.btNewBuilding.Location = new System.Drawing.Point(316, 26);
            this.btNewBuilding.Name = "btNewBuilding";
            this.btNewBuilding.Size = new System.Drawing.Size(29, 21);
            this.btNewBuilding.TabIndex = 3;
            this.btNewBuilding.UseVisualStyleBackColor = true;
            this.btNewBuilding.Click += new System.EventHandler(this.btNewBuilding_Click);
            // 
            // btNewEntity
            // 
            this.btNewEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewEntity.ImageKey = "New";
            this.btNewEntity.ImageList = this.imageList1;
            this.btNewEntity.Location = new System.Drawing.Point(316, -1);
            this.btNewEntity.Name = "btNewEntity";
            this.btNewEntity.Size = new System.Drawing.Size(29, 21);
            this.btNewEntity.TabIndex = 1;
            this.btNewEntity.UseVisualStyleBackColor = true;
            this.btNewEntity.Click += new System.EventHandler(this.btNewEntity_Click);
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // RoomPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEntity);
            this.Controls.Add(this.btNewEntity);
            this.Controls.Add(this.btNewBuilding);
            this.Controls.Add(this.btNewRoom);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.lbBuilding);
            this.Controls.Add(this.lbEntity);
            this.Controls.Add(this.cbBuilding);
            this.synapseErrorProvider1.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RoomPicker";
            this.Size = new System.Drawing.Size(345, 73);
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEntity;
        private System.Windows.Forms.Label lbEntity;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.Label lbBuilding;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Button btNewRoom;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btNewBuilding;
        private System.Windows.Forms.Button btNewEntity;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;

    }
}
