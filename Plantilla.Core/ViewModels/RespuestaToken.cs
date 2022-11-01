using System;

namespace plantilla.Core.ViewModels
{
    /// <summary>
    /// Clase envoltorio de respuesta para consultas graphql que devuelven un Cliente
    /// </summary>
    public class RespuestaToken
    {
        public AuthToken Respuesta { get; set; }
    }

    public class AuthToken
    {
        public string AccessToken { get; set; }
        public long SesionId { get; set; }
        public DateTime Expiracion { get; set; }
    }

}
