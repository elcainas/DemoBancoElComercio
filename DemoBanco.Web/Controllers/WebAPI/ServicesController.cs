using DemoBanco.Business.Component;
using DemoBanco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoBanco.Web.Controllers
{
    [RoutePrefix("api/Services")]
    public class ServicesController : ApiController
    {
        private BCOrdenPago _bcOrdenPago;
        private BCOrdenPago BCOrdenPago
        {
            get
            {
                _bcOrdenPago = _bcOrdenPago == null ? new BCOrdenPago() : _bcOrdenPago;
                return _bcOrdenPago;
            }
        }

        private BCSucursal _bcSucursal;
        private BCSucursal BCSucursal
        {
            get
            {
                _bcSucursal = _bcSucursal == null ? new BCSucursal() : _bcSucursal;
                return _bcSucursal;
            }
        }

        [HttpGet]
        [Route("ListOrdenPagoBySucursal/{sucursalId}/{moneda?}")]
        public IEnumerable<OrdenPago> ListOrdenPagoBySucursal(int sucursalId, string moneda = null)
        {
            return BCOrdenPago.ListBySucursal(sucursalId, moneda);
        }

        [HttpGet]
        [Route("ListSucursalByBanco/{bancoId}")]
        // GET: api/Sucursal
        public IHttpActionResult ListSucursalByBanco(int bancoId)
        {
            var model= BCSucursal.ListByBanco(bancoId);
            return Content(HttpStatusCode.OK, model, Configuration.Formatters.XmlFormatter);
        }
    }
}
