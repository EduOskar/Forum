using InaForum.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Logic
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
