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
    public class TarifaServicioImpl:ITarifaServicio
    {
        private ITarifaRepository tarifaRepository = new TarifaRepositoryImpl();

        public bool Delete(int id)
        {
            return tarifaRepository.Delete(id);
        }

        public List<Tarifa> FindAll()
        {
            return tarifaRepository.FindAll();
        }

        public Tarifa FindById(int? id)
        {
            return tarifaRepository.FindById(id);
        }

        public bool Insert(Tarifa t)
        {
            return tarifaRepository.Insert(t);
        }

        public bool Update(Tarifa t)
        {
            return tarifaRepository.Update(t);
        }
    }
}
