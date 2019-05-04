using Data;
using Data.Implementacion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Implementacion
{
    public class LocalizacionServicioImpl : ILocalizacionServicio
    {
        private ILocalizacionRepository localizacionRepository = new LocalizacionRepositoryImpl();
        public bool Delete(int id)
        {
            return localizacionRepository.Delete(id);
        }

        public List<Localizacion> FindAll()
        {
            return localizacionRepository.FindAll();
        }

        public Localizacion FindById(int? id)
        {
            return localizacionRepository.FindById(id);
        }

        public bool Insert(Localizacion t)
        {
           
            return localizacionRepository.Insert(t);
        }

        public bool Update(Localizacion t)
        {
            return localizacionRepository.Update(t);
        }
    }
}
