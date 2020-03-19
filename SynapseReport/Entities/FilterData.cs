using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    public class FilterData : SynapseEntity<FilterData>
    {
        private static string _query = "";
        private static string _tableName = "";
        private static string _IDproperty = "";
        private static string _EcludeForSave = "";

        private string _VALUE;
        public string VALUE
        {
            get { return _VALUE; }
            set { _VALUE = value; }
        }

        private string _DISPLAY;
        public string DISPLAY
        {
            get { return _DISPLAY; }
            set { _DISPLAY = value; }
        }
    }
}
