using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SynapseCore.Controls
{
    public enum SynapseTextBoxValidation
    { 
          Text = 0,
          Number = 1,
          Decimal = 2,
          Regex = 100
    };
    [ToolboxBitmap(typeof(SynapseTextBox),"Properties.Resources.Close")]
    public partial class SynapseTextBox:TextBox
    {
        public List<String> MessageList = new List<string>();
        protected override void OnCreateControl()
        {
            if (this._CurrentErrorProvider != null)
            {
                _CurrentErrorProvider.Add(this);
            }
            base.OnCreateControl();
        }

        string[] RegexValidations = new string[] { @"\w+", @"\d+","^[-+]?[0-9]+[,]?[0-9]{0,[XX]}$" };
        public SynapseTextBox()
        {

        }

    #region "properties"

            private bool _Mandatory;
            [Category("Synapse Control"), Description("Mandatory field")]
            public bool Mandatory
            {
                get { return _Mandatory; }
                set { _Mandatory = value; }
            }

            private bool _validate;
            [Category("Synapse Control"), Description("Is Validated")]
            public bool Validate
            {
                get { return _validate; }
                set { _validate = value; }
            }

            private string _RegularExpression;

            [Category("Synapse Control"), Description("Validation Regex")]
            public string RegularExpression
            {
                get { return _RegularExpression; }
                set { _RegularExpression = value; }
            }
            private SynapseTextBoxValidation _Validation;

            [Category("Synapse Control"), Description("Validation Type")]
            public SynapseTextBoxValidation Validation
            {
                get { return _Validation; }
                set { _Validation = value; }
            }

            private Int32 _MaxLength;
            [Category("Synapse Control"), Description("Maximum Length")]
            public Int32 MaxLength
            {
                get { return _MaxLength; }
                set { _MaxLength = value; }
            }
            private Int32 _MinLength;
            [Category("Synapse Control"), Description("Minumum Length")]
            public Int32 MinLength
            {
                get { return _MinLength; }
                set { _MinLength = value; }
            }
            private Int32 _NumberOfDecimal = 2;
            [Category("Synapse Control"), Description("Number Of Decimal")]
            public Int32 NumberOfDecimal
            {
                get { return _NumberOfDecimal; }
                set { _NumberOfDecimal = value; }
            }
            private SynapseErrorProvider _CurrentErrorProvider;
            [Category("Synapse Control"), Description("Error Provider")]
            public SynapseErrorProvider CurrentErrorProvider
            {
                get { return _CurrentErrorProvider; }
                set { _CurrentErrorProvider = value; }
            }

            private string _TooLongErrorMessage = "Too long";

            [Category("Synapse Control"), Description("Message for too long data")]
            public string TooLongErrorMessage
            {
                get { return _TooLongErrorMessage; }
                set { _TooLongErrorMessage = value; }
            }
            private string _MandatoryErrorMessage = "Mandatory field";

            [Category("Synapse Control"), Description("Message for mandatory field")]
            public string MandatoryErrorMessage
            {
                get { return _MandatoryErrorMessage; }
                set { _MandatoryErrorMessage = value; }
            }
            private string _NotMatchErrorMessage = "Not Valid";

            [Category("Synapse Control"), Description("Message for validation error")]
            public string NotMatchErrorMessage
            {
                get { return _NotMatchErrorMessage; }
                set { _NotMatchErrorMessage = value; }
            }

    #endregion

    #region Events
            protected override void OnKeyUp(KeyEventArgs e)
            {
                if (this.Validate) 
                {
                    while (this.Text.Length >= 1 && !this.ValidateControl())
                    {
                        this.Text = this.Text.Remove(this.Text.Length - 1);
                        this.SelectionStart = this.Text.Length;
                    }
                    if (this.ValidateControl())
                        CurrentErrorProvider.SetError(this, "");
                
                }

                base.OnKeyUp(e);
            }
    #endregion

    #region functions
            public bool ValidateControl()
            {
                MessageList.Clear();
                string TextToValidate;
                Regex expression;
                try
                {
                    TextToValidate = this.Text;
                    switch (_Validation)
                    {
                        case SynapseTextBoxValidation.Text:
                        case SynapseTextBoxValidation.Number:
                            expression = new Regex(RegexValidations[(int)_Validation]);
                            //CDC525 14-03-2017 impossible to correct it via control properties => must accept ?
                            // expression = new Regex(@"[\w+]|_"); doesn't work((((((
                            break;
                        case SynapseTextBoxValidation.Decimal:
                            expression = new Regex(RegexValidations[(int)_Validation].Replace("[XX]", _NumberOfDecimal.ToString()), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
     
                            break;
                        default:
                            expression = new Regex(_RegularExpression);
                            break;
                    }    
                }
                catch
                {
                    return false;
                }
                bool empty = TextToValidate.Length == 0;
                bool match = expression.IsMatch(TextToValidate);
                //CDC525 14-03-2017 impossible to correct it via control properties => must accept ?
                if (TextToValidate.IndexOf("?") > -1) match = true;
                bool toolong = TextToValidate.Length > _MaxLength;
                bool ControlOnError = false;

                match=match & (TextToValidate.Length>=_MinLength);

                if (empty && _Mandatory)
                {
                    CurrentErrorProvider.SetError(this, _MandatoryErrorMessage);
                    MessageList.Add(_MandatoryErrorMessage);
                    ControlOnError =true;
                }
                if (toolong)
                {
                    CurrentErrorProvider.SetError(this, _TooLongErrorMessage);
                    MessageList.Add(_TooLongErrorMessage);
                    ControlOnError = true;
                }
                if (!empty && !match)
                {
                    CurrentErrorProvider.SetError(this, _NotMatchErrorMessage);
                    MessageList.Add(_NotMatchErrorMessage);
                    ControlOnError = true;
                }
                if (ControlOnError)
                    this.BackColor = Color.Tomato;
                else
                    this.BackColor = Color.White;

                return !ControlOnError;

            }
    #endregion
    }
}
