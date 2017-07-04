using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBanco.Web.Models
{
    public class OrdenPago
    {
        public int Id { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public string Moneda { get; set; }
        [Required]
        public string Estado { get; set; }
        [Display(Name = "Fecha de Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }
        [Required]
        public int SucursalId { get; set; }
        public Sucursal Sucursal{ get; set; }

    }
}