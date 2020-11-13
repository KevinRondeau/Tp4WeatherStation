using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace OpenWeatherAPI
{
    public class OpenWeatherService:ITemperatureService
    {
        private static OpenWeatherProcessor owp;

        public TemperatureModel LastTemp;

        public OpenWeatherService(string ApiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = ApiKey;
        }

        public async Task<TemperatureModel> GetTempAsync()
        {
            var weather =  await owp.GetCurrentWeatherAsync();
            TemperatureModel temp = new TemperatureModel();

            DateTime dateTime = DateTime.UtcNow;

            temp.DateTime = dateTime;
            temp.Temperature = weather.Main.Temperature;
            LastTemp = temp;
            return LastTemp;

        }
    }
}
