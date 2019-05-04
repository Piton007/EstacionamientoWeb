using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Data.Implementacion
{
    public class EspacioRepositoryImpl : IEspacioRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Delete  from Espacio Where id_Espacio='" + id + "'", connection);
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

        public List<Espacio> FindAll()
        {
            var espacios = new List<Espacio>();
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select E.id_Espacio, E.Disponibilidad, E.id_estacionamiento from Espacio as E inner join Estacionamiento as Et on Et.id_estacionamiento=E.id_estacionamiento ", connection);
                    using (var dr = query.ExecuteReader())
                    {
                        var espacio = new Espacio();
                        var Estacionamiento = new Estacionamiento();
                        while (dr.Read())
                        {

                            espacio.Id = Convert.ToInt32(dr["id_Espacio"]);
                            espacio.Disponible = Convert.ToBoolean(dr["Disponibilidad"]);
                            Estacionamiento.Id = Convert.ToInt32(dr["id_estacionamiento"]);
                            espacio.estacionamiento = Estacionamiento;

                            espacios.Add(espacio);
                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return espacios;
        }

        public Espacio FindById(int? id)
        {
            Espacio espacio = null;
            try
            {
                using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT E.id_Espacio, E.Disponibilidad, E.id_estacionamiento  from Espacio as E inner join Estacionamiento as ES on E.id_estacionamientos=ES.id_estacionamiento " +
                        "WHERE id_Espacio='" + id + "'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            espacio = new Espacio();
                            Estacionamiento estacionamiento = new Estacionamiento();
                            espacio.Id = Convert.ToInt32(dr["id_Espacio"]);
                            espacio.Disponible = Convert.ToBoolean(dr["Disponibilidad"]);
                            estacionamiento.Id = Convert.ToInt32(dr["id_estacionamiento"]);
                            espacio.estacionamiento = estacionamiento;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return espacio;
        }

        public bool Insert(Espacio t)
        {
            bool rpta = false;
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager
                    .ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO Espacio VALUES( @id_estacionamiento,@Disponibilidad)", con);
                    query.Parameters.AddWithValue("@Disponibilidad", t.Disponible);
                    query.Parameters.AddWithValue("@id_estacionamiento", t.estacionamiento.Id);
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

        public bool Update(Espacio t)
        {
            bool rpta = false;
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Update Espacio Set id_estacionamiento ='" + t.estacionamiento.Id
                                             + "'" + ", Disponibilidad='" + t.Disponible
                                             + "'" + " Where id_Espacio='" + t.Id + "'", connection);
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
