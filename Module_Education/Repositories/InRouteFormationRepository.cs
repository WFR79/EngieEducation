using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Repositories
{
    public class InRouteFormationRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public InRouteFormationRepository()
        {

        }

        public List<Education_Matrice_Formation> LoadMatriceFormation(string matriceName)
        {
            List<Education_Matrice_Formation> listMatriceFormation = db.Education_Matrice_Formation
                 .Where(x => x.Education_Matrice.Matrice_Description == matriceName)
                 .ToList();
           

            return listMatriceFormation;
        }

        public List<Education_Matrice_Formation> SaveMatriceFormation(Education_Matrice matriceF, int recurrency)
        {
            List<Education_Matrice_Formation> listMatriceFormation = db.Education_Matrice_Formation
                 .Where(x => x.MatriceFormation_Matrice == matriceF.Matrice_Id)
                 .ToList();
            if (listMatriceFormation.Count > 0)
                foreach (Education_Matrice_Formation matriceFormationItem in listMatriceFormation)
                {
                    matriceFormationItem.MatriceFormation_Recurrency = recurrency;
                    db.SaveChanges();
                }

            return listMatriceFormation;
        }

        public Education_Matrice_Formation SaveMatriceFormation(Education_Matrice_Formation matriceFormation, int recurrency)
        {
            Education_Matrice_Formation MatriceFormation = db.Education_Matrice_Formation
                 .Where(x => x.MatriceFormation_Matrice == matriceFormation.MatriceFormation_Matrice
                 && x.MatriceFormation_Formation == matriceFormation.MatriceFormation_Formation)
                 .FirstOrDefault();
            if (MatriceFormation != null)
            {
                MatriceFormation.MatriceFormation_Recurrency = recurrency;
                db.SaveChanges();
            }

            return MatriceFormation;
        }

        public void RemoveFormationFromTrajet(string formationSAP, string routeName)
        {
            Education_Matrice Matrice = db.Education_Matrice
               .Where(x => x.Matrice_Description == routeName)
               .FirstOrDefault();

            Education_Matrice_Formation MatriceFormation = db.Education_Matrice_Formation
                .Where(p => p.Education_Matrice.Matrice_Id == Matrice.Matrice_Id
                && p.Education_Formation.Formation_SAP == formationSAP)
                .FirstOrDefault(); ;

            db.Education_Matrice_Formation.Remove(MatriceFormation);
            db.SaveChanges();
        }

        public void RemoveAllMatriceForamtion(TreeNodeCollection nodes, string routeName)
        {
            Education_Matrice Matrice = db.Education_Matrice
               .Where(x => x.Matrice_Description == routeName)
               .FirstOrDefault();

            foreach (TreeNode singleRecord in nodes)
            {
                Education_Matrice_Formation MatriceFormation = db.Education_Matrice_Formation
                    .Where(p => p.Education_Matrice.Matrice_Id == Matrice.Matrice_Id
                    && p.Education_Formation.Formation_SAP == singleRecord.Name)
                    .FirstOrDefault(); ;


                db.Education_Matrice_Formation.Remove(MatriceFormation);
                db.SaveChanges();
            }

            db.Education_Matrice.Remove(Matrice);
            db.SaveChanges();
        }

        public void SaveCurrencyOfFormation(string formationSAP, string routeName, int recurrency)
        {
            

            Education_Matrice_Formation MatriceFormation = db.Education_Matrice_Formation
                .Where(p => p.Education_Matrice.Matrice_Description == routeName
                && p.Education_Formation.Formation_SAP == formationSAP)
                .FirstOrDefault(); 

            MatriceFormation.MatriceFormation_Recurrency = recurrency;

            db.SaveChanges();
        }
    }
}
