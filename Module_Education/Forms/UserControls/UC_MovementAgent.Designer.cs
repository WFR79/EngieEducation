namespace Module_Education.Forms.UserControls
{
    partial class UC_MovementAgent
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
            this.tabControlMovement = new System.Windows.Forms.TabControl();
            this.tbListMovement = new System.Windows.Forms.TabPage();
            this.btnManageMvt = new System.Windows.Forms.Button();
            this.btnSaveProgressRoute = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblNbrRowsAgent = new System.Windows.Forms.Label();
            this.tbNbrRows = new System.Windows.Forms.TextBox();
            this.lblNbrRows = new System.Windows.Forms.Label();
            this.picExportExcel = new System.Windows.Forms.PictureBox();
            this.dG_MvtAgents = new Zuby.ADGV.AdvancedDataGridView();
            this.btn_NextAgent = new System.Windows.Forms.Button();
            this.btn_PreviousAgent = new System.Windows.Forms.Button();
            this.lblTiteLstAgent = new System.Windows.Forms.Label();
            this.tabMvtDetails = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatut = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelStepAgent = new System.Windows.Forms.Panel();
            this.cbStatut = new System.Windows.Forms.ComboBox();
            this.tbStepAgentRemarks = new System.Windows.Forms.TextBox();
            this.tbStepAgentWho = new System.Windows.Forms.TextBox();
            this.picSaveStepAgent = new System.Windows.Forms.PictureBox();
            this.tbStepAgentAction = new System.Windows.Forms.TextBox();
            this.tbStepAgentSupport = new System.Windows.Forms.TextBox();
            this.lblOPP = new System.Windows.Forms.Label();
            this.lblTCAction = new System.Windows.Forms.Label();
            this.lblLHFutur = new System.Windows.Forms.Label();
            this.lblLHActual = new System.Windows.Forms.Label();
            this.lblServiceActual = new System.Windows.Forms.Label();
            this.cbServiceActual = new System.Windows.Forms.ComboBox();
            this.lblAdminAction = new System.Windows.Forms.Label();
            this.lblServiceFutur = new System.Windows.Forms.Label();
            this.lblDateDemande = new System.Windows.Forms.Label();
            this.lblMvtToBeDone = new System.Windows.Forms.Label();
            this.cbMvtToBeDone = new System.Windows.Forms.ComboBox();
            this.cbServiceFutur = new System.Windows.Forms.ComboBox();
            this.datePRequest = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPercentage = new System.Windows.Forms.TextBox();
            this.tbAgentName = new System.Windows.Forms.TextBox();
            this.lblTypemvt = new System.Windows.Forms.TextBox();
            this.tabEditSteps = new System.Windows.Forms.TabPage();
            this.cbTypeMvt = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblSupport = new System.Windows.Forms.Label();
            this.lvlHeaderWho = new System.Windows.Forms.Label();
            this.panelStepItem = new System.Windows.Forms.Panel();
            this.tbWhoStep = new System.Windows.Forms.TextBox();
            this.picAddStep = new System.Windows.Forms.PictureBox();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.tbSupport = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbActionOPP = new Module_Education.Classes.TextBoxExtensions();
            this.tbTCAction = new Module_Education.Classes.TextBoxExtensions();
            this.tbLHFutur = new Module_Education.Classes.TextBoxExtensions();
            this.tbLHActuel = new Module_Education.Classes.TextBoxExtensions();
            this.textBoxAdmin = new Module_Education.Classes.TextBoxExtensions();
            this.tabControlMovement.SuspendLayout();
            this.tbListMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_MvtAgents)).BeginInit();
            this.tabMvtDetails.SuspendLayout();
            this.panelStepAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveStepAgent)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabEditSteps.SuspendLayout();
            this.panelStepItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMovement
            // 
            this.tabControlMovement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMovement.Controls.Add(this.tbListMovement);
            this.tabControlMovement.Controls.Add(this.tabMvtDetails);
            this.tabControlMovement.Controls.Add(this.tabEditSteps);
            this.tabControlMovement.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabControlMovement.Location = new System.Drawing.Point(2, 3);
            this.tabControlMovement.Name = "tabControlMovement";
            this.tabControlMovement.SelectedIndex = 0;
            this.tabControlMovement.Size = new System.Drawing.Size(1199, 566);
            this.tabControlMovement.TabIndex = 1;
            // 
            // tbListMovement
            // 
            this.tbListMovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbListMovement.Controls.Add(this.btnManageMvt);
            this.tbListMovement.Controls.Add(this.btnSaveProgressRoute);
            this.tbListMovement.Controls.Add(this.btnRefresh);
            this.tbListMovement.Controls.Add(this.label4);
            this.tbListMovement.Controls.Add(this.lblMax);
            this.tbListMovement.Controls.Add(this.lblMin);
            this.tbListMovement.Controls.Add(this.lblNbrRowsAgent);
            this.tbListMovement.Controls.Add(this.tbNbrRows);
            this.tbListMovement.Controls.Add(this.lblNbrRows);
            this.tbListMovement.Controls.Add(this.picExportExcel);
            this.tbListMovement.Controls.Add(this.dG_MvtAgents);
            this.tbListMovement.Controls.Add(this.btn_NextAgent);
            this.tbListMovement.Controls.Add(this.btn_PreviousAgent);
            this.tbListMovement.Controls.Add(this.lblTiteLstAgent);
            this.tbListMovement.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbListMovement.Location = new System.Drawing.Point(4, 23);
            this.tbListMovement.Name = "tbListMovement";
            this.tbListMovement.Padding = new System.Windows.Forms.Padding(3);
            this.tbListMovement.Size = new System.Drawing.Size(1191, 539);
            this.tbListMovement.TabIndex = 0;
            this.tbListMovement.Text = "Liste mouvements du personnel";
            // 
            // btnManageMvt
            // 
            this.btnManageMvt.AllowDrop = true;
            this.btnManageMvt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnManageMvt.FlatAppearance.BorderSize = 0;
            this.btnManageMvt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMvt.Font = new System.Drawing.Font("Arial", 10F);
            this.btnManageMvt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManageMvt.Location = new System.Drawing.Point(358, 9);
            this.btnManageMvt.Name = "btnManageMvt";
            this.btnManageMvt.Size = new System.Drawing.Size(135, 27);
            this.btnManageMvt.TabIndex = 97;
            this.btnManageMvt.Text = "Gestion";
            this.btnManageMvt.UseVisualStyleBackColor = false;
            // 
            // btnSaveProgressRoute
            // 
            this.btnSaveProgressRoute.AllowDrop = true;
            this.btnSaveProgressRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnSaveProgressRoute.FlatAppearance.BorderSize = 0;
            this.btnSaveProgressRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProgressRoute.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSaveProgressRoute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveProgressRoute.Location = new System.Drawing.Point(864, 9);
            this.btnSaveProgressRoute.Name = "btnSaveProgressRoute";
            this.btnSaveProgressRoute.Size = new System.Drawing.Size(135, 27);
            this.btnSaveProgressRoute.TabIndex = 96;
            this.btnSaveProgressRoute.Text = "Afficher Tout";
            this.btnSaveProgressRoute.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnRefresh.Location = new System.Drawing.Point(962, 495);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.Text = "Rafaichir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "-";
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMax.AutoSize = true;
            this.lblMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMax.Location = new System.Drawing.Point(557, 499);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(35, 14);
            this.lblMax.TabIndex = 25;
            this.lblMax.Text = "label3";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMax.Visible = false;
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMin.AutoSize = true;
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMin.Location = new System.Drawing.Point(512, 499);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(35, 14);
            this.lblMin.TabIndex = 24;
            this.lblMin.Text = "label2";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.Visible = false;
            // 
            // lblNbrRowsAgent
            // 
            this.lblNbrRowsAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNbrRowsAgent.AutoSize = true;
            this.lblNbrRowsAgent.Enabled = false;
            this.lblNbrRowsAgent.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRowsAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRowsAgent.Location = new System.Drawing.Point(10, 496);
            this.lblNbrRowsAgent.Name = "lblNbrRowsAgent";
            this.lblNbrRowsAgent.Size = new System.Drawing.Size(42, 16);
            this.lblNbrRowsAgent.TabIndex = 23;
            this.lblNbrRowsAgent.Text = "label1";
            // 
            // tbNbrRows
            // 
            this.tbNbrRows.Location = new System.Drawing.Point(822, 13);
            this.tbNbrRows.Name = "tbNbrRows";
            this.tbNbrRows.Size = new System.Drawing.Size(36, 20);
            this.tbNbrRows.TabIndex = 21;
            this.tbNbrRows.Text = "50";
            // 
            // lblNbrRows
            // 
            this.lblNbrRows.AutoSize = true;
            this.lblNbrRows.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRows.Location = new System.Drawing.Point(653, 15);
            this.lblNbrRows.Name = "lblNbrRows";
            this.lblNbrRows.Size = new System.Drawing.Size(169, 16);
            this.lblNbrRows.TabIndex = 20;
            this.lblNbrRows.Text = "Nombre de lignes à afficher:";
            // 
            // picExportExcel
            // 
            this.picExportExcel.Location = new System.Drawing.Point(1005, 9);
            this.picExportExcel.Name = "picExportExcel";
            this.picExportExcel.Size = new System.Drawing.Size(32, 32);
            this.picExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExportExcel.TabIndex = 19;
            this.picExportExcel.TabStop = false;
            // 
            // dG_MvtAgents
            // 
            this.dG_MvtAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dG_MvtAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dG_MvtAgents.BackgroundColor = System.Drawing.Color.White;
            this.dG_MvtAgents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dG_MvtAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_MvtAgents.FilterAndSortEnabled = true;
            this.dG_MvtAgents.Location = new System.Drawing.Point(8, 52);
            this.dG_MvtAgents.MultiSelect = false;
            this.dG_MvtAgents.Name = "dG_MvtAgents";
            this.dG_MvtAgents.ReadOnly = true;
            this.dG_MvtAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_MvtAgents.Size = new System.Drawing.Size(1106, 428);
            this.dG_MvtAgents.TabIndex = 18;
            this.dG_MvtAgents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dG_MvtAgents_MouseClick);
            // 
            // btn_NextAgent
            // 
            this.btn_NextAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_NextAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_NextAgent.Location = new System.Drawing.Point(593, 495);
            this.btn_NextAgent.Name = "btn_NextAgent";
            this.btn_NextAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_NextAgent.TabIndex = 16;
            this.btn_NextAgent.Text = "Suivant";
            this.btn_NextAgent.UseVisualStyleBackColor = true;
            this.btn_NextAgent.Visible = false;
            // 
            // btn_PreviousAgent
            // 
            this.btn_PreviousAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PreviousAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_PreviousAgent.Location = new System.Drawing.Point(433, 495);
            this.btn_PreviousAgent.Name = "btn_PreviousAgent";
            this.btn_PreviousAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_PreviousAgent.TabIndex = 15;
            this.btn_PreviousAgent.Text = "Précédent";
            this.btn_PreviousAgent.UseVisualStyleBackColor = true;
            this.btn_PreviousAgent.Visible = false;
            // 
            // lblTiteLstAgent
            // 
            this.lblTiteLstAgent.AutoSize = true;
            this.lblTiteLstAgent.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiteLstAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblTiteLstAgent.Location = new System.Drawing.Point(9, 11);
            this.lblTiteLstAgent.Name = "lblTiteLstAgent";
            this.lblTiteLstAgent.Size = new System.Drawing.Size(324, 24);
            this.lblTiteLstAgent.TabIndex = 8;
            this.lblTiteLstAgent.Text = "Suivi Mouvement du personnel";
            // 
            // tabMvtDetails
            // 
            this.tabMvtDetails.AutoScroll = true;
            this.tabMvtDetails.BackColor = System.Drawing.Color.White;
            this.tabMvtDetails.Controls.Add(this.button1);
            this.tabMvtDetails.Controls.Add(this.lblStatut);
            this.tabMvtDetails.Controls.Add(this.label11);
            this.tabMvtDetails.Controls.Add(this.lblRemarks);
            this.tabMvtDetails.Controls.Add(this.label2);
            this.tabMvtDetails.Controls.Add(this.label3);
            this.tabMvtDetails.Controls.Add(this.label5);
            this.tabMvtDetails.Controls.Add(this.panelStepAgent);
            this.tabMvtDetails.Controls.Add(this.lblOPP);
            this.tabMvtDetails.Controls.Add(this.lblTCAction);
            this.tabMvtDetails.Controls.Add(this.lblLHFutur);
            this.tabMvtDetails.Controls.Add(this.lblLHActual);
            this.tabMvtDetails.Controls.Add(this.lblServiceActual);
            this.tabMvtDetails.Controls.Add(this.cbServiceActual);
            this.tabMvtDetails.Controls.Add(this.lblAdminAction);
            this.tabMvtDetails.Controls.Add(this.lblServiceFutur);
            this.tabMvtDetails.Controls.Add(this.lblDateDemande);
            this.tabMvtDetails.Controls.Add(this.lblMvtToBeDone);
            this.tabMvtDetails.Controls.Add(this.cbMvtToBeDone);
            this.tabMvtDetails.Controls.Add(this.cbServiceFutur);
            this.tabMvtDetails.Controls.Add(this.datePRequest);
            this.tabMvtDetails.Controls.Add(this.panel1);
            this.tabMvtDetails.Controls.Add(this.tbActionOPP);
            this.tabMvtDetails.Controls.Add(this.tbTCAction);
            this.tabMvtDetails.Controls.Add(this.tbLHFutur);
            this.tabMvtDetails.Controls.Add(this.tbLHActuel);
            this.tabMvtDetails.Controls.Add(this.textBoxAdmin);
            this.tabMvtDetails.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabMvtDetails.Location = new System.Drawing.Point(4, 23);
            this.tabMvtDetails.Name = "tabMvtDetails";
            this.tabMvtDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabMvtDetails.Size = new System.Drawing.Size(1191, 539);
            this.tabMvtDetails.TabIndex = 1;
            this.tabMvtDetails.Text = "Détails";
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(271, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 27);
            this.button1.TabIndex = 110;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblStatut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblStatut.Location = new System.Drawing.Point(675, 359);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(33, 16);
            this.lblStatut.TabIndex = 146;
            this.lblStatut.Text = "Etat";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(20, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1072, 1);
            this.label11.TabIndex = 145;
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRemarks.Location = new System.Drawing.Point(870, 359);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(81, 16);
            this.lblRemarks.TabIndex = 144;
            this.lblRemarks.Text = "Remarques";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(486, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 143;
            this.label2.Text = "Action";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(201, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Support";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label5.Location = new System.Drawing.Point(44, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 141;
            this.label5.Text = "Qui?";
            // 
            // panelStepAgent
            // 
            this.panelStepAgent.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelStepAgent.Controls.Add(this.cbStatut);
            this.panelStepAgent.Controls.Add(this.tbStepAgentRemarks);
            this.panelStepAgent.Controls.Add(this.tbStepAgentWho);
            this.panelStepAgent.Controls.Add(this.picSaveStepAgent);
            this.panelStepAgent.Controls.Add(this.tbStepAgentAction);
            this.panelStepAgent.Controls.Add(this.tbStepAgentSupport);
            this.panelStepAgent.Location = new System.Drawing.Point(20, 383);
            this.panelStepAgent.Name = "panelStepAgent";
            this.panelStepAgent.Size = new System.Drawing.Size(1117, 49);
            this.panelStepAgent.TabIndex = 140;
            // 
            // cbStatut
            // 
            this.cbStatut.FormattingEnabled = true;
            this.cbStatut.Items.AddRange(new object[] {
            "Fait",
            "Pas Fait",
            "NA"});
            this.cbStatut.Location = new System.Drawing.Point(633, 9);
            this.cbStatut.Name = "cbStatut";
            this.cbStatut.Size = new System.Drawing.Size(79, 22);
            this.cbStatut.TabIndex = 7;
            // 
            // tbStepAgentRemarks
            // 
            this.tbStepAgentRemarks.Location = new System.Drawing.Point(718, 9);
            this.tbStepAgentRemarks.Multiline = true;
            this.tbStepAgentRemarks.Name = "tbStepAgentRemarks";
            this.tbStepAgentRemarks.Size = new System.Drawing.Size(312, 32);
            this.tbStepAgentRemarks.TabIndex = 6;
            // 
            // tbStepAgentWho
            // 
            this.tbStepAgentWho.Location = new System.Drawing.Point(12, 9);
            this.tbStepAgentWho.Multiline = true;
            this.tbStepAgentWho.Name = "tbStepAgentWho";
            this.tbStepAgentWho.Size = new System.Drawing.Size(72, 22);
            this.tbStepAgentWho.TabIndex = 5;
            // 
            // picSaveStepAgent
            // 
            this.picSaveStepAgent.Image = global::Module_Education.Properties.Resources.outline_save_black_24dp1;
            this.picSaveStepAgent.Location = new System.Drawing.Point(1036, 9);
            this.picSaveStepAgent.Name = "picSaveStepAgent";
            this.picSaveStepAgent.Size = new System.Drawing.Size(32, 32);
            this.picSaveStepAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSaveStepAgent.TabIndex = 3;
            this.picSaveStepAgent.TabStop = false;
            // 
            // tbStepAgentAction
            // 
            this.tbStepAgentAction.Location = new System.Drawing.Point(341, 9);
            this.tbStepAgentAction.Multiline = true;
            this.tbStepAgentAction.Name = "tbStepAgentAction";
            this.tbStepAgentAction.Size = new System.Drawing.Size(286, 32);
            this.tbStepAgentAction.TabIndex = 2;
            // 
            // tbStepAgentSupport
            // 
            this.tbStepAgentSupport.Location = new System.Drawing.Point(90, 9);
            this.tbStepAgentSupport.Multiline = true;
            this.tbStepAgentSupport.Name = "tbStepAgentSupport";
            this.tbStepAgentSupport.Size = new System.Drawing.Size(245, 32);
            this.tbStepAgentSupport.TabIndex = 1;
            // 
            // lblOPP
            // 
            this.lblOPP.AutoSize = true;
            this.lblOPP.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblOPP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblOPP.Location = new System.Drawing.Point(217, 133);
            this.lblOPP.Name = "lblOPP";
            this.lblOPP.Size = new System.Drawing.Size(116, 16);
            this.lblOPP.TabIndex = 138;
            this.lblOPP.Text = "Action admin OPP";
            // 
            // lblTCAction
            // 
            this.lblTCAction.AutoSize = true;
            this.lblTCAction.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblTCAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTCAction.Location = new System.Drawing.Point(218, 83);
            this.lblTCAction.Name = "lblTCAction";
            this.lblTCAction.Size = new System.Drawing.Size(92, 16);
            this.lblTCAction.TabIndex = 136;
            this.lblTCAction.Text = "TC pour action";
            // 
            // lblLHFutur
            // 
            this.lblLHFutur.AutoSize = true;
            this.lblLHFutur.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblLHFutur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblLHFutur.Location = new System.Drawing.Point(218, 224);
            this.lblLHFutur.Name = "lblLHFutur";
            this.lblLHFutur.Size = new System.Drawing.Size(53, 16);
            this.lblLHFutur.TabIndex = 134;
            this.lblLHFutur.Text = "LH futur";
            // 
            // lblLHActual
            // 
            this.lblLHActual.AutoSize = true;
            this.lblLHActual.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblLHActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblLHActual.Location = new System.Drawing.Point(219, 174);
            this.lblLHActual.Name = "lblLHActual";
            this.lblLHActual.Size = new System.Drawing.Size(63, 16);
            this.lblLHActual.TabIndex = 132;
            this.lblLHActual.Text = "LH actuel";
            // 
            // lblServiceActual
            // 
            this.lblServiceActual.AutoSize = true;
            this.lblServiceActual.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblServiceActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblServiceActual.Location = new System.Drawing.Point(17, 174);
            this.lblServiceActual.Name = "lblServiceActual";
            this.lblServiceActual.Size = new System.Drawing.Size(89, 16);
            this.lblServiceActual.TabIndex = 131;
            this.lblServiceActual.Text = "Service actuel";
            // 
            // cbServiceActual
            // 
            this.cbServiceActual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbServiceActual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbServiceActual.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbServiceActual.FormattingEnabled = true;
            this.cbServiceActual.Location = new System.Drawing.Point(17, 194);
            this.cbServiceActual.Name = "cbServiceActual";
            this.cbServiceActual.Size = new System.Drawing.Size(185, 22);
            this.cbServiceActual.TabIndex = 102;
            this.cbServiceActual.Text = "Equipe/Affectation";
            // 
            // lblAdminAction
            // 
            this.lblAdminAction.AutoSize = true;
            this.lblAdminAction.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblAdminAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblAdminAction.Location = new System.Drawing.Point(14, 129);
            this.lblAdminAction.Name = "lblAdminAction";
            this.lblAdminAction.Size = new System.Drawing.Size(113, 16);
            this.lblAdminAction.TabIndex = 125;
            this.lblAdminAction.Text = "Admin pour action";
            // 
            // lblServiceFutur
            // 
            this.lblServiceFutur.AutoSize = true;
            this.lblServiceFutur.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblServiceFutur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblServiceFutur.Location = new System.Drawing.Point(17, 223);
            this.lblServiceFutur.Name = "lblServiceFutur";
            this.lblServiceFutur.Size = new System.Drawing.Size(84, 16);
            this.lblServiceFutur.TabIndex = 122;
            this.lblServiceFutur.Text = "Service Futur";
            // 
            // lblDateDemande
            // 
            this.lblDateDemande.AutoSize = true;
            this.lblDateDemande.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblDateDemande.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDateDemande.Location = new System.Drawing.Point(14, 271);
            this.lblDateDemande.Name = "lblDateDemande";
            this.lblDateDemande.Size = new System.Drawing.Size(124, 16);
            this.lblDateDemande.TabIndex = 119;
            this.lblDateDemande.Text = "Date de la demande";
            // 
            // lblMvtToBeDone
            // 
            this.lblMvtToBeDone.AutoSize = true;
            this.lblMvtToBeDone.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblMvtToBeDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblMvtToBeDone.Location = new System.Drawing.Point(17, 83);
            this.lblMvtToBeDone.Name = "lblMvtToBeDone";
            this.lblMvtToBeDone.Size = new System.Drawing.Size(113, 16);
            this.lblMvtToBeDone.TabIndex = 118;
            this.lblMvtToBeDone.Text = "Mouvement à faire";
            // 
            // cbMvtToBeDone
            // 
            this.cbMvtToBeDone.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbMvtToBeDone.FormattingEnabled = true;
            this.cbMvtToBeDone.Location = new System.Drawing.Point(17, 104);
            this.cbMvtToBeDone.Name = "cbMvtToBeDone";
            this.cbMvtToBeDone.Size = new System.Drawing.Size(186, 22);
            this.cbMvtToBeDone.TabIndex = 100;
            // 
            // cbServiceFutur
            // 
            this.cbServiceFutur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbServiceFutur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbServiceFutur.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbServiceFutur.FormattingEnabled = true;
            this.cbServiceFutur.Location = new System.Drawing.Point(17, 243);
            this.cbServiceFutur.Name = "cbServiceFutur";
            this.cbServiceFutur.Size = new System.Drawing.Size(185, 22);
            this.cbServiceFutur.TabIndex = 103;
            this.cbServiceFutur.Text = "Equipe/Affectation";
            // 
            // datePRequest
            // 
            this.datePRequest.Location = new System.Drawing.Point(17, 287);
            this.datePRequest.Name = "datePRequest";
            this.datePRequest.Size = new System.Drawing.Size(200, 20);
            this.datePRequest.TabIndex = 104;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbPercentage);
            this.panel1.Controls.Add(this.tbAgentName);
            this.panel1.Controls.Add(this.lblTypemvt);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 80);
            this.panel1.TabIndex = 98;
            // 
            // tbPercentage
            // 
            this.tbPercentage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPercentage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.tbPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.tbPercentage.Location = new System.Drawing.Point(464, 28);
            this.tbPercentage.Name = "tbPercentage";
            this.tbPercentage.Size = new System.Drawing.Size(180, 25);
            this.tbPercentage.TabIndex = 3;
            this.tbPercentage.Text = "New Hire";
            // 
            // tbAgentName
            // 
            this.tbAgentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAgentName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.tbAgentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.tbAgentName.Location = new System.Drawing.Point(28, 48);
            this.tbAgentName.Name = "tbAgentName";
            this.tbAgentName.Size = new System.Drawing.Size(261, 25);
            this.tbAgentName.TabIndex = 2;
            this.tbAgentName.Text = "Agent Name";
            // 
            // lblTypemvt
            // 
            this.lblTypemvt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTypemvt.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTypemvt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTypemvt.Location = new System.Drawing.Point(17, 17);
            this.lblTypemvt.Name = "lblTypemvt";
            this.lblTypemvt.Size = new System.Drawing.Size(261, 25);
            this.lblTypemvt.TabIndex = 1;
            this.lblTypemvt.Text = "New Hire";
            // 
            // tabEditSteps
            // 
            this.tabEditSteps.AutoScroll = true;
            this.tabEditSteps.Controls.Add(this.cbTypeMvt);
            this.tabEditSteps.Controls.Add(this.lblAction);
            this.tabEditSteps.Controls.Add(this.lblSupport);
            this.tabEditSteps.Controls.Add(this.lvlHeaderWho);
            this.tabEditSteps.Controls.Add(this.panelStepItem);
            this.tabEditSteps.Controls.Add(this.label1);
            this.tabEditSteps.Location = new System.Drawing.Point(4, 23);
            this.tabEditSteps.Name = "tabEditSteps";
            this.tabEditSteps.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditSteps.Size = new System.Drawing.Size(1191, 539);
            this.tabEditSteps.TabIndex = 2;
            this.tabEditSteps.Text = "Editions des check-listes";
            this.tabEditSteps.UseVisualStyleBackColor = true;
            // 
            // cbTypeMvt
            // 
            this.cbTypeMvt.FormattingEnabled = true;
            this.cbTypeMvt.Location = new System.Drawing.Point(24, 37);
            this.cbTypeMvt.Name = "cbTypeMvt";
            this.cbTypeMvt.Size = new System.Drawing.Size(242, 22);
            this.cbTypeMvt.TabIndex = 97;
            this.cbTypeMvt.SelectedIndexChanged += new System.EventHandler(this.cbTypeMvt_SelectedIndexChanged);
            this.cbTypeMvt.TextChanged += new System.EventHandler(this.cbTypeMvt_TextChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblAction.Location = new System.Drawing.Point(717, 74);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(47, 16);
            this.lblAction.TabIndex = 96;
            this.lblAction.Text = "Action";
            // 
            // lblSupport
            // 
            this.lblSupport.AutoSize = true;
            this.lblSupport.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lblSupport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSupport.Location = new System.Drawing.Point(363, 74);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(58, 16);
            this.lblSupport.TabIndex = 95;
            this.lblSupport.Text = "Support";
            // 
            // lvlHeaderWho
            // 
            this.lvlHeaderWho.AutoSize = true;
            this.lvlHeaderWho.Font = new System.Drawing.Font("Arial", 10.25F);
            this.lvlHeaderWho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lvlHeaderWho.Location = new System.Drawing.Point(112, 74);
            this.lvlHeaderWho.Name = "lvlHeaderWho";
            this.lvlHeaderWho.Size = new System.Drawing.Size(38, 16);
            this.lvlHeaderWho.TabIndex = 94;
            this.lvlHeaderWho.Text = "Qui?";
            // 
            // panelStepItem
            // 
            this.panelStepItem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelStepItem.Controls.Add(this.tbWhoStep);
            this.panelStepItem.Controls.Add(this.picAddStep);
            this.panelStepItem.Controls.Add(this.picSave);
            this.panelStepItem.Controls.Add(this.tbAction);
            this.panelStepItem.Controls.Add(this.tbSupport);
            this.panelStepItem.Controls.Add(this.lblNum);
            this.panelStepItem.Location = new System.Drawing.Point(21, 95);
            this.panelStepItem.Name = "panelStepItem";
            this.panelStepItem.Size = new System.Drawing.Size(1093, 63);
            this.panelStepItem.TabIndex = 93;
            // 
            // tbWhoStep
            // 
            this.tbWhoStep.Location = new System.Drawing.Point(49, 7);
            this.tbWhoStep.Multiline = true;
            this.tbWhoStep.Name = "tbWhoStep";
            this.tbWhoStep.Size = new System.Drawing.Size(108, 22);
            this.tbWhoStep.TabIndex = 5;
            // 
            // picAddStep
            // 
            this.picAddStep.Image = global::Module_Education.Properties.Resources.add_512;
            this.picAddStep.Location = new System.Drawing.Point(1025, 9);
            this.picAddStep.Name = "picAddStep";
            this.picAddStep.Size = new System.Drawing.Size(32, 32);
            this.picAddStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddStep.TabIndex = 4;
            this.picAddStep.TabStop = false;
            this.picAddStep.Click += new System.EventHandler(this.ClickAddLine);
            // 
            // picSave
            // 
            this.picSave.Image = global::Module_Education.Properties.Resources.outline_save_black_24dp1;
            this.picSave.Location = new System.Drawing.Point(975, 9);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(32, 32);
            this.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSave.TabIndex = 3;
            this.picSave.TabStop = false;
            this.picSave.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tbAction
            // 
            this.tbAction.Location = new System.Drawing.Point(550, 7);
            this.tbAction.Multiline = true;
            this.tbAction.Name = "tbAction";
            this.tbAction.Size = new System.Drawing.Size(321, 45);
            this.tbAction.TabIndex = 2;
            // 
            // tbSupport
            // 
            this.tbSupport.Location = new System.Drawing.Point(196, 7);
            this.tbSupport.Multiline = true;
            this.tbSupport.Name = "tbSupport";
            this.tbSupport.Size = new System.Drawing.Size(321, 45);
            this.tbSupport.TabIndex = 1;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNum.Location = new System.Drawing.Point(12, 9);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(15, 16);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "Type de mouvement";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbActionOPP
            // 
            this.tbActionOPP.Location = new System.Drawing.Point(221, 153);
            this.tbActionOPP.Name = "tbActionOPP";
            this.tbActionOPP.Size = new System.Drawing.Size(185, 20);
            this.tbActionOPP.TabIndex = 107;
            // 
            // tbTCAction
            // 
            this.tbTCAction.Location = new System.Drawing.Point(222, 103);
            this.tbTCAction.Name = "tbTCAction";
            this.tbTCAction.Size = new System.Drawing.Size(185, 20);
            this.tbTCAction.TabIndex = 106;
            // 
            // tbLHFutur
            // 
            this.tbLHFutur.Location = new System.Drawing.Point(222, 244);
            this.tbLHFutur.Name = "tbLHFutur";
            this.tbLHFutur.Size = new System.Drawing.Size(185, 20);
            this.tbLHFutur.TabIndex = 109;
            // 
            // tbLHActuel
            // 
            this.tbLHActuel.Location = new System.Drawing.Point(223, 194);
            this.tbLHActuel.Name = "tbLHActuel";
            this.tbLHActuel.Size = new System.Drawing.Size(185, 20);
            this.tbLHActuel.TabIndex = 108;
            // 
            // textBoxAdmin
            // 
            this.textBoxAdmin.Location = new System.Drawing.Point(18, 149);
            this.textBoxAdmin.Name = "textBoxAdmin";
            this.textBoxAdmin.Size = new System.Drawing.Size(185, 20);
            this.textBoxAdmin.TabIndex = 101;
            // 
            // UC_MovementAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMovement);
            this.Name = "UC_MovementAgent";
            this.Size = new System.Drawing.Size(1202, 573);
            this.tabControlMovement.ResumeLayout(false);
            this.tbListMovement.ResumeLayout(false);
            this.tbListMovement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_MvtAgents)).EndInit();
            this.tabMvtDetails.ResumeLayout(false);
            this.tabMvtDetails.PerformLayout();
            this.panelStepAgent.ResumeLayout(false);
            this.panelStepAgent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveStepAgent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabEditSteps.ResumeLayout(false);
            this.tabEditSteps.PerformLayout();
            this.panelStepItem.ResumeLayout(false);
            this.panelStepItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMovement;
        private System.Windows.Forms.TabPage tbListMovement;
        private System.Windows.Forms.Button btnSaveProgressRoute;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblNbrRowsAgent;
        private System.Windows.Forms.TextBox tbNbrRows;
        private System.Windows.Forms.Label lblNbrRows;
        private System.Windows.Forms.PictureBox picExportExcel;
        private Zuby.ADGV.AdvancedDataGridView dG_MvtAgents;
        private System.Windows.Forms.Button btn_NextAgent;
        private System.Windows.Forms.Button btn_PreviousAgent;
        private System.Windows.Forms.Label lblTiteLstAgent;
        private System.Windows.Forms.TabPage tabMvtDetails;
        private System.Windows.Forms.TextBox lblTypemvt;
        private System.Windows.Forms.Button btnManageMvt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabEditSteps;
        private System.Windows.Forms.TextBox tbAgentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelStepItem;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.TextBox tbSupport;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.Label lvlHeaderWho;
        private System.Windows.Forms.PictureBox picAddStep;
        private System.Windows.Forms.PictureBox picSave;
        private System.Windows.Forms.TextBox tbWhoStep;
        private System.Windows.Forms.ComboBox cbTypeMvt;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Classes.TextBoxExtensions tbActionOPP;
        private System.Windows.Forms.Label lblOPP;
        private Classes.TextBoxExtensions tbTCAction;
        private System.Windows.Forms.Label lblTCAction;
        private Classes.TextBoxExtensions tbLHFutur;
        private System.Windows.Forms.Label lblLHFutur;
        private Classes.TextBoxExtensions tbLHActuel;
        private System.Windows.Forms.Label lblLHActual;
        private System.Windows.Forms.Label lblServiceActual;
        private System.Windows.Forms.ComboBox cbServiceActual;
        private Classes.TextBoxExtensions textBoxAdmin;
        private System.Windows.Forms.Label lblAdminAction;
        private System.Windows.Forms.Label lblServiceFutur;
        private System.Windows.Forms.Label lblDateDemande;
        private System.Windows.Forms.Label lblMvtToBeDone;
        private System.Windows.Forms.ComboBox cbMvtToBeDone;
        private System.Windows.Forms.ComboBox cbServiceFutur;
        private System.Windows.Forms.DateTimePicker datePRequest;
        private System.Windows.Forms.Panel panelStepAgent;
        private System.Windows.Forms.TextBox tbStepAgentRemarks;
        private System.Windows.Forms.TextBox tbStepAgentWho;
        private System.Windows.Forms.PictureBox picSaveStepAgent;
        private System.Windows.Forms.TextBox tbStepAgentAction;
        private System.Windows.Forms.TextBox tbStepAgentSupport;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cbStatut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPercentage;
    }
}
