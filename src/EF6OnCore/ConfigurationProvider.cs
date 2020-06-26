using Microsoft.Extensions.Configuration;
using System.IO;

namespace EF6OnCore
{
    public static class ConfigurationProvider
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationProvider()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}