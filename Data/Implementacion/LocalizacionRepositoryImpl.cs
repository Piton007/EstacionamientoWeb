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
        public int GetCantEstacionamientos(Localizacion local)
        {
            int Estacionamientos = 0;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select Count(*) as Cantidad FROM Estacionamiento as E  where E.cod_local=@id ", connection);
                    query.Parameters.AddWithValue("@id", local.CodLocalizacion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Estacionamientos = Convert.ToInt32(dr["Cantidad"]);

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Estacionamientos;

        }
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("DELETE FROM Localizacion WHERE id_Tarifa='" + id + "'", con);

                    query.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }

        public List<Localizacion> FindAll()
        {
            var locales = new List<Localizacion>();
            try
            {
                using (var connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select l.cod_local, l.nombre FROM Localizacion l", connection);
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
            Localizacion localizacion = new Localizacion();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM  Localizacion WHERE cod_local=@cod", con);
                    query.Parameters.AddWithValue("@cod", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
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
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO Localizacion(nombre) VALUES(@nombre)", con);
                    query.Parameters.AddWithValue("@nombre", t.Nombre);

                    query.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }

        public bool Update(Localizacion t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE Localizacion SET nombre=@nombre WHERE cod_local=@cod", con);
                    query.Parameters.AddWithValue("@nombre", t.Nombre);
                    query.Parameters.AddWithValue("@cod", t.CodLocalizacion);

                    query.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rpta;
        }
    }
}
