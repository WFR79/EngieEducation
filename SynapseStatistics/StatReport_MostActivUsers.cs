using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseStatistics
{
    class StatReport_MostActivUsers : StatReport_TotalUsage
    {
        public override void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            query = "SELECT [USERID] as Label,cast(sum(cast(dbo.Synapse_Statistics.ACTIVITY_TIME as decimal)/cast(3600 as decimal)) as decimal(18,2)) as Value FROM [SYNAPSE].[dbo].[Synapse_Statistics] group by [USERID]";
            title = "Top 10 form usage";
            xtitle = "Forms";
            ytitle = "Time (hours)";
            angle = 90;
            fontsize = 6;
            base.Generate(ref graph);
        }
    }
}
