using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Repositories;
using Module_Education.Models;
using Module_Education.Classes.Extensions;
using Module_Education.Helper;

namespace Module_Education.Forms.UserControls
{
    public partial class UC_MovementAgent : UserControl
    {
        private static UC_MovementAgent _instance;
        private MovementTypeRepository movementTypeRepository = new MovementTypeRepository();
        private MovementStepRepository movementStepRepository = new MovementStepRepository();
        private MovementAgentRepository MovementAgentRepository = new MovementAgentRepository();
        private MovementAgentStepRepository MovementAgentStepRepository = new MovementAgentStepRepository();
        private ServiceRepository serviceRepository = new ServiceRepository();

        private List<Panel> listPanelSteps = new List<Panel>();
        PictureBox picAddType = new PictureBox();
        private long mvttypeId;
        private List<Panel> listPanelAgentSteps = new List<Panel>();

        public long AgentId { get; private set; }
        public Education_MovementType CurrentMovement { get; private set; }
        public Education_MovementAgent CurrentMovementAgent { get; private set; }
        public List<Education_MovementStepAgent> CurrentMovementAgentSteps { get; private set; }


        public UC_MovementAgent()
        {
            InitializeComponent();
            LoadDataGridMovements();
            LoadComboTypesCheckLists();
        }

