using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservations();
        Task InsertReservationAsync(Reservation reservation);
    }
}

