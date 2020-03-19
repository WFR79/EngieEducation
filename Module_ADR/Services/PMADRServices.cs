using Module_ADR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Module_ADR.Helper;
using System.IO;
using Module_ADR.DataAccessLayer.Repos;
using System.Reflection;

namespace Module_ADR.Services
{
    public class PMADRServices
    {
        /// <summary>
        /// Va chercher les ordres en fonction du workcenter
        /// </summary>
        /// <param name="WorkCenter">Le workcenter de l'utilisateur</param>
        /// <param name="Criticality">Le niveau de criticité</param>
        public IEnumerable<ADR_SAPOrders> GetOrders(string WorkCenter, string Criticality)
        {
            PMADRService.PMADRSERVICEPortClient Client = CreateClient();

            PMADRService.GetOrderdetailsResponse OrdersDetails = Client.GetOrderdetails(new PMADRService.GetOrderdetails
            {
                OperationCallData = CreateOperation(),
                InputDataOrderdetails = new PMADRService.OrderDataI[]
                {
                    CreateOrderData(WorkCenter, Criticality)
                }
            });

            return ParseOrders(OrdersDetails);
        }

        /// <summary>
        /// Ajoute le fichier pdf de l'analyse à l'ordre concerné (SAP)
        /// </summary>
        /// <param name="OrderNbs"></param>
        /// <param name="UserId"></param>
        public void AddAttachementToOrder(string OrderNbs, string UserId, int RiskId, Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.PMADRSERVICEPortClient Client = CreateClient();

            PMADRService.GetOrderattachmentResponse OrderAttachement = Client.GetOrderattachment(new PMADRService.GetOrderattachment()
            {
                OperationCallData = CreateOperation(),
                InputDataAttachment = new PMADRService.CreateAttachment[]
                {
                    CreateAttachement(OrderNbs, UserId, RiskId, RisqueAndValue)
                }
            });
        }

        /// <summary>
        /// Ajoute le fihcier pdf de l'analyse dans le plan (SAP)
        /// </summary>
        /// <param name="OrderNbs">Numéro d'ordre</param>
        /// <param name="UserId">Id du user</param>
        /// <param name="Plan">Numéro du plan de maintance</param>
        public void AddAttachementToPlan(string UserId, string Plan, string RiskLevel, Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.PMADRSERVICEPortClient Client = CreateClient();

            PMADRService.GetMPItemattachmentResponse PlanAttachement = Client.GetMPItemattachment(new PMADRService.GetMPItemattachment()
            {
                OperationCallData = CreateOperation(),
                InputMPIAttachment = new PMADRService.CreateMPIAttachment[]
                {
                    CreatePMAttachement(UserId, Plan, RiskLevel, RisqueAndValue)
                }
            });
        }

        /// <summary>
        /// Créer le client pour communiquer avec le webservice
        /// Ajoute le certificat pour la communication
        /// </summary>
        /// <returns></returns>
        private PMADRService.PMADRSERVICEPortClient CreateClient()
        {
            PMADRService.PMADRSERVICEPortClient Client = new PMADRService.PMADRSERVICEPortClient();

            X509Certificate2 Certificate = CreateCertificate();
            Client.ClientCredentials.ClientCertificate.Certificate = Certificate;

            return Client;
        }

