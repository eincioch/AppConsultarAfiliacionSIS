using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EVSoft.WebApi.ConsultSIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //El método UseUrls es para indicar las direcciones IP o 
                    //direcciones de host con puertos y protocolos que el servidor 
                    //debe escuchar para las solicitudes.
                    webBuilder.UseUrls("http://*:5000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
