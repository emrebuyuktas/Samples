using ReservationAPI.Infrastructure;
using ReservationAPI.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationAPI.Services
{
    public class ReservationService : IReservationService
    {
        public ReservationDTO GetReservationById(int id)
        {
            return new ReservationDTO() { 
                Id = id,Amount=50,
                CheckinDate=DateTime.Now.AddDays(10),
                CheckoutDate=DateTime.Now.AddDays(15)
            };
        }
    }
}
