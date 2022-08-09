using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task<Reservation?> GetReservationByIdAsync(string reservationId);
        Task InsertReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(string reservationId);
        Task UpdateReservationAsync(string reservationId, Reservation newReservation);
    }
}
