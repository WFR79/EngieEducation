using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SynapseCore.Graph
{
    public enum TraceType { Curve, Line, Bar, Square }
    //public enum XAXisFormat {X,Date,Label }
    public class SynapseGraphTrace
    {
        private TraceType _type;

        public TraceType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private XAxisType _xType;

        public XAxisType XType
        {
            get { return _xType; }
            set { _xType = value; }
        }


        private IList<SynapseGraphPoint> _PointList;

        public IList<SynapseGraphPoint> PointList
        {
            get { return _PointList; }
            set { _PointList = value; }
        }
        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private Color _color;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private ZedGraph.SymbolType _symbol;

        public ZedGraph.SymbolType Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        private object _tag;

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public SynapseGraphTrace(string label, TraceType type, IList<SynapseGraphPoint> list, Color color, ZedGraph.SymbolType symbol, object Tag, XAxisType xType = XAxisType.Values)
        {
            _type=type;
            _xType = xType;
            _PointList=list;
            _label = label;
            _color = color;
            _symbol = symbol;
            _tag = Tag;
        }
    }
}
