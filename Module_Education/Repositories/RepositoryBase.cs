using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using SynapseCore.Database;

using System.Web;
using PagedList;
using System.Threading.Tasks;
namespace Module_Education
{
    public class RepositoryBase : IDisposable
    {
        protected readonly CFNEducation_FormationEntities Db;

        public RepositoryBase()
        {
            Db = new CFNEducation_FormationEntities();
            Db.SwicthEFAppRole(EducationHelper.GetApplicationRole());
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
