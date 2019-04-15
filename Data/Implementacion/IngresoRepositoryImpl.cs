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
    public class IngresoRepositoryImpl : IIngresoRepository
    {
        public bool Delete(int id)
        {
            bool seElimino = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("DELETE FROM Ingreso WHERE cod_registro=@id");
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

        public List<Ingreso> FindAll()
        {
            var ingresos = new List<Ingreso>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT cod_registro, id_Tarifa, id_Cajero, Placa, Fecha_reg, id_Espacio FROM Ingreso", conn);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ing = new Ingreso();
                            ing.Tarifa = new Tarifa();
                            ing.Cajero = new Cajero();
                            ing.Espacio = new Espacio();

                            ing.CodIngreso = Convert.ToInt32(dr["cod_registro"]);
                            ing.Tarifa.Id = Convert.ToInt32(dr["id_Tarifa"]);
                            ing.Cajero.Id = Convert.ToInt32(dr["id_Cajero"]);
                            ing.Placa = dr["Placa"].ToString();
                            ing.FechaIngreso = Convert.ToDateTime(dr["Fecha_reg"]);
                            ing.Espacio.Id = Convert.ToInt32(dr["id_Espacio"]);
                            ingresos.Add(ing);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ingresos;
        }

        public Ingreso FindById(int? id)
        {
            var ingreso = new Ingreso();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT cod_registro, id_Tarifa, id_Cajero, Placa, Fecha_reg, id_Espacio FROM Ingreso", conn);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            ingreso.Tarifa = new Tarifa();
                            ingreso.Cajero = new Cajero();
                            ingreso.Espacio = new Espacio();

                            ingreso.CodIngreso = Convert.ToInt32(dr["cod_registro"]);
                            ingreso.Tarifa.Id = Convert.ToInt32(dr["id_Tarifa"]);
                            ingreso.Cajero.Id = Convert.ToInt32(dr["id_Cajero"]);
                            ingreso.Placa = dr["Placa"].ToString();
                            ingreso.FechaIngreso = Convert.ToDateTime(dr["Fecha_reg"]);
                            ingreso.Espacio.Id = Convert.ToInt32(dr["id_Espacio"]);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ingreso;
        }

        public bool Insert(Ingreso t)
        {
            bool seInserto = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("INSERT INTO Ingreso(id_Tarifa, id_Cajero, Placa, Fecha_reg, id_Espacio) VALUES(@idTarifa,@idCajero,@Placa,@fecha,@idEspacio)", conn);

                    query.Parameters.AddWithValue("@idTarifa",t.Tarifa.Id);
                    query.Parameters.AddWithValue("@idCajero",t.Cajero.Id);
                    query.Parameters.AddWithValue("@Placa",t.Placa);
                    query.Parameters.AddWithValue("@fecha",t.FechaIngreso);
                    query.Parameters.AddWithValue("@idEspacio",t.Espacio.Id);
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

        public bool Update(Ingreso t)
        {
            bool seActualizo = false;
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("UPDATE Ingreso SET id_Tarifa=@idTarifa, id_Cajero=@idCajero, Placa=@Placa, Fecha_reg=@fecha, id_Espacio=@idEspacio WHERE cod_registro=@id", conn);

                    query.Parameters.AddWithValue("@id", t.CodIngreso);
                    query.Parameters.AddWithValue("@idTarifa", t.Tarifa.Id);
                    query.Parameters.AddWithValue("@idCajero", t.Cajero.Id);
                    query.Parameters.AddWithValue("@Placa", t.Placa);
                    query.Parameters.AddWithValue("@fecha", t.FechaIngreso);
                    query.Parameters.AddWithValue("@idEspacio", t.Espacio.Id);
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
