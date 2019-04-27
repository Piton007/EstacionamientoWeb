using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Data.Implementacion
{
	public class CajeroRepositoryImpl : ICajeroRepository
	{
		public bool Delete(int id)
		{
			bool rpta = false;
			try
			{
				using (var conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
				{
					conexion.Open();
					var query = new SqlCommand("Delete  from Cajero Where id_cajero='" + id + "'", conexion);
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

		public List<Cajero> FindAll()
		{
			var cajeros = new List<Cajero>();
			try
			{
				using (var conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
				{
					conexion.Open();
					var query = new SqlCommand("Select C.id_cajero, C.Nombre, C.Turno,C.id_pAtencion,PA.Ubicacion  from Cajero as C inner join PuntoAtencion as PA on C.id_pAtencion=PA.id_pAtencion ", conexion);
					using (var dr = query.ExecuteReader())
					{
						var cajero = new Cajero();
						var punto_atencion = new PuntoAtencion();
						while (dr.Read())
						{

							cajero.Id = Convert.ToInt32(dr["id_cajero"]);
							cajero.Nombre = dr["Nombre"].ToString();
							cajero.Turno = dr["Turno"].ToString();

							punto_atencion.Ubicacion = dr["Ubicacion"].ToString();
							punto_atencion.Id = Convert.ToInt32(dr["id_pAtencion"]);
							cajero.PuntoA = punto_atencion;

							cajeros.Add(cajero);
						}


					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			return cajeros;
		}

		public Cajero FindById(int? id)
		{
			Cajero cajero= new Cajero();
			try
			{
				using (var conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
				{
					conexion.Open();

					var query = new SqlCommand("Select C.id_cajero, C.Nombre, C.Turno,C.id_pAtencion,PA.Ubicacion  from Cajero as C inner join PuntoAtencion as PA on C.id_pAtencion=PA.id_pAtencion " +
						"WHERE id_cajero='" + id + "'", conexion);
					using (var dr = query.ExecuteReader())
					{
						while (dr.Read())
						{
							PuntoAtencion punto_atencion = new PuntoAtencion();
						    cajero.Id = Convert.ToInt32(dr["id_cajero"]);
							cajero.Nombre = dr["Nombre"].ToString();
							cajero.Turno = dr["Turno"].ToString();
							punto_atencion.Ubicacion= dr["Ubicacion"].ToString();
							punto_atencion.Id= Convert.ToInt32(dr["id_pAtencion"]);
						    cajero.PuntoA= punto_atencion;

						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			return cajero;
		}

		public bool Insert(Cajero t)
		{
			bool rpta = false;
			try
			{
				using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager
					.ConnectionStrings["Estacionamiento"].ToString()))
				{
					conexion.Open();
					var query = new SqlCommand("INSERT INTO Cajero VALUES(@id_pAtencion,@Nombre,@Turno)", conexion);
					query.Parameters.AddWithValue("@Nombre", t.Nombre);
					query.Parameters.AddWithValue("@Turno", t.Turno);
					query.Parameters.AddWithValue("@id_pAtencion", t.PuntoA.Id);
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

		public bool Update(Cajero t)
		{
			bool rpta = false;
			try
			{
				using (var conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Estacionamiento"].ToString()))
				{
					conexion.Open();
					var query = new SqlCommand("Update Cajero Set Nombre=@Nombre,Turno=@Turno WHERE id_pAtencion=@id ", conexion);
					query.Parameters.AddWithValue("@Turno", t.Turno);
					query.Parameters.AddWithValue("@Nombre", t.Nombre);
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
