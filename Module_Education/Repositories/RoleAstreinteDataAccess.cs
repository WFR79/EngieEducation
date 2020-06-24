using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Module_Education
{
    public class RoleAstreinteDataAccess : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public RoleAstreinteDataAccess()
        {

        }
        public List<Education_RoleAstreinte> LoadAllRoleAstreinte()
        {
            return db.Education_RoleAstreinte.ToList();
        }

    }
}