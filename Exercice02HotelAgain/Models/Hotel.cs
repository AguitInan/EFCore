using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02HotelAgain.Models
{
    internal class Hotel
    {
        // Propriétés
        public int HotelId { get; set; }
        public string Nom { get; set; }

        // Relations
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();







    }
}
