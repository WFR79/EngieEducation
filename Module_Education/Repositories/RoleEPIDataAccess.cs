using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Module_Education
{
    public class RoleEPIDataAccess : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public RoleEPIDataAccess()
        {

        }
        public List<Education_RoleEPI> LoadAllRoleEPI()
        {
            return db.Education_RoleEPI.ToList();
        }

    }
}