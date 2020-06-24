using Module_Education.Classes;
using Module_Education.Forms.UserControls;
using Module_Education.Models;
using Module_Education.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Forms
{
    public partial class FrmFormation : Form
    {
        public FormationRepository dbFormation = new FormationRepository();
        public FrmFormation()
        {
            InitializeComponent();
            LoadFormation();
        }

        private void LoadFormation()
        {
            IPagedList <Education_Formation> listFormations = dbFormation.LoadAllEducation_FormationsInFrame(UC_MatriceFormations.listMatriceFormationSelected).ToPagedList(1,100);
            //foreach(var item in listFormations)

            l_PopUp.DataSource = GetDataSource(listFormations);
        }
        private object GetDataSource(IPagedList<Education_Formation> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionFrmFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_SAP = o.Formation_SAP,

            }).ToList();

            return dataSource;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddFormations_Click(object sender, EventArgs e)
        {
            if (l_PopUp.SelectedRows.Count > 0)
            {
                var selectedRows = l_PopUp.SelectedRows
                                   .OfType<DataGridViewRow>()
                                   .Where(row => !row.IsNewRow)
                                   .ToArray();
                FormationRepository db = new FormationRepository();
                UC_MatriceFormations.Instance.lFormationToAddToMatrice = new List<Education_Formation>();

                foreach (DataGridViewRow row in selectedRows)
                {
                    var item = db.LoadSingleEducation_Formation(row.Cells[1].Value.ToString());
                    UC_MatriceFormations.Instance.lFormationToAddToMatrice.Add(item);
                }
            }
            this.Close();
        }

        private void l_PopUp_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {

        }
    }
}
