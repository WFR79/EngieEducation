using Module_Education.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class AgentPassportSafetyRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentPassportSafetyRepository()
        {

        }

        public List<Education_AgentPassportSafety> LoadPassportSafety(Education_Agent agent)
        {
            return db.Education_AgentPassportSafety.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

        public List<Education_Agent> LoadAllPassportSafety()
        {
            return db.Education_Agent
                .Include("Education_AgentPassportSafety")
                    .ToList();
        }

        public List<Education_Agent> LoadAgentsFiltered(string filter, List<Education_Agent> listAgentFiltered)
        {
            IPagedList<Education_Agent> userTemp;
            int StartIndex = filter.IndexOf("[");
            int EndIndex = filter.IndexOf("]");
            //List<Education_Agent> sequenceQueryResult = new List<Education_Agent>();

            if (filter != "")
            {
                if (filter.Contains(""))
                {
                    var sequenceMaxQuery = "SELECT t1.*, t2.*, t3.PassportSafety_LevelPS  as  Niveau_PS" +
                                          " FROM dbo.Education_Agent t1 INNER JOIN dbo.Education_AgentPassportSafety t2 on t2.AgentPassportSafety_Agent = t1.Agent_Id " +
                                          " inner join dbo.Education_PassportSafety t3 on t3.PassportSafety_Id = t2.AgentPassportSafety_Passport" +
                                          " WHERE t3.PassportSafety_LevelPS in " + filter;
                    listAgentFiltered = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                    var sequenceQueryResult = listAgentFiltered;
                }
                return listAgentFiltered;


            }
            else
            {
                var filterColumn = filter.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

                int StartIndexValue = filter.IndexOf("IN");
                int EndIndexValue = filter.LastIndexOf(')'); ;
                var filterValue = filter.Substring(StartIndexValue, EndIndexValue - StartIndexValue);


                var sequenceMaxQuery = "SELECT * " +
                                      " FROM dbo.Education_Agent t1 on t2 dbo.Education_AgentPassportSafety t2 on t2.AgentPassportSafety_Agent = t1.Agent_Id";
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
