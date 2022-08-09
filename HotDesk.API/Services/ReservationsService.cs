using System;
using HotDesk.API.Config;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class ReservationsService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservations;

        public ReservationsService(IDatabaseContext database)
        {
            _reservations = database.GetReservationsCollection();
        }

        public async Task<IEnumerable<Reservation>> GetReservations() =>
      await _reservations.Find(_ => true).ToListAsync();
    }
}

