using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class UnitePriceRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public UnitePriceRepository()
        {

        }
        public List<Education_UnitePrice> LoadUnitePrice()
        {
            return db.Education_UnitePrice
                 .ToList();
        }
    }
}
