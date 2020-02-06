using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EVSoft.WebApi.ConsultSIS
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program'
    public class Program
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program'
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program.Main(string[])'
        public static void Main(string[] args)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program.Main(string[])'
        {
            CreateHostBuilder(args).Build().Run();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program.CreateHostBuilder(string[])'
        public static IHostBuilder CreateHostBuilder(string[] args) =>
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible de forma pública 'Program.CreateHostBuilder(string[])'
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
