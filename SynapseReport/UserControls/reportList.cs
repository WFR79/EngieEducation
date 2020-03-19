using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseReport.Entities;
using SynapseCore.Controls;
using SynapseReport.Functionalities;

namespace SynapseReport.UserControls
{
    public partial class reportList : UserControl
    {
        public reportList()
        {
            InitializeComponent();
        }

        public reportList(IList<FilterData> _data)
        {
            InitializeComponent();

            listBox.Items.Clear();
            foreach (FilterData fdata in _data)
            {
                listBox.Items.Add(fdata);
            }

            listBox.DisplayMember = "DISPLAY";
            listBox.ValueMember = "VALUE";
            listBox.SelectedIndex = -1;
        }

        public void refreshList(string _query = "")
        {
            listBox.Items.Clear();
            Filter _flt=Filter.LoadByID((Int64)this.Tag);
            string _filterQuery = GlobalFunctions.ReplaceXtraVariables(_flt.DATA_QUERY);
            if (_filterQuery.Contains("ORDER BY"))
            {
                _filterQuery=_filterQuery.Replace("ORDER BY", _query + " ORDER BY");
            }
            else
            {
                _filterQuery = _filterQuery + " " + _query;
            }
            IList<FilterData> _data = FilterData.LoadFromQuery(_filterQuery, GlobalVariables.selectedOrigin.DBCONNECTION);
            foreach (FilterData fdata in _data)
            {
                listBox.Items.Add(fdata);
            }
            listBox.SelectedIndex = -1;
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.ParentForm.AcceptButton.PerformClick();
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Apply_Filter(null, null);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Reset_Filter(null, null);
                //this.ParentForm.CancelButton.PerformClick();
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                listBox.SelectedItems.Clear();
                listBox.SelectedIndex = -1;
                return;
            }
        }
    }
}
