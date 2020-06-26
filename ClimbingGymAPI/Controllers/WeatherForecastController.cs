using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimbingGymAPI.DAL;
using ClimbingGymAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClimbingGymAPI.Controllers
{
    //TODO 4: Write a new controller to accomodate the Gym Models
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IGymDAO _gymDAO;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGymDAO gymDAO)
        {
            _logger = logger;
            _gymDAO= gymDAO;
        }

        [HttpGet]
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
        [HttpGet("/Gyms")]
        public List<Gym> GetGyms()
        {
            return _gymDAO.ListAllGyms();
        }
    }
}