        /// <summary>
        /// Créer le certificat en fonction de l'environement et les informations stockées en db (ADR_Parameter).
        /// ATTENTION !!! Environment, définit dans l'appconfig.
        /// </summary>
        /// <returns>Certificat</returns>
        private X509Certificate2 CreateCertificate()
        {
            string Password;

            using (ParamterRepository ParamterRepository = new ParamterRepository())
            {
                Password = ParamterRepository.GetValue("WebServiceCertificate", ConfigurationManager.AppSettings["Environment"]);
            }

            byte[] Certificate = null;

            switch (ConfigurationManager.AppSettings["Environment"])
            {
                case "PRD":
                    Certificate = Properties.Resources.corp_hdm523;
                    break;
                case "ACC":
                    Certificate = Properties.Resources.corp_din506;
                    break;
                default:
                    Certificate = Properties.Resources.corp_eam565;
                    break;
            }

            return new X509Certificate2(Certificate, Password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
        }

        /// <summary>
        /// Créer l'operation
        /// </summary>
        /// <returns></returns>
        private PMADRService.OperationCallData CreateOperation()
        {
            PMADRService.OperationCallData OperationCallData = new PMADRService.OperationCallData();

            OperationCallData.MessageID = Guid.NewGuid().ToString();

            using (ParamterRepository ParamterRepository = new ParamterRepository())
            {
                OperationCallData.UserID = ParamterRepository.GetValue("WebServiceUser", ConfigurationManager.AppSettings["Environment"]);
            }

            OperationCallData.Language = "EN";
            OperationCallData.Channel = CreateChannel();

            return OperationCallData;
        }

        /// <summary>
        /// Créer le channel
        /// </summary>
        /// <returns></returns>
        private PMADRService.Channel CreateChannel()
        {
            PMADRService.Channel Channel = new PMADRService.Channel();
            Channel.Application = PMADRService.Application.ADR;
            Channel.Profile = PMADRService.Profile.EBL;

            return Channel;
        }

        /// <summary>
        /// Créer les informations à communiquer au webservice
        /// </summary>
        /// <param name="WorkCenter"></param>
        /// <param name="StartDateFrom"></param>
        /// <param name="StartDateTo"></param>
        /// <returns></returns>
        private PMADRService.OrderDataI CreateOrderData(string WorkCenter, string Criticality)
        {
            PMADRService.OrderDataI OrderDataI = new PMADRService.OrderDataI();

            OrderDataI.MainWorkCenter = $"{WorkCenter}";
            OrderDataI.RiskLevel = Criticality;

            return OrderDataI;
        }

        /// <summary>
        /// Créer l'attachement à envoyer au webservice (Ordre)
        /// </summary>
        /// <param name="OrderNbs"></param>
        /// <param name="UserdId"></param>
        /// <returns></returns>
        private PMADRService.CreateAttachment CreateAttachement(string OrderNbs, string UserdId, int RiskLevel, Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.Attachment Attachement = new PMADRService.Attachment();

            Attachement.FileName = $"ADR_{OrderNbs}.pdf";
            Attachement.Content = Convert.ToBase64String(File.ReadAllBytes($"{Path.GetTempPath()}\\ADR.pdf"));
            Attachement.Description = $"ADR risk {RiskLevel}";

            PMADRService.CreateAttachment CAttachement = CreateSmartForm(RisqueAndValue);
            CAttachement.OrderNumber = OrderNbs;
            CAttachement.UserID = UserdId;

            CAttachement.Attachment = new PMADRService.Attachment[] { Attachement };

            return CAttachement;
        }

        /// <summary>
        /// Créer l'attachement à envoyer au webservice (Plan)
        /// </summary>
        /// <param name="Plan"></param>
        /// <param name="UserdId"></param>
        /// <returns></returns>
        private PMADRService.CreateMPIAttachment CreatePMAttachement(string UserdId, string Plan, string RiskLevel, Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.Attachment Attachement = new PMADRService.Attachment();

            Attachement.FileName = $"ADR_{Plan}.pdf";
            Attachement.Content = Convert.ToBase64String(File.ReadAllBytes($"{Path.GetTempPath()}\\ADR.pdf"));
            Attachement.Description = $"ADR risk {RiskLevel}";

            PMADRService.CreateMPIAttachment CAttachement = CreateSmartFormPlan(RisqueAndValue);
            CAttachement.MaintenanceItem = Plan;
            CAttachement.UserID = UserdId;
            CAttachement.RiskLevel = RiskLevel;
            CAttachement.Attachment = new PMADRService.Attachment[] { Attachement };


            return CAttachement;
        }

        /// <summary>
        /// Mappe les ordres reçus du webservice en ADR_SAPOrders
        /// </summary>
        /// <param name="OrdersDetails">Ordres à mapper</param>
        /// <returns>Liste de ADR_SAPOrders</returns>
        private IEnumerable<ADR_SAPOrders> ParseOrders(PMADRService.GetOrderdetailsResponse OrdersDetails)
        {
            List<ADR_SAPOrders> SAPOrders = new List<ADR_SAPOrders>();

            foreach (PMADRService.OrderDataO order in OrdersDetails.OrderDetailsFindResponse)
            {
                SAPOrders.Add(order.WebServiceToADR());
            }

            return SAPOrders;
        }

        /// <summary>
        /// Créer le smartforme sur base d'un dictionnaire pour l'ordre (généré lors du pdf).
        /// </summary>
        /// <param name="Attachement"></param>
        /// <param name="RisqueAndValue"></param>
        /// <returns></returns>
        private PMADRService.CreateAttachment CreateSmartForm(Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.CreateAttachment Attachement = new PMADRService.CreateAttachment();

            foreach (PropertyInfo property in Attachement.GetType().GetProperties())
            {
                if (RisqueAndValue.ContainsKey(property.Name))
                    property.SetValue(Attachement, RisqueAndValue[property.Name], null);
            }

            return Attachement;
        }

        /// <summary>
        /// Créer le smartforme sur base d'un dictionnaire pour le plan (généré lors du pdf).
        /// </summary>
        /// <param name="Attachement"></param>
        /// <param name="RisqueAndValue"></param>
        /// <returns></returns>
        private PMADRService.CreateMPIAttachment CreateSmartFormPlan(Dictionary<string, string> RisqueAndValue)
        {
            PMADRService.CreateMPIAttachment Attachement = new PMADRService.CreateMPIAttachment();

            foreach (PropertyInfo property in Attachement.GetType().GetProperties())
            {
                if (RisqueAndValue.ContainsKey(property.Name))
                    property.SetValue(Attachement, RisqueAndValue[property.Name], null);
            }

            return Attachement;
        }
    }
}
