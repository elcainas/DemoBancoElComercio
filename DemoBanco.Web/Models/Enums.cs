using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBanco.Web.Models
{
    public enum EstadoOrdenPago
    {
        [Display(Name = "Declinada")]
        Declinada = 0,
        [Display(Name = "Fallida")]
        Fallida = 1,
        [Display(Name = "Anulada")]
        Anulada = 2
    }
    public enum Moneda
    {
        [Display(Name = "Soles")]
        Soles = 0,
        [Display(Name = "Dolares")]
        Dolares = 1
    }
}