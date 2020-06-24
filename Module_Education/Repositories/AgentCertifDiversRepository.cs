using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class AgentCertifDiversRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentCertifDiversRepository()
        {

        }
        public List<Education_AgentCertificatDivers> LoadCertificateDiversAgent(Education_Agent agent)
        {
            return db.Education_AgentCertificatDivers.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

        public Education_AgentCertificatDivers NewPassportDivers(Education_AgentCertificatDivers newRecord)
        {
            Education_AgentCertificatDivers itemdb = new Education_AgentCertificatDivers();
            itemdb = newRecord;

            if (itemdb != null)
            {
                itemdb = db.Education_AgentCertificatDivers.Add(itemdb);
                db.SaveChanges();
            }

            return itemdb;
        }

        internal Education_AgentCertificatDivers LoadSingleCertificate(long passportId)
        {
            return db.Education_AgentCertificatDivers
                                      .Where(w => w.AgentCertificatDivers_Certificate == passportId)
                                         .FirstOrDefault()
                                         ;
        }
    }
}
