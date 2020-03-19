using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Module_ADR.Helper
{
    public static class ADRHelper
    {
        /// <summary>
        /// Vérifie quel type de recherche on doit éfeectuer
        /// 1 SAPOrders
        /// 2 Analyses
        /// </summary>
        /// <param name="SelectedIndex">Valeur de la recherche</param>
        /// <returns></returns>
        public static ModeEnum CheckSelectedSearch(int SelectedIndex)
        {
            if (SelectedIndex == 0)
                return ModeEnum.Save;
            else if (SelectedIndex == 1)
                return ModeEnum.Modify;
            else if (SelectedIndex == 2)
                return ModeEnum.Read;
            else
                return ModeEnum.Model;
        }

        /// <summary>
        /// Get application role for 
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationRole()
        {
            return ConfigurationManager.AppSettings.Get("ApplicationRole");
        }

        public static int CheckRisk(string RiskName)
        {
            using (CriticalityHelperParametersRepository CriticalityHelperParametersRepository = new CriticalityHelperParametersRepository())
            {
                return CriticalityHelperParametersRepository.Get(RiskName);
            }
        }

        /// <summary>
        /// Transforme les informations du webservice en model SAPOrders
        /// </summary>
        /// <param name="OrderData">Model à transformer</param>
        /// <returns>ADR_SAPOrders</returns>
        public static ADR_SAPOrders WebServiceToADR(this PMADRService.OrderDataO OrderData)
        {
            ADR_SAPOrders SAPOrder = new ADR_SAPOrders();

            SAPOrder.Criticality = int.Parse(OrderData.RiskLevel);

            int j = 0;

            while ((OrderData.OrderNumber.Substring(j, 1) == "0"))
            {
                j++;
            }

            if (j > 0)
                SAPOrder.OrderNbs = OrderData.OrderNumber.Substring(j, OrderData.OrderNumber.Length - j);
            else
                SAPOrder.OrderNbs = OrderData.OrderNumber;

            if (!string.IsNullOrEmpty(OrderData.MaintenanceItem))
            {
                int i = 0;

                while ((OrderData.MaintenanceItem.Substring(i, 1) == "0"))
                {
                    i++;
                }

                if (i > 0)
                    SAPOrder.MaintencaneItem = OrderData.MaintenanceItem.Substring(i, OrderData.MaintenanceItem.Length - i);
                else
                    SAPOrder.MaintencaneItem = OrderData.MaintenanceItem;
            }
            else
                SAPOrder.MaintencaneItem = null;

            SAPOrder.OrderShortDesc = OrderData.OrderDescription;
            SAPOrder.FuncLocation = OrderData.FunctionalLocation;
            SAPOrder.WorkCenter = OrderData.WorkCenter;
            SAPOrder.MaintenancePlant = OrderData.MaintenancePlan;
            SAPOrder.Revision = OrderData.Revision;
            SAPOrder.StartDate = OrderData.BasicStartDate;
            SAPOrder.FinishDate = OrderData.BasicFinishDate;
            SAPOrder.ExecutionDate = OrderData.UltimateExecutionDate;
            SAPOrder.RevisionPhase = OrderData.RevisionPhase;
            SAPOrder.Preparator = OrderData.ZPPartnerName;
            SAPOrder.Workspace = OrderData.WorkCenter;
            SAPOrder.IsManual = false;

            return SAPOrder;
        }

        /// <summary>
        /// Change la couleur du button si il est désavtivé
        /// </summary>
        /// <param name="Button"></param>
        public static void ChangeColorDiabled(Button Button)
        {
            if (!Button.Enabled)
            {
                Button.BackColor = Color.FromArgb(79, 113, 128);
                Button.ForeColor = Color.LightSlateGray;
            }
            else
            {
                Button.BackColor = Color.FromArgb(0, 159, 227);
                Button.ForeColor = SystemColors.ButtonHighlight;
            }
        }
    }
}
