using System;

namespace plantilla.Core.Utilidades
{
    /// <summary>
    /// Generar n�mero aleatorio
    /// </summary>
    public static class GenRandom
    {
        /// <summary>
        /// Generar un n�mero aleatorio de 6 d�gitos
        /// </summary>
        /// <returns>N�mero aleatorio</returns>
        public static int ObtenerRandom()
        {
            Random rnd = new Random();
            int valor = rnd.Next(100000, 999999);
            return valor;
        }
    }
}