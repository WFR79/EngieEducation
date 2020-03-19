using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace SynapseCore.Controls
{
    public partial class uc_Field : UserControl
    {
        private string _FieldName;
        private bool _enabled;
        private FieldType _type;
        private string _query;
        private string _DisplayName;

        public string DisplayName
        {
            set { _DisplayName = value;
            label1.Text = _DisplayName;
          
            }
        }


        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value;
            textBox1.Enabled = _enabled;
            }
        }

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value;
            //label1.Text = _FieldName;
            }
        }
        private object _FieldValue;

        public object FieldValue
        {
            get
            {
                switch (_type)
                { 
                    case FieldType.text:
                    case FieldType.number:
                        _FieldValue = textBox1.Text;
                        break;
                    case FieldType.dropdown:
                        _FieldValue = comboBox1.SelectedValue.ToString();
                        break;
                    case FieldType.checkbox:
                        _FieldValue = checkBox1.Checked;
                        break;
                    default:
                        _FieldValue = textBox1.Text;
                        break;
                }
                return _FieldValue;
            }
            set { _FieldValue = value;
                textBox1.Text = _FieldValue.ToString();
                comboBox1.SelectedValue = _FieldValue;
                bool val;
                bool.TryParse(_FieldValue.ToString(),out val);
                checkBox1.Checked = val;
            }
        }
        public uc_Field()
        {
            _type = FieldType.text;
            InitializeComponent();
            SetupControl();
        }
        public uc_Field(EntityFieldType type)
        {
            _type = type.Type;
            _query = type.Query;
            InitializeComponent();
            SetupControl();
        }

        void SetupControl()
        {
            switch (_type)
            { 
                case FieldType.text:
                    textBox1.Visible = true;
                    break;
                case FieldType.number:
                    textBox1.Visible = true;
                    break;
                case FieldType.dropdown:
                    comboBox1.Visible = true;
                    IList<ComboBoxObject> items;
                    items = ComboBoxObject.LoadFromQuery(_query);
                    comboBox1.DisplayMember = "Text";
                    comboBox1.ValueMember = "Value";
                    comboBox1.DataSource = items;
                    break;
                case FieldType.checkbox:
                    checkBox1.Visible = true;
                    break;
                default:
                    textBox1.Visible = true;
                    break;
            }
        }

        private void uc_Field_Load(object sender, EventArgs e)
        {

        }
    }
}
