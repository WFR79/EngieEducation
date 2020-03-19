using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace Module_Gaziview.Entities
{
    public class o_Constant : SynapseEntity<o_Constant>
    {
        

        private static string _query = "SELECT * FROM [Gaziview_Constant]";
        private static string _tableName = "[Gaziview_Constant]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";


        public Int64 ID { get; set; }
        public Int64 ChainID { get; set; }
        public double BackgroundNoise { get; set; }
        public double DetectionLimit { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime EncodedDate { get; set; }
        public string EncodedBy { get; set; }
        public DateTime ValidationDate { get; set; }
        public string ValidationBy { get; set; }

        public override void save()
        {
            base.save();
            Helper.LoadConstants();
        }


    }
}
