using Exercice02HotelAgain.Models;
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










    }
}
