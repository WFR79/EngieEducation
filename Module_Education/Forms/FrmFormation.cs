using Module_Education.Classes;
using Module_Education.Models;
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
        public Education_FormationDataAccess dbFormation = new Education_FormationDataAccess();
        public FrmFormation()
        {
            InitializeComponent();
            LoadFormation();
        }

        private void LoadFormation()
        {
            IPagedList <Education_Formation> listFormations = dbFormation.LoadAllEducation_Formations().ToPagedList(1,100);
            //foreach(var item in listFormations)

            l_PopUp.DataSource = GetDataSource(listFormations);
        }
        private object GetDataSource(IPagedList<Education_Formation> listPaged)
        {
            //using (CFNEducation_FormationEntities dbTemp = new CFNEducation_FormationEntities())
            //{
            object dataSource = listPaged.Select(o => new MyColumnCollectionFrmFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_SAP = o.Formation_SAP,

            }).ToList();

            //lblMin.Text = listPaged.FirstItemOnPage.ToString();
            //lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddFormations_Click(object sender, EventArgs e)
        {
            if (l_PopUp.SelectedRows.Count > 1)
            {
                var selectedRows = l_PopUp.SelectedRows
                                   .OfType<DataGridViewRow>()
                                   .Where(row => !row.IsNewRow)
                                   .ToArray();
                Education_FormationDataAccess db = new Education_FormationDataAccess();
                UCEducation_Formation.Instance.lFormationToAddToMatrice = new List<Education_Formation>();

                foreach (DataGridViewRow row in selectedRows)
                {
                    var item = db.LoadSingleEducation_Formation(row.Cells[1].Value.ToString());
                    UCEducation_Formation.Instance.lFormationToAddToMatrice.Add(item);

                }
            }

            this.Close();
        }
    }
}
