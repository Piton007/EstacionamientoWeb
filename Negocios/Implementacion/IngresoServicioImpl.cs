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
            return ingresoRepository.Insert(t);
        }

        public bool Update(Ingreso t)
        {
            return ingresoRepository.Update(t);
        }
    }
}
