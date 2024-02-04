﻿// <auto-generated />
using System;
using Exercice02HotelAgain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exercice02HotelAgain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240122092348_2ndMigration")]
    partial class _2ndMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Exercice02HotelAgain.Models.Chambre", b =>
                {
                    b.Property<int>("ChambreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChambreId"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("NombreDeLits")
                        .HasColumnType("int");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<decimal>("Tarif")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ChambreId");

                    b.HasIndex("HotelId");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.HasIndex("HotelId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("HotelId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ReservationChambre", b =>
                {
                    b.Property<int>("ChambreNumero")
                        .HasColumnType("int");

                    b.Property<int>("ReservationIdentifiant")
                        .HasColumnType("int");

                    b.HasKey("ChambreNumero", "ReservationIdentifiant");

                    b.HasIndex("ReservationIdentifiant");

                    b.ToTable("ReservationChambre");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Chambre", b =>
                {
                    b.HasOne("Exercice02HotelAgain.Models.Hotel", "Hotel")
                        .WithMany("Chambres")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Client", b =>
                {
                    b.HasOne("Exercice02HotelAgain.Models.Hotel", null)
                        .WithMany("Clients")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Reservation", b =>
                {
                    b.HasOne("Exercice02HotelAgain.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exercice02HotelAgain.Models.Hotel", "Hotel")
                        .WithMany("Reservations")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("ReservationChambre", b =>
                {
                    b.HasOne("Exercice02HotelAgain.Models.Chambre", null)
                        .WithMany()
                        .HasForeignKey("ChambreNumero")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Exercice02HotelAgain.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationIdentifiant")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Exercice02HotelAgain.Models.Hotel", b =>
                {
                    b.Navigation("Chambres");

                    b.Navigation("Clients");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
