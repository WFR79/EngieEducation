using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SynapseReport.Forms;
using SynapseReport.Functionalities;
using SynapseCore.Entities;

namespace SynapseReport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                startMain();
                return;
            }

            if (args[0] == "/dev")
            {
                if (args.Length == 1)
                {
                    startMain();
                    return;
                }
                
                if (args.Length > 2)
                    GlobalVariables.setXtraVariables(args[2]);

                startForModule(args[1]);
            }
            else
            {
                if (args.Length > 1)
                    GlobalVariables.setXtraVariables(args[1]);

                startForModule(args[0]);
            }
        }

        private static void startMain()
        {
            Application.Run(new frmMain());
        }

        private static void startForModule(string ModuleAndInterface)
        {
            Int64 ModuleID = 0;
            Int64 InterfaceID = 0;

            string[] param = ModuleAndInterface.Split(',');
            if (param.Length > 1)
            {
                ModuleID = long.Parse(param[0]);
                InterfaceID = long.Parse(param[1]);
            }
            else
                ModuleID = long.Parse(param[0]);

            ReportOrigin.setTo(SynapseModule.LoadByID(ModuleID));
            frmReport fReport = new frmReport(true);
            fReport.InterfaceID = InterfaceID;
            fReport.ShowMenu = true;
            Application.Run(fReport);
        }
    }
}
