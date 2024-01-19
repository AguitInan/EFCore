using Exercice01Personnage.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01Personnage.Data
{
    public class Database
    {
        private DatabaseContext context;

        public Database()
        {
            context = new DatabaseContext();
        }

        internal void CreerPersonnage(Personnage personnage)
        {
            context.Personnages.Add(personnage);
            context.SaveChanges();
        }

        internal void MettreAJourPersonnage(Personnage personnage)
        {
            context.Personnages.Update(personnage);
            context.SaveChanges();
        }

        internal List<Personnage> ObtenirTousLesPersonnages()
        {
            return context.Personnages.ToList();
        }



        internal void TaperPersonnage(int attaquantId, int defenseurId)
        {
            var attaquant = context.Personnages.FirstOrDefault(p => p.Id == attaquantId);
            var defenseur = context.Personnages.FirstOrDefault(p => p.Id == defenseurId);

            if (attaquant != null && defenseur != null)
            {
                int degatsRestants = attaquant.Degats - defenseur.Armure;
                defenseur.Armure -= attaquant.Degats;

                if (degatsRestants > 0)
                {
                    defenseur.PointsDeVie -= degatsRestants;
                }

                if (defenseur.PointsDeVie < 0)
                {
                    defenseur.PointsDeVie = 0;
                }
                if (defenseur.Armure < 0)
                {
                    defenseur.Armure = 0;
                }

                if (defenseur.PointsDeVie == 0 && defenseur.Armure == 0)
                {
                    attaquant.NombrePersonneTues++;
                    context.Personnages.Remove(defenseur);
                    Console.WriteLine("Le personnage défenseur est mort et a été supprimé.");
                }

                context.SaveChanges();
            }
            else
            {
                if (attaquant == null)
                    Console.WriteLine("Personnage attaquant non trouvé !");
                if (defenseur == null)
                    Console.WriteLine("Personnage défenseur non trouvé !");
            }
        }


        internal List<Personnage> ObtenirPersonnagesAvecPVSuperieursMoyenne()
        {
            var moyennePV = context.Personnages.Average(p => p.PointsDeVie + p.Armure);
            return context.Personnages.Where(p => (p.PointsDeVie + p.Armure) > moyennePV).ToList();
        }
    }
}