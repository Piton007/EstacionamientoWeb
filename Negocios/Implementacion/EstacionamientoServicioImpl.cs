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
   public  class EstacionamientoServicioImpl : IEstacionamientoServicio
        
    { private ILocalizacionRepository Localizacion = new LocalizacionRepositoryImpl();
        private IEstacionamientoRepository estacionamiento = new EstacionamientoRepositoryImpl();
        public bool Delete(int id)
        {
            return estacionamiento.Delete(id);
        }

        public List<Estacionamiento> FindAll()
        {
            return estacionamiento.FindAll();
        }

        public Estacionamiento FindById(int? id)
        {
            return estacionamiento.FindById(id);
        }

        public bool Insert(Estacionamiento t)
        {
            Localizacion local = Localizacion.FindById(t.localizacion.CodLocalizacion);
            t.localizacion = local;
            return estacionamiento.Insert(t);
        }

        public bool Update(Estacionamiento t)
        {
            return estacionamiento.Update(t);
        }
    }
}
