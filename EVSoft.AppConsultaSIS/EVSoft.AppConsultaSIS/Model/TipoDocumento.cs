using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EVSoft.AppConsultaSIS.Model
{
    [DataContract]
    public class TipoDocumento
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "descr")]
        public string Descr { get; set; }
    }

    public class TipoDocumentoData
    {

        public static List<TipoDocumento> tipoDocumentos { get; private set; }

        static TipoDocumentoData()
        {
            tipoDocumentos = new List<TipoDocumento>();

            tipoDocumentos.Add(new TipoDocumento { Id = 1, Descr = "Documento Nacional Identidad" });
            tipoDocumentos.Add(new TipoDocumento { Id = 2, Descr = "Cedula Extranjera" });
        }
    }
}
