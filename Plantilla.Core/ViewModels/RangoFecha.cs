using System;
using System.ComponentModel.DataAnnotations;

namespace plantilla.Core.ViewModels
{
    /// <summary>
    /// Vista de rango fecha
    /// </summary>
    public class RangoFecha
    {
        [Required]
        public DateTime Inicio { get; set; }
        [Required]
        public DateTime Fin { get; set; }

    }
}
