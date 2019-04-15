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
    public class PuntoAtencionServicioImpl : IPuntoAtencionServicio
    {
        private IPuntoAtencionRepository puntoAtencionRepository = new PuntoAtencionRepositoryImpl();
        public bool Delete(int id)
        {
           return puntoAtencionRepository.Delete(id);
        }

        public List<PuntoAtencion> FindAll()
        {
            return puntoAtencionRepository.FindAll();
        }

        public PuntoAtencion FindById(int? id)
        {
            return puntoAtencionRepository.FindById(id);
        }

        public bool Insert(PuntoAtencion t)
        {
            return puntoAtencionRepository.Insert(t);
        }

        public bool Update(PuntoAtencion t)
        {
            return puntoAtencionRepository.Update(t);
        }
    }
}
