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
    public class EspacioServicioImpl : IEspacioServicio
    {

        private IEstacionamientoRepository Estacionamiento = new EstacionamientoRepositoryImpl();
        private IEspacioRepository espacio = new EspacioRepositoryImpl();


        public bool Delete(int id)
        {
            return espacio.Delete(id);
        }

        public List<Espacio> FindAll()
        {
            return espacio.FindAll();
        }

        public Espacio FindById(int? id)
        {
            return espacio.FindById(id);
        }

        public bool Insert(Espacio t)
        {
            Estacionamiento estacionamiento = Estacionamiento.FindById(t.estacionamiento.Id);
            t.estacionamiento = estacionamiento;
            return espacio.Insert(t);
        }

        public bool Update(Espacio t)
        {
            return espacio.Update(t);
        }

    }
}
