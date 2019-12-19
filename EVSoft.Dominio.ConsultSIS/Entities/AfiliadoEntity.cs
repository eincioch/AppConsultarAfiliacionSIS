using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVSoft.WebApi.ConsultSIS.Model
{
    public class AfiliadoEntity
    {
        public string codError { get; set; }
        public string resultado { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string nombres { get; set; }
        public string fecAfiliacion { get; set; }
        public string eess { get; set; }
        public string descEESS { get; set; }
        public string eessUbigeo { get; set; }
        public string descEESSUbigeo { get; set; }
        public string regimen { get; set; }
        public string tipoSeguro { get; set; }
        public string descTipoSeguro { get; set; }
        public string contrato { get; set; }
        public string fecCaducidad { get; set; }
        public string estado { get; set; }
        public string tabla { get; set; }
        public string idNumReg { get; set; }
        public string genero { get; set; }
        public string fecNacimiento { get; set; }
        public string idUbigeo { get; set; }
        public string direccion { get; set; }
        public string disa { get; set; }
        public string tipoFormato { get; set; }
        public string nroContrato { get; set; }
        public string correlativo { get; set; }
        public string idPlan { get; set; }
        public string idGrupoPoblacional { get; set; }
        public string msgConfidencial { get; set; }
    }
}
