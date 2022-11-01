using Common.Utils.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using plantilla.Core.DbQueries;
using plantilla.Core.Models;
using plantilla.Core.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace plantilla.Persistence.Repositories
{
    /// <summary>
    /// Persistencia para permiso del repositorio
    /// </summary>
    public class OpcionDeFinanciacionRepository : Repository<OpcionDeFinanciacion>, IOpcionDeFinanciacionRepository
    {
        /// <summary>
        /// importa el DbContexto
        /// </summary>
        /// <param name="context"></param>
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public OpcionDeFinanciacionRepository(DbContext context, ILogger<OpcionDeFinanciacionRepository> logger, IConfiguration config, IHttpContextAccessor contextAccessor) : base(context)
        {
            _logger = logger;
            _config = config;
            _contextAccessor = contextAccessor;
        }
        public plantillaContext plantillaContext
        {
            get { return Context as plantillaContext; }
        }



        /// <summary>
        /// Devuelve un proceso estado de negocio segun el id
        /// </summary>
        /// <paramref name="importe"/>
        /// <paramref name="sueldo"/>
        /// <paramref name="totalDeDias"/>
        /// <paramref name="cedula"/>
        /// <returns>Retorna la tabla de proceso estado de negocio.</returns>
        public List <OpcionDeFinanciacion> GetOpcionesDeFinanciacion(string importe, string sueldo, double totalDeDias, int cedula)
        {
            //var opciones = plantillaContext.OpcionesDeFinanciacion.FromSql($"CONSULTA_SIMULADOR_ORDENES @importe,@sueldo,@TOTALDIAS,@CLICED", parametrosDeOpcionesDeFinanciacion).ToList();
            

            
            List<SqlParameter> parametrosDeOpcionesDeFinanciacion = new List<SqlParameter>();

          

            List<OpcionDeFinanciacion> opciones = plantillaContext.OpcionDeFinanciacion.FromSql($"CONSULTA_SIMULADOR_ORDENES {importe}, {sueldo}, {totalDeDias}, {cedula}").ToList();



            return opciones;
            


            
        }

        
    }
}
