using AutoMapper;
using DemoBanco.Business.Component;
using DemoBanco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoBanco.Web.Controllers
{
    public class OrdenPagoController : BaseController
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
        // GET: OrdenPago
        public ActionResult Index()
        {
            var entities = BCOrdenPago.ListAll();
            var model = Mapper.Map<List<OrdenPago>>(entities);
            return View(model);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            var entity = BCOrdenPago.Get(id);
            var model = Mapper.Map<OrdenPago>(entity);
            return View(model);
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            PopulateEstadoOrdenPagoDropDownList();
            PopulateMonedasDropDownList();
            PopulateSucursalesDropDownList();
            return View();
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(OrdenPago model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Business.Entities.OrdenPago>(model);
                    BCOrdenPago.Create(entity);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //todo:
            }
            return View(model);
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var entity = BCOrdenPago.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var model = Mapper.Map<OrdenPago>(entity);
                PopulateEstadoOrdenPagoDropDownList(entity.Estado);
                PopulateMonedasDropDownList(entity.Moneda);
                PopulateSucursalesDropDownList(entity.Sucursal);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(OrdenPago model)
        {
            try
            {
                var entity = Mapper.Map<Business.Entities.OrdenPago>(model);
                BCOrdenPago.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model.Id);
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var entity = BCOrdenPago.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var model = Mapper.Map<OrdenPago>(entity);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: OrdenPago/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                BCOrdenPago.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
        private void PopulateSucursalesDropDownList(object selected = null)
        {
            var sucursales = BCSucursal.ListAll();
            ViewBag.SucursalId = new SelectList(sucursales, "Id", "Nombre", selected);
        }
        private void PopulateMonedasDropDownList(object selected = null)
        {
            var monedas = Business.Entities.Constants.Monedas;
            ViewBag.Moneda = new SelectList(monedas, selected);
        }
        private void PopulateEstadoOrdenPagoDropDownList(object selected = null)
        {
            var estados = Business.Entities.Constants.EstadoOrdenPago;
            ViewBag.Estado = new SelectList(estados, selected);
        }
    }
}
