using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
