using InaForum.Logic;
using InaForum.Server.Mapper;
using InaForum.Server.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InaForum.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecastViewModel>> Get()
        {
            var weatherForecasts = await _mediator.Send(new GetWeatherForecastQuery());

            return weatherForecasts.Map();
        }
    }
}
