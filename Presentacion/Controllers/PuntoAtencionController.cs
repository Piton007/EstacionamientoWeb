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
    public class PuntoAtencionController : Controller
    {
        private IPuntoAtencionServicio paServicio = new PuntoAtencionServicioImpl();
        // GET: PuntoAtencion
        public ActionResult Index()
        {
            return View(paServicio.FindAll());
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PuntoAtencion pa)
        {
            bool inserto = paServicio.Insert(pa);
            if (inserto)
                return RedirectToAction("Create");
            return View();
        }

        //GET
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool elimino = paServicio.Delete(id);
            if (elimino)
                return RedirectToAction("Index");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var pa = paServicio.FindAll().Where(p => p.Id == id).FirstOrDefault();
            return View(pa);
        }

        [HttpPost]
        public ActionResult Edit(PuntoAtencion pa)
        {
            bool actualizo = paServicio.Update(pa);
            if (actualizo)
                return RedirectToAction("Index");
            return View();
        }
    }
}