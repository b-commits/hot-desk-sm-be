using HotDesk.API.Models;
using HotDesk.API.Utilities;
using HotDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers
{
    [ApiController]
    [Route("/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IDeskService _deskService;

        public ReservationsController(IReservationService reservationService, IDeskService deskService)
        {
            _reservationService = reservationService;
            _deskService = deskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(await _reservationService.GetReservationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostReserivation(Reservation reservation)
        {
            var desk = await _deskService.GetDeskByIdAsync(reservation.DeskId);

            if (desk is null)
            {
                return NotFound(ValidationUtils.DESK_DOES_NOT_EXIST);
            }

            var reservations = await _reservationService.GetReservationsAsync();

            try
            {
                var overlaps = reservations.Where(existingReservation => ValidationUtils.CheckDateOverlaps
                    (existingReservation.StartDate, existingReservation.EndDate,
                    reservation.StartDate, reservation.EndDate)).ToList();
                if (overlaps.Any())
                {
                    return Conflict("The desk is reserved for the provided timeframe");
                }
            }
            catch (ArgumentException ex)
            {
                return Conflict(ex.Message);
            }

            if (
                (reservation.EndDate - reservation.StartDate).TotalDays
                > ValidationUtils.MAX_RESERVATION_LENGTH
            )
            {
                return BadRequest(ValidationUtils.RESERVATION_LENGTH_EXCEEDED);
            }

            await _reservationService.InsertReservationAsync(reservation);
            return CreatedAtAction(
                nameof(GetReservations),
                new { id = reservation.Id },
                reservation
            );
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetReservationById(string id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation is null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteReservationById(string id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation is null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservationAsync(id);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateReservation(string id, Reservation newReservation)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation is null)
            {
                return NotFound();
            }

            newReservation.Id = reservation.Id;

            await _reservationService.UpdateReservationAsync(id, newReservation);

            return Ok();
        }
    }
}
