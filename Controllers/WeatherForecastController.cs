using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi_test.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Route("Get")]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpGet]
    [Route("Get")]
    public IEnumerable<WeatherForecast> GetById([FromQuery] int id)
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecastWithCity
      {
        City = id.ToString(),
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public IEnumerable<WeatherForecast> GetByIdSecondary([FromRoute] int id)
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecastWithCity
      {
        City = id.ToString(),
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpPost]
    [Route("Post")]
    public IEnumerable<WeatherForecast> Post([FromBody] City city)
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecastWithCity
      {
        City = city.Name,
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}
