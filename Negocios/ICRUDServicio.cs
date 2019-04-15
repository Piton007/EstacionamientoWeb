using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public interface ICRUDServicio<T>
    {
        bool Insert(T t);
        bool Update(T t);

        bool Delete(int id);

        List<T> FindAll();

        T FindById(int? id);

    }

}
