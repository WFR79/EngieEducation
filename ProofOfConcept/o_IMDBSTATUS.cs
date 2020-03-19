using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace ProofOfConcept
{
    [DBConnectionAttribute("WSS")]
    public class o_IMDBSTATUS : SynapseEntity<o_IMDBSTATUS>
    {
            private static string _query = "SELECT * FROM IMDBSTATUS";
            private static string _tableName = "IMDBSTATUS";
            private static string _IDproperty = "STATUSID";
            private static string _EcludeForSave = "||";
            private Decimal _STATUSID;

            public Decimal STATUSID
            {
                get { return _STATUSID; }
                set { _STATUSID = value; }
            }

            private string _STATUSNAME;

            public string STATUSNAME
            {
                get { return _STATUSNAME; }
                set { _STATUSNAME = value; }
            }
            private Decimal _TYPEID;

            public Decimal TYPEID
            {
                get { return _TYPEID; }
                set { _TYPEID = value; }
            }
        }

}
