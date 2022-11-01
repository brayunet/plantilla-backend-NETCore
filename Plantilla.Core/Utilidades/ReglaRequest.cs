using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.Utilidades
{
    public class ReglaRequest
    {
        public ReglaRequest(string nombre, string valor, long rolId)
        {
            Nombre = nombre;
            Valor = valor;
            RolId = rolId;
        }

        public string Nombre { get; set; }
        public string Valor { get; set; }
        public long RolId { get; set; }
    }
}
