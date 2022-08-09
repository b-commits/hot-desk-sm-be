using HotDesk.API.Models;
using HotDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers;

[ApiController]
[Route("/locations")]
public class LocationsController : ControllerBase
{

    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<ActionResult<Location>> GetLocations()
    {
        var locations = await _locationService.SelectLocationsAsync();
        return Ok(locations);
    }

    [HttpPost]
    public async Task<IActionResult> PostLocation(Location location)
    {
        await _locationService.InsertLocationAsync(location);
        return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
    }


}

