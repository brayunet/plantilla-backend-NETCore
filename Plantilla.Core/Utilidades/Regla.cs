using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plantilla.Core.Utilidades
{
    public class Regla
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
       
        public Regla(string nombre,string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
