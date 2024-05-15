using InaForum.Domain;
using InaForum.Infrastructure.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        public IWeatherForeccastRepository _weatherForecastRepository;

        public GetWeatherForecastQueryHandler(IWeatherForeccastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var weatherForecast = _weatherForecastRepository.Get();

            return Task.FromResult(weatherForecast);

        }
    }
}
