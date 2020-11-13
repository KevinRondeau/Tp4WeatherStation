using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
   
    class AppConfiguration
    {
        private static IConfiguration configuration;

        public static string GetValue(string value)
        {
            if (configuration==null)
            {
                initConfig();
            }
            return configuration[value];
        }
        private static void initConfig()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configBuilder.AddUserSecrets<MainWindow>();
            configuration = configBuilder.Build();

        }
    }
}
