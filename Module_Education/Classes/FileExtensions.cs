using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class FileExtensions
    {
        public FileExtensions()
        {

        }
        public string SaveFile(string fileName, string formationSAP)
        {
            try
            {
                string[] fileNameSplitted = fileName.Split('\\');
                string filePathRoot = Path
                    .Combine(ConfigurationManager
                    .AppSettings["InfoFicheFolderPath"]);

                bool exists = System.IO.Directory.Exists(Path
                    .Combine(filePathRoot,formationSAP));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Path
                    .Combine(filePathRoot, formationSAP));

                string fileSavedPath = filePathRoot + "\\" + formationSAP + "\\" + fileNameSplitted[fileNameSplitted.Length - 1];
                File.Copy( fileName, fileSavedPath,true);

                return fileSavedPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
