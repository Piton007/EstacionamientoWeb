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
            bool rpta = comprobante.Insert(t);
           

            return rpta;
            
        }

        public Comprobante Preview(int ?id)
        {
            var tmpcomprobante = new Comprobante();
            var tmpingreso = ingreso.FindById(id);
            tmpingreso.Tarifa = tarifa.FindById(tmpingreso.Tarifa.Id);
            tmpcomprobante.cod_ingreso = tmpingreso;
            tmpcomprobante.FechaFinal = DateTime.Today;
            var horas = (tmpcomprobante.cod_ingreso.FechaIngreso -tmpcomprobante.FechaFinal).Hours;
            double Tarifa =(tmpcomprobante.cod_ingreso.Tarifa.MontoTarifa)*horas;
            tmpcomprobante.Monto = Tarifa;
            return tmpcomprobante;

        }

        public bool Update(Comprobante t)
        {
           
            return comprobante.Update(t);

        }
    }
}
