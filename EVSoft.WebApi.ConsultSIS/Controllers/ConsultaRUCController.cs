using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EVSoft.Dominio.ConsultSIS.Entities;
using EVSoft.WebApi.ConsultSIS.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVSoft.WebApi.ConsultSIS.Controllers
{
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaRUCController : ControllerBase
    {

        private readonly ILoggerService _logger;

        public ConsultaRUCController(ILoggerService logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Consultar RUC - Persona Juridica (20...)
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        [HttpGet("GetPersonaJuridica/{ruc}")]
        //[ProducesResponseType(200)]
        ///[ProducesResponseType(400)]
        public async Task<RUCJuridicaEntity> GetPersonaJuridica(string ruc) {

            RUCJuridicaEntity rUC = new RUCJuridicaEntity();
            string endpoint = $"https://api.sunat.cloud/ruc/{ruc}";
            HttpClient httpClient = new HttpClient();

            try
            {
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    rUC = JsonConvert.DeserializeObject<RUCJuridicaEntity>(json, Converter.Settings);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {ex.InnerException}");
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return rUC;
        }

        /// <summary>
        /// Consultar RUC - Persona Natural (10...)
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        [HttpGet("GetPersonaNatural/{ruc}")]
        public async Task<RUCNaturalEntity> GetPersonaNatural(string ruc)
        {

            RUCNaturalEntity rUC = new RUCNaturalEntity();
            string endpoint = $"https://api.sunat.cloud/ruc/{ruc}";
            HttpClient httpClient = new HttpClient();

            try
            {
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    rUC = JsonConvert.DeserializeObject<RUCNaturalEntity>(json, Converter.Settings);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {ex.InnerException}");
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return rUC;
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

    }
}