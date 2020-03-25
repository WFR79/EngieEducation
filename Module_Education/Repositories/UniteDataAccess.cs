using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class UniteDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();


        public UniteDataAccess()
        {

        }
        public List<Education_UnitePrice> LoadAllUnite()
        {
            return db.Education_UnitePrice.ToList();
        }

    }
}