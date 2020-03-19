using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SynapseCore.Controls
{
    public partial class SynapseValidationControl : System.ComponentModel.Component
    {

        public SynapseValidationControl()
        {
            if (this._CurrentErrorProvider != null)
            {
                _CurrentErrorProvider.Add(this);
            }
        }

        private void InitializeComponent()
        {

        }
        
        private void SynapseValidationControl_Load(object sender, EventArgs e)
        {

        }
        public bool ValidateControl()
        {
            _CurrentErrorProvider.SetError(_ControlToValidate, ErrorMessage);
            return IsValid;
        }

        private SynapseErrorProvider _CurrentErrorProvider;
        [Category("Synapse Control"), Description("Error Provider")]
        public SynapseErrorProvider CurrentErrorProvider
        {
            get { return _CurrentErrorProvider; }
            set {
                _CurrentErrorProvider = value;
                if (this._CurrentErrorProvider != null)
                {
                    _CurrentErrorProvider.Add(this);
                }
            }
        }
        private Control _ControlToValidate;
        [Category("Synapse Control"), Description("Control to validate")]
        public Control ControlToValidate
        {
            get { return _ControlToValidate; }
            set { _ControlToValidate = value; }
        }
        private string _ErrorMessage;
        [Category("Synapse Control"), Description("Error Message")]
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        private bool _IsValid=false;
        [Category("Synapse Control"), Description("Error Message")]
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }

    }
}
