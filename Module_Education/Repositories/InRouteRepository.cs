using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education
{
    public class InRouteRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public InRouteRepository()
        {

        }
        public List<Education_InRoute> LoadAllInRoute()
        {
            return db.Education_InRoute.ToList();
        }
        public Education_Matrice AddNewMatrice(string nameMatrice, int recurrency)
        {

            Education_Matrice matrice = db.Education_Matrice
                 .Where(x => x.Matrice_Description == nameMatrice)
                 .FirstOrDefault();
            if (matrice == null)
            {
                Education_Matrice newRecord = new Education_Matrice
                {

                    Matrice_Recurrency = recurrency,
                    Matrice_Description = nameMatrice
                };
                db.Education_Matrice.Add(newRecord);
                db.SaveChanges();

                return newRecord;
            }
            else
            {
                return null;
            }

        }
    }
}
