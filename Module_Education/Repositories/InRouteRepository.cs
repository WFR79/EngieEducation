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
    }
}
