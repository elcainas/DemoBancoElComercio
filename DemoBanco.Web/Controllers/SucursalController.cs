using AutoMapper;
using DemoBanco.Business.Component;
using DemoBanco.Business.Interface;
using DemoBanco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoBanco.Web.Controllers
{
    public class SucursalController : BaseController
    {
        private BCSucursal _bcSucursal;
        private BCSucursal BCSucursal
        {
            get
            {
                _bcSucursal = _bcSucursal == null ? new BCSucursal() : _bcSucursal;
                return _bcSucursal;
            }
        }
        private BCBanco _bcBanco;
        private BCBanco BCBanco
        {
            get
            {
                _bcBanco = _bcBanco == null ? new BCBanco() : _bcBanco;
                return _bcBanco;
            }
        }
        // GET: Sucursal
        public ActionResult Index()
        {
            var entities = BCSucursal.ListAll();
            var model = Mapper.Map<List<Sucursal>>(entities);
            return View(model);
        }

        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            var entity = BCSucursal.Get(id);
            var model = Mapper.Map<Sucursal>(entity);

            return View(model);
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            PopulateBancosDropDownList();
            return View();
        }

        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(Sucursal model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Business.Entities.Sucursal>(model);
                    BCSucursal.Create(entity);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //todo:
            }
            return View(model);
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var entity = BCSucursal.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var model = Mapper.Map<Sucursal>(entity);
                PopulateBancosDropDownList(model.BancoId);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(Sucursal model)
        {
            try
            {
                var entity = Mapper.Map<Business.Entities.Sucursal>(model);
                BCSucursal.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model.Id);
            }
        }
        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var entity = BCSucursal.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var model = Mapper.Map<Sucursal>(entity);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                BCSucursal.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
        private void PopulateBancosDropDownList(object selected = null)
        {
            var bancos = BCBanco.ListAll();
            ViewBag.BancoId = new SelectList(bancos, "Id", "Nombre", selected);
        }

    }
}
