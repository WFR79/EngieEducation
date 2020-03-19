using Module_ADR.Helper;
using Module_ADR.Models;
using SynapseCore.Database;
using System;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class RepositoryBase : IDisposable
    {
        protected readonly ADREntities Db;

        public RepositoryBase()
        {
            Db = new ADREntities();
            Db.SwicthEFAppRole(ADRHelper.GetApplicationRole());
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
