using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBanco.Web.Models
{
    public class Banco : Sede
    {
        public List<Sucursal> Sucursales { get; set; }
    }
}