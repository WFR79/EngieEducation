namespace Module_Gaziview
{
    partial class frm_BDFHistory
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
            this.gb_Filtres = new System.Windows.Forms.GroupBox();
            this.lb_Chain = new System.Windows.Forms.Label();
            this.lb_Unit = new System.Windows.Forms.Label();
            this.btn_View = new System.Windows.Forms.Button();
            this.cb_Chain = new System.Windows.Forms.ComboBox();
            this.cb_Unit = new System.Windows.Forms.ComboBox();
            this.synapseGraphic1 = new SynapseCore.Controls.SynapseGraphic();
            this.gb_Filtres.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Filtres
            // 
            this.gb_Filtres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Filtres.Controls.Add(this.lb_Chain);
            this.gb_Filtres.Controls.Add(this.lb_Unit);
            this.gb_Filtres.Controls.Add(this.btn_View);
            this.gb_Filtres.Controls.Add(this.cb_Chain);
            this.gb_Filtres.Controls.Add(this.cb_Unit);
            this.gb_Filtres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Filtres.Location = new System.Drawing.Point(7, 6);
            this.gb_Filtres.Name = "gb_Filtres";
            this.gb_Filtres.Size = new System.Drawing.Size(739, 63);
            this.gb_Filtres.TabIndex = 0;
            this.gb_Filtres.TabStop = false;
            this.gb_Filtres.Text = "Filtres";
            // 
            // lb_Chain
            // 
            this.lb_Chain.AutoSize = true;
            this.lb_Chain.Location = new System.Drawing.Point(246, 26);
            this.lb_Chain.Name = "lb_Chain";
            this.lb_Chain.Size = new System.Drawing.Size(46, 13);
            this.lb_Chain.TabIndex = 4;
            this.lb_Chain.Text = "Chaine";
            // 
            // lb_Unit
            // 
            this.lb_Unit.AutoSize = true;
            this.lb_Unit.Location = new System.Drawing.Point(15, 26);
            this.lb_Unit.Name = "lb_Unit";
            this.lb_Unit.Size = new System.Drawing.Size(54, 13);
            this.lb_Unit.TabIndex = 3;
            this.lb_Unit.Text = "Tranche";
            // 
            // btn_View
            // 
            this.btn_View.Location = new System.Drawing.Point(501, 21);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(75, 23);
            this.btn_View.TabIndex = 2;
            this.btn_View.Text = "Afficher";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // cb_Chain
            // 
            this.cb_Chain.FormattingEnabled = true;
            this.cb_Chain.Location = new System.Drawing.Point(332, 23);
            this.cb_Chain.Name = "cb_Chain";
            this.cb_Chain.Size = new System.Drawing.Size(121, 21);
            this.cb_Chain.TabIndex = 1;
            // 
            // cb_Unit
            // 
            this.cb_Unit.FormattingEnabled = true;
            this.cb_Unit.Location = new System.Drawing.Point(92, 23);
            this.cb_Unit.Name = "cb_Unit";
            this.cb_Unit.Size = new System.Drawing.Size(121, 21);
            this.cb_Unit.TabIndex = 0;
            this.cb_Unit.SelectedIndexChanged += new System.EventHandler(this.cb_Unit_SelectedIndexChanged);
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
            this.synapseGraphic1.Location = new System.Drawing.Point(7, 75);
            this.synapseGraphic1.Name = "synapseGraphic1";
            this.synapseGraphic1.PageSetupMenu = null;
            this.synapseGraphic1.PrintMenu = null;
            this.synapseGraphic1.SaveAsMenu = null;
            this.synapseGraphic1.SetDefaultScaleMenu = null;
            this.synapseGraphic1.ShowAllCurvesMenu = null;
            this.synapseGraphic1.ShowHideCurveMenu = null;
            this.synapseGraphic1.ShowHideLegendMenu = null;
            this.synapseGraphic1.ShowPointValuesMenu = null;
            this.synapseGraphic1.Size = new System.Drawing.Size(740, 473);
            this.synapseGraphic1.TabIndex = 1;
            this.synapseGraphic1.UndoAllZoomMenu = null;
            this.synapseGraphic1.UnZoomMenu = null;
            // 
            // frm_BDFHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 553);
            this.Controls.Add(this.synapseGraphic1);
            this.Controls.Add(this.gb_Filtres);
            this.Debug = true;
            this.ModuleID = 28;
            this.Name = "frm_BDFHistory";
            this.Text = "Historique bruit de fond";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_BDFHistory_Load);
            this.gb_Filtres.ResumeLayout(false);
            this.gb_Filtres.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Filtres;
        private SynapseCore.Controls.SynapseGraphic synapseGraphic1;
        private System.Windows.Forms.Label lb_Chain;
        private System.Windows.Forms.Label lb_Unit;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.ComboBox cb_Chain;
        private System.Windows.Forms.ComboBox cb_Unit;
    }
}