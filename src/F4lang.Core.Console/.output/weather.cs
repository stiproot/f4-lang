using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeatherForecastAPI
{
    // Data model class
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    // DbContext class
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }

    // Interface for dependency inversion principle
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetWeatherForecastAsync();
    }

    // Implementation of IWeatherForecastService
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly WeatherContext _context;

        public WeatherForecastService(WeatherContext context)
        {
            _context = context;
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync()
        {
            return await _context.WeatherForecasts.FirstOrDefaultAsync();
        }
    }

    // Weather Controller
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpPost]
        public async Task<IActionResult> Get()
        {
            var weather = await _weatherForecastService.GetWeatherForecastAsync();

            if(weather == null)
            {
                return NotFound();
            }

            return Ok(weather);
        }
    }
}