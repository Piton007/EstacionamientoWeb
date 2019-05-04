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
        
    { private ILocalizacionRepository Localizacionrepository = new LocalizacionRepositoryImpl();
        private IEstacionamientoRepository estacionamientorepository = new EstacionamientoRepositoryImpl();
        public bool Delete(int id)
        {
            return estacionamientorepository.Delete(id);
        }

        public List<Estacionamiento> FindAll()
        {
            return estacionamientorepository.FindAll();
        }

        public Estacionamiento FindById(int? id)
        {
            return estacionamientorepository.FindById(id);
        }

        public bool Insert(Estacionamiento t)
        {
            Localizacion local = Localizacionrepository.FindById(t.localizacion.CodLocalizacion);
            t.localizacion = local;

            var estacionamientos = Localizacionrepository.GetCantEstacionamientos(local);
            if (estacionamientos > 4) return false;
            
      
            return estacionamientorepository.Insert(t);
        }

        public bool Update(Estacionamiento t)
        {
            return estacionamientorepository.Update(t);
        }
    }
}
