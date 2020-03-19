using SynapseCore.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Module_ADR.Forms
{
    public partial class FrmWait : SynapseForm
    {
        public FrmWait()
        {
            InitializeComponent();
        }

        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        private static string Message;

        //The type of form to be displayed as the splash screen.
        private static FrmWait Waiting;

        static public void ShowWatingForms(string Texte)
        {
            // Make sure it is only launched once.
            if (Waiting != null)
                return;

            Message = Texte;
            Thread thread = new Thread(new ThreadStart(ShowForm));
            thread.IsBackground = false;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            Waiting = new FrmWait();
            Waiting.lblWait.Text = Message;
            Application.Run(Waiting);
        }

        static public void CloseForm()
        {
            Waiting.Invoke(new CloseDelegate(CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            Waiting.Close();
            Waiting = null;
        }
    }
}
