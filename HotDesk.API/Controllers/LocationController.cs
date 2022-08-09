using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {

    }
}

