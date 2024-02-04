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



    }
}