using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02HotelAgain.Models
{
    internal class Client
    {
        // Propriétés
        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroTelephone { get; set; }

        // Relation: Un client peut avoir plusieurs réservations
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();


        // Constructeur

        public Client()
        {
            Reservations = new List<Reservation>();
        }


    }
}
