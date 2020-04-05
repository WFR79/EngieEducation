using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using Module_Education.Models;
using Module_Education.Helper;
using Module_Education.Classes;

namespace Module_Education
{
    public partial class UC_Provider : UserControl
    {
        #region Declarations
        IPagedList<Education_Provider> listProvidersPaged;
        int pageSize = 50;

        private static UC_Provider _instance;

        #endregion
        public UC_Provider()
        {
            InitializeComponent();
        }

        public static UC_Provider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Provider();
                return _instance;
            }
        }


        private async Task<IPagedList<Education_Provider>> LoadDatagriEducation_Providers(int pagNumber = 1, int pageSize = 100)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    {
                        pageSize = Int32.Parse(tbNbrRowsProviders.Text);

                        if (MainWindow.globalListProviders == null)
                        {

                            return dbList.Education_Provider
                            //.Include("Education_CategorieFormation")
                            //.Include("Education_FormationProvider")
                            //.Include("Education_FormationResultat")
                            //.Include("Education_FormationSession")
                            //.Include("Education_Matrice_Formation")
                            //.Include("Education_UnitePrice")

                            .OrderBy(p => p.Provider_Id).ToPagedList(pagNumber, pageSize);
                            //dG_Education_Formations.DataSource = lEducation_Formations.ToPagedList(1, 100); ;
                        }
                        else
                        {
                            return MainWindow.globalListProviders.ToPagedList(pagNumber, pageSize); ;
                            //dG_Education_Formations.DataSource = MainWindow.globalListEducation_Formations.ToPagedList(1, 100); 
                        }
                    }


                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC Provider");
                throw;
            }
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async  void LoadDataGridProdiver()
        {
            dG_Providers.SelectionChanged -= dG_Education_Provider_SelectionChanged; // Remove the handler.
            //dG_Education_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.

            listProvidersPaged = await LoadDatagriEducation_Providers(1, pageSize);
            dG_Providers.DataSource = GetDataSource(listProvidersPaged);
            dG_Providers.Refresh();
            dG_Providers.SelectionChanged += dG_Education_Provider_SelectionChanged; // ReAdd the handler.
            lblNbrProviders.Text = "Nombre total de formations : " + listProvidersPaged.TotalItemCount.ToString();
        }
        private object GetDataSource(IPagedList<Education_Provider> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGProvider(o)
            {
                Provider_Name = o.Provider_Name,


            }).ToList();

            lblMin.Text = listPaged.FirstItemOnPage.ToString();
            lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
        }

        private void dG_Education_Provider_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {

            }
        }

    }
}
