using Exercice01Personnage.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class DatabaseContext : DbContext
{
    public DatabaseContext() : base()
    {
    }
    public DbSet<Personnage> Personnages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\demo01ado;Database=Personnage;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Personnage>(entity =>
        {
            entity.ToTable("Personnage");
        });
    }

}