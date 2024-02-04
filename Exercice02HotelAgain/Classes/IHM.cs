using Exercice02HotelAgain.Data;
using Exercice02HotelAgain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercice02HotelAgain.Models.Reservation;

namespace Exercice02HotelAgain
{
    internal class IHM
    {
        private HotelDatabase database;

        public IHM()
        {
            database = new HotelDatabase();
        }

        public void Demarrer()
        {
            bool continuer = true;
            while (continuer)
            {
                //Console.Clear();
                AfficherTitre();
                Console.WriteLine("1. Voir les réservations");
                Console.WriteLine("2. Faire une réservation");
                Console.WriteLine("3. Faire un check-out");
                Console.WriteLine("4. Annuler une réservation");
                //Console.WriteLine("5. Avancer d'une journée");
                Console.WriteLine("5. Ajouter un nouveau client");
                Console.WriteLine("0. Quitter");
                Console.Write("Choisissez une option: ");

                var choix = Console.ReadLine();
                //Console.Clear();
                switch (choix)
                {
                    case "1":
                        VoirReservations();
                        break;
                    case "2":
                        FaireReservation();
                        break;
                    case "3":
                        FaireCheckOut();
                        break;
                    case "4":
                        AnnulerReservation();
                        break;
                    case "5":
                        AjouterClient();
                        break;
                    //case "5":
                    //    AvancerDuneJournee();
                    //    break;
                    case "0":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        private void AfficherTitre()
        {
            Console.WriteLine("=== Gestion Hôtel ===");
        }

        private void VoirReservations()
        {
            var reservations = database.VoirReservations();
            foreach (var reservation in reservations)
            {
                //Console.WriteLine($"Test {reservation.Client.Prenom}");
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Client: {reservation.Client.Prenom} {reservation.Client.Nom}, Statut: {reservation.Statut}");
            }
        }

        //private void AfficherTousLesPersonnages()
        //{
        //    var personnages = database.ObtenirTousLesPersonnages();
        //    foreach (var personnage in personnages)
        //    {
        //        Console.WriteLine($"{personnage.Id} - {personnage.Pseudo} - PV: {personnage.PointsDeVie} - Armure: {personnage.Armure} - Degats: {personnage.Degats} - Date de création: {personnage.DateCreation} - Nombre de personnes tuées: {personnage.NombrePersonneTues}");
        //    }
        //}

        private void FaireReservation()
        {
            Console.WriteLine("Entrez les informations pour la nouvelle réservation:");
            Console.WriteLine("ID Client:");
            int clientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Numéro de chambre:");
            int chambreNumero = int.Parse(Console.ReadLine());
            //Console.WriteLine("Date de début (yyyy-MM-dd):");
            //DateTime dateDebut = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Date de fin (yyyy-MM-dd):");
            //DateTime dateFin = DateTime.Parse(Console.ReadLine());

            var client = database.ObtenirClientParId(clientId);
            var chambre = database.ObtenirChambreParNumero(chambreNumero);

            if (client != null && chambre != null)
            {
                var reservation = new Reservation
                {
                    Client = client,
                    Chambres = new List<Chambre> { chambre },
                    Statut = StatutReservation.Prevu,
                    HotelId = 1
                };
                database.FaireReservation(reservation);
                Console.WriteLine("Réservation créée avec succès.");
            }
            else
            {
                Console.WriteLine("Client ou chambre introuvable.");
            }
        }


    }
}