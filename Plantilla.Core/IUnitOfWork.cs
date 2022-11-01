using plantilla.Core.Repositories;
using System.Threading.Tasks;

//using plantilla.Core.Repositories;

namespace plantilla.Core
{
    /// <summary>
    /// Interfaz para el manejo de las operaciones
    /// relacionadas con la base de datos
    /// </summary>
    public interface IUnitOfWork //: IDisposable
    {


        /// <summary>
        /// Interface de actividades
        /// </summary>
        IOpcionDeFinanciacionRepository OpcionDeFinanciaciones { get; }
        IConsultarEstadoplantillainTarjetaRepository ConsultarEstadoplantillainTarjetas { get; }
        



        Task<int> Complete();
    }
}
