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
            return db.Education_Agent
                //.Include("Education_Function")
                //.Include("Education_GroupLearner_Agent")
                //.Include("Education_MovementAgent")
                //.Include("Education_RoleAstreinte")
                //.Include("Education_RoleEPI")
                //.Include("Education_AgentStatus")
                //.Include("Education_Agent_Formation")
                //.Include("Education_Habilitation")
                //.Include("Education_Role")
                .ToList();
        }

        public List<Education_Agent> LoadAllAgentsCertificate()
        {
            return db.Education_Agent
                  .Include("Education_AgentPassportSafety")
                        .Include("Education_AgentCertifElecFunc")
                        .Include("Education_AgentCertifElecOPP")
                        .Include("Education_AgentPassportBusiness")
                        .Include("Education_AgentPassportDesign")

                .ToList();
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

        public Education_Agent LoadSingleUser(long? userId)
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
            var sequenceQueryResult = listAgentFiltered;
            if (filter == "")
            {
                var sequenceMaxQuery = "SELECT * " +
                                      " FROM dbo.Education_Agent t1 ";
                listAgentFiltered = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                sequenceQueryResult = listAgentFiltered;
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
                if (filter.Contains("Agent_DateOfEntry") || filter.Contains("Agent_DateSeniority") || filter.Contains("Agent_DateFunction") ||
                    filter.Contains("Agent_Etat") || filter.Contains("Agent_Fullname") || filter.Contains("Agent_FirstName") || filter.Contains("Agent_Name") ||
                    filter.Contains("Agent_Matricule") || filter.Contains("Agent_Admin") || filter.Contains("Agent_Name") || filter.Contains("Agent_IsWorksManager"))
                {
                    sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
                    sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();
                    //sequenceQueryResult = sequenceQueryResult.Except(listAgentFiltered).ToList();
                }

                if (filter.Contains("Agent_InRoute"))
                {
                    var sequenceInRouteQuery = "SELECT * " +
                                     " FROM dbo.Education_InRoute t1 ";
                    sequenceInRouteQuery += "WHERE t1.InRoute_Name" + " " + filterValue;
                    var sequenceQueryFunction = db.Database.SqlQuery<Education_InRoute>(sequenceInRouteQuery).ToList();

                    filterValue = " IN ( ";
                    List<Education_Agent> listTemp = new List<Education_Agent>();
                    for (int i = 0; i < sequenceQueryFunction.Count; i++)
                    {
                        if (i < sequenceQueryFunction.Count - 1)
                            filterValue += "'" + sequenceQueryFunction[i].InRoute_Name + "'" + " ,";
                        else
                            filterValue += "'" + sequenceQueryFunction[i].InRoute_Name + "'";

                    }

                    filterValue += " )";
                    sequenceMaxQuery += "INNER JOIN dbo.Education_InRoute t2 on t2.InRoute_Id = t1.Agent_InRouteId ";
                    sequenceMaxQuery += " WHERE t2.InRoute_Name " + filterValue;
                    sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

                    sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery)
                        .ToList();
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();

                }

                if (filter.Contains("Function_Name"))
                {

                    var sequenceFunctQuery = "SELECT * " +
                                      " FROM dbo.Education_Function t1 ";
                    sequenceFunctQuery += "WHERE t1.Function_Name" + " " + filterValue;
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

                    sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery)
                        .ToList();
                    sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();


                }

                //var query = db.Education_Formation.Find(filter);
                return sequenceQueryResult;
            }

        }

        //    internal List<Education_Matrice_Agent> LoadMatriceAgentsFiltered(string filterString, List<Education_Matrice_Agent> distinctList)
        //    {
        //        IPagedList<Education_Agent> userTemp;
        //        int StartIndex = filterString.IndexOf("[");
        //        int EndIndex = filterString.IndexOf("]");
        //        var sequenceQueryResult = listAgentFiltered;
        //        if (filter == "")
        //        {
        //            var sequenceMaxQuery = "SELECT * " +
        //                                  " FROM dbo.Education_Agent t1 ";
        //            listAgentFiltered = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

        //            sequenceQueryResult = listAgentFiltered;
        //            return sequenceQueryResult;

        //        }
        //        else
        //        {
        //            var filterColumn = filter.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

        //            int StartIndexValue = filter.IndexOf("IN");
        //            int EndIndexValue = filter.LastIndexOf(')'); ;
        //            var filterValue = filter.Substring(StartIndexValue, EndIndexValue - StartIndexValue);


        //            var sequenceMaxQuery = "SELECT * " +
        //                                  " FROM dbo.Education_Agent t1 ";
        //            if (filter.Contains("Agent_DateOfEntry") || filter.Contains("Agent_DateSeniority") || filter.Contains("Agent_DateFunction") ||
        //                filter.Contains("Agent_Etat") || filter.Contains("Agent_Fullname") || filter.Contains("Agent_FirstName") || filter.Contains("Agent_Name") ||
        //                filter.Contains("Agent_Matricule") || filter.Contains("Agent_Admin") || filter.Contains("Agent_Name") || filter.Contains("Agent_IsWorksManager"))
        //            {
        //                sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
        //                sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

        //                sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();
        //                //sequenceQueryResult = sequenceQueryResult.Except(listAgentFiltered).ToList();
        //            }

        //            if (filter.Contains("Agent_InRoute"))
        //            {
        //                var sequenceInRouteQuery = "SELECT * " +
        //                                 " FROM dbo.Education_InRoute t1 ";
        //                sequenceInRouteQuery += "WHERE t1.InRoute_Name" + " " + filterValue;
        //                var sequenceQueryFunction = db.Database.SqlQuery<Education_InRoute>(sequenceInRouteQuery).ToList();

        //                filterValue = " IN ( ";
        //                List<Education_Agent> listTemp = new List<Education_Agent>();
        //                for (int i = 0; i < sequenceQueryFunction.Count; i++)
        //                {
        //                    if (i < sequenceQueryFunction.Count - 1)
        //                        filterValue += "'" + sequenceQueryFunction[i].InRoute_Name + "'" + " ,";
        //                    else
        //                        filterValue += "'" + sequenceQueryFunction[i].InRoute_Name + "'";

        //                }

        //                filterValue += " )";
        //                sequenceMaxQuery += "INNER JOIN dbo.Education_InRoute t2 on t2.InRoute_Id = t1.Agent_InRouteId ";
        //                sequenceMaxQuery += " WHERE t2.InRoute_Name " + filterValue;
        //                sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

        //                sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery)
        //                    .ToList();
        //                sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();

        //            }

        //            if (filter.Contains("Function_Name"))
        //            {

        //                var sequenceFunctQuery = "SELECT * " +
        //                                  " FROM dbo.Education_Function t1 ";
        //                sequenceFunctQuery += "WHERE t1.Function_Name" + " " + filterValue;
        //                var sequenceQueryFunction = db.Database.SqlQuery<Education_Function>(sequenceFunctQuery).ToList();

        //                filterValue = " IN ( ";
        //                List<Education_Agent> listTemp = new List<Education_Agent>();
        //                for (int i = 0; i < sequenceQueryFunction.Count; i++)
        //                {
        //                    if (i < sequenceQueryFunction.Count - 1)
        //                        filterValue += "'" + sequenceQueryFunction[i].Function_Name + "'" + " ,";
        //                    else
        //                        filterValue += "'" + sequenceQueryFunction[i].Function_Name + "'";

        //                }

        //                filterValue += " )";
        //                sequenceMaxQuery += "INNER JOIN dbo.Education_Function t2 on t2.function_Id = t1.Agent_Function ";
        //                sequenceMaxQuery += " WHERE " + filterColumn + " " + filterValue;
        //                sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery).ToList();

        //                sequenceQueryResult = db.Database.SqlQuery<Education_Agent>(sequenceMaxQuery)
        //                    .ToList();
        //                sequenceQueryResult = listAgentFiltered.Where(x => sequenceQueryResult.Any(c => c.Agent_Matricule.Equals(x.Agent_Matricule))).ToList();


        //            }

        //            //var query = db.Education_Formation.Find(filter);
        //            return sequenceQueryResult;
        //        }
        //}
    }
}