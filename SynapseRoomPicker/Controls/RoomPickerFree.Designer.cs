namespace SynapseRoomPicker.Controls
{
    partial class RoomPickerFree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPickerFree));
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btNewEntity = new System.Windows.Forms.Button();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.btNewBuilding = new System.Windows.Forms.Button();
            this.lbRoom = new System.Windows.Forms.Label();
            this.lbBuilding = new System.Windows.Forms.Label();
            this.lbEntity = new System.Windows.Forms.Label();
            this.txRoom = new System.Windows.Forms.TextBox();
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
            this.cbEntity.TabIndex = 6;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "New");
            // 
            // btNewEntity
            // 
            this.btNewEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewEntity.ImageKey = "New";
            this.btNewEntity.ImageList = this.imageList1;
            this.btNewEntity.Location = new System.Drawing.Point(316, -1);
            this.btNewEntity.Name = "btNewEntity";
            this.btNewEntity.Size = new System.Drawing.Size(29, 21);
            this.btNewEntity.TabIndex = 8;
            this.btNewEntity.UseVisualStyleBackColor = true;
            this.btNewEntity.Click += new System.EventHandler(this.btNewEntity_Click);
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
            this.cbBuilding.TabIndex = 9;
            this.cbBuilding.SelectedIndexChanged += new System.EventHandler(this.cbBuilding_SelectedIndexChanged);
            // 
            // btNewBuilding
            // 
            this.btNewBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNewBuilding.ImageKey = "New";
            this.btNewBuilding.ImageList = this.imageList1;
            this.btNewBuilding.Location = new System.Drawing.Point(316, 26);
            this.btNewBuilding.Name = "btNewBuilding";
            this.btNewBuilding.Size = new System.Drawing.Size(29, 21);
            this.btNewBuilding.TabIndex = 10;
            this.btNewBuilding.UseVisualStyleBackColor = true;
            this.btNewBuilding.Click += new System.EventHandler(this.btNewBuilding_Click);
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Location = new System.Drawing.Point(-2, 55);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(35, 13);
            this.lbRoom.TabIndex = 14;
            this.lbRoom.Text = "Room";
            // 
            // lbBuilding
            // 
            this.lbBuilding.AutoSize = true;
            this.lbBuilding.Location = new System.Drawing.Point(-2, 30);
            this.lbBuilding.Name = "lbBuilding";
            this.lbBuilding.Size = new System.Drawing.Size(44, 13);
            this.lbBuilding.TabIndex = 11;
            this.lbBuilding.Text = "Building";
            // 
            // lbEntity
            // 
            this.lbEntity.AutoSize = true;
            this.lbEntity.Location = new System.Drawing.Point(-2, 3);
            this.lbEntity.Name = "lbEntity";
            this.lbEntity.Size = new System.Drawing.Size(33, 13);
            this.lbEntity.TabIndex = 7;
            this.lbEntity.Text = "Entity";
            // 
            // txRoom
            // 
            this.txRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.synapseErrorProvider1.SetIconAlignment(this.txRoom, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txRoom.Location = new System.Drawing.Point(80, 52);
            this.txRoom.MaxLength = 20;
            this.txRoom.Name = "txRoom";
            this.txRoom.Size = new System.Drawing.Size(264, 20);
            this.txRoom.TabIndex = 15;
            // 
            // synapseErrorProvider1
            // 
            this.synapseErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.synapseErrorProvider1.ContainerControl = this;
            this.synapseErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("synapseErrorProvider1.Icon")));
            this.synapseErrorProvider1.ShowMessageBox = true;
            // 
            // RoomPickerFree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txRoom);
            this.Controls.Add(this.cbEntity);
            this.Controls.Add(this.btNewEntity);
            this.Controls.Add(this.btNewBuilding);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.lbBuilding);
            this.Controls.Add(this.lbEntity);
            this.Controls.Add(this.cbBuilding);
            this.Name = "RoomPickerFree";
            this.Size = new System.Drawing.Size(345, 73);
            ((System.ComponentModel.ISupportInitialize)(this.synapseErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEntity;
        private SynapseCore.Controls.SynapseErrorProvider synapseErrorProvider1;
        private System.Windows.Forms.Button btNewEntity;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btNewBuilding;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Label lbBuilding;
        private System.Windows.Forms.Label lbEntity;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.TextBox txRoom;
    }
}
