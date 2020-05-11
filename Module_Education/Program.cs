using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education
{
    static class Program
    {
        /// <summary>

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            Application.Run(new MainWindow());
        }

        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandled Exception");
        }

    }
}   
