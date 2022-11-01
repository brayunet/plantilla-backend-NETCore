using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Utils.Repository;
using plantilla.Core.DbQueries;
using plantilla.Core.Models;

namespace plantilla.Core.Repositories
{
    /// <summary>
    /// Interfaz para el programa del responsable
    /// </summary>
    public interface IOpcionDeFinanciacionRepository : IRepository<OpcionDeFinanciacion>
    {
        //Task<IEnumerable<Componente>> GetByTareaAsync(long tareaId);
        //Task<IEnumerable<RolPermisoCampo>> GetPermisosAsync(long componenteId);

        /// <summary>
        /// Interfaz para obtener los prgramas con el nombre del tipo
        /// </summary>
        /// <returns></returns>
      List <OpcionDeFinanciacion> GetOpcionesDeFinanciacion(string importe, string sueldo, double totalDeDias, int cedula);

        


    }
}
