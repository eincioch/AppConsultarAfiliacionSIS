﻿using EVSoft.Dominio.ConsultSIS.Entities;
using EVSoft.WebApi.ConsultSIS.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVSoft.WebApi.ConsultSIS.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")] //se agrego
    [EnableCors("CorsPolicy")] //Habilita la politica CORS
    [Route("api/[controller]")]
    [ApiController]
    public class SISAfiliacionController : ControllerBase
    {

        private readonly ILoggerService _logger;

        public SISAfiliacionController(ILoggerService logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Consultar Afiliado SIS MINSA
        /// </summary>
        /// <param name="tiDocumento"></param>
        /// <param name="nuDocumento"></param>
        /// <returns></returns>
        [HttpGet("{tiDocumento}/{nuDocumento}")]
        public async Task<IEnumerable<AfiliadoEntity>> Get(string tiDocumento, string nuDocumento)
        {
            List<AfiliadoEntity> afiliadoEntities = new List<AfiliadoEntity>();
            try
            {
                _logger.LogInfo("Consulta afiliación");

                //pasa parameters
                var afiliadoSis = new WSISAfiliacion.afiliadoSisRequestType();
                afiliadoSis.tiDocumento = tiDocumento;
                afiliadoSis.nuDocumento = nuDocumento;

                //devuelve object
                var objResponce = new WSISAfiliacion.AfiliadoSisServiceClient();

                AfiliadoEntity afiliadoEntity;
                

                //AfiliadoResumenEntity afiliadoEntity;
                //List<AfiliadoResumenEntity> afiliadoEntities = new List<AfiliadoResumenEntity>();

                var objAfiliado = await objResponce.afiliadoSisAsync(afiliadoSis).ConfigureAwait(true);

                foreach (var item in objAfiliado.afiliadoSisResponse1)
                {
                    afiliadoEntity = new AfiliadoEntity()
                    {
                        //nuError = item.nuError,
                        //deEstado = item.deEstado,
                        //apPaterno = item.apPaterno,
                        //apMaterno = item.apMaterno,
                        //deNombres = item.deNombres,
                        //nuAfiliacion = item.nuAfiliacion,
                        //tiDocumento = item.tiDocumento,
                        //nuDocumento = item.nuDocumento

                        codError = item.codError,
                        resultado = item.resultado,
                        tipoDocumento = item.tipoDocumento,
                        nroDocumento = item.nroDocumento,
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

                
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return afiliadoEntities;
        }
    }
}