using HotDesk.API.Entities;
using HotDesk.API.Services;
using HotDesk.API.Services.ReservationsService;
using HotDesk.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DesksController : ControllerBase
{
    private readonly IDeskService _deskService;
    private readonly IReservationService _reservationService;

    public DesksController(IDeskService deskService, IReservationService reservationService)
    {
        _deskService = deskService;
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDesks() => Ok(await _deskService.GetDesksAsync());
    

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(string id)
    {
        var desk = await _deskService.GetDeskByIdAsync(id);

        if (desk is null)
        {
            return NotFound();
        }

        return Ok(desk);
    }

    [HttpPost]
    public async Task<IActionResult> PostDesk(Desk desk)
    {
        await _deskService.InsertDeskAsync(desk);
        return CreatedAtAction(nameof(GetDesks), new { id = desk.Id }, desk);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteDesk(string id)
    {
        var desk = await _deskService.GetDeskByIdAsync(id);

        if (desk is null)
        {
            return NotFound();
        }

        var deskReservations = await _reservationService.GetReservationsAsync();

        if (deskReservations.Any(reservation => reservation.DeskId == id))
        {
            return BadRequest(ValidationUtils.CANNOT_DELETE_DESK);
        }

        await _deskService.DeleteDeskAsync(id);

        return Ok();
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateDesk(string id, Desk newDesk)
    {
        var desk = await _deskService.GetDeskByIdAsync(id);

        if (desk is null)
        {
            return NotFound();
        }

        newDesk.Id = desk.Id;

        await _deskService.UpdateDeskAsync(id, newDesk);

        return Ok();
    }
}