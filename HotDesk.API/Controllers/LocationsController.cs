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
        var locations = await _locationService.GetLocationsAsync();
        return Ok(locations);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Location>> GetLocationById(string id)
    {
        var location = await _locationService.GetLocationBydIdAsync(id);

        if (location is null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> PostLocation(Location location)
    {
        await _locationService.InsertLocationAsync(location);
        return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteLocation(string id)
    {
        var location = await _locationService.GetLocationBydIdAsync(id);

        if (location is null)
        {
            return NotFound();
        }

        await _locationService.DeleteLocationAsync(id);

        return Ok();
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateLocation(string id, Location newLocation)
    {
        var location = await _locationService.GetLocationBydIdAsync(id);

        if (location is null)
        {
            return NotFound();
        }

        newLocation.Id = location.Id;

        await _locationService.UpdateLocationAsync(id, newLocation);

        return Ok();
    }
}
