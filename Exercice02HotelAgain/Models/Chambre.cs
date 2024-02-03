using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02HotelAgain.Models
{

    internal class Chambre
    {
        // Propriétés
        public int ChambreId { get; set; }
        public StatutChambre Statut { get; set; }
        public int NombreDeLits { get; set; }
        public decimal Tarif { get; set; }

        // Clé étrangère pour Hotel
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        // Relation: Une chambre peut être concernée par plusieurs réservations (selon la période)
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();


        // Constructeur

        public Chambre()
        {
            Reservations = new List<Reservation>();
        }
        public Chambre(int chambreId, StatutChambre statut, int nombreDeLits, decimal tarif)
        {
            ChambreId = chambreId;
            Statut = statut;
            NombreDeLits = nombreDeLits;
            Tarif = tarif;
        }

        public enum StatutChambre
        {
            Libre,
            Occupe,
            EnNettoyage
        }
    }
}
