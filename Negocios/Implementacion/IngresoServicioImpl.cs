using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data;
using Data.Implementacion;

namespace Negocios.Implementacion
{
    public class IngresoServicioImpl : IIngresoServicio
    {
        private IIngresoRepository ingresoRepository = new IngresoRepositoryImpl();
        private ITarifaRepository tarifaRepository = new TarifaRepositoryImpl();
        private ICajeroRepository cajeroRepository = new CajeroRepositoryImpl();
        private IEspacioRepository espacioRepository = new EspacioRepositoryImpl();
        public bool Delete(int id)
        {
            return ingresoRepository.Delete(id);
        }

        public List<Ingreso> FindAll()
        {
            return ingresoRepository.FindAll();
        }

        public Ingreso FindById(int? id)
        {
            return ingresoRepository.FindById(id);
        }

        public bool Insert(Ingreso t)
        {
            t.FechaIngreso = DateTime.Now;
            t.Placa = t.Placa.Trim();
            //t.Espacio= espacioRepository.FindById(t.Espacio.Id);
            //t.Cajero = cajeroRepository.FindById(t.Cajero.Id);
            //t.Tarifa = tarifaRepository.FindById(t.Tarifa.Id);
            return ingresoRepository.Insert(t);
        }

        public bool Update(Ingreso t)
        {
            return ingresoRepository.Update(t);
        }
    }
}
