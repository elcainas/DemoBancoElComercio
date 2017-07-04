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
    public class BancoController : BaseController
    {
        private BCBanco _bcBanco;
        private BCBanco BCBanco
        {
            get
            {
                _bcBanco = _bcBanco == null ? new BCBanco() : _bcBanco;
                return _bcBanco;
            }
        }

        // GET: Banco
        public ActionResult Index()
        {
            var entities = BCBanco.ListAll();
            var model = Mapper.Map<List<Banco>>(entities);
            return View(model);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            var entity = BCBanco.Get(id);
            var model = Mapper.Map<Banco>(entity);
            return View(model);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(Banco model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Business.Entities.Banco>(model);
                    BCBanco.Create(entity);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //todo:
            }
            return View(model);
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var entity = BCBanco.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var model = Mapper.Map<Banco>(entity);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(Banco model)
        {
            try
            {
                var entity = Mapper.Map<Business.Entities.Banco>(model);
                BCBanco.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model.Id);
            }
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var entity = BCBanco.Get(id);
                if (entity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var model = Mapper.Map<Banco>(entity);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                BCBanco.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
    }
}
