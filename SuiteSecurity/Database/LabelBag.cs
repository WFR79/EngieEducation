using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SynapseCore.Entities;

namespace SynapseCore.Database
{
    public class LabelBag
    {
        private IList<SynapseLabel> _labels;

        public IList<SynapseLabel> Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }
        private string _defaultLabel = "";


        public SynapseLabel GetLabel(string languageCode)
        {
            return (SynapseLabel)(from x in _labels where x.LANGUAGE == languageCode select x).FirstOrDefault();
        }

        public Int64 GetLabelID()
        {
            if (_labels.Count > 0)
            {
                return _labels[0].LABELID;
            }
            else
                return 0;
        }
        public void load(Int64 ID,string DefaultText)
        {
            _labels = SynapseLabel.Load("Where LABELID = " + ID + " ORDER BY LANGUAGE");
            _defaultLabel = DefaultText;
        }
        public override string ToString()
        {
            string Text = (from label in _labels where label.LANGUAGE == Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToUpper() select label.TEXT).SingleOrDefault();
            if (Text == null | Text == "" | Text == string.Empty)
                Text = _defaultLabel;
            if (Text == null | Text == "" | Text == string.Empty)
                Text = "No Label Defined";
            return Text;
        }
    }
}
