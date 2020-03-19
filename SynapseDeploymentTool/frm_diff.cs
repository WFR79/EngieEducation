using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseAdvancedControls;

namespace SynapseDeploymentTool
{
    public partial class frm_diff : Form
    {
        public frm_diff()
        {
            InitializeComponent();
            col_acc.AspectGetter = delegate(object x)
            {
                return x.ToString();
            };
            col_prd.AspectGetter = delegate(object x)
            {
                return x.ToString();
            };
        }
        public ObjectListView AccList
        {
            get { return objectListView1; }
            set { objectListView1 = value; }
        }
        public ObjectListView PrdList
        {
            get { return objectListView2; }
            set { objectListView1 = value; }
        }
    }
}
