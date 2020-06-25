using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace ClimbingGymAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //// This code reads the connection string from appsettings.json
            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //IConfigurationRoot configuration = builder.Build();
            ////This is the configuration string to use for the rest of the program
            //string connectionString = configuration.GetConnectionString("ClimbingGym");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });




    }
}
