using Module_Education.Repositories;
using Module_Education.Models;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Module_Education
{
    public static class EducationHelper
    {
       
        /// <summary>
        /// Get application role for 
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationRole()
        {
            return ConfigurationManager.AppSettings.Get("ApplicationRole");
        }

    }
}
