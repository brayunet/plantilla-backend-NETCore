
using Common.Utils.CustomTypes;
using Common.Utils.Exceptions;
using Common.Utils.General;
using Common.Utils.JWT;
using Common.Utils.Loggers;
using Common.Utils.Media;
using Common.Utils.Redirecccionamiento;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using plantilla.Core;
//using plantilla.Core.DbQueries;
using plantilla.Core.Models;
using plantilla.Core.ViewModels;
using System.Collections;
using plantilla.Core.DbQueries;

namespace plantilla.Api.Graphql.Queries
{
    /// <summary>
    /// Operaciones de consultas
    /// </summary>
    public class Query
    {
       

        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Representa el contexto en el cual fue llamado el middleware. Deberia ser inyectado.
        /// </summary>        
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Representa la configuracion del servicio. Deberia ser inyectado.
        /// </summary>
        private readonly IConfiguration _config;
        /// <summary>
        /// Representa la instancia de un calls para hacer llamados externos a rest y graphql
        /// </summary>
        private readonly Calls _Cliente;
        /// <summary>
        /// Representa la instancia del logger
        /// </summary>
        protected readonly ILogger _logger;

        public Query(IUnitOfWork unitOfWork, IHttpContextAccessor accessor, ILogger<Query> logger, IConfiguration config, Calls cliente)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _httpContextAccessor = accessor;
            _config = config;
            _logger = logger;
            _Cliente = cliente;
            
        }


        /// <summary>
        /// Obtener todas las obciones de financiacion
        /// </summary>
        /// <returns>Listado de mï¿½dulos</returns>
        public List<OpcionDeFinanciacion> GetOpcionesDeFinanciacion(string importe, string sueldo, double totalDeDias, int cedula)
        {
            List<OpcionDeFinanciacion> opcionesFinanciacion = _unitOfWork.OpcionDeFinanciaciones.GetOpcionesDeFinanciacion(importe, sueldo, totalDeDias, cedula);
            return opcionesFinanciacion;
        }


        /// <summary>
        /// Obtener todas las obciones de financiacion
        /// </summary>
        /// <returns>Listado de mï¿½dulos</returns>
        public List<ConsultarEstadoplantillainTarjeta> GetConsultarEstadoplantillainTarjetas(long idplantilla)
        {
            List<ConsultarEstadoplantillainTarjeta> estadoplantillainTarjeta = _unitOfWork.ConsultarEstadoplantillainTarjetas.GetConsultarEstadoplantillainTarjeta(idplantilla);
            return estadoplantillainTarjeta;
        }






    }
}
