using HotDesk.API.Models;
using HotDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers
{
    [ApiController]
    [Route("/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(_reservationService.GetReservationsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostReserivation(Reservation reservation)
        {
            await _reservationService.InsertReservationAsync(reservation);
            return CreatedAtAction(
                nameof(GetReservations),
                new { id = reservation.Id },
                reservation
            );
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Reservation>> GetReservationById(string id)
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
