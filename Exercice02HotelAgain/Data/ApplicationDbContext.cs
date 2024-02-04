using Exercice02HotelAgain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02HotelAgain.Data
{
    internal class ApplicationDbContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\demo01ado; Database=HotelAgain;");
        }

        // S'exécute lors de la création des tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configuration de la relation plusieurs-à-plusieurs entre Chambre et Reservation
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Chambres)
                .WithMany(c => c.Reservations)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservationChambre", // Nom de la table de jonction
                    j => j.HasOne<Chambre>().WithMany().HasForeignKey("ChambreNumero").OnDelete(DeleteBehavior.NoAction), // Configurer la relation et la suppression pour Chambre
                    j => j.HasOne<Reservation>().WithMany().HasForeignKey("ReservationIdentifiant").OnDelete(DeleteBehavior.NoAction) // Configurer la relation et la suppression pour Reservation
                );

            // ... autres configurations

            base.OnModelCreating(modelBuilder);


            //    // Configuration pour la relation plusieurs-à-plusieurs entre Chambre et Reservation
            //    modelBuilder.Entity<Reservation>()
            //        .HasMany(r => r.Chambres)
            //        .WithMany(c => c.Reservations)
            //        .UsingEntity(j => j.ToTable("ReservationChambres"))
            //        .HasOne<Chambre>().WithMany().HasForeignKey("ChambreNumero").OnDelete(DeleteBehavior.NoAction); // Clé étrangère et comportement de suppression pour Chambre
            //.HasOne<Reservation>().WithMany().HasForeignKey("ReservationIdentifiant").OnDelete(DeleteBehavior.NoAction); // Clé étrangère et comportement de suppression pour Reservation

            //    // ... autres configurations

            //    base.OnModelCreating(modelBuilder);





            //// Configurer la relation plusieurs-à-plusieurs entre Chambre et Reservation
            //modelBuilder.Entity<Reservation>()
            //    .HasMany(r => r.Chambres)
            //    .WithMany(c => c.Reservations)
            //    .UsingEntity(j => j.ToTable("ReservationChambres"))
            //    .HasOne<Reservation>().WithMany().HasForeignKey("ReservationId").OnDelete(DeleteBehavior.NoAction);
            //// Ou utilisez .OnDelete(DeleteBehavior.Restrict) selon votre politique de suppression préférée

            //// ... autres configurations, assurez-vous de configurer la suppression pour d'autres relations si nécessaire









            //// Configuration pour la relation plusieurs-à-plusieurs entre Chambre et Reservation
            //modelBuilder.Entity<Reservation>()
            //    .HasMany(r => r.Chambres)
            //    .WithMany(c => c.Reservations)
            //    .UsingEntity(j => j.ToTable("ReservationChambres")); // Nom de la table de jonction

            //// Ajoutez ici des configurations supplémentaires si nécessaire

            //// Exemple d'ajout de données initiales à la base de données
            ////modelBuilder.Entity<Hotel>().HasData(
            ////    new Hotel() { Identifiant = 1, Nom = "Hotel Sunset Boulevard" },
            ////    // ...
            ////);




            //modelBuilder.Entity<PostTag>()
            //    .HasKey(pt => new { pt.TagId, pt.PostId });

            //// HasData permet d'ajouter des données dans la base lors de la création des tables
            //modelBuilder.Entity<Blog>().HasData(
            //    new Blog() { Id = 1, Nom = "JohnnyHalliday115", Url = "http://www.johnnyhalliday115.skyblog.com" },
            //new Blog() { Id = 2, Nom = "Koreus", Url = "http://www.koreus.com" },
            //    new Blog() { Id = 3, Nom = "Toto", Url = "http://www.toto.com" });

            //modelBuilder.Entity<Post>().HasData(
            //    new Post() { Id = 1, Titre = "Johnny est mort.", BlogId = 1, Contenu = "Trop triste :'(" },
            //    new Post() { Id = 2, Titre = "Trop mdr xd la vidéo OLALALA", BlogId = 2, Contenu = "Le chat il tombe là" },
            //    new Post() { Id = 3, Titre = "Tu connais la blague de toto aux toilettes ?", BlogId = 3, Contenu = "Moi non plus la porte était fermée ^^" }
            //    );
        }


    }
}
