using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{

    public class FunctionDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FunctionDataAccess()
        {

        }
        public List<Education_Function> LoadAllFunctions()
        {
            return db.Education_Function.ToList();
        }
    }
}