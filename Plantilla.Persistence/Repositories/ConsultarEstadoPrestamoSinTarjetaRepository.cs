using System;

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
using System.Text;

namespace plantilla.Persistence.Repositories
{
    public class ConsultarEstadoplantillainTarjetaRepository : Repository<ConsultarEstadoplantillainTarjeta>, IConsultarEstadoplantillainTarjetaRepository
    {
        /// <summary>
        /// importa el DbContexto
        /// </summary>
        /// <param name="context"></param>
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;


        public ConsultarEstadoplantillainTarjetaRepository(DbContext context, ILogger<ConsultarEstadoplantillainTarjetaRepository> logger, IConfiguration config, IHttpContextAccessor contextAccessor) : base(context)
        {
            _logger = logger;
            _config = config;
            _contextAccessor = contextAccessor;
        }

        public plantillaContext plantillaContext
        {
            get { return Context as plantillaContext; }
        }

        public List<ConsultarEstadoplantillainTarjeta> GetConsultarEstadoplantillainTarjeta(long idplantilla)
        {
            throw new NotImplementedException();
        }
    }
}
