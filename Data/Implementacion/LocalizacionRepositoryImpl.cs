using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Data.Implementacion
{
    public class LocalizacionRepositoryImpl : ILocalizacionRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Localizacion> FindAll()
        {
            var locales = new List<Localizacion>();
            try
            {
                using (var connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select * FROM Localizacion", connection);
                    using (var dr=query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var localizacion = new Localizacion();
                            localizacion.CodLocalizacion = Convert.ToInt32(dr["cod_local"]);
                            localizacion.Nombre = dr["nombre"].ToString();
                            locales.Add(localizacion);
                        }
                        

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return locales;
        }

        public Localizacion FindById(int? id)
        {
            Localizacion localizacion = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM  Localizacion WHERE cod_local='" + id + "'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            localizacion = new Localizacion();
                            localizacion.CodLocalizacion = Convert.ToInt32(dr["cod_local"]);
                            localizacion.Nombre = dr["nombre"].ToString();



                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return localizacion;
        }
            public bool Insert(Localizacion t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Localizacion t)
        {
            throw new NotImplementedException();
        }
    }
}
