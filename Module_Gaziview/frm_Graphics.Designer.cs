namespace Module_Gaziview
{
    partial class frm_Graphics
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
            this.synapseGraphic1 = new SynapseCore.Controls.SynapseGraphic();
            this.gb_Filters = new System.Windows.Forms.GroupBox();
            this.dtp_SelectedDate = new System.Windows.Forms.DateTimePicker();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.cb_Unit = new System.Windows.Forms.ComboBox();
            this.lb_Unit = new System.Windows.Forms.Label();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.lb_Type = new System.Windows.Forms.Label();
            this.chk_Values = new System.Windows.Forms.CheckBox();
            this.gb_Filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // synapseGraphic1
            // 
            this.synapseGraphic1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.synapseGraphic1.CopyMenu = null;
            this.synapseGraphic1.CurveOnlyMenu = null;
            this.synapseGraphic1.CurvesMenu = null;
            this.synapseGraphic1.FontSize = 8.25F;
            this.synapseGraphic1.HideCurvesMenu = false;
            this.synapseGraphic1.HideShowAllCurvesMenu = false;
            this.synapseGraphic1.Location = new System.Drawing.Point(12, 72);
            this.synapseGraphic1.Name = "synapseGraphic1";
            this.synapseGraphic1.PageSetupMenu = null;
            this.synapseGraphic1.PrintMenu = null;
            this.synapseGraphic1.SaveAsMenu = null;
            this.synapseGraphic1.SetDefaultScaleMenu = null;
            this.synapseGraphic1.ShowAllCurvesMenu = null;
            this.synapseGraphic1.ShowHideCurveMenu = null;
            this.synapseGraphic1.ShowHideLegendMenu = null;
            this.synapseGraphic1.ShowPointValuesMenu = null;
            this.synapseGraphic1.Size = new System.Drawing.Size(907, 339);
            this.synapseGraphic1.TabIndex = 0;
            this.synapseGraphic1.UndoAllZoomMenu = null;
            this.synapseGraphic1.UnZoomMenu = null;
            // 
            // gb_Filters
            // 
            this.gb_Filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Filters.Controls.Add(this.chk_Values);
            this.gb_Filters.Controls.Add(this.dtp_SelectedDate);
            this.gb_Filters.Controls.Add(this.btn_Draw);
            this.gb_Filters.Controls.Add(this.cb_Unit);
            this.gb_Filters.Controls.Add(this.lb_Unit);
            this.gb_Filters.Controls.Add(this.cb_Type);
            this.gb_Filters.Controls.Add(this.lb_Type);
            this.gb_Filters.Location = new System.Drawing.Point(13, 13);
            this.gb_Filters.Name = "gb_Filters";
            this.gb_Filters.Size = new System.Drawing.Size(906, 53);
            this.gb_Filters.TabIndex = 1;
            this.gb_Filters.TabStop = false;
            this.gb_Filters.Text = "Filtres";
            // 
            // dtp_SelectedDate
            // 
            this.dtp_SelectedDate.Location = new System.Drawing.Point(13, 20);
            this.dtp_SelectedDate.Name = "dtp_SelectedDate";
            this.dtp_SelectedDate.Size = new System.Drawing.Size(200, 20);
            this.dtp_SelectedDate.TabIndex = 5;
            // 
            // btn_Draw
            // 
            this.btn_Draw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Draw.Location = new System.Drawing.Point(818, 18);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(75, 23);
            this.btn_Draw.TabIndex = 4;
            this.btn_Draw.Text = "Afficher";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // cb_Unit
            // 
            this.cb_Unit.FormattingEnabled = true;
            this.cb_Unit.Location = new System.Drawing.Point(513, 20);
            this.cb_Unit.Name = "cb_Unit";
            this.cb_Unit.Size = new System.Drawing.Size(121, 21);
            this.cb_Unit.TabIndex = 3;
            // 
            // lb_Unit
            // 
            this.lb_Unit.AutoSize = true;
            this.lb_Unit.Location = new System.Drawing.Point(439, 24);
            this.lb_Unit.Name = "lb_Unit";
            this.lb_Unit.Size = new System.Drawing.Size(47, 13);
            this.lb_Unit.TabIndex = 2;
            this.lb_Unit.Text = "Tranche";
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "14 Jours",
            "1 An"});
            this.cb_Type.Location = new System.Drawing.Point(291, 20);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(121, 21);
            this.cb_Type.TabIndex = 1;
            this.cb_Type.Text = "14 Jours";
            // 
            // lb_Type
            // 
            this.lb_Type.AutoSize = true;
            this.lb_Type.Location = new System.Drawing.Point(235, 24);
            this.lb_Type.Name = "lb_Type";
            this.lb_Type.Size = new System.Drawing.Size(31, 13);
            this.lb_Type.TabIndex = 0;
            this.lb_Type.Text = "Type";
            // 
            // chk_Values
            // 
            this.chk_Values.AutoSize = true;
            this.chk_Values.Location = new System.Drawing.Point(656, 25);
            this.chk_Values.Name = "chk_Values";
            this.chk_Values.Size = new System.Drawing.Size(115, 17);
            this.chk_Values.TabIndex = 6;
            this.chk_Values.Text = "Afficher les valeurs";
            this.chk_Values.UseVisualStyleBackColor = true;
            // 
            // frm_Graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 423);
            this.Controls.Add(this.gb_Filters);
            this.Controls.Add(this.synapseGraphic1);
            this.Debug = true;
            this.ModuleID = 28;
            this.Name = "frm_Graphics";
            this.Text = "frm_Graphics";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_Graphics_Load);
            this.gb_Filters.ResumeLayout(false);
            this.gb_Filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseCore.Controls.SynapseGraphic synapseGraphic1;
        private System.Windows.Forms.GroupBox gb_Filters;
        private System.Windows.Forms.ComboBox cb_Unit;
        private System.Windows.Forms.Label lb_Unit;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.Label lb_Type;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.DateTimePicker dtp_SelectedDate;
        private System.Windows.Forms.CheckBox chk_Values;
    }
}