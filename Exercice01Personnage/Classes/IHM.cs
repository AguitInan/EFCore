using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice01Personnage.Data;

namespace Exercice01Personnage.Classes
{

    internal class IHM
    {
        private Database database;

        public IHM()
        {
            database = new Database();
        }

        public void AfficherTitre()
        {
            string title = @"
  ____                     _   _                  
 |  _ \ ___ _ __ ___  ___ | \ | | __ _  __ _  ___ 
 | |_) / _ \ '__/ __|/ _ \|  \| |/ _` |/ _` |/ _ \
 |  __/  __/ |  \__ \ (_) | |\  | (_| | (_| |  __/
 |_|   \___|_|  |___/\___/|_| \_|\__,_|\__, |\___|
                                       |___/       
";

            Console.WriteLine(title);
        }


        public void Demarrer()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.Clear();
                AfficherTitre();
                Console.WriteLine("1. Créer un personnage");
                Console.WriteLine("2. Mettre à jour un personnage");
                Console.WriteLine("3. Afficher tous les personnages");
                Console.WriteLine("4. Taper un personnage");
                Console.WriteLine("5. Afficher les personnages ayant des PVs (PV + armure) supérieurs à la moyenne");
                Console.WriteLine("0. Quitter\n");
                Console.Write("Choisissez une option: ");

                var choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        CreerPersonnage();
                        break;
                    case "2":
                        MettreAJourPersonnage();
                        break;
                    case "3":
                        AfficherTousLesPersonnages();
                        break;
                    case "4":
                        TaperPersonnage();
                        break;
                    case "5":
                        AfficherPersonnagesAvecPVSuperieursMoyenne();
                        break;
                    case "0":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix non valide");
                        break;
                }

                if (continuer)
                {
                    Console.WriteLine("Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                }
            }
        }


        private void CreerPersonnage()
        {
            Console.Write("Entrez le pseudo du personnage : ");
            string pseudo = Console.ReadLine();

            Console.Write("Entrez les points de vie du personnage : ");
            int pointsDeVie = int.Parse(Console.ReadLine());

            Console.Write("Entrez l'armure du personnage : ");
            int armure = int.Parse(Console.ReadLine());

            Console.Write("Entrez les dégâts du personnage : ");
            int degats = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nombre de personnes tuées par le personnage : ");
            int nombrePersonneTues = int.Parse(Console.ReadLine());

            Personnage nouveauPersonnage = new Personnage
            {
                Pseudo = pseudo,
                PointsDeVie = pointsDeVie,
                Armure = armure,
                Degats = degats,
                DateCreation = DateTime.Now,
                NombrePersonneTues = nombrePersonneTues
            };

            database.CreerPersonnage(nouveauPersonnage);
            Console.WriteLine("Personnage créé avec succès !");
        }

        private void MettreAJourPersonnage()
        {
            Console.Write("Entrez l'Id du personnage à mettre à jour : ");
            int id = int.Parse(Console.ReadLine());

            Personnage personnage = database.ObtenirTousLesPersonnages().FirstOrDefault(p => p.Id == id);
            if (personnage == null)
            {
                Console.WriteLine("Personnage non trouvé !");
                return;
            }

            Console.Write("Entrez les nouveaux points de vie du personnage (actuel: " + personnage.PointsDeVie + "): ");
            personnage.PointsDeVie = int.Parse(Console.ReadLine());

            Console.Write("Entrez la nouvelle valeur d'armure du personnage (actuel: " + personnage.Armure + "): ");
            personnage.Armure = int.Parse(Console.ReadLine());

            Console.Write("Entrez les nouveaux dégâts du personnage (actuel: " + personnage.Degats + "): ");
            personnage.Degats = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nouveau nombre de personnes tuées par le personnage (actuel: " + personnage.NombrePersonneTues + "): ");
            personnage.NombrePersonneTues = int.Parse(Console.ReadLine());

            database.MettreAJourPersonnage(personnage);
            Console.WriteLine("Personnage mis à jour avec succès !");
        }

        private void AfficherTousLesPersonnages()
        {
            var personnages = database.ObtenirTousLesPersonnages();
            foreach (var personnage in personnages)
            {
                Console.WriteLine($"{personnage.Id} - {personnage.Pseudo} - PV: {personnage.PointsDeVie} - Armure: {personnage.Armure} - Degats: {personnage.Degats} - Date de création: {personnage.DateCreation} - Nombre de personnes tuées: {personnage.NombrePersonneTues}");
            }
        }

        private void TaperPersonnage()
        {
            Console.Write("Entrez l'Id du personnage à taper : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Entrez les dégâts à infliger : ");
            int degats = int.Parse(Console.ReadLine());

            database.TaperPersonnage(id, degats);
            Console.WriteLine("Dégâts infligés au personnage !");
        }

        private void AfficherPersonnagesAvecPVSuperieursMoyenne()
        {
            var personnages = database.ObtenirPersonnagesAvecPVSuperieursMoyenne();
            if (personnages.Any())
            {
                foreach (var personnage in personnages)
                {
                    Console.WriteLine($"{personnage.Id} - {personnage.Pseudo} - PV: {personnage.PointsDeVie} - Armure: {personnage.Armure} - Degats: {personnage.Degats} - Date de création: {personnage.DateCreation} - Nombre de personnes tuées: {personnage.NombrePersonneTues}");
                }
            }
            else
            {
                Console.WriteLine("Aucun personnage n'a des PV + armure supérieurs à la moyenne.");
            }
        }
    }
}