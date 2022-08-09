using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetReservations();
    }
}

