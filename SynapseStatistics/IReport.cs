using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseStatistics
{
    public interface IReport
    {
        void Generate(ref ZedGraph.ZedGraphControl graph);
    }
}
