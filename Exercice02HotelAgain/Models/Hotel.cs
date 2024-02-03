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


        // Constructeur

        public Hotel()
        {
            Clients = new List<Client>();
            Chambres = new List<Chambre>();
            Reservations = new List<Reservation>();
        }


        // Méthodes pour gérer l'hôtel (ajouter client, ajouter chambre, créer réservation, etc.)

        public void AjouterClient(Client client)
        {
            Clients.Add(client);
        }

        public void AjouterChambre(Chambre chambre)
        {
            Chambres.Add(chambre);
        }

        public void CreerReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

    }
}
