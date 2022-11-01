namespace plantilla.Core.ViewModels
{
    /// <summary>
    /// Clase envoltorio de respuesta para consultas graphql que devuelven un booleano
    /// </summary>
    public class RespuestaString
    {
        /// <summary>
        /// Campo respuesta de tipo booleano
        /// </summary>
        public string Respuesta { get; set; }
    }
}
