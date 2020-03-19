using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Database
{
    public class LabelId:Attribute
    {
        private string _IDField;
        private string _DefaultField;

        public string DefaultField
        {
            get { return _DefaultField; }
            set { _DefaultField = value; }
        }

        public string IDField
        {
            get { return _IDField; }
            set { _IDField = value; }
        }
        public LabelId(string LabelIdField)
        {
            _IDField = LabelIdField;
            _DefaultField = null;
        }
        public LabelId(string LabelIdField,string DefaultField)
        {
            _IDField = LabelIdField;
            _DefaultField = DefaultField;
        }
    }
}
