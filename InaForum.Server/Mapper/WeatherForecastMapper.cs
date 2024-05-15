using InaForum.Domain;
using InaForum.Server.ViewModels;
using System.Runtime.CompilerServices;

namespace InaForum.Server.Mapper
{
    public static class WeatherForecastMapper
    {
        public static IEnumerable<WeatherForecastViewModel> Map(this IEnumerable<WeatherForecast> weatherForecasts) => weatherForecasts.Select(wf => Map(wf));

        public static WeatherForecastViewModel Map(this WeatherForecast weatherForecast) => new()
        {
            Date = weatherForecast.Date,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        };
    }
}
