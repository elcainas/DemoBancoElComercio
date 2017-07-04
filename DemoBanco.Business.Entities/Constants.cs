using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBanco.Business.Entities
{
    public static class Constants
    {
        public static List<string> Monedas
        {
            get
            {
                return new List<string> { "USD", "PEN" };
            }
        }
        public static List<string> EstadoOrdenPago
        {
            get
            {
                return new List<string> { "Declinada", "Fallida", "Anulada" };
            }
        }
    }
}