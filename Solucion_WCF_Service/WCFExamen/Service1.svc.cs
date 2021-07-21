using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WCFExamen
{

    public class Service1 : IService1
    {
        public IEnumerable<Actividad> Actividades()
        {
            List<Actividad> temporal = new List<Actividad>();
            using (SqlConnection cn = new SqlConnection(

            ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("exec sp_listado_actividades", cn);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Actividad reg = new Actividad();
                    reg.idact = dr.GetString(0);
                    reg.desact = dr.GetString(1); 
                    reg.idcateg = dr.GetString(2);
                    reg.fecha = dr.GetString(3);
                    reg.vacantes = dr.GetString(4); 
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }

            return temporal;
        }

        public string Agregar(Solicitud reg)
        {
            string mensaje = ""; 
            SqlConnection cn = new SqlConnection( 
              ConfigurationManager.ConnectionStrings["cn"].ConnectionString); 
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            { 
                SqlCommand cmd = new SqlCommand("sp_agregar_solicitud", cn, tr);

                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@fsolicitud", reg.fsolicitud); 
                cmd.Parameters.AddWithValue("@idact", reg.idact); 
                cmd.Parameters.AddWithValue("@dni", reg.dni); 
                cmd.Parameters.AddWithValue("@nombre", reg.nombre); 
                cmd.Parameters.AddWithValue("@email", reg.email); 
                int i = cmd.ExecuteNonQuery(); 
                mensaje = string.Format("Se ha procesado {0} operaciones", i); 
            }

            catch (SqlException ex)
            { 
                mensaje = ex.Message; 
                tr.Rollback(); 
            } 
            finally
            { 
                cn.Close(); 
            } 
            return mensaje;
        }

        public string Eliminar(string nsolicitud)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Solicitudes> Solicitudes()
        {
            List<Solicitudes> temporal = new List<Solicitudes>();
            using (SqlConnection cn = new SqlConnection(

            ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("exec sp_listado_solicitudes", cn);
                cn.Open();
                 
                SqlDataReader dr = cmd.ExecuteReader(); 
                while (dr.Read()) 
                {
                    Solicitudes reg = new Solicitudes(); 
                    reg.nsolicitud = dr.GetString(0); 
                    reg.fsolicitud = dr.GetString(1); 
                    reg.desact = dr.GetString(2); 
                    reg.descat = dr.GetString(3); 
                    reg.dni = dr.GetString(4);
                    reg.nombre = dr.GetString(5);
                    reg.email = dr.GetString(6);
                    temporal.Add(reg); 
                } 
                dr.Close(); cn.Close();
            }
            return temporal;
        }
    }
}
