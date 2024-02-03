using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02HotelAgain.Models
{

    internal class Reservation
    {
        // Propriétés
        //public int Identifiant { get; set; }
        //public StatutReservation Statut { get; set; }
        //public List<Chambre> Chambres { get; set; }
        //public Client Client { get; set; }

        public int ReservationId { get; set; }
        public StatutReservation Statut { get; set; }

        // Clé étrangère pour Client
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Clé étrangère pour Hotel
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        // Relation: Une réservation concerne plusieurs chambres
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();


        // Constructeur

        public Reservation()
        {
        }
        //public Reservation(int reservationId, StatutReservation statut, List<Chambre> chambres, Client client)
        //{
        //    ReservationId = reservationId;
        //    Statut = statut;
        //    Chambres = chambres ?? new List<Chambre>(); // Initialise avec une liste vide si null est passé
        //    Client = client;
        //    HotelId = 1;
        //}

        public enum StatutReservation
        {
            Prevu,
            EnCours,
            Fini,
            Annule
        }
    }
}
