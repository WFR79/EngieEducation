using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class EquipeDataAccess : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public EquipeDataAccess()
        {

        }
        public List<Education_Equipe> LoadAllEquipes()
        {
            return db.Education_Equipe.ToList();
        }
    }
}