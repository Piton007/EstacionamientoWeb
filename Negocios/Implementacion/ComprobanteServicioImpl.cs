using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Entidades;

namespace Negocios.Implementacion
{
    public class ComprobanteServicioImpl : IComprobanteServicio
    {
       private IComprobanteRepository comprobante = new ComprobanteRepositoryImpl();
       private IIngresoRepository ingreso = new IngresoRepositoryImpl();
       private ITarifaRepository tarifa = new TarifaRepositoryImpl();

        public bool Delete(int id)
        {
            return comprobante.Delete(id);
        }

        public List<Comprobante> FindAll()
        {
            return comprobante.FindAll();
        }

        public Comprobante FindById(int? id)
        {
            return comprobante.FindById(id);
        }

        public bool Insert(Comprobante t)
        {
            t.cod_ingreso = ingreso.FindById(t.cod_ingreso.CodIngreso);
            t.FechaFinal = DateTime.Today;
            var horas = (t.FechaFinal - t.cod_ingreso.FechaIngreso).Hours;
            double Tarifa = (tarifa.FindById(t.cod_ingreso.Tarifa.Id).MontoTarifa)*horas;
            t.Monto = Tarifa;
            return comprobante.Insert(t);
            
        }

        public bool Update(Comprobante t)
        {
           
            return comprobante.Update(t);

        }
    }
}
