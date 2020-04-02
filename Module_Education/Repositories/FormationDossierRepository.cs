using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class FormationDossierRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();


        public Education_FormationDossier LoadInfoFiche(Education_Formation formation)
        {
            return db.Education_FormationDossier
                .Where(x => x.FormationDossier_Formation == formation.Formation_Id)
                .FirstOrDefault();
        }

        public Education_FormationDossier SaveInfoFiche(Education_Formation formation, string filePath)
        {
            Education_FormationDossier newRecord;
            var recordFound = db.Education_FormationDossier.Where(x => x.FormationDossier_Formation == formation.Formation_Id).FirstOrDefault();
            if (recordFound == null)
            {
                newRecord = new Education_FormationDossier()
                {
                    FormationDossier_Formation = formation.Formation_Id,
                    FormationDossier_DateUpdate = DateTime.Now,
                    FormationDossier_InfoFicheHyperLink = filePath,

                };
                db.Education_FormationDossier.Add(newRecord);
                db.SaveChanges();
                return newRecord;
            }
            else
            {
                recordFound.FormationDossier_DateUpdate = DateTime.Now;
                recordFound.FormationDossier_InfoFicheHyperLink = filePath;

                db.Education_FormationDossier.Add(recordFound);
                db.SaveChanges();
                return recordFound;
            }
           
           
        }
        public Education_FormationDossier SaveSyllabus(Education_Formation formation, string filePath)
        {
            Education_FormationDossier newRecord = new Education_FormationDossier()
            {
                FormationDossier_Formation = formation.Formation_Id,
                FormationDossier_DateUpdate = DateTime.Now,
                FormationDossier_InfoFicheHyperLink = filePath,


            };
            db.Education_FormationDossier.Add(newRecord);
            db.SaveChanges();
            return newRecord;
        }
    }
}
