using Entidades;
using Negocios;
using Negocios.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class LocalizacionController : Controller
    {
        private ILocalizacionServicio localizacionService = new LocalizacionServicioImpl();
        // GET: Localizacion
        public ActionResult Index()
        {
            return View(localizacionService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Localizacion local)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create");
            bool rpta = localizacionService.Insert(local);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
           
            return View();
        }
        //
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(localizacionService.FindById(id));
        }
        [HttpPost]
        public ActionResult Delete(Localizacion local)
        {
            bool rpta = localizacionService.Delete(local.CodLocalizacion);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(localizacionService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Localizacion local)
        {
            bool rpta = localizacionService.Update(local);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var nuevo = localizacionService.FindById(id);

            return View(nuevo);
        }
    }
}