using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseStatistics
{
    class StatReport_LastMonthUsage:StatReport_TotalUsage
    {
        public override void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            query = "SELECT cast(sum(cast(dbo.Synapse_Statistics.ACTIVITY_TIME as decimal)/cast(3600 as decimal)) as decimal(18,2)) as Value,  dbo.Synapse_Module.TECHNICALNAME As Label FROM         dbo.Synapse_Statistics INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Statistics.FK_MODULE_ID = dbo.Synapse_Module.ID where MONTH(dbo.Synapse_Statistics.CLOSE_TIME) = MONTH(GetDate()) group by dbo.Synapse_Module.TECHNICALNAME";
            title = "Last month usage";
            xtitle = "Modules";
            ytitle = "Time (hours)";
            base.Generate(ref graph);
        }
    }
}
