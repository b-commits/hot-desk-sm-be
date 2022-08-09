using System;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class ReservationsService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservationsService;

        public ReservationsService(IMongoCollection<Reservation> reservationsCollection)
        {
            _reservationsService = reservationsCollection;
        }

        public async Task<IEnumerable<Desk>> GetDesks() =>
      await _desksCollection.Find(_ => true).ToListAsync();
    }
}

