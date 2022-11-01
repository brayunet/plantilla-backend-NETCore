
using Common.Utils.Redirecccionamiento;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Linq;
using System.Threading.Tasks;

using plantilla.Core;
using plantilla.Core.Repositories;
using plantilla.Persistence.Repositories;
using plantilla.Core.Models;
//using plantilla.Core.Repositories;
//using plantilla.Persistence.Repositories;

namespace plantilla.Persistence
{
    /// <summary>
    /// Clase para persistir los cambios 
    /// de la data en la BD
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        // Contexto de base de datos
        private readonly plantillaContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly Calls _cliente;



        // Colecciones 
        public IOpcionDeFinanciacionRepository OpcionDeFinanciaciones { get; private set; }
        public IConsultarEstadoplantillainTarjetaRepository ConsultarEstadoplantillainTarjetas { get; private set; }



        /// <summary>
        /// Constructor que recibe el contexto de base 
        /// de datos e inicializa los repositorios
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public UnitOfWork(plantillaContext context
            , IHttpContextAccessor contextAccessor
            , IConfiguration config
            , ILoggerFactory loggerFactory
            , Calls calls
            /* , ApplicationRoleParams appRoleParam*/
            )
        {

            _context = context;
            _contextAccessor = contextAccessor;
            _config = config;
            _cliente = calls;

            //context.setApplicationRoleParametro(appRoleParam);

            OpcionDeFinanciaciones = new OpcionDeFinanciacionRepository(_context, loggerFactory.CreateLogger<OpcionDeFinanciacionRepository>(), _config, _contextAccessor);
            ConsultarEstadoplantillainTarjetas = new ConsultarEstadoplantillainTarjetaRepository(_context, loggerFactory.CreateLogger<ConsultarEstadoplantillainTarjetaRepository>(), _config, _contextAccessor);
            

        }

        /// <summary>
        /// Método para persistir los cambios de
        /// las colecciones en la base de datos
        /// </summary>
        /// <returns>Valor entero resultado de la operación</returns>
        public async Task<int> Complete()
        {
            var entries = _context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntidadBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Modified)
                {
                    ((EntidadBase)entityEntry.Entity).FechaModificacion = DateTime.Now;
                    //Asignar al registro entrante la fecha de creación original
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = ((EntidadBase)entityEntry.OriginalValues.Clone().ToObject()).FechaCreacion;
                }
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = DateTime.Now;
                }
            }

            // return base.SaveChanges();


            //int resultado = 
            return await _context.SaveChangesAsync();

            //if (resultado == 0)
            //{

            //    throw new BusinessException("ID8-FALLO-AL-GUARDAR");
            //}

            //return resultado;
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
