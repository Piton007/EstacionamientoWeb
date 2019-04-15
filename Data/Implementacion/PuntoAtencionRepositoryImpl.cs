using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Data.Implementacion
{
    public class PuntoAtencionRepositoryImpl : IPuntoAtencionRepository
    {
        public bool Delete(int id)
        {
            bool seElimino = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("DELETE FROM PuntoAtencion WHERE id_pAtencion=@id");
                    query.Parameters.AddWithValue("@id", id);
                    query.ExecuteNonQuery();
                    seElimino = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seElimino;
        }

        public List<PuntoAtencion> FindAll()
        {
            var puntoAtenciones = new List<PuntoAtencion>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT id_pAtencion, ubicacion FROM PuntoAtencion", conn);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            PuntoAtencion pa = new PuntoAtencion();
                            pa.Id = Convert.ToInt32(dr["id_pAtencion"]);
                            pa.Ubicacion = dr["ubicacion"].ToString();
                            puntoAtenciones.Add(pa);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return puntoAtenciones;
        }

        public PuntoAtencion FindById(int? id)
        {
            var pa = new PuntoAtencion();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT id_pAtencion, ubicacion FROM PuntoAtencion WHERE id_pAtencion=@id", conn);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pa.Id = Convert.ToInt32(dr["id_pAtencion"]);
                            pa.Ubicacion = dr["ubicacion"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return pa;
        }

        public bool Insert(PuntoAtencion t)
        {
            bool seInserto = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("INSERT INTO PuntoAtencion(ubicacion) VALUES(@ubicacion)", conn);

                    query.Parameters.AddWithValue("@ubicacion", t.Ubicacion);
                    query.ExecuteNonQuery();
                    seInserto = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seInserto;
        }

        public bool Update(PuntoAtencion t)
        {
            bool seActualizo = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("UPDATE PuntoAtencion SET ubicacion = @ubi WHERE id_pAtencion=@id", conn);

                    query.Parameters.AddWithValue("@id", t.Id);
                    query.Parameters.AddWithValue("@ubi", t.Ubicacion);
                    query.ExecuteNonQuery();
                    seActualizo = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seActualizo;
        }
    }
}
