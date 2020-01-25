using System;
using System.Collections.Generic;
using System.Text;

namespace EVSoft.Dominio.ConsultSIS.Entities
{
    public class AfiliadoResumenEntity
    {
        public  string nuAfiliacion { get; set; }
        public string tiDocumento { get; set; }
        public string nuDocumento { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string deNombres { get; set; }
        public string deEstado { get; set; }
        public string nuError { get; set; }
    }
}
