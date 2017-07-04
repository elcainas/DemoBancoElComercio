using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanco.Business.Entities
{
    public enum EstadoOrdenPago
    {
        Declinada = 0,
        Fallida = 1,
        Anulada = 2
    }
    public enum Moneda
    {
        Soles = 0,
        Dolares = 1
    }
}
