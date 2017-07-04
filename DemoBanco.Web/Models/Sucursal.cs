using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBanco.Web.Models
{
    public class Sucursal : Sede
    {
        [Required]
        public int BancoId { get; set; }
        public Banco Banco { get; set; }
    }
}