using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    class MyColumnCollectionDGGrpAgent
    {
          

            [DisplayName("Nom groupe")]
            public string Grp_Description { get; set; }

            [DisplayName("Code Groupe")]
            public string Grp_Code { get; set; }



            private Education_GroupLearner _obj;

            public MyColumnCollectionDGGrpAgent(Education_GroupLearner obj)
            {
                _obj = obj;
            }

            public Education_GroupLearner GetModel()
            {
                return _obj;
            }
        }
}
