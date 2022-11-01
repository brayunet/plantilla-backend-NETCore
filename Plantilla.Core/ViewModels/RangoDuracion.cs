using System.ComponentModel.DataAnnotations;

namespace plantilla.Core.ViewModels
{
    /// <summary>
    /// Vista de rango duración
    /// </summary>
    public class RangoDuracion
    {
        [Required]
        public int Min { get; set; }
        [Required]
        public int Max { get; set; }

    }
}