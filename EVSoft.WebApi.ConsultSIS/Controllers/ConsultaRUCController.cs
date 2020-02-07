using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EVSoft.Dominio.ConsultSIS.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EVSoft.WebApi.ConsultSIS.Controllers
{
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaRUCController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        [HttpGet("{ruc}")]
        //[ProducesResponseType(200)]
        ///[ProducesResponseType(400)]
        public async Task<RUCEntity> Get(string ruc) {

            RUCEntity rUC = new RUCEntity();
            string endpoint = $"https://api.sunat.cloud/ruc/{ruc}";
            HttpClient httpClient = new HttpClient();

            try
            {
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    rUC = JsonConvert.DeserializeObject<RUCEntity>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
                //throw;
            }
            return rUC;
        }
    }
}