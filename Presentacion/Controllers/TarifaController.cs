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
    public class TarifaController : Controller
    {
        private ITarifaServicio tarifaService = new TarifaServicioImpl();
        // GET: Tarifa
        public ActionResult Index()
        {
            return View(tarifaService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tarifa tarifa)
        {
            bool rpta = tarifaService.Insert(tarifa);
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
            return View(tarifaService.FindById(id));
        }
        [HttpPost]
        public ActionResult Delete(Tarifa tarifa)
        {
            bool rpta = tarifaService.Delete(tarifa.Id);
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
            return View(tarifaService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Tarifa tarifa)
        {
            bool rpta = tarifaService.Update(tarifa);
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
            var nuevo = tarifaService.FindById(id);

            return View(nuevo);
        }
    }
}