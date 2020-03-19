using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Synapse
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (arg.ToUpper().StartsWith(("/con:").ToUpper()))
                {
                    string value=arg.Replace("/con:", "");
                    SynapseCore.Database.DBFunction.ConnectionName = value;
                    SynapseCore.Database.DBFunction.FormBackColor = System.Drawing.Color.Tomato;
                    SynapseCore.Controls.SynapseForm.DevACK = true;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Startup());
        }
    }
}
