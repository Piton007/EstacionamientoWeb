using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacion
{
    public class ComprobanteRepositoryImpl : IComprobanteRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var connection= new SqlConnection(System.Configuration.ConfigurationManager
                    .ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Delete from Comprobante Where id_boleta='" + id + "'", connection);
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

        public List<Comprobante> FindAll()
        {
            var comprobantes = new List<Comprobante>();
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select C.id_boleta,C.Fecha_Inicio,C.Monto,C.cod_registro,I.Fecha_reg" +
                        " from Comprobante as C inner join Ingreso as I on I.cod_Registro=C.cod_Registro",connection);

                    using (var dr = query.ExecuteReader())
                        
                    {
                        
                        while (dr.Read())
                        {
                            var comprobante = new Comprobante();
                            var ingreso = new Ingreso();
                            comprobante.Id = Convert.ToInt32(dr["id_boleta"]);
                            comprobante.FechaFinal = Convert.ToDateTime(dr["Fecha_Final"]);
                            comprobante.Monto = Convert.ToDouble(dr["Monto"]);
                            ingreso.CodIngreso = Convert.ToInt32(dr["cod_Registro"]);
                            ingreso.FechaIngreso = Convert.ToDateTime(dr["Fecha_reg"]);
                            comprobante.cod_ingreso = ingreso;

                            comprobantes.Add(comprobante);

                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return comprobantes;
            
        }

        public Comprobante FindById(int? id)
        {
            Comprobante comprobante = new Comprobante();
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Select C.id_boleta,C.Fecha_final,C.Monto,C.cod_registro,I.Fecha_reg" +
                        " from Comprobante as C inner join Ingreso as I on I.cod_Registro=C.cod_Registro", connection);
                    using (var dr=query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var registro = new Ingreso();
                            comprobante.Id = Convert.ToInt32(dr["id_boleta"]);
                            registro.CodIngreso = Convert.ToInt32(dr["cod_registro"]);
                            registro.FechaIngreso = Convert.ToDateTime(dr["Fecha_reg"]);
                            comprobante.FechaFinal = Convert.ToDateTime(dr["Fecha_final"]);
                            comprobante.Monto = Convert.ToDouble(dr["Monto"]);
                            comprobante.cod_ingreso = registro;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return comprobante;
        }


        public bool Insert(Comprobante t)
        {
            bool rpta = false;
            try
            {
                using (var connection= new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Insert into Comprobante values(@cod_registro,@Monto,@Fecha_Final)", connection);
                    query.Parameters.AddWithValue("@cod_registro", t.cod_ingreso.CodIngreso);
                    query.Parameters.AddWithValue("@Fecha_Final", t.FechaFinal);
                    query.Parameters.AddWithValue("@Monto", t.Monto);
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

        public bool Update(Comprobante t)
        {
            bool rpta = false;
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
                {
                    connection.Open();
                    var query = new SqlCommand("Update Comprobante Set cod_Registro=@registro,Fecha_Final=@fecha,Monto=@monto where id_boleta=@id", connection);
                    query.Parameters.AddWithValue("@registro", t.cod_ingreso.CodIngreso);
                    query.Parameters.AddWithValue("@fecha", t.FechaFinal);
                    query.Parameters.AddWithValue("@monto", t.Monto);
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
