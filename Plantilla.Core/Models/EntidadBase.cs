using System;

namespace plantilla.Core.Models
{
    /// <summary>
    /// Entidad base para todos los modelos del proyecto
    /// </summary>
    public class EntidadBase
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
