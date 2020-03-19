using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace Module_Gaziview.Entities
{
    class o_Chain : SynapseEntity<o_Chain>
    {

        private static string _query = "SELECT * FROM [Gaziview_Chain]";
        private static string _tableName = "[Gaziview_Chain]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";


        public Int64 ID { get; set; }
        public Int64 UnitID { get; set; }
        public string Name { get; set; }
        public Int64 SisterID { get; set; }
        

    }
}
