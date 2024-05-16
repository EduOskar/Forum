using InaForum.Domain;
using InaForum.Infrastructure.Repository.IRepository;
using InaForum.Logic.Querys;
using MediatR;

namespace InaForum.Logic.QueryHandlers
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
