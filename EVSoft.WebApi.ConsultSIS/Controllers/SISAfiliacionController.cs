using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVSoft.WebApi.ConsultSIS.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVSoft.WebApi.ConsultSIS.Controllers
{
    [Produces("application/json")] //se agrego
    [EnableCors("CorsPolicy")] //Habilita la politica CORS
    [Route("api/[controller]")]
    [ApiController]
    public class SISAfiliacionController : ControllerBase
    {

        [HttpGet("{tiDocumento}/{nuDocumento}")]
        public IEnumerable<AfiliadoEntity> Get(string tiDocumento, string nuDocumento) {

            //pasa parameters
            var afiliadoSis = new WSISAfiliacion.afiliadoSisRequestType();
            afiliadoSis.tiDocumento = tiDocumento;
            afiliadoSis.nuDocumento = nuDocumento;

            //devuelve object
            var objResponce = new WSISAfiliacion.;

            AfiliadoEntity afiliadoEntity;
            List<AfiliadoEntity> afiliadoEntities = new List<AfiliadoEntity>();

            foreach (var item in objResponce.FirstOrDefault(afiliadoSis))
            {
                afiliadoEntity = new AfiliadoEntity()
                {
                    codError=item.codError,
                    resultado=item.resultado,
                    tipoDocumento=item.tipoDocumento,
                    nroDocumento=item.nroDocumento,
                    apePaterno = item.apePaterno,
                    apeMaterno = item.apeMaterno,
                    nombres = item.nombres,
                    //datos centro de atencion
                    fecAfiliacion = item.fecAfiliacion,
                    eess = item.eess,
                    descEESS = item.descEESS,
                    eessUbigeo = item.eessUbigeo,
                    descEESSUbigeo = item.descEESSUbigeo,
                    regimen = item.regimen,
                    tipoSeguro = item.tipoSeguro,
                    descTipoSeguro = item.descTipoSeguro,
                    contrato = item.contrato,
                    fecCaducidad = item.fecCaducidad,
                    estado = item.estado,

                    tabla = item.tabla,
                    idNumReg = item.idNumReg,
                    genero = item.genero,
                    fecNacimiento = item.fecNacimiento,
                    idUbigeo = item.idUbigeo,
                    direccion = item.direccion,
                    disa = item.disa,
                    tipoFormato = item.tipoFormato,
                    nroContrato = item.nroContrato,
                    correlativo = item.correlativo,
                    idPlan = item.idPlan,
                    idGrupoPoblacional = item.idGrupoPoblacional,
                    msgConfidencial = item.msgConfidencial
                };
                afiliadoEntities.Add(afiliadoEntity);
            }

            return afiliadoEntities;
        }
    }
}