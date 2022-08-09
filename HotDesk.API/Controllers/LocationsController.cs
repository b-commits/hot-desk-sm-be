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
    public IActionResult GetLocations()
    {
        return Ok(_locationService.SelectLocations());
    }

    [HttpPost]
    public IActionResult PostLocation(Location location)
    {
        _locationService.InsertLocation(location);
        return Ok();
    }


}

