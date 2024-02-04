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


    }
}