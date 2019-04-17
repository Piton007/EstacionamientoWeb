using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;



namespace Data.Implementacion
{
    public class EstacionamientoRepositoryImpl : IEstacionamientoRepository
    {
       

        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Delete  from Estacionamiento Where id_estacionamiento='" + id + "'", connection);
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

        public List<Estacionamiento> FindAll()
        {
            var estacionamientos = new List<Estacionamiento>();
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select E.id_estacionamiento, E.Nombre_Estacionamiento, E.nro_espacios, E.Direccion, E.cod_local, L.nombre from Estacionamiento as E inner join Localizacion as L on L.cod_local=E.cod_local ", connection);
                    using (var dr = query.ExecuteReader())
                    {
                        var estacionamiento = new Estacionamiento();
                        var Localizacion = new Localizacion();
                        while (dr.Read())
                        {

                            estacionamiento.Id = Convert.ToInt32(dr["id_estacionamiento"]);
                            estacionamiento.Nombre = dr["Nombre_Estacionamiento"].ToString();
                            estacionamiento.espacios = Convert.ToInt32(dr["nro_Espacios"]);
                            estacionamiento.Direccion = dr["Direccion"].ToString();
                            Localizacion.Nombre = dr["nombre"].ToString();
                            Localizacion.CodLocalizacion = Convert.ToInt32(dr["cod_local"]);
                            estacionamiento.localizacion = Localizacion;

                            estacionamientos.Add(estacionamiento);
                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return estacionamientos;
        }

        public Estacionamiento FindById(int? id)
        {
            Estacionamiento estacionamiento = null;
            try
            {
                using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT E.id_estacionamiento, E.Nombre_Estacionamiento, E.nro_espacios, E.Direccion, E.cod_local, L.nombre  from Estacionamiento as E inner join Localizacion as L on L.cod_local=E.cod_local " +
                        "WHERE id_estacionamiento='" + id + "'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            estacionamiento = new Estacionamiento();
                            Localizacion localizacion = new Localizacion();
                            estacionamiento.Id = Convert.ToInt32(dr["id_estacionamiento"]);
                            estacionamiento.Nombre = dr["Nombre_Estacionamiento"].ToString();
                            estacionamiento.espacios = Convert.ToInt32(dr["nro_Espacios"]);
                            estacionamiento.Direccion = dr["Direccion"].ToString();
                            localizacion.Nombre = dr["nombre"].ToString();
                            localizacion.CodLocalizacion = Convert.ToInt32(dr["cod_local"]);
                            estacionamiento.localizacion = localizacion;




                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return estacionamiento;
        }

        public bool Insert(Estacionamiento t)
        {
            bool rpta = false;
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager
                    .ConnectionStrings["Estacionamiento"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO Estacionamiento VALUES( @cod_local,@Nombre,@nroEspacios,@Direccion)", con);
                    query.Parameters.AddWithValue("@Nombre", t.Nombre);
                    query.Parameters.AddWithValue("@nroEspacios", t.espacios);
                    query.Parameters.AddWithValue("@Direccion", t.Direccion);
                    query.Parameters.AddWithValue("@cod_local", t.localizacion.CodLocalizacion);
                    query.ExecuteNonQuery();
                    rpta = true;
                }



            }
            catch (Exception )
            {
                throw;
            }
            return rpta;
        }

        public bool Update(Estacionamiento t)
        {
            bool rpta = false;
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Update Estacionamiento Set cod_local ='" + t.localizacion.CodLocalizacion
                                             + "'" + ", Nombre_Estacionamiento='" + t.Nombre
                                             + "'" + ", nro_Espacios='" + t.espacios
                                             + "'" + ", Direccion='" + t.Direccion + "'" + " Where id_estacionamiento='" + t.Id + "'", connection);
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
