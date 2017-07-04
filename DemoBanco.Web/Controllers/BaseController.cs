using AutoMapper;
using DemoBanco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBanco.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Banco, Business.Entities.Banco>();
                cfg.CreateMap<Business.Entities.Banco, Banco>();
                cfg.CreateMap<Sucursal, Business.Entities.Sucursal>();
                cfg.CreateMap<Business.Entities.Sucursal, Sucursal>();
                cfg.CreateMap<OrdenPago, Business.Entities.OrdenPago>();
                cfg.CreateMap<Business.Entities.OrdenPago, OrdenPago>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}