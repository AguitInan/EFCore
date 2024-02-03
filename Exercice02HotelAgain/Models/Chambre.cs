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

 



    }
}
