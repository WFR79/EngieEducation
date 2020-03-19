using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SynapseDeploymentTool
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_DataMig());
        }
    }
}
