using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseReport.Entities
{
    class FieldFunction
    {
        private string _CODE;
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        private string _LABEL;
        public string LABEL
        {
            get { return _LABEL; }
            set { _LABEL = value; }
        }
    }
}
