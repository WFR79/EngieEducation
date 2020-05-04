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

        public Education_Matrice SaveDetailsRoute(string nameMatrice, int recurrency, string newMatriceName)
        {
            try
            {
                var matriceDB = db.Education_Matrice.Where(x => x.Matrice_Description == nameMatrice).FirstOrDefault();
                if (matriceDB != null)
                {
                    if (nameMatrice != newMatriceName)
                    {
                        matriceDB.Matrice_Description = newMatriceName;
                    }
                    matriceDB.Matrice_Recurrency = recurrency;
                    db.SaveChanges();
                    return matriceDB;
                }
                else
                {
                    Education_Matrice newRecord = new Education_Matrice()
                    {
                        Matrice_Description = newMatriceName,
                        Matrice_Recurrency = recurrency
                    };
                    db.Education_Matrice.Add(newRecord);
                    db.SaveChanges();
                    return matriceDB;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Education_Agent>  LoadAllAgentsExcepted(Education_Matrice matriceSelected)
        {
            List<Education_Agent> listAgentInGrp = db.Education_Agent
                         .Where(w => w.Education_Matrice_Agent.Any(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceSelected.Matrice_Id))
                         .ToList();

            List<Education_Agent> listAgent = db.Education_Agent
               .ToList();

            List<Education_Agent> listIntersect = listAgent.Except(listAgentInGrp).ToList();

            return listIntersect;
        }

        public List<Education_GroupLearner> LoadAllGrpAgentsExcepted(Education_Matrice matriceSelected)
        {
            db = new CFNEducation_FormationEntities();
            List<Education_GroupLearner> listAgentInGrp = db.Education_GroupLearner
                         .Where(w => w.Education_Matrice_GrLearner.Any(x => x.MatriceGrLearner_Matrice == matriceSelected.Matrice_Id))
                         .ToList();

            List<Education_GroupLearner> listAgent = db.Education_GroupLearner
               .ToList();

            List<Education_GroupLearner> listIntersect = listAgent.Except(listAgentInGrp).ToList();

            return listIntersect;
        }
    }
}
