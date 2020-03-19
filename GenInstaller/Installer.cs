using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace GenInstaller
{
    public enum InstallOptions
    {
        Normal,
        DeleteBefore,
        Force
    }
    public static class Installer
    {
        static StatusDialog dialog = new StatusDialog();
        public static string Install(string title, string source,string target,InstallOptions options)
        {
            try
            {
                dialog.Clear();
                dialog.Title = title;

                bool InstallNeeded = false;
                DirectoryInfo DI_Source = new DirectoryInfo(source);
                DirectoryInfo DI_Target = new DirectoryInfo(target);
                int sourceCount = DI_Source.GetFiles("*.*", SearchOption.AllDirectories).Count();
                dialog.FilesCount = sourceCount;
                FileInfo[] SourceVersions = DI_Source.GetFiles("*.gvf", SearchOption.TopDirectoryOnly);
                FileInfo[] TargetVersions = new List<FileInfo>().ToArray();
                try
                {
                    TargetVersions = DI_Target.GetFiles("*.gvf", SearchOption.TopDirectoryOnly);
                }
                catch (Exception)
                {
                    InstallNeeded = true;
                }

                foreach (FileInfo sfi in SourceVersions)
                {
                    if ((from tv in TargetVersions where tv.Name == sfi.Name select tv).Count() > 0)
                        foreach (FileInfo tfi in (from tv in TargetVersions where tv.Name == sfi.Name select tv))
                        {
                            if (sfi.LastWriteTime != tfi.LastWriteTime)
                            {
                                InstallNeeded = true;
                                break;
                            }
                        }
                    else
                        InstallNeeded = true;
                }

                if (options == InstallOptions.Force)
                {
                    InstallNeeded = true;
                    try
                    {
                        DeleteFiles(new DirectoryInfo(target));
                    }
                    catch (Exception ex)
                    {
                        dialog.WriteText(ex.Message);
                    }
                }

                if (InstallNeeded)
                {
                    if (dialog == null)
                        dialog = new StatusDialog();
                    dialog.Show();

                    if (options == InstallOptions.DeleteBefore)
                    {
                        dialog.WriteText("Deleting " + title + " files...");
                        DeleteFiles(DI_Target);
                    }

                    dialog.WriteText("Installing " + title + " files...");
                    DoInstall(DI_Source, DI_Target, options);
                }
                else
                {
                    dialog.WriteText("Version up to date");
                }
                dialog.Complete();
                dialog.WriteText("Done.");
                dialog.Hide();

                return "ok";
            }
            catch (Exception ex)
            {
                dialog.WriteText(ex.Message);
                System.Threading.Thread.Sleep(2000);
                dialog.Hide();
                throw ex;
            }
        }
        public static void DoInstall(DirectoryInfo source,DirectoryInfo target,InstallOptions options)
        {
            CopyFiles(source.GetFiles().ToList(), target);
            foreach (DirectoryInfo di in source.GetDirectories())
            {
                DoInstall(di, new DirectoryInfo(target.FullName + "\\" + di.Name), options);
            }
        }
        static void CopyFiles(List<FileInfo> files, DirectoryInfo target)
        {
            if (!target.Exists)
                Directory.CreateDirectory(target.FullName);
            foreach (FileInfo fi in files)
            {
                try
                {
                    File.Copy(fi.FullName, target.FullName + "\\" + fi.Name, true);
                }
                catch (Exception ex)
                { }
                dialog.Progress();
            }
        }

        static void DeleteFiles(DirectoryInfo dir)
        {
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                subdir.Delete(true);
            }
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
        }
        public static void ChangeTextInFiles(string searchString, string newString, FileInfo[] listOfFiles)
        {
            foreach (FileInfo tempfi in listOfFiles)
            {
                string fileToBeEdited = tempfi.FullName; // <== This line was missing
                File.SetAttributes(tempfi.FullName, File.GetAttributes(fileToBeEdited) &
                                                    ~FileAttributes.ReadOnly);
                string strFile = System.IO.File.ReadAllText(fileToBeEdited);
                if (strFile.Contains(searchString))
                { // <== replaced newString by searchString
                    strFile = strFile.Replace(searchString, newString);
                    System.IO.File.WriteAllText(fileToBeEdited, strFile);

                }
            }
        }
    }
}
