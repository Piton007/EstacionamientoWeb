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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("DELETE FROM PuntoAtencion WHERE id_pAtencion='"+id+"'",conn);
                 
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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    conn.Open();
                    /*id_pAtencion, ubicacion*/
                    var query = new SqlCommand("SELECT * FROM PuntoAtencion", conn);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                           var pa = new PuntoAtencion();
                            pa.Id = Convert.ToInt32(dr["id_pAtencion"]);
                            pa.Ubicacion = dr["Ubicacion"].ToString();
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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT id_pAtencion, Ubicacion FROM PuntoAtencion WHERE id_pAtencion=@id", conn);
					query.Parameters.AddWithValue("@id", id);
					using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pa.Id = Convert.ToInt32(dr["id_pAtencion"]);
                            pa.Ubicacion = dr["Ubicacion"].ToString();
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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("INSERT INTO PuntoAtencion VALUES(@Ubicacion)", conn);

                    query.Parameters.AddWithValue("@Ubicacion", t.Ubicacion);
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
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("UPDATE PuntoAtencion SET Ubicacion = @ubi WHERE id_pAtencion=@id", conn);

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
