using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Entities
{
    public class ComboBoxObject:SynapseEntity<ComboBoxObject>
    {

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }


    }
}
