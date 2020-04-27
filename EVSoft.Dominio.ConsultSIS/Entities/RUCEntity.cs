using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVSoft.Dominio.ConsultSIS.Entities
{
    public partial class RUCJuridicaEntity
    {
        [JsonProperty("ruc")]
        public string Ruc { get; set; }

        [JsonProperty("razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty("ciiu")]
        public string Ciiu { get; set; }

        [JsonProperty("fecha_actividad")]
        public DateTimeOffset FechaActividad { get; set; }

        [JsonProperty("contribuyente_condicion")]
        public string ContribuyenteCondicion { get; set; }

        [JsonProperty("contribuyente_tipo")]
        public string ContribuyenteTipo { get; set; }

        [JsonProperty("contribuyente_estado")]
        public string ContribuyenteEstado { get; set; }

        [JsonProperty("nombre_comercial")]
        public string NombreComercial { get; set; }

        [JsonProperty("fecha_inscripcion")]
        public DateTimeOffset FechaInscripcion { get; set; }

        [JsonProperty("domicilio_fiscal")]
        public string DomicilioFiscal { get; set; }

        [JsonProperty("sistema_emision")]
        public string SistemaEmision { get; set; }

        [JsonProperty("sistema_contabilidad")]
        public string SistemaContabilidad { get; set; }

        [JsonProperty("actividad_exterior")]
        public string ActividadExterior { get; set; }

        [JsonProperty("emision_electronica")]
        public DateTimeOffset EmisionElectronica { get; set; }

        [JsonProperty("fecha_inscripcion_ple")]
        public DateTimeOffset FechaInscripcionPle { get; set; }

        [JsonProperty("fecha_baja")]
        public string FechaBaja { get; set; }

        [JsonProperty("representante_legal")]
        public Dictionary<string, RepresentanteLegal> RepresentanteLegal { get; set; }

        [JsonProperty("empleados")]
        public Dictionary<string, Empleado> Empleados { get; set; }

        [JsonProperty("locales")]
        public List<object> Locales { get; set; }
    }

    public partial class Empleado
    {
        [JsonProperty("trabajadores")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Trabajadores { get; set; }

        [JsonProperty("pensionistas")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Pensionistas { get; set; }

        [JsonProperty("prestadores_servicio")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PrestadoresServicio { get; set; }
    }

    public partial class RepresentanteLegal
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("cargo")]
        public string Cargo { get; set; }

        [JsonProperty("desde")]
        public DateTimeOffset Desde { get; set; }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    public partial class RUCNaturalEntity
    {
        [JsonProperty("ruc")]
        public string Ruc { get; set; }

        [JsonProperty("razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty("ciiu")]
        public string Ciiu { get; set; }

        [JsonProperty("fecha_actividad")]
        public DateTimeOffset FechaActividad { get; set; }

        [JsonProperty("contribuyente_condicion")]
        public string ContribuyenteCondicion { get; set; }

        [JsonProperty("contribuyente_tipo")]
        public string ContribuyenteTipo { get; set; }

        [JsonProperty("contribuyente_estado")]
        public string ContribuyenteEstado { get; set; }

        [JsonProperty("nombre_comercial")]
        public string NombreComercial { get; set; }

        [JsonProperty("fecha_inscripcion")]
        public DateTimeOffset FechaInscripcion { get; set; }

        [JsonProperty("domicilio_fiscal")]
        public string DomicilioFiscal { get; set; }

        [JsonProperty("sistema_emision")]
        public string SistemaEmision { get; set; }

        [JsonProperty("sistema_contabilidad")]
        public string SistemaContabilidad { get; set; }

        [JsonProperty("actividad_exterior")]
        public string ActividadExterior { get; set; }

        [JsonProperty("emision_electronica")]
        public DateTimeOffset EmisionElectronica { get; set; }

        [JsonProperty("fecha_inscripcion_ple")]
        public string FechaInscripcionPle { get; set; }

        [JsonProperty("Oficio")]
        public string Oficio { get; set; }

        [JsonProperty("fecha_baja")]
        public string FechaBaja { get; set; }

        [JsonProperty("representante_legal")]
        public List<object> RepresentanteLegal { get; set; }

        [JsonProperty("empleados")]
        public List<object> Empleados { get; set; }

        [JsonProperty("locales")]
        public List<object> Locales { get; set; }
    }
}
