using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseStatistics
{
    class StatReport_Top20AvgByForm : StatReport_TotalUsage
    {
        public override void Generate(ref ZedGraph.ZedGraphControl graph)
        {
            query = "SELECT top 20 cast(avg(cast(dbo.Synapse_Statistics.ACTIVITY_TIME as decimal)/cast(60 as decimal)) as decimal(18,2)) as Value,  dbo.Synapse_Module.TECHNICALNAME+'.'+dbo.Synapse_Statistics.FORMNAME As Label FROM         dbo.Synapse_Statistics INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Statistics.FK_MODULE_ID = dbo.Synapse_Module.ID where MONTH(dbo.Synapse_Statistics.CLOSE_TIME) = MONTH(GetDate()) group by dbo.Synapse_Module.TECHNICALNAME+'.'+dbo.Synapse_Statistics.FORMNAME order by Value desc";
            title = "Top 10 form usage";
            xtitle = "Forms";
            ytitle = "Time (hours)";
            angle = 90;
            fontsize = 6;
            base.Generate(ref graph);
        }
    }
}
