using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EVSoft.Backend.ConsultSIS.Services
{
    public class ServiceClient
    {
        string BaseEndPoint = "http://dpidesalud.minsa.gob.pe/sis/afiliado/v1.0/afiliado?wsdl";

        HttpClient httpClient;

        public ServiceClient()
        {
            httpClient = new HttpClient();
        }

        
    }
}
