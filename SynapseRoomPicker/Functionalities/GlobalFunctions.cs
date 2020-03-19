using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;

namespace SynapseRoomPicker.Functionalities
{
    class GlobalFunctions
    {
        private static List<String> _errorList = new List<String>();

        public static void resetError()
        {
            _errorList.Clear();
        }

        public static void addError(String code, String param = "")
        {
            String _msg;

            _msg = SynapseForm.GetLabel(code);

            if (_msg == null)
            { _msg = code; }

            if (param != "")
            {
                _msg = _msg.Replace("#1", param);
            }

            _errorList.Add(_msg);
        }

        public static void showError(String CODE = "", String PARAM1 = "", String PARAM2 = "")
        {
            String _message = "";

            if (CODE != "")
            {
                _message = SynapseForm.GetLabel(CODE);
                if (PARAM1 != "")
                {
                    _message = _message.Replace("#1", PARAM1);
                }
                if (PARAM2 != "")
                {
                    _message = _message.Replace("#2", PARAM2);
                }
            }
            else
            {
                foreach (string line in _errorList)
                {
                    _message = _message + line.Replace("$tab$", "        ") + "\n";
                }
            }

            MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static System.Windows.Forms.DialogResult showMessage(String TYPE, String CODE = "", String PARAM1 = "", String PARAM2 = "")
        {
            String _message = "";

            if (CODE != "")
            {
                _message = SynapseForm.GetLabel(CODE);
                if (PARAM1 != "")
                {
                    _message = _message.Replace("#1", PARAM1);
                }
                if (PARAM2 != "")
                {
                    _message = _message.Replace("#2", PARAM2);
                }
            }

            switch (TYPE)
            {
                case "WARN":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                case "ERR":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                case "INFO":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                case "QUEST":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                case "QUEST&CANCEL":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Warning"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                default:
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
