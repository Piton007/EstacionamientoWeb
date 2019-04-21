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
    public class EspacioController : Controller
    {
        private IEspacioServicio espacioServicio = new EspacioServicioImpl();
        private IEstacionamientoServicio estacionamientoServicio = new EstacionamientoServicioImpl();
        //GET: Espacio
        public ActionResult Index()
        {
            return View(espacioServicio.FindAll());
        }
        public ActionResult Create()
        {
            ViewBag.estacionamientos = estacionamientoServicio.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Espacio espacio)
        {
            ViewBag.estacionamientos = estacionamientoServicio.FindAll();
            bool rptaInsert = espacioServicio.Insert(espacio);
            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Estacionamiento estacionamiento = estacionamientoServicio.FindById(id);
            return View(estacionamiento);
        }
        [HttpPost]
        public ActionResult Delete(Espacio espacio)
        {
            ViewBag.estacionamientos = estacionamientoServicio.FindAll();
            bool rpta = espacioServicio.Delete(espacio.Id);
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
            ViewBag.estacionamientos = estacionamientoServicio.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }

            Espacio espacio = espacioServicio.FindById(id);


            return View(espacio);
        }

        [HttpPost]
        public ActionResult Edit(Espacio espacio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool rptaEdit = espacioServicio.Update(espacio);

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
            Espacio espacio = espacioServicio.FindById(id);
            return View(espacio);
        }
    }

}

