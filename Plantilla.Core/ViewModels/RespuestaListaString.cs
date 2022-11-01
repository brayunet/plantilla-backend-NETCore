using System.Collections.Generic;

namespace plantilla.Core.ViewModels
{
    /// <summary>
    /// Clase envoltorio de respuesta para consultas graphql que devuelven un booleano
    /// </summary>
    public class RespuestaListaString
    {
        /// <summary>
        /// Campo respuesta de tipo booleano
        /// </summary>
        public List<string> Respuesta { get; set; }
    }
}
