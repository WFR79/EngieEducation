namespace SynapseResourceBuilder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using log4net;
    using log4net.Config;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using SynapseCore.Entities;

    public class Program
    {
        private static Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
        private static IList<SynapseLanguage> Languages = SynapseLanguage.Load();
        private static ILog logger = LogManager.GetLogger("SynapseResourcesLogger");

        static void LoadCurrentRessources(string c_directory)
        {
            Console.WriteLine("<Loading existing control resource>");
            Console.WriteLine("-----------------------------------");
            string[] filePaths = Directory.GetFiles(c_directory + @"\Resources\", "*.txt", SearchOption.AllDirectories);
            foreach (string filename in filePaths)
            {
                Regex regex = new Regex(@".*\x2E(?<Culture>.*)\x2E.*", RegexOptions.Compiled | RegexOptions.Multiline);

                string culture = null;
                Match match = regex.Match(filename);
                if (match.Success)
                {
                    culture = match.Groups["Culture"].Value;
                }

                if (culture == null)
                    culture = "Default";

                dic[culture] = new Dictionary<string, string>();

                Console.WriteLine("Loading " + Path.GetFileName(filename));
                StreamReader re = File.OpenText(filename);
                string input = null;
                while ((input = re.ReadLine()) != null)
                {
                    //Console.WriteLine("  =>" + input);
                    if (input != string.Empty)
                    {
                        string[] entry = input.Split('=');
                        dic[culture][entry[0]] = entry[1];
                    }
                }
                re.Close();
                Console.WriteLine(dic[culture].Count.ToString() + " Entries loaded");
            }
            if (!dic.ContainsKey("Default"))
                dic["Default"] = new Dictionary<string, string>();
            foreach (SynapseLanguage lang in Languages)
            {
                if (!dic.ContainsKey(lang.CULTURE))
                    dic[lang.CULTURE] = new Dictionary<string, string>();
            }
        }
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            try
            {
                string dbvalue = null;
                string scan_directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string target_directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                foreach (string argu in args)
                {
                    Console.WriteLine("line: >" + argu);
                    string arg = argu.Trim('"');
                    arg = arg.TrimEnd('*');
                    if (arg.Contains(':'))
                    {
                        string param = arg.Substring(0, arg.IndexOf(':'));
                        string value = arg.Substring(arg.IndexOf(':') + 1);
                        switch (param)
                        {
                            case "scan":
                                Console.WriteLine("scan:" + value);
                                if (Directory.Exists(value))
                                    scan_directory = value;
                                else
                                    throw new NotImplementedException("bad scan dir");
                                break;
                            case "target":
                                Console.WriteLine("Target:" + value);
                                if (Directory.Exists(value))
                                    target_directory = value;
                                else
                                    throw new NotImplementedException("bad target dir");
                                break;
                            case "db":
                                dbvalue = value;
                                break;
                            default:
                                Console.WriteLine(string.Format("Param:{0} -> Value:{1}", param, value));
                                break;
                        }
                    }
                }



                LoadCurrentRessources(target_directory);

                Console.WriteLine("\n");
                Console.WriteLine("<Getting new control resource>");
                Console.WriteLine("------------------------------");

                string[] filePaths = Directory.GetFiles(scan_directory, "*.SynapseResource", SearchOption.AllDirectories);
                StringBuilder SB = new StringBuilder();

                foreach (string filename in filePaths)
                {
                    Console.WriteLine("Processing " + Path.GetFileName(filename));
                    StreamReader re = File.OpenText(filename);
                    string input = null;
                    while ((input = re.ReadLine()) != null)
                    {
                        //Console.WriteLine("  =>"+input);
                        if (input != string.Empty)
                        {
                            string[] entry = input.Split('=');
                            if (entry.Length == 2)
                            {
                                string translated = string.Empty;
                                if (!dic["Default"].ContainsKey(entry[0]))
                                {
                                    dic["Default"].Add(entry[0], entry[1]);
                                    Console.WriteLine("...adding " + entry[0] + " with value:" + entry[1]);
                                }
                                foreach (SynapseLanguage lang in Languages)
                                {

                                    if (!dic[lang.CULTURE].ContainsKey(entry[0]))
                                    {
                                        dic[lang.CULTURE].Add(entry[0], entry[1]);
                                        Console.WriteLine("...adding " + entry[0] + " with value:" + entry[1]);
                                    }
                                }
                            }
                        }
                    }
                    re.Close();
                }

                Console.WriteLine("\n");
                Console.WriteLine("<DB Resource files>");
                Console.WriteLine("------------------");

                Console.Write("Generate DB fields resources ? (y/(n)) ");
                if (dbvalue == null)
                {
                    ConsoleKeyInfo Enteredkey = Console.ReadKey();

                    if (Enteredkey.Key == ConsoleKey.Y)
                        GenerateDBFields();
                }
                else
                    if (dbvalue.Substring(0, 1).ToUpper() == "Y")
                    GenerateDBFields();
                Console.WriteLine("\n");
                Console.WriteLine("<Saving text files>");
                Console.WriteLine("-------------------");
                Console.WriteLine("Saving Default text file");
                var resourceDirectory = Path.Combine(target_directory, "Resources");
                if (!Directory.Exists(resourceDirectory)) Directory.CreateDirectory(resourceDirectory);

                writeStringResources(Path.Combine(resourceDirectory, "formLabels.txt"), dic["Default"]);

                foreach (SynapseLanguage lang in Languages)
                {
                    Console.WriteLine("Saving " + lang + " text file");
                    writeStringResources(Path.Combine(resourceDirectory, "formLabels." + lang.CULTURE + ".txt"), dic[lang.CULTURE]);
                }

                Console.WriteLine("\n");
                Console.WriteLine("<Generating resource files>");
                Console.WriteLine("---------------------------");

                string[] fileResPaths = Directory.GetFiles(resourceDirectory, "*.txt", SearchOption.AllDirectories);
                foreach (string filename in fileResPaths)
                {
                    Console.WriteLine(">Generating resource for:" + filename);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.UseShellExecute = false;
                    //proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    if (System.IO.File.Exists(@"C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\resgen.exe"))
                        proc.StartInfo.FileName = @"C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\resgen.exe";
                    else
                        if (System.IO.File.Exists(@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\resgen.exe"))
                            proc.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\resgen.exe";
                    else
                        if (System.IO.File.Exists(@"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\ResGen.exe"))
                         proc.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\ResGen.exe";
                    else
                        throw (new Exception("No resgen found"));


                    proc.StartInfo.WorkingDirectory = resourceDirectory;
                    Console.WriteLine("in: " + resourceDirectory);
                    string resourceFileName = filename.Replace(".txt", ".resources");
                    // Check out from TFS 
                    //checkOutFile(resourceFileName);
                    proc.StartInfo.Arguments = "\"" + filename + "\" \"" + resourceFileName + "\"";
                    proc.Start();
                    proc.WaitForExit();
                    Console.WriteLine(proc.ExitCode.ToString());
                }
                Console.WriteLine("\n\nDone.");
                if (dbvalue == null)
                    Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                logger.Error(ex);
            }
        }

        /// <summary>
        /// Replaces the contents of the file provided with the string resources present in the provided dictionary
        /// </summary>
        /// <param name="fileName">File name including full path</param>
        /// <param name="resourceDictionary">String dictionary that contains the resources</param>
        private static void writeStringResources(string fileName, Dictionary<string, string> resourceDictionary)
        {
            using (var fileWriter = getFileWriter(fileName))
            {
                Console.WriteLine(fileName);
                foreach (string key in resourceDictionary.Keys)
                {
                    fileWriter.WriteLine(key + "=" + resourceDictionary[key]);
                }
                fileWriter.Flush();
            }
        }

        /// <summary>
        /// Return a Writer to the provided file
        /// </summary>
        /// <param name="fileFullPath">File name including full path</param>
        /// <remarks>The file is checked out from TFS if needed.</remarks>
        /// <returns>A TextWriter ready for use</returns>
        private static TextWriter getFileWriter(string fileFullPath)
        {
            System.IO.TextWriter w = null;
            try
            {
                w = new System.IO.StreamWriter(fileFullPath, false, Encoding.Unicode);
            }
            catch (UnauthorizedAccessException)
            {
                // This exception is thrown when the item is read-only. This normally means that the item is not checked-out so let's do it.
                Console.WriteLine("\tChecking out '{0}'", fileFullPath);
                checkOutFile(fileFullPath);

                // Re-try
                w = new System.IO.StreamWriter(fileFullPath, false, Encoding.Unicode);
            }
            return w;
        }

        /// <summary>
        /// Checks out the file in parameter from TFS Version Control
        /// </summary>
        /// <param name="fileFullPath">File name including full path</param>
        private static void checkOutFile(string fileFullPath)
        {
            // See http://stackoverflow.com/questions/5097946/check-out-for-edit-an-item-in-tfs-programmatically

            // To optimize we make the reasonable assumption that all files are in the same workspace and collection !
            if (fileFullPath == null) { Console.WriteLine("fileFullPath is null"); }
            if (Workstation.Current == null) { Console.WriteLine("Workstation.Current is null"); }
            Console.WriteLine("1");
            if (_currentWorkspaceInfo == null)
            {
                Console.WriteLine("1.1");
                _currentWorkspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(fileFullPath);
            }

            Console.WriteLine("2");
            if (_tfsCollection == null)
            {
                Console.WriteLine("2.1");
                if (_currentWorkspaceInfo == null) { Console.WriteLine("_currentWorkspaceInfo is null"); }
                _tfsCollection = new TfsTeamProjectCollection(_currentWorkspaceInfo.ServerUri);
            }

            Console.WriteLine("3");
            if (_currentWorkspace == null)
            {
                Console.WriteLine("3.1");
                _currentWorkspace = _currentWorkspaceInfo.GetWorkspace(_tfsCollection);
            }

            Console.WriteLine("4");
            _currentWorkspace.PendEdit(fileFullPath);
        }

        // "Cache" of TFS Objects
        private static Workspace _currentWorkspace;
        private static WorkspaceInfo _currentWorkspaceInfo;
        private static TfsTeamProjectCollection _tfsCollection;

        private static void GenerateDBFields()
        {
            var DBFields = ComboBoxObject.LoadFromQuery("select (T.TABLE_NAME+'.'+C.COLUMN_NAME) as Text,C.COLUMN_NAME as Value from INFORMATION_SCHEMA.TABLES T inner join INFORMATION_SCHEMA.COLUMNS C on T.TABLE_NAME=C.TABLE_NAME;");
            foreach (ComboBoxObject field in DBFields)
            {
                string translated = string.Empty;
                if (!dic["Default"].ContainsKey(field.Text.ToUpperInvariant()))
                {
                    dic["Default"].Add(field.Text.ToUpperInvariant(), field.Value.ToString().ToUpperInvariant());
                    Console.WriteLine("...adding " + field.Text.ToUpperInvariant() + " with value:" + field.Value.ToString().ToUpperInvariant());
                }
                foreach (SynapseLanguage lang in Languages)
                {

                    if (!dic[lang.CULTURE].ContainsKey(field.Text.ToUpperInvariant()))
                    {
                        dic[lang.CULTURE].Add(field.Text.ToUpperInvariant(), field.Value.ToString().ToUpperInvariant());
                        Console.WriteLine("...adding " + field.Text.ToUpperInvariant() + " with value:" + field.Value.ToString().ToUpperInvariant());
                    }
                }
            }
        }
    }
}