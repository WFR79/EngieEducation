using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseReport.GraphTemplates
{
    public interface IGraph
    {
        void Generate(ref ZedGraph.ZedGraphControl graph, String _query, SynapseReport.Entities.Definition _report, List<SynapseReport.Entities.Field> _fields);
    }
}
