using System.Security.Cryptography;
using System.Text;

namespace plantilla.Core.Utilidades
{
    /// <summary>
    /// Codificar cadenas
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Generar SHA256
        /// </summary>
        /// <param name="entrada">Cadena a codificar</param>
        /// <returns>Cadena codificada</returns>
        public static string GenerarSHA256(string entrada)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(entrada);
            byte[] hash = sha256.ComputeHash(bytes);
            return GenerarCadena(hash);
        }

        /// <summary>
        /// Generar cadena
        /// </summary>
        /// <param name="hash">Hash</param>
        /// <returns>Cadena hasheada</returns>
        private static string GenerarCadena(byte[] hash)
        {
            StringBuilder resultado = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                resultado.Append(hash[i].ToString("X2"));
            }
            return resultado.ToString();
        }
    }
}
