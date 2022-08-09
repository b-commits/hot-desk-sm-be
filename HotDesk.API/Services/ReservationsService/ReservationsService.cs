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

        public async Task DeleteReservationAsync(string reservationId) =>
            await _reservations.DeleteOneAsync(reservation => reservation.Id == reservationId);

        public async Task<Reservation?> GetReservationByIdAsync(string reservationId) =>
            await _reservations
                .Find(reservation => reservation.Id == reservationId)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<Reservation>> GetReservationsAsync() =>
            await _reservations.Find(_ => true).ToListAsync();

        public async Task InsertReservationAsync(Reservation reservation) =>
            await _reservations.InsertOneAsync(reservation);

        public async Task UpdateReservationAsync(
            string reservationId,
            Reservation newReservation
        ) =>
            await _reservations.ReplaceOneAsync(
                reservation => reservation.Id == reservationId,
                newReservation
            );
    }
}
