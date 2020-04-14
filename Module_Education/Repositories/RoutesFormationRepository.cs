using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class RoutesFormationRepository
    {
        CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public RoutesFormationRepository()
        {

        }

        public List<Education_Matrice> LoadAllMatrice()
        {
            return db.Education_Matrice.ToList();
        }

        public List<Education_Matrice> LoadAllMatriceById()
        {
            return db.Education_Matrice.ToList();
        }

        public Education_Matrice SaveMatrice(Education_Matrice newMatrice)
        {
            db.Education_Matrice.Add(newMatrice);
            db.SaveChanges();
            return newMatrice;
        }

        public void SaveCurrencyOfFormation(string nameMatrice, int recurrency)
        {
            var matriceDB =  db.Education_Matrice.Where(x => x.Matrice_Description == nameMatrice).FirstOrDefault();
            matriceDB.Matrice_Recurrency = recurrency;
            db.SaveChanges();
        }
    }
}
