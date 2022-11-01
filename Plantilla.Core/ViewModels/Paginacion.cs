using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.ViewModels
{
    public class Paginacion
    {
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public bool TienePaginaPrevia { get; set; }
        public bool TienePaginaSiguiente { get; set; }
    }
}
