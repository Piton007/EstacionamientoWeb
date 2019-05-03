using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocios;
using Negocios.Implementacion;

namespace Presentacion.Controllers
{
    public class ComprobanteController : Controller
    {
        private IComprobanteServicio comprobante = new ComprobanteServicioImpl();

        private IIngresoServicio ingreso = new IngresoServicioImpl(); 
        // GET: Comprobante
        public ActionResult Index()
        {
            ViewBag.Tarifas = ingreso.FindAll();
            return View(comprobante.FindAll());
        }
        public ActionResult Create()
        {
            ViewBag.Ingreso = ingreso.FindAll();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Comprobante nuevo_comprobante)
        {
            ViewBag.Ingreso = ingreso.FindAll();
            bool rpta = comprobante.Insert(nuevo_comprobante);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public ActionResult Delete(int ?id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            return View(comprobante.FindById(id));
        }
        [HttpPost]
        public ActionResult Delete(Comprobante nuevo_comprobante)
        {
            bool rpta = comprobante.Delete(nuevo_comprobante.Id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Ingreso = ingreso.FindAll();
            if (id==null)
            {
                return HttpNotFound();
            }
            return View(comprobante.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Comprobante nuevo_comprobante)
        {
            ViewBag.Ingreso = ingreso.FindAll();
            bool rpta = comprobante.Update(nuevo_comprobante);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Details(int? id)
        {
            

            if (id==null)
            {
                return HttpNotFound();
            }
            var nuevo = comprobante.FindById(id);

            return View(nuevo);
        }

        /////////////////////////// JSonResult
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Comprobante> ComList = new List<Comprobante>();
            try
            {
                int Id = Convert.ToInt32(SearchValue);
                ComList.Add(comprobante.FindById(Id));
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} Is Not A ID ", SearchValue);
            }
            return Json(ComList, JsonRequestBehavior.AllowGet);
        }

    }
}