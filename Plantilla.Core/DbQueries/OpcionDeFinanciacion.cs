using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.DbQueries
{
    public class OpcionDeFinanciacion
    {

        public decimal IMPORTE { get; set; }
        public int CUOTAS { get; set; }
        public decimal IMPORTE_CUOTA { get; set; }
        public decimal IMPORTE_TOTAL { get; set; }
        public decimal TEA { get; set; }
        public decimal MORA { get; set; }
        public int DIAS { get; set; }
        public decimal GASTOREAL { get; set; }
        public decimal PRIMA { get; set; }
        public decimal SEGURO { get; set; }
    }
}
