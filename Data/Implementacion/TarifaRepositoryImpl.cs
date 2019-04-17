using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Data.Implementacion
{
    public class TarifaRepositoryImpl : ITarifaRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarifa> FindAll()
        {
            throw new NotImplementedException();
        }

        public Tarifa FindById(int? id)
        {
            Tarifa tarifa = new Tarifa();
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select * from Tarifa where id_Tarifa=@tarifa", connection);
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
            throw new NotImplementedException();
        }

        public bool Update(Tarifa t)
        {
            throw new NotImplementedException();
        }
    }
}
