using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVSoft.Dominio.ConsultSIS.Entities
{
    public class RUCEntity
    {
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string ciiu { get; set; }
        public string fecha_actividad { get; set; }
        public string contribuyente_condicion { get; set; }
        public string contribuyente_tipo { get; set; }
        public string contribuyente_estado { get; set; }
        public string nombre_comercial { get; set; }
        public string fecha_inscripcion { get; set; }
        public string domicilio_fiscal { get; set; }
        public string sistema_emision { get; set; }
        public string sistema_contabilidad { get; set; }
        public string actividad_exterior { get; set; }
        public string emision_electronica { get; set; }
        public string fecha_inscripcion_ple { get; set; }
        public string Oficio { get; set; }
        public string fecha_baja { get; set; }
        [JsonExtensionData]
        public Dictionary<string, RepresentaLegal> representante_legal { get; set; }
        [JsonExtensionData]
        public Dictionary<string, Empleado> empleados { get; set; }
        public string[] locales { get; set; }
    }

    public class RepresentaLegal
    {
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string desde { get; set; }
    }

    public class Empleado
    {
        public string trabajadores { get; set; }
        public string pensionistas { get; set; }
        public string prestadores_servicio { get; set; }
    }
}
