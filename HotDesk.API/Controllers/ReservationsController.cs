using System;
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
        public IActionResult GetDesks()
        {
            return Ok(_reservationService.GetReservations());
        }

        [HttpPost]
        public async Task<IActionResult> PostReserivation(Reservation reservation)
        {
            await _reservationService.InsertReservationAsync(reservation);
            return CreatedAtAction(nameof(GetDesks), new { id = reservation.Id }, reservation);
        }
    }
}

