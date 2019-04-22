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
    public class CajeroServicioImpl : ICajeroServicio
    {
		private IPuntoAtencionRepository punto_atencion = new PuntoAtencionRepositoryImpl();
		private ICajeroRepository cajero = new CajeroRepositoryImpl();

		public bool Delete(int id)
        {
			return cajero.Delete(id);
		}

        public List<Cajero> FindAll()
        {
			return cajero.FindAll();
        }

        public Cajero FindById(int? id)
        {
			return cajero.FindById(id);
        }

        public bool Insert(Cajero t)
        {
			PuntoAtencion puntoA = punto_atencion.FindById(t.PuntoA.Id);
			t.PuntoA = puntoA;
			return cajero.Insert(t);
		}

        public bool Update(Cajero t)
        {
			return cajero.Update(t);
        }
    }
}
