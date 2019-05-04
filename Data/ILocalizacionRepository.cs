﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Data
{
    public interface ILocalizacionRepository: ICRUDRepository<Localizacion>
    {
        int GetCantEstacionamientos(Localizacion local);
    }
}
