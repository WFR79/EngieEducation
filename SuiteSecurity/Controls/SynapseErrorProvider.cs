using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SynapseCore.Controls
{
    public partial class SynapseErrorProvider:ErrorProvider
    {
        public SynapseErrorProvider()
        {
            this.Icon = Properties.Resources.error;
        }
        private bool _ShowMessageBox = true;

        public bool ShowMessageBox
        {
            get { return _ShowMessageBox; }
            set { _ShowMessageBox = value; }
        }
        public List<Object> ValidationControls = new List<Object>();
        public List<Object> ControlsInError = new List<Object>();
        public List<string> ErrorMessageList = new List<string>();
        public void Add(Object ctrl)
        {
            ValidationControls.Add(ctrl);
        }
        public bool ValidateControls()
        {
            this.Clear();
            ErrorMessageList.Clear();
            ControlsInError.Clear();
            bool result = true;
            foreach (Object c in ValidationControls)
            {
                if (c is SynapseTextBox)
                {
                    bool ControlResult = ((SynapseTextBox)c).ValidateControl();
                    if (!ControlResult)
                    {
                        ControlsInError.Add(c);
                        ErrorMessageList.AddRange(((SynapseTextBox)c).MessageList);
                    }
                    result = result & ControlResult;
                }
                if (c is SynapseValidationControl)
                {
                    ((SynapseValidationControl)c).ValidateControl();
                    if (!((SynapseValidationControl)c).IsValid)
                    {
                        ControlsInError.Add(c);
                        ErrorMessageList.Add(((SynapseValidationControl)c).ErrorMessage);
                    }
                    result = result & ((SynapseValidationControl)c).IsValid;
                }
            }
            if (_ShowMessageBox && !result)
            { 
                MessageBox.Show(string.Join("\r\n",ErrorMessageList.ToArray()),"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            return result;
        }
        public void MySetError(Control control, string error)
        {
            this.SetError(control, error);
            for (int i = 0; i < 6; i++)
            { 
                control.Left+=5;
                control.Top += 5;
                System.Threading.Thread.Sleep(20);
                control.Left -= 5;
                control.Top -= 5;
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
