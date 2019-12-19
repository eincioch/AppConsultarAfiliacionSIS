﻿using EVSoft.WebApi.ConsultSIS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EVSoft.Backend.ConsultSIS.Services
{
    public class ServiceClient
    {
        string BaseEndPoint = "http://172.16.2.21:5000/api/SISAfiliacion/"; //1/40606047";

        HttpClient httpClient;

        public ServiceClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<AfiliadoEntity>> GetAfiliacionAsync(string tiDocumento, string nuDocumento)
        {

            var afiliadoEntities = new List<AfiliadoEntity>();
            var Uri = new Uri(BaseEndPoint + tiDocumento +"/" + nuDocumento);

            try
            {
                var Response = await httpClient.GetAsync(Uri);
                if (Response.IsSuccessStatusCode)
                {
                    var Content = await Response.Content.ReadAsStringAsync();
                    afiliadoEntities = JsonConvert.DeserializeObject<List<AfiliadoEntity>>(Content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return afiliadoEntities;
        }


    }
}