using ReservationAPI.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationAPI.Infrastructure
{
    public interface IReservationService
    {
        public ReservationDTO GetReservationById(int id);
    }
}
