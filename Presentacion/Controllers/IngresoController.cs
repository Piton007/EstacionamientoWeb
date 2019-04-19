using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocios;
using Negocios.Implementacion;
using Entidades;

namespace Presentacion.Controllers
{
    public class IngresoController : Controller
    {
        private IIngresoServicio ingresoServicio = new IngresoServicioImpl();
        private ITarifaServicio tarifaServicio = new TarifaServicioImpl();
        private ICajeroServicio cajeroServicio = new CajeroServicioImpl();
        private IEspacioServicio espacioServicio = new EspacioServicioImpl();
        // GET: Ingreso
        public ActionResult Index()
        {
            return View(ingresoServicio.FindAll());
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.tarifas = tarifaServicio.FindAll();
            ViewBag.cajeros = cajeroServicio.FindAll();
            ViewBag.espacios = espacioServicio.FindAll();
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Ingreso ing)
        {
            bool inserto = ingresoServicio.Insert(ing);
            if (inserto)
                return RedirectToAction("Create");
            return View();
        }

        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(ingresoServicio.FindById(id));
        }
        //POST
        [HttpPost]
        public ActionResult Delete(Ingreso ing)
        {
            bool elemino = ingresoServicio.Delete(ing.CodIngreso);
            if (elemino)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET
        public ActionResult Edit(int? id)
        {
            ViewBag.tarifas = tarifaServicio.FindAll();
            ViewBag.cajeros = cajeroServicio.FindAll();
            ViewBag.espacios = espacioServicio.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(ingresoServicio.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Ingreso ing)
        {
            ViewBag.tarifas = tarifaServicio.FindAll();
            ViewBag.cajeros = cajeroServicio.FindAll();
            ViewBag.espacios = espacioServicio.FindAll();
            bool edito= ingresoServicio.Update(ing);
            if (edito)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        //GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(ingresoServicio.FindById(id));
        }
    }
}