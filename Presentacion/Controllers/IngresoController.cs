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
            ViewBag.Tarifas = tarifaServicio.FindAll();
            return View(ingresoServicio.FindAll());
        }
		public JsonResult GetSearchingData(string SearchBy, string SearchValue)
		{
			List<Ingreso> StuList = new List<Ingreso>();


			try
			{
				int Id = Convert.ToInt32(SearchValue);
				StuList.Add(ingresoServicio.FindById(Id));

				//db.Cajero.Where(x => x.id_cajero == Id || SearchValue == null).ToList();
			}
			catch (FormatException)
			{
				Console.WriteLine("{0} Is Not A ID ", SearchValue);
			}


			return Json(StuList, JsonRequestBehavior.AllowGet);
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
            ViewBag.tarifas = tarifaServicio.FindAll();
            ViewBag.cajeros = cajeroServicio.FindAll();
            ViewBag.espacios = espacioServicio.FindAll();
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

        public JsonResult GuardarIngreso(Ingreso ingreso)
        {
            var result = false;
            try
            {
                
                
                
                    Cajero cajero = new Cajero();
                    Espacio espacio = new Espacio();
                    Tarifa tarifa = new Tarifa();
                    tarifa.Id = ingreso.Tarifa.Id;
                    cajero.Id = 1;
                    espacio.Id = 1;


                    Ingreso ingresonew = new Ingreso();
                    ingresonew.CodIngreso = ingreso.CodIngreso;
                    ingresonew.Placa = ingreso.Placa;
                    ingresonew.Tarifa = tarifa;
                    ingresonew.Cajero = cajero;
                    ingresonew.Espacio = espacio;

                    result = ingresoServicio.Insert(ingresonew);


                






            }
            catch (Exception ex )
            {

                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}