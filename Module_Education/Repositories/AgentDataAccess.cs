using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using System.Web;
using PagedList;
using System.Threading.Tasks;

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

        public List<Education_Agent> LoadAgentsFiltered(string filter, List<Education_Agent> listAgentFiltered)
        {
            IPagedList<Education_Agent> userTemp;
            int StartIndex = filter.IndexOf("[");
            int EndIndex = filter.IndexOf("]");
            if (filter == "")
            {
                var sequenceMaxQuery = "SELECT * " +
                                      " FROM dbo.Education_Agent t1 ";
                listAgentFiltered = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                var sequenceQueryResult = listAgentFiltered;
                return sequenceQueryResult;

            }
            else
            {
                var filterColumn = filter.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

                int StartIndexValue = filter.IndexOf("IN");
                int EndIndexValue = filter.LastIndexOf(')'); ;
                var filterValue = filter.Substring(StartIndexValue, EndIndexValue - StartIndexValue);


                var sequenceMaxQuery = "SELECT * " +
                                      " FROM dbo.Education_Agent t1 ";
                sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                var sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                if (filter.Contains("Agent_Matricule") || filter.Contains("Agent_Admin"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();
                }

                if (filter.Contains("Agent_Name"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Name.Equals(x.Agent_Name))).ToList();
                }
                if (filter.Contains("Agent_FirstName"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_FirstName.Equals(x.Agent_FirstName))).ToList();
                }
                if (filter.Contains("Agent_Etat"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Etat.Equals(x.Agent_Etat))).ToList();
                }
                if (filter.Contains("Agent_DateOfEntry"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Name.Equals(x.Agent_Name))).ToList();
                }


                if (filter.Contains("Function_Name"))
                {
                    var sequenceFunctQuery = "SELECT * " +
                                      " FROM dbo.Education_Function ";
                    sequenceFunctQuery += "WHERE Function_Name" + " " + filterValue;
                    var sequenceQueryFunction = db.Database.SqlQuery<Education_Function>(sequenceFunctQuery).ToList();

                    filterValue = " IN ( ";
                    List<Education_Agent> listTemp = new List<Education_Agent>();
                    for (int i = 0; i < sequenceQueryFunction.Count; i++)
                    {
                        if (i < sequenceQueryFunction.Count - 1)
                            filterValue += "'" + sequenceQueryFunction[i].Function_Name + "'" + " ,";
                        else
                            filterValue += "'" + sequenceQueryFunction[i].Function_Name + "'";

                    }

                    filterValue += " )";
                    sequenceMaxQuery += "INNER JOIN dbo.Education_Function t2 on t2.function_Id = t1.Agent_Function ";
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();


                }

                //var query = db.Education_Formation.Find(filter);
                return sequenceQueryResult;
            }

        }
    }
}