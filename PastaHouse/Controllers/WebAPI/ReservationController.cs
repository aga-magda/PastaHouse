using PastaHouse.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;
using System.Linq;

namespace PastaHouse.Controllers.WebAPI
{
    public class ReservationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/reservation?date=2019-01-30&tableId=1
        public IEnumerable<ReservationAPI> Get(string date, int tableId)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var filteredReservations = db
                .Reservations
                .Where(r => r.ReservationDateTime.Year == parsedDate.Year &&
                            r.ReservationDateTime.Month == parsedDate.Month &&
                            r.ReservationDateTime.Day == parsedDate.Day &&
                            r.TableId == tableId)
                .ToList();

            List<ReservationAPI> reservationAPIList = new List<ReservationAPI>();
            for (int i = 10; i <= 20; i += 2)
            {
                var time = $"{i}:00";
                ReservationAPI reservationAPI = new ReservationAPI();
                reservationAPI.Time = time;
                reservationAPI.IsReserved = "No";
                reservationAPIList.Add(reservationAPI);

                if (filteredReservations.FirstOrDefault(r => r.ReservationDateTime.TimeOfDay.ToString() == $"{time}:00") != null)
                {
                    reservationAPI.IsReserved = "Yes";
                }
                else
                {
                    reservationAPI.IsReserved = "No";
                }
            }

            return reservationAPIList;
        }
    }
}