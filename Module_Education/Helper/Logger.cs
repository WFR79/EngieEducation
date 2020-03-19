
using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education.Helper
{
    public static class Logger
    {
        public static void LogError(Exception ex, string source)
        {
            CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();
            Education_Log logError = new Education_Log
            {
                Log_Date = DateTime.Now,
                Log_Message = ex.Message,
                Log_Stacktrace = ex.StackTrace,
                Log_Source = source
            };

            db.Education_Log.Add(logError);
            db.SaveChanges();
        }

        public static void LogError(string messageException, string source)
        {
            CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();
            Education_Log logInfo = new Education_Log
            {
                Log_Date = DateTime.Now,
                Log_Message = messageException,
                Log_Source = source
            };

            db.Education_Log.Add(logInfo);
            db.SaveChanges();

        }

        public static void LogInfo(string Message, string source)
        {
            CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

            Education_Log logInfo = new Education_Log
            {
                Log_Date = DateTime.Now,
                Log_Message = Message,
                Log_Source = source
            };

            db.Education_Log.Add(logInfo);
            db.SaveChanges();

        }

    }
}