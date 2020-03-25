﻿using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Module_Education
{
    public class Education_FormationDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public List<Education_Formation> LoadAllEducation_Formations()
        {
            try
            {
                return db.Education_Formation.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<List<Education_Formation>> LoadAllEducation_FormationsAsync()
        {
            try
            {
                using (var dbFormation = new CFNEducation_FormationEntities())
                {
                    return await dbFormation.Education_Formation.ToListAsync();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Education_Formation> LoadAllEducation_FormationsFiltered(string filter, string columnToFilter)
        {
            try
            {
                var sequenceMaxQuery = "SELECT * " +
                                  " FROM dbo.Education_Formation ";
                if (columnToFilter != "")
                {
                    switch (columnToFilter)
                    {
                        case "Formation_SAP":
                            columnToFilter = "Formation_SAP";
                            sequenceMaxQuery += "WHERE " + filter;
                            break;
                        case "Formation_ShortTitle":
                            columnToFilter = "Formation_ShortTitle";
                            sequenceMaxQuery += "WHERE " + columnToFilter + " " + filter;
                            break;
                        case "Titre Long":
                            columnToFilter = "Formation_LongTitle"; sequenceMaxQuery = "SELECT * " +
                                   " FROM dbo.Education_Formation " +
                                   "WHERE " + columnToFilter + " LIKE ('%" + filter + "%')";
                            break;
                        case "Formation_DurationInDays":
                            columnToFilter = "Formation_DurationInDays";
                            sequenceMaxQuery = "SELECT * " +
                                  " FROM dbo.Education_Formation " +
                                  "WHERE " + filter;
                            break;
                    }
                }
                else
                {
                    if (filter == "")
                    {
                        sequenceMaxQuery = "SELECT * " +
                                     " FROM dbo.Education_Formation ";
                                     }
                    else
                    {
                        sequenceMaxQuery += "WHERE " + filter;
                    }
                }

                var sequenceQueryResult = db.Database.SqlQuery<Education_Formation>(sequenceMaxQuery).ToList();
                //var query = db.Education_Formation.Find(filter);
                return sequenceQueryResult;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Education_Formation> LoadAllEducation_FormationOfSingleAgent(Education_Agent education_Agent)
        {
            List<Education_Formation> listEducation_Formations = new List<Education_Formation>();
            var Education_FormationUserTemp = db.Education_Agent_Formation.Where(x => x.AgentFormation_Agent == education_Agent.Agent_Id).ToList();
            foreach (var Education_FormationTemp in Education_FormationUserTemp)
            {
                listEducation_Formations.Add(db.Education_Formation.Where(y => y.Formation_Id == Education_FormationTemp.AgentFormation_Formation)
                    .FirstOrDefault());
            }

            return listEducation_Formations;
        }


        /// <summary>
        /// Adding new Education_Formation
        /// </summary>
        /// <param name="newEducation_Formation"></param>
        /// <returns> Newly added Education_Formation </returns>
        public Education_Formation AddEducation_Formation(Education_Formation newEducation_Formation)
        {
            var Education_FormationFromDB = db.Education_Formation.Where(x => x.Formation_SAP == newEducation_Formation.Formation_SAP).FirstOrDefault();
            if (Education_FormationFromDB == null)
            {
                db.Education_Formation.Add(newEducation_Formation);
                db.SaveChangesAsync();
            }

            return newEducation_Formation;
        }

        /// <summary>
        /// Update an existing  Education_Formation
        /// </summary>
        /// <param name="updatedEducation_Formation"></param>
        /// <returns> updated Education_Formation Education_Formation </returns>
        public Education_Formation UpdateEducation_Formation(Education_Formation updatedEducation_Formation)
        {
            var Education_FormationFromDB = db.Education_Formation.Where(x => x.Formation_SAP == updatedEducation_Formation.Formation_SAP).FirstOrDefault();
            if (Education_FormationFromDB == null)
            {
                Education_FormationFromDB.Formation_IsInterne = updatedEducation_Formation.Formation_IsInterne;
                Education_FormationFromDB.Formation_AnnualOrders = updatedEducation_Formation.Formation_AnnualOrders;
                Education_FormationFromDB.Formation_DemandeDeDates = updatedEducation_Formation.Formation_DemandeDeDates;
                Education_FormationFromDB.Formation_DurationInDays = updatedEducation_Formation.Formation_DurationInDays;
                Education_FormationFromDB.Formation_LongTitle = updatedEducation_Formation.Formation_LongTitle;
                Education_FormationFromDB.Formation_MaxCapacity = updatedEducation_Formation.Formation_MaxCapacity;
                Education_FormationFromDB.Formation_MinCapacity = updatedEducation_Formation.Formation_MinCapacity;
                Education_FormationFromDB.Formation_OptimalCapacity = updatedEducation_Formation.Formation_OptimalCapacity;
                Education_FormationFromDB.Formation_Price = updatedEducation_Formation.Formation_Price;
                Education_FormationFromDB.Formation_ShortTitle = updatedEducation_Formation.Formation_ShortTitle;
                Education_FormationFromDB.Formation_YearOfCreation = updatedEducation_Formation.Formation_YearOfCreation;

                db.SaveChangesAsync();
            }

            return Education_FormationFromDB;
        }

        public async void SaveEducation_Formation(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation != null)
            {
                var Education_Formation = db.Education_Formation.Where(x => x.Formation_SAP == currentEducation_Formation.Formation_SAP).FirstOrDefault();

                Education_Formation = currentEducation_Formation;
                await db.SaveChangesAsync();
            }
            else
            {
                db.Education_Formation.Add(currentEducation_Formation);
                await db.SaveChangesAsync();
            }
        }

        public Education_Formation LoadSingleEducation_Formation(string Education_FormationSAPSelected)
        {
            return db.Education_Formation.Where(w => w.Formation_SAP == Education_FormationSAPSelected).FirstOrDefault();
        }
    }
}