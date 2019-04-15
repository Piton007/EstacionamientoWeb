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
    public class EstacionamientoController : Controller
    {
        private IEstacionamientoServicio estacionamientoServicio = new EstacionamientoServicioImpl();
        private ILocalizacionServicio localizacionServicio = new LocalizacionServicioImpl();
        // GET: Estacionamiento
        public ActionResult Index()
        {
            return View(estacionamientoServicio.FindAll());
        }
        public ActionResult Create()
        {
            ViewBag.localizaciones = localizacionServicio.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Estacionamiento estacionamient)
        {
            ViewBag.localizaciones = localizacionServicio.FindAll();
            bool rptaInsert = estacionamientoServicio.Insert(estacionamient);
            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            Estacionamiento estacionamiento = estacionamientoServicio.FindById(id);
            return View(estacionamiento);
        }
        [HttpPost]
        public ActionResult Delete(Estacionamiento estacionamiento)
        {
            ViewBag.localizaciones = localizacionServicio.FindAll();
            bool rpta = estacionamientoServicio.Delete(estacionamiento.Id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.localizaciones = localizacionServicio.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }

            Estacionamiento estacionamiento = estacionamientoServicio.FindById(id);


            return View(estacionamiento);
        }

        [HttpPost]
        public ActionResult Edit(Estacionamiento estacionamiento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool rptaEdit = estacionamientoServicio.Update(estacionamiento);

            if (rptaEdit)
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
            Estacionamiento estacionamiento = estacionamientoServicio.FindById(id);
            return View(estacionamiento);
        }
    }
}