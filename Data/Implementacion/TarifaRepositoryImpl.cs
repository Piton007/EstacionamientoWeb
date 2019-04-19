using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;

namespace Data.Implementacion
{
    public class TarifaRepositoryImpl : ITarifaRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("DELETE FROM Tarifa WHERE id_Tarifa='" + id + "'", con);

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

        public List<Tarifa> FindAll()
        {
            var tarifas = new List<Tarifa>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT t.Id_Tarifa, t.Tipo_Veh, t.Tarifa FROM Tarifa as t", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tarifa = new Tarifa();
                            tarifa.Id = Convert.ToInt32(dr["Id_Tarifa"]);
                            tarifa.TipoVehiculo = dr["Tipo_Veh"].ToString();
                            tarifa.MontoTarifa = Convert.ToInt32(dr["Tarifa"]);

                            tarifas.Add(tarifa);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tarifas;
        }

        public Tarifa FindById(int? id)
        {
            Tarifa tarifa = new Tarifa();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM Tarifa WHERE id_Tarifa=@tarifa", con);
                    query.Parameters.AddWithValue("@tarifa", id);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tarifa.MontoTarifa = Convert.ToDouble(dr["Tarifa"]);
                            tarifa.TipoVehiculo = dr["Tipo_Veh"].ToString();
                            tarifa.Id = Convert.ToInt32(id);
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tarifa;
        }

        public bool Insert(Tarifa t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO Tarifa VALUES(@Tarifa,@Tipo_Veh)", con);
                    query.Parameters.AddWithValue("@Tarifa", t.MontoTarifa);
                    query.Parameters.AddWithValue("@Tipo_Veh", t.TipoVehiculo);

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

        public bool Update(Tarifa t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EstacionamientoDB"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE Tarifa SET Tipo_Veh=@Tipo_Veh, Tarifa=@Tarifa WHERE Id_Tarifa=@id", con);
                    query.Parameters.AddWithValue("@Tarifa", t.MontoTarifa);
                    query.Parameters.AddWithValue("@Tipo_Veh", t.TipoVehiculo);
                    query.Parameters.AddWithValue("@id", t.Id);

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