        public static UC_MovementAgent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_MovementAgent();
                return _instance;
            }
        }


        #region Liste

        public void LoadDataGridMovements()
        {
            dG_MvtAgents.DataSource = GetDataSource(MovementAgentRepository.LoadAllMovements());
            dG_MvtAgents.Columns[0].Visible = false;
            dG_MvtAgents.Columns[1].Visible = false;

            lblNbrRowsAgent.Text = "Nombre total d'Agents : " + dG_MvtAgents.RowCount.ToString();

        }

        private object GetDataSource(List<Education_MovementAgent> list)
        {

            object dataSource = list.Select(o => new MyColumnCollectionDGMvtAgent(o)
            {
                mvttypeId = o.MovementAgent_Type,
                mvt_AgentId = o.Education_Agent.Agent_Id,
                mvt_Admin = o.MovementAgent_Admin,
                mvt_agent = o.Education_Agent.Agent_FullName,
                mvt_Date = o.MovementAgent_Date,
                mvt_TypeName = o.Education_MovementType.MovementType_Name,
                mvt_ServiceActual = o.Education_Service?.Service_Name,
                mvt_LHActual = o.MovementAgent_LHActual,
                mvt_ServiceFutur = o.Education_Service1?.Service_Name,
                mvt_LHFutur = o.MovementAgent_LHFutur,
                mvt_TC = o.MovementAgent_TCAction,
                mvt_OPP = o.MovementAgent_AdminOPP,
                mvt_statut = o.MovementAgent_Statut + " %"


            }).ToList();

            return dataSource;
        }

        private void cbDone_CheckedChanged(object sender, EventArgs e)
        {
            //if (tabMvtDetails.Checked)
            //    tabMvtDetails.BackColor = Color.Green;
            //else
            //    tabMvtDetails.BackColor = Color.Red;
        }

        private void dG_MvtAgents_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    //DataGridView dgPassportElecFunc = this.Controls.Find("dgPassportElecFunc", true).FirstOrDefault() as DataGridView;

                    ContextMenu m = new ContextMenu();

                    int currentMouseOverRow = dG_MvtAgents.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        dG_MvtAgents.Rows[dG_MvtAgents.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        m.MenuItems.Add(new MenuItem(string.Format("Afficher les détails", currentMouseOverRow.ToString()),
                           ShowDetailsMovement));
                        //m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification safety", currentMouseOverRow.ToString()),
                        //    ShowNewCertificationForm));

                    }

                    m.Show(dG_MvtAgents, new Point(e.X, e.Y));
                    AgentId = Convert.ToInt64(dG_MvtAgents.SelectedCells[0].Value.ToString());
                    mvttypeId = Convert.ToInt64(dG_MvtAgents.SelectedCells[1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowDetailsMovement(object sender, EventArgs e)
        {
            LoadDetailsMvtAgent();
        }

        private void LoadDetailsMvtAgent()
        {

            this.tabControlMovement.SelectedIndex = 1;
            LoadComboServices();

            List<Education_MovementStepAgent> listMovementStepAgents = new List<Education_MovementStepAgent>();
            Education_MovementAgent mvtAgentSelected = MovementAgentRepository.LoadSingleMvtAgent(AgentId, mvttypeId);
            CurrentMovementAgent = mvtAgentSelected;
            lblTypemvt.Text = mvtAgentSelected.Education_MovementType.MovementType_Name;
            tbAgentName.Text = mvtAgentSelected.Education_Agent.Agent_FullName;
            tbPercentage.Text = mvtAgentSelected.MovementAgent_Statut + "%";

            cbMvtToBeDone.SelectedIndex = cbMvtToBeDone.FindStringExact(mvtAgentSelected.Education_MovementType.MovementType_Name);
            cbServiceActual.SelectedIndex = cbServiceActual.FindStringExact(mvtAgentSelected.Education_Service?.Service_Name);
            cbServiceFutur.SelectedIndex = cbServiceFutur.FindStringExact(mvtAgentSelected.Education_Service1?.Service_Name);
            datePRequest.Value = (DateTime)mvtAgentSelected.MovementAgent_Date;
            tbTCAction.Text = mvtAgentSelected.MovementAgent_TCAction;
            tbActionOPP.Text = mvtAgentSelected.MovementAgent_AdminOPP;
            tbLHActuel.Text = mvtAgentSelected.MovementAgent_LHActual;
            textBoxAdmin.Text = mvtAgentSelected.MovementAgent_Admin;
            tbLHFutur.Text = mvtAgentSelected.MovementAgent_LHFutur;
            LoadAllStepsOfAgent();


        }

        private void LoadComboServices()
        {

            cbMvtToBeDone.DataSource = movementTypeRepository.LoadAllTypes();
            cbMvtToBeDone.DisplayMember = "MovementType_Name";

            cbServiceFutur.DataSource = serviceRepository.LoadAllService();
            cbServiceFutur.DisplayMember = "Service_Name";

            cbServiceActual.DataSource = serviceRepository.LoadAllService();
            cbServiceActual.DisplayMember = "Service_Name";


        }
        #endregion

        #region Editing CheckList

        private void LoadComboTypesCheckLists()
        {
            cbTypeMvt.DataSource = movementTypeRepository.LoadAllTypes();
            cbTypeMvt.DisplayMember = "MovementType_Name";

            GeneratePicAddType();

        }

        private void GeneratePicAddType()
        {
            picAddType.Paint += new PaintEventHandler(this.PaintAddLine);
            picAddType.Click += new EventHandler(this.ClickAddType);
            picAddType.Name = "picAddType";
            ToolTip ttAddPicType = new ToolTip();
            ttAddPicType.SetToolTip(picAddType, "Ajouter un type de checklist");
            picAddType.Visible = true;
            picAddType.Enabled = false;
            picAddType.Image = Module_Education.Properties.Resources.add_512;
            picAddType.SizeMode = PictureBoxSizeMode.Zoom;
            picAddType.Size = picAddStep.Size;
            int xCalculatedPicAdd = cbTypeMvt.Location.X + (cbTypeMvt.Width + 10);
            picAddType.Location = new Point(xCalculatedPicAdd, cbTypeMvt.Location.Y);
            tabEditSteps.Controls.Add(picAddType);
        }

        private void ClickAddType(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Etes-vous sur de vouloir ajouter cette liste?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var record = movementTypeRepository.AddType(cbTypeMvt.Text);
                if (record == null)
                    AutoClosingMessageBox.Show("le type n'a pas été ajouté", "Error", 1000, MessageBoxIcon.Error);
                else
                    LoadComboTypesCheckLists();
            }

        }

        private void cbTypeMvt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentMovement != (Education_MovementType)cbTypeMvt.SelectedItem)
            {
                //LoadComboTypesCheckLists();

                CurrentMovement = (Education_MovementType)cbTypeMvt.SelectedItem;
                LoadAllSteps(CurrentMovement);

            }

        }

        private void cbTypeMvt_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentMovement != (Education_MovementType)cbTypeMvt.SelectedItem)
            {
                CurrentMovement = (Education_MovementType)cbTypeMvt.SelectedItem;
                LoadAllSteps(CurrentMovement);

            }
        }

        private void LoadAllSteps(Education_MovementType currentMovement)
        {
            if (currentMovement.Education_MovementStep.Count > 0)
            {
                RemoveAllDynamicPanels();

                for (int i = 1; i < currentMovement.Education_MovementStep.Count + 1; i++)
                {
                    GeneratePanelStep(currentMovement.Education_MovementStep.ElementAt(i - 1), i);

                }
                panelStepItem.Visible = false;
            }
            else
            {
                RemoveAllDynamicPanels();
                panelStepItem.Visible = true;

            }
        }

        private void LoadAllStepsOfAgent()
        {
            CurrentMovementAgentSteps = MovementAgentStepRepository.LoadAllStepsOfAgent(AgentId, mvttypeId);
            if (CurrentMovementAgentSteps.Count > 0)
            {
                RemoveAllDynamicStepPanels();

                for (int i = 1; i < CurrentMovementAgentSteps.Count + 1; i++)
                {
                    GeneratePanelStepAgent(CurrentMovementAgentSteps[i - 1], i);

                }
                panelStepAgent.Visible = false;
            }
            else
            {
                RemoveAllDynamicStepPanels();
                panelStepAgent.Visible = true;

            }
        }

        private void GeneratePanelStepAgent(Education_MovementStepAgent education_MovementStepAgent, int index)
        {


            TextBox newTbWho = new TextBox();
            newTbWho.Paint += new PaintEventHandler(this.tbWhoPaint);
            newTbWho.Name = "tbWhoStepAgentWho_" + index;
            newTbWho.Text = education_MovementStepAgent.Education_MovementStep.MovementStep_Who;
            newTbWho.Size = tbStepAgentWho.Size;
            int ynewTbWhoAxisCalculated = (this.tbStepAgentWho.Location.Y - 10) + (this.tbStepAgentWho.Size.Height - 5);
            newTbWho.Location = new Point(this.tbStepAgentWho.Location.X, ynewTbWhoAxisCalculated);
            newTbWho.BackColor = Color.White;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newTbWho.Font = tbStepAgentWho.Font;

            TextBox newtbSupport = new TextBox();
            newtbSupport.Paint += new PaintEventHandler(this.newtbSupportPaint);
            newtbSupport.Name = "tbStepAgentSupport_" + index;
            newtbSupport.Text = education_MovementStepAgent.Education_MovementStep.MovementStep_Support;
            newtbSupport.Size = tbStepAgentSupport.Size;
            int yLAbelAxisCalculated = (this.tbStepAgentSupport.Location.Y - 10) + (this.tbStepAgentSupport.Size.Height - 15);
            newtbSupport.Location = new Point(this.tbStepAgentSupport.Location.X, yLAbelAxisCalculated);
            newtbSupport.BackColor = Color.White;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newtbSupport.Multiline = true;
            newtbSupport.ScrollBars = ScrollBars.Both;
            newtbSupport.Font = tbStepAgentSupport.Font;

            ComboBox newCbStatut = new ComboBox();
            newCbStatut.Paint += new PaintEventHandler(this.newtbSupportPaint);
            newCbStatut.SelectedIndexChanged += new EventHandler(this.SelectedIndexChanged);
            newCbStatut.Name = "cbStatut_" + index;
            foreach (var item in cbStatut.Items)
                newCbStatut.Items.Add(item);
            newCbStatut.Size = cbStatut.Size;
            int ynewCbStatutlAxisCalculated = (this.cbStatut.Location.Y) + (this.cbStatut.Size.Height - 15);
            newCbStatut.Location = new Point(this.cbStatut.Location.X, ynewCbStatutlAxisCalculated);
            newCbStatut.BackColor = Color.White;
            newCbStatut.Font = tbStepAgentSupport.Font;

            string status;
            switch (education_MovementStepAgent.MovementStepAgent_Status)
            {
                case true:
                    status = "Fait";
                    break;

                case false:
                    status = "Pas Fait";
                    break;

                default:
                    status = "NA";
                    break;
            }
            newCbStatut.SelectedIndex = newCbStatut.FindStringExact(status);


            TextBox newtbAction = new TextBox();
            newtbAction.Paint += new PaintEventHandler(this.tbActionPaint);
            //newtbAction.TextChanged += new EventHandler(this.TextChanged);
            newtbAction.Name = "tbStepAgentAction_" + index;
            newtbAction.Text = education_MovementStepAgent.Education_MovementStep.MovementStep_IntituleAction;
            newtbAction.Size = tbStepAgentAction.Size;
            int ynewtbActionAxisCalculated = (this.tbStepAgentAction.Location.Y - 10) + (this.tbStepAgentAction.Size.Height - 15);
            newtbAction.Location = new Point(this.tbStepAgentAction.Location.X, ynewtbActionAxisCalculated);
            newtbAction.BackColor = Color.White;
            newtbAction.Multiline = true;
            newtbAction.ScrollBars = ScrollBars.Both;
            newtbAction.Font = tbStepAgentAction.Font;

            TextBox newtbStepAgentRemarks = new TextBox();
            newtbStepAgentRemarks.Paint += new PaintEventHandler(this.newtbSupportPaint);
            newtbStepAgentRemarks.TextChanged += new EventHandler(this.TextRemarksChanged);
            newtbStepAgentRemarks.Name = "tbStepAgentRemarks_" + index;
            newtbStepAgentRemarks.Text = education_MovementStepAgent.MovementStepAgent_Remarks;
            newtbStepAgentRemarks.Size = tbStepAgentRemarks.Size;
            int ytbStepAgentRemarksAxisCalculated = (this.tbStepAgentRemarks.Location.Y - 10) + (this.tbStepAgentRemarks.Size.Height - 15);
            newtbStepAgentRemarks.Location = new Point(this.tbStepAgentRemarks.Location.X, ytbStepAgentRemarksAxisCalculated);
            newtbStepAgentRemarks.BackColor = Color.White;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newtbStepAgentRemarks.Multiline = true;
            newtbStepAgentRemarks.ScrollBars = ScrollBars.Both;
            newtbStepAgentRemarks.Font = tbStepAgentSupport.Font;

            // Pic Save line

            PictureBox newPicSaveAgent = new PictureBox();
            newPicSaveAgent.Paint += new PaintEventHandler(this.PaintSave);
            newPicSaveAgent.Click += new EventHandler(this.SaveStepAgent);
            newPicSaveAgent.Name = "newPicSave_" + index;

            newPicSaveAgent.Tag = education_MovementStepAgent.MovementStepAgent_Id;
            newPicSaveAgent.Enabled = true;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(newPicSaveAgent, "Afficher les informations d'équivalence");
            newPicSaveAgent.Visible = true;
            newPicSaveAgent.Image = Module_Education.Properties.Resources.outline_save_black_24dp1;
            newPicSaveAgent.SizeMode = PictureBoxSizeMode.Zoom;
            newPicSaveAgent.Size = picSaveStepAgent.Size;
            int yTbAxisCalculated = (this.picSaveStepAgent.Location.Y - 20) + this.picSaveStepAgent.Size.Height;
            newPicSaveAgent.Location = new Point(this.picSaveStepAgent.Location.X, yTbAxisCalculated);




            Panel newPanel = new Panel();
            newPanel.Paint += new PaintEventHandler(this.panel_Paint);
            if (index % 2 == 0)
                newPanel.BackColor = Color.LightSkyBlue;
            else
                newPanel.BackColor = Color.LightSkyBlue;

            newPanel.Size = this.panelStepAgent.Size;
            newPanel.Name = "panelStepItem_" + index;
            int yAxisCalculated = (this.panelStepAgent.Location.Y - 50) + (this.panelStepAgent.Size.Height * index);
            newPanel.Location = new Point(this.panelStepAgent.Location.X, yAxisCalculated);

            //newPanel.Controls.Add(newLabelNum);
            newPanel.Controls.Add(newTbWho);
            newPanel.Controls.Add(newtbSupport);
            newPanel.Controls.Add(newtbAction);
            newPanel.Controls.Add(newPicSaveAgent);
            newPanel.Controls.Add(newCbStatut);

            newPanel.Controls.Add(newtbStepAgentRemarks);

            listPanelAgentSteps.Add(newPanel);
            this.tabMvtDetails.Controls.Add(newPanel);
        }

        private void TextRemarksChanged(object sender, EventArgs e)
        {
            TextBox tbremark = (TextBox)sender;
            string[] tbremarkArray = tbremark.Name.Split('_').ToArray();
            CurrentMovementAgentSteps[Convert.ToInt32(tbremarkArray[1]) - 1].MovementStepAgent_Remarks = tbremark.Text;

        }

        private void SaveStepAgent(object sender, EventArgs e)
        {
            PictureBox savePic = (PictureBox)sender;
            string[] savePicSplit = savePic.Name.Split('_').ToArray();


            SaveMovementStepAgent(CurrentMovementAgentSteps, savePicSplit.Length > 1 ? Convert.ToInt32(savePicSplit[1]) : 1
                , savePic.Tag == null ? 0 : Convert.ToInt32(savePic.Tag));

            LoadDetailsMvtAgent();
        }

        private void SaveMovementStepAgent(List<Education_MovementStepAgent> currentMovementAgentSteps, int v1, int v2)
        {
            MovementAgentStepRepository.SaveStepAgent(currentMovementAgentSteps);
            LoadDataGridMovements();
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbStatutDyn = (ComboBox)sender;
            bool? status;
            string[] cbStatutDynArray = cbStatutDyn.Name.Split('_').ToArray();
            switch (cbStatutDyn.Text)
            {
                case "Fait":
                    status = true;
                    break;

                case "Pas Fait":
                    status = false;
                    break;

                default:
                    status = null;
                    break;
            }
            CurrentMovementAgentSteps[Convert.ToInt32(cbStatutDynArray[1]) - 1].MovementStepAgent_Status = status;
        }

        private void RemoveAllDynamicPanels()
        {
            foreach (Panel panelItem in listPanelSteps)
            {
                tabEditSteps.Controls.Remove(panelItem);
                panelItem.Dispose();
            }
        }

        private void RemoveAllDynamicStepPanels()
        {
            if (listPanelAgentSteps != null)
            {
                foreach (Panel panelItem in listPanelAgentSteps)
                {
                    tabMvtDetails.Controls.Remove(panelItem);
                    panelItem.Dispose();
                }
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            TextBox tbWhoDyn = new TextBox();
            TextBox tbActionDyn = new TextBox();
            TextBox tbSupportDyn = new TextBox();
            PictureBox picSave = new PictureBox(); ;
            string[] tbsplit = tb?.Name.Split('_').ToArray();

            if (tb.Parent != null)
            {
                foreach (Control ctrlInPanel in tb.Parent.Controls)
                {
                    if (ctrlInPanel is PictureBox && ctrlInPanel.Name.Contains("newPicSave_"))
                    {
                        picSave = ctrlInPanel as PictureBox;
                    }

                    if (ctrlInPanel is TextBox)
                    {
                        if (ctrlInPanel.Name.Contains(tbWhoStep.Name + "_"))
                            tbWhoDyn = ctrlInPanel as TextBox;

                        if (ctrlInPanel.Name.Contains(tbAction.Name + "_"))
                            tbActionDyn = ctrlInPanel as TextBox;

                        if (ctrlInPanel.Name.Contains(tbSupport.Name + "_"))
                            tbSupportDyn = ctrlInPanel as TextBox;


                    }
                }
                if (tbWhoDyn.Text == "" || tbActionDyn.Text == "" /*| tbSupportDyn.Text == ""*/)
                {
                    errorProvider1.SetError(picSave, "Champs vide");
                    picSave.Enabled = false;
                }
                else
                {
                    errorProvider1.SetError(picSave, "");

                    picSave.Enabled = true;

                }
            }
            //btnSaveCertificate.Enabled = true;
        }

        private void GeneratePanelStep(Education_MovementStep movementStep, int index)
        {

            Label newLabelNum = new Label();
            newLabelNum.Paint += new PaintEventHandler(this.newLabelNumPaint);
            newLabelNum.Name = "newLabelNum_" + index;
            newLabelNum.Text = index.ToString();
            newLabelNum.Size = lblNum.Size;
            int yLAbelNumAxisCalculated = this.lblNum.Location.Y + (this.lblNum.Size.Height - 5);
            int yCalculatedLAbel = this.lblNum.Location.Y + (this.lblNum.Size.Height);
            newLabelNum.Location = new Point(this.lblNum.Location.X, yLAbelNumAxisCalculated);
            newLabelNum.BackColor = Color.LightSkyBlue;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newLabelNum.Font = lblNum.Font;


            TextBox newTbWho = new TextBox();
            newTbWho.Paint += new PaintEventHandler(this.tbWhoPaint);
            newTbWho.TextChanged += new EventHandler(this.TextChanged);
            newTbWho.Name = "tbWhoStep_" + index;
            newTbWho.Text = movementStep.MovementStep_Who;
            newTbWho.Size = tbWhoStep.Size;
            int ynewTbWhoAxisCalculated = this.tbWhoStep.Location.Y + (this.tbWhoStep.Size.Height - 5);
            newTbWho.Location = new Point(this.tbWhoStep.Location.X, ynewTbWhoAxisCalculated);
            newTbWho.BackColor = Color.White;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newTbWho.Font = tbWhoStep.Font;

            TextBox newtbSupport = new TextBox();
            newtbSupport.Paint += new PaintEventHandler(this.newtbSupportPaint);
            newtbSupport.TextChanged += new EventHandler(this.TextChanged);
            newtbSupport.Name = "tbSupport_" + index;
            newtbSupport.Text = movementStep.MovementStep_Support;
            newtbSupport.Size = tbSupport.Size;
            int yLAbelAxisCalculated = (this.tbSupport.Location.Y - 30) + (this.tbSupport.Size.Height - 15);
            newtbSupport.Location = new Point(this.tbSupport.Location.X, yLAbelAxisCalculated);
            newtbSupport.BackColor = Color.White;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newtbSupport.Multiline = true;
            newtbSupport.ScrollBars = ScrollBars.Both;
            newtbSupport.Font = tbSupport.Font;

            TextBox newtbAction = new TextBox();
            newtbAction.Paint += new PaintEventHandler(this.tbActionPaint);
            newtbAction.TextChanged += new EventHandler(this.TextChanged);

            newtbAction.Name = "tbAction_" + index;
            newtbAction.Text = movementStep.MovementStep_IntituleAction;
            newtbAction.Size = tbSupport.Size;
            int ynewtbActionAxisCalculated = (this.tbAction.Location.Y - 30) + (this.tbAction.Size.Height - 15);
            newtbAction.Location = new Point(this.tbAction.Location.X, ynewtbActionAxisCalculated);
            newtbAction.BackColor = Color.White;
            newtbAction.Multiline = true;
            newtbAction.ScrollBars = ScrollBars.Both;

            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newtbAction.Font = tbSupport.Font;

            // Pic Save line

            PictureBox newPicSave = new PictureBox();
            newPicSave.Paint += new PaintEventHandler(this.PaintSave);
            newPicSave.Click += new EventHandler(this.pictureBox1_Click);
            newPicSave.Name = "newPicSave_" + index;

            newPicSave.Tag = movementStep.MovementStep_Id;
            newPicSave.Enabled = false;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(newPicSave, "Afficher les informations d'équivalence");
            newPicSave.Visible = true;
            newPicSave.Image = Module_Education.Properties.Resources.outline_save_black_24dp1;
            newPicSave.SizeMode = PictureBoxSizeMode.Zoom;
            newPicSave.Size = picSave.Size;
            int yTbAxisCalculated = (this.picSave.Location.Y - 15) + this.picSave.Size.Height;
            newPicSave.Location = new Point(this.picSave.Location.X, yTbAxisCalculated);

            // Pic AddLine

            PictureBox newPicAddLine = new PictureBox();
            newPicAddLine.Paint += new PaintEventHandler(this.PaintAddLine);
            newPicAddLine.Click += new EventHandler(this.ClickAddLine);
            newPicAddLine.Name = "newPicAddLine_" + index;
            ToolTip ttAddLine = new ToolTip();
            tt.SetToolTip(newPicAddLine, "Ajouter une étape de la check-list");
            newPicAddLine.Visible = true;
            newPicAddLine.Image = Module_Education.Properties.Resources.add_512;
            newPicAddLine.SizeMode = PictureBoxSizeMode.Zoom;
            newPicAddLine.Size = picAddStep.Size;
            int picAddStepAxisCalculated = (this.picAddStep.Location.Y - 15) + this.picAddStep.Size.Height;
            newPicAddLine.Location = new Point(this.picAddStep.Location.X, yTbAxisCalculated);


            Panel newPanel = new Panel();
            newPanel.Paint += new PaintEventHandler(this.panel_Paint);
            if (index % 2 == 0)
                newPanel.BackColor = Color.LightSkyBlue;
            else
                newPanel.BackColor = Color.LightSkyBlue;

            newPanel.Size = this.panelStepItem.Size;
            newPanel.Name = "panelStepItem_" + index;
            int yAxisCalculated = (this.panelStepItem.Location.Y - 45) + (this.panelStepItem.Size.Height * index);
            newPanel.Location = new Point(this.panelStepItem.Location.X, yAxisCalculated);

            newPanel.Controls.Add(newLabelNum);
            newPanel.Controls.Add(newTbWho);
            newPanel.Controls.Add(newtbSupport);
            newPanel.Controls.Add(newtbAction);
            newPanel.Controls.Add(newPicSave);
            newPanel.Controls.Add(newPicAddLine);

            listPanelSteps.Add(newPanel);
            this.tabEditSteps.Controls.Add(newPanel);

        }

        private void ClickAddLine(object sender, EventArgs e)
        {
            Education_MovementStep newLine = new Education_MovementStep();
            //CurrentMovement.Education_MovementStep.Add(newLine);
            GeneratePanelStep(newLine, CurrentMovement.Education_MovementStep.Count + 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox savePic = (PictureBox)sender;
            string[] savePicSplit = savePic.Name.Split('_').ToArray();

            SaveMovementStep(CurrentMovement, savePicSplit.Length > 1 ? Convert.ToInt32(savePicSplit[1]) : 1
                , savePic.Tag == null ? 0 : Convert.ToInt32(savePic.Tag));
        }

        private void SaveMovementStep(Education_MovementType currentMovement, int index, int idTag)
        {

            Education_MovementStep education_MovementStep;
            TextBox tbWhoDyn = new TextBox();
            TextBox tbActionDyn = new TextBox();
            TextBox tbSupportDyn = new TextBox();
            bool isNewRecord = true;

            if (idTag > 0)
                isNewRecord = false;
            if (index > 1)
            {
                foreach (Control ctrl in this.tabEditSteps.Controls)
                {
                    if (ctrl is Panel)
                    {
                        foreach (Control ctrlOfPanel in ctrl.Controls)
                        {
                            if (ctrlOfPanel is TextBox)
                            {
                                if (ctrlOfPanel.Name == tbWhoStep.Name + "_" + index.ToString())
                                    tbWhoDyn = ctrlOfPanel as TextBox;

                                if (ctrlOfPanel.Name == tbAction.Name + "_" + index.ToString())
                                    tbActionDyn = ctrlOfPanel as TextBox;

                                if (ctrlOfPanel.Name == tbSupport.Name + "_" + index.ToString())
                                    tbSupportDyn = ctrlOfPanel as TextBox;


                            }

                        }
                    }

                }
                education_MovementStep = movementStepRepository
                  .SaveMovementStep(CurrentMovement, idTag, tbWhoDyn.Text, tbActionDyn.Text, tbSupportDyn.Text, isNewRecord);
                if (education_MovementStep != null)
                    currentMovement.Education_MovementStep.Add(education_MovementStep);
            }
            else
            {
                education_MovementStep = movementStepRepository
                     .SaveMovementStep(CurrentMovement, idTag, tbWhoStep.Text, tbAction.Text, tbSupport.Text, isNewRecord);
                if (education_MovementStep != null)
                    currentMovement.Education_MovementStep.Add(education_MovementStep);
            }

        }

        private void newLabelNumPaint(object sender, PaintEventArgs e)
        {
        }

        private void PaintAddLine(object sender, PaintEventArgs e)
        {
        }

        private void ClickSaveStep(object sender, EventArgs e)
        {
        }

        private void PaintSave(object sender, PaintEventArgs e)
        {
        }

        private void newtbSupportPaint(object sender, PaintEventArgs e)
        {
        }

        private void tbWhoPaint(object sender, PaintEventArgs e)
        {
        }

        private void tbActionPaint(object sender, PaintEventArgs e)
        {
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cbTypeMvt_TextChanged(object sender, EventArgs e)
        {
            if (cbTypeMvt.SelectedItem == null)
            {
                picAddType.Enabled = true;

            }
            else
            {
                picAddType.Enabled = false;

            }
        }




        #endregion

        #region Details

        private void textBoxAdmin_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            CurrentMovementAgent.MovementAgent_Admin = tb.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void tbActionOPP_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            CurrentMovementAgent.MovementAgent_AdminOPP = tb.Text;
        }

        private void tbLHActuel_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            CurrentMovementAgent.MovementAgent_LHActual = tb.Text;
        }

        private void tbLHFutur_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            CurrentMovementAgent.MovementAgent_LHFutur = tb.Text;
        }

        private void tbTCAction_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            CurrentMovementAgent.MovementAgent_TCAction = tb.Text;
        }

        private void datePRequest_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtPick = (DateTimePicker)sender;
            CurrentMovementAgent.MovementAgent_Date = dtPick.Value;
        }

        private void cbServiceFutur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMovementAgent.MovementAgent_ServiceFutur != ((Education_Service)cbServiceFutur.SelectedItem).Service_Id)
                {
                    CurrentMovementAgent.MovementAgent_ServiceFutur = ((Education_Service)cbServiceFutur.SelectedItem).Service_Id;
                    //ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void cbServiceActual_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMovementAgent.MovementAgent_ServiceActual != ((Education_Service)cbServiceActual.SelectedItem).Service_Id)
                {
                    CurrentMovementAgent.MovementAgent_ServiceActual = ((Education_Service)cbServiceActual.SelectedItem).Service_Id;
                    //ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }
    }
}
