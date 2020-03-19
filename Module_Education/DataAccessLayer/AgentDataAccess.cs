using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using System.Web;

namespace Module_Education
{
    public class AgentDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentDataAccess()
        {

        }
        public List<Education_Agent> LoadAllAgents()
        {
            return db.Education_Agent.ToList();
        }

        public async void SaveAgent(Education_Agent userToUpdate)
        {
            if (userToUpdate != null)
            {
                var user = db.Education_Agent.Where(x => x.Agent_Id == userToUpdate.Agent_Id).FirstOrDefault();

                user = userToUpdate;
                 await db.SaveChangesAsync();
            }
            else
            {
                db.Education_Agent.Add(userToUpdate);
                 await db.SaveChangesAsync();
            }
        }

        public List<Education_Agent> LoadAllAgentsFilteredByEducation_Formation(Education_Formation Education_Formation)
        {
            List<Education_Agent> UserListFiltered = new List<Education_Agent>();
            var userEducation_FormationList = db.Education_Agent_Formation.Where(x => x.AgentFormation_Formation == Education_Formation.Formation_Id).ToList();
            if (userEducation_FormationList != null)
            {
                foreach (var userEducation_Formation in userEducation_FormationList)
                {
                    var userTemp = db.Education_Agent.Where(y => y.Agent_Id == userEducation_Formation.AgentFormation_Agent).FirstOrDefault();
                    UserListFiltered.Add(userTemp);
                }

            }
            return UserListFiltered;
        }
       

        public List<Education_Agent> LoadAllAgentsFiltered(Education_Formation Education_Formation)
        {
            List<Education_Agent> UserListFiltered = new List<Education_Agent>();
            var userEducation_FormationList =  db.Education_Agent_Formation.Where(x => x.AgentFormation_Formation == Education_Formation.Formation_Id).ToList();
            if (userEducation_FormationList != null)
            {
                foreach (var userEducation_Formation in userEducation_FormationList)
                {
                    var userTemp = db.Education_Agent.Where(y => y.Agent_Id == userEducation_Formation.AgentFormation_Agent).FirstOrDefault();
                    UserListFiltered.Add(userTemp);
                }
                
            }
            return UserListFiltered;
        }

        public Education_Agent LoadSingleUser(long userId)
        {
            var userTemp = db.Education_Agent.Where(x => x.Agent_Id == userId).FirstOrDefault();
            if (userTemp != null)
            {
                return userTemp;
            }
            else
                return null;
           
        }

        public Education_Agent LoadSingleUserWithMatricule(long matricule)
        {
            var userTemp = db.Education_Agent.Where(x => x.Agent_Matricule == matricule).FirstOrDefault();
            if (userTemp != null)
            {
                return userTemp;
            }
            else
                return null;
        }
    }
}