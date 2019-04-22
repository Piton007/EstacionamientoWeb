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
    public class CajeroController : Controller
    {

		private ICajeroServicio CajeroService = new CajeroServicioImpl();
		private IPuntoAtencionServicio puntoAtencion = new PuntoAtencionServicioImpl();
		// GET: Cajero
		public ActionResult Index()
        {
            return View(CajeroService.FindAll());
        }


		public ActionResult Create()
		{
		
			ViewBag.punto_atencion = puntoAtencion.FindAll();
			return View();
		}
		[HttpPost]
		public ActionResult Create(Cajero cajero)
		{
			ViewBag.punto_atencion = puntoAtencion.FindAll();
			bool rpta = CajeroService.Insert(cajero);
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
			Cajero cajero = CajeroService.FindById(id);
			return View(cajero);
		}
		[HttpPost]
		public ActionResult Delete(Cajero cajero)
		{
			ViewBag.punto_atencion = puntoAtencion.FindAll();
			bool rpta = CajeroService.Delete(cajero.Id);
			if (rpta)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public ActionResult Edit(int? id)
		{
			ViewBag.punto_atencion = puntoAtencion.FindAll();
			if (id == null)
			{
				return HttpNotFound();
			}

			Cajero cajero = CajeroService.FindById(id);
			return View(cajero);
		}
		[HttpPost]
		public ActionResult Edit(Cajero cajero)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			bool rpta = CajeroService.Update(cajero);
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
			var nuevo = CajeroService.FindById(id);

			return View(nuevo);
		}
	}
}