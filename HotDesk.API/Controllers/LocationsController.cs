using System.Web.Http.Cors;
using HotDesk.API.Models;
using HotDesk.API.Services;
using HotDesk.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers;

[ApiController]
[EnableCors(origins: "*", headers: "*", methods: "*")]
[Route("/locations")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IDeskService _deskService;

    public LocationsController(ILocationService locationService, IDeskService deskService)
    {
        _locationService = locationService;
        _deskService = deskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        return Ok(await _locationService.GetLocationsAsync());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetLocationById(string id)
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

        var desksInLocation = await _deskService.GetDesksAsync();

        if (desksInLocation.Any(desk => desk.LocationId == id))
        {
            return BadRequest(ValidationUtils.CANNOT_DELETE_LOCATION);
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
