using InaForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InaForum.Infrastructure.Repository.IRepository
{
    public interface IWeatherForeccastRepository
    {
        public IEnumerable<WeatherForecast> Get();
    }
}
