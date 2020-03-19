using Module_ADR.Models;
using SynapseCore.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_ADR.Forms
{
    public partial class FrmImportSap : SynapseForm
    {
        public FrmImportSap(IEnumerable<ADR_SAPOrders> OrdersAdd, IEnumerable<ADR_SAPOrders> OrdersEx)
        {
            InitializeComponent();

            oblvAdd.PrimarySortColumn = OrderRisk;
            oblvExclude.PrimarySortColumn = OrderExRisk;
            oblvAdd.Sorting = SortOrder.Ascending;
            oblvExclude.Sorting = SortOrder.Ascending;

            oblvAdd.SetObjects(OrdersAdd);
            oblvExclude.SetObjects(OrdersEx);
        }
    }
}
