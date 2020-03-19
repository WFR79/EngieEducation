using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_Gaziview.Entities
{
    public class o_EmissionReport:o_GasEmission
    {
        static IList<o_Chain> Chains;// = o_Chain.Load();
        public static void LoadChains()
        {
        Chains=o_Chain.Load();
        }
        
        public string ChainName { get { return Chains.Single(c => c.ID == this.ChainID).Name; } }
        public int WeekNr { get { return Helper.GetWeekNr(this.Date); } }

    }
}
