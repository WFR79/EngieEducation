using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Database
{
    public enum FieldType { 
        text = 1,
        number = 2,
        dropdown = 3,
        checkbox = 4
        
    }
    public class EntityFieldType:Attribute
    {
        private FieldType _type;

        internal FieldType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _query;

        public string Query
        {
            get { return _query; }
            set { _query = value; }
        }

        public EntityFieldType(FieldType type, string query)
        {
            _type = type;
            _query = query;
        }
    }
}
