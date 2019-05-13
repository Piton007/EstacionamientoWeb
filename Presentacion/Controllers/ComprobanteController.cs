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
        private ITarifaServicio tarifa = new TarifaServicioImpl();
        // GET: Comprobante
        public ActionResult Index()
        {
            ViewBag.Tarifas = ingreso.FindAll();
            return View(comprobante.FindAll());
        }
        public ActionResult Create(int? id)
        {
            var tmpcomprobante = comprobante.Preview(id);
            var diff = (tmpcomprobante.cod_ingreso.FechaIngreso -tmpcomprobante.FechaFinal );

            ViewBag.Time =  diff.Hours.ToString("00") + ":" + diff.Minutes.ToString("00");


            return View(tmpcomprobante);
        }
        [HttpPost]
        public ActionResult Create(Comprobante nuevo_comprobante)
        {
        
                bool rpta = comprobante.Insert(nuevo_comprobante);

            //if (rpta)
            //{
            //    return RedirectToAction("Index");
            //}

            string Mensaje = "";
            if (rpta)
            {
                 Mensaje = "Se ha insertado un comprobante";
            }
            else
            {
                Mensaje = "Hubo un error al generar un comprobante";
            }

            return Json(Mensaje, JsonRequestBehavior.AllowGet);

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