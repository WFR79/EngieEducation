using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseStatistics
{
    class StatReport_Top20FormUsageThisWeek : StatReport_TotalUsage
    {
        public override void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            query = "SELECT top 20 CAST(count(*) as decimal(18,2)) as Value,  dbo.Synapse_Module.TECHNICALNAME+'.'+dbo.Synapse_Statistics.FORMNAME As Label FROM         dbo.Synapse_Statistics INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Statistics.FK_MODULE_ID = dbo.Synapse_Module.ID where DATEPART(WK,dbo.Synapse_Statistics.CLOSE_TIME) = datepart(WK,GetDate()) AND dbo.Synapse_Statistics.ACTIVITY_TIME>20 group by dbo.Synapse_Module.TECHNICALNAME+'.'+dbo.Synapse_Statistics.FORMNAME order by Value desc";
            title = "Top 20 form usage this week with a minimum 20s visit";
            xtitle = "Forms";
            ytitle = "Visits";
            angle = 90;
            fontsize = 6;
            base.Generate(ref graph);
        }
    }
}
