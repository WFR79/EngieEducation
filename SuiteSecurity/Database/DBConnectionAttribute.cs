using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Database
{
    public class DBConnectionAttribute:Attribute
    {
        private string _ConnectionName;

        public string ConnectionName
        {
            get { return _ConnectionName; }
            set { _ConnectionName = value; }
        }


        public DBConnectionAttribute(String ConnectionName)
        {
            _ConnectionName = ConnectionName;

        }
    }
}
