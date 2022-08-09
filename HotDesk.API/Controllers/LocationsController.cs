using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return null;
    }
}

