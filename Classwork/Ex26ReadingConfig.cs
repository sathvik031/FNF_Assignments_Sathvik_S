using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace SampleConApp
{
    internal class Ex26ReadingConfig
    {
        public static IConfiguration AppConfig { get; private set; }
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var appName = config["AppSettings:AppName"];
            var title = config["AppSettings:Title"];

            Console.WriteLine($"~~~~~~~~~~{appName.ToUpper()}~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"~~~~~~~~~~{title.ToUpper()}~~~~~~~~~~~~~~~~~~~");
            Console.ReadKey();

            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings );
            Console.WriteLine(appSettings.Title);

        }
        class AppSettings()
        {
            public string AppName { get; set; }
            public string Title { get; set; }
        }
    }
}