using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01Personnage.Classes;

//[Table("Personnage")]
internal class Personnage
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public int PointsDeVie { get; set; }
    public int Armure { get; set; }
    public int Degats { get; set; }
    public DateTime DateCreation { get; set; }
    public int NombrePersonneTues { get; set; }

    public Personnage() : this("No Name", 0, 0, 0, 0)
    {
    }
    public Personnage(string pseudo, int pointsDeVie, int armure, int degats, int nombrePersonneTues)
    {
        Pseudo = pseudo;
        PointsDeVie = pointsDeVie;
        Armure = armure;
        Degats = degats;
        DateCreation = DateTime.Now;
        NombrePersonneTues = nombrePersonneTues;
    }

}
