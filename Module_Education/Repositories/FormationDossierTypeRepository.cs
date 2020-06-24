using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Module_Education.Repositories
{
    public class FormationDossierTypeRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationDossierTypeRepository()
        {

        }

        public List<Education_FormationDossierType> LoadAllTypeDossier()
        {
            return db.Education_FormationDossierType.ToList();
        
        }
    }
}
