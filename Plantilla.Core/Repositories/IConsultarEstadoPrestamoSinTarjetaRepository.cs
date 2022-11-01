
using Common.Utils.Repository;
using plantilla.Core.DbQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.Repositories
{
    public interface IConsultarEstadoplantillainTarjetaRepository : IRepository<ConsultarEstadoplantillainTarjeta>
    {
        /// <summary>
        /// Interfaz para obtener el nombre del estado del plantilla
        /// </summary>
        /// <returns></returns>
        List<ConsultarEstadoplantillainTarjeta> GetConsultarEstadoplantillainTarjeta(long idplantilla);
    }
}
