using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ADR.Helper
{
    public class GenerateHistorique
    {
        /// <summary>
        /// Creation de l'historique
        /// </summary>
        /// <param name="UserId">Utilisateur qui fait l'action</param>
        /// <param name="Action">Type d'action</param>
        /// <param name="Origine">Avant</param>
        /// <param name="Destination">Après</param>
        public void CreateHistorique(string UserId, string Action, string Origine, string Destination = null)
        {
            ADR_Historique Historique = new ADR_Historique();

            Historique.Date = DateTime.Now;
            Historique.UserId = UserId.ToUpper();
            Historique.TypeAction = Action;
            Historique.Origine = Origine;
            Historique.Destination = Destination;

            using (HistoriqueRepository HistoriqueRepository = new HistoriqueRepository())
            {
                HistoriqueRepository.Insert(Historique);
            }
        }
    }
}
