using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
namespace SynapseStatistics
{
    class E_Label_Value:SynapseEntity<E_Label_Value>
    {
        private string _Label;

        public string Label
        {
            get { return _Label; }
            set { _Label = value; }
        }
        private decimal _Value;

        public decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
