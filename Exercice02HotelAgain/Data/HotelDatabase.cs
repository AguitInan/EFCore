﻿using Exercice02HotelAgain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercice02HotelAgain.Models.Reservation;

namespace Exercice02HotelAgain.Data
{
    public class HotelDatabase
    {
        private ApplicationDbContext context;

        public HotelDatabase()
        {
            context = new ApplicationDbContext();
        }

        internal void FaireReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        internal void AnnulerReservation(int reservationId)
        {
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                reservation.Statut = StatutReservation.Annule;
                context.SaveChanges();
            }
        }

        internal List<Reservation> VoirReservations()
        {
            return context.Reservations.ToList();
        }

        internal void FaireCheckOut(int reservationId)
        {
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                // Mettre à jour le statut de la réservation et éventuellement la chambre
                reservation.Statut = StatutReservation.Fini;
                // Plus de logique ici si nécessaire
                context.SaveChanges();
            }
        }

        internal void AjouterClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        internal void AvancerDuneJournee()
        {
            // Logique pour avancer d'une journée, par exemple, mise à jour des dates de réservation
            // Plus de logique ici si nécessaire
            context.SaveChanges();
        }

        internal Client ObtenirClientParId(int clientId)
        {
            // Trouver un client par son identifiant
            return context.Clients.FirstOrDefault(c => c.ClientId == clientId);
        }

        internal Chambre ObtenirChambreParNumero(int chambreNumero)
        {
            // Trouver une chambre par son numéro
            return context.Chambres.FirstOrDefault(c => c.ChambreId == chambreNumero);
        }
    }
}
