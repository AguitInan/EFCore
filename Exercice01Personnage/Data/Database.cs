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


        internal void TaperPersonnage(int id, int degats)
        {
            var personnage = context.Personnages.FirstOrDefault(p => p.Id == id);
            if (personnage != null)
            {
                int degatsRestants = degats - personnage.Armure;
                personnage.Armure -= degats;

                if (degatsRestants > 0)
                {
                    personnage.PointsDeVie -= degatsRestants;
                }

                if (personnage.PointsDeVie < 0)
                {
                    personnage.PointsDeVie = 0;
                }
                if (personnage.Armure < 0)
                {
                    personnage.Armure = 0;
                }

                if (personnage.PointsDeVie == 0 && personnage.Armure == 0)
                {
                    context.Personnages.Remove(personnage);
                    Console.WriteLine("Le personnage est mort et a été supprimé.");
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Personnage non trouvé !");
            }
        }


        internal List<Personnage> ObtenirPersonnagesAvecPVSuperieursMoyenne()
        {
            var moyennePV = context.Personnages.Average(p => p.PointsDeVie + p.Armure);
            return context.Personnages.Where(p => (p.PointsDeVie + p.Armure) > moyennePV).ToList();
        }
    }
}