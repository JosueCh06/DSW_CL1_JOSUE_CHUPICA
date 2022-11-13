using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DSW_CL1_JOSUE_CHUPICA.Services;
using DSW_CL1_JOSUE_CHUPICA.Entity;
using DSW_CL1_JOSUE_CHUPICA.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace DSW_CL1_JOSUE_CHUPICA.Models
{
    public class EmpleadoDAO : IEmpleadoDAO<Empleado>
    {
        public void ActualizarEmpleado(Empleado e)
        {
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_EmpleadoActualizar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEmpleado", e.idEmpleado);
            cmd.Parameters.AddWithValue("@apeEmpleado", e.apeEmpleado);
            cmd.Parameters.AddWithValue("@nombEmpleado", e.nombEmpleado);
            cmd.Parameters.AddWithValue("@fecNac", e.FecNac);
            cmd.Parameters.AddWithValue("@dirEmpleado", e.dirEmpleado);
            cmd.Parameters.AddWithValue("@idDistrito", e.idDistrito);
            cmd.Parameters.AddWithValue("@celEmpleado", e.celEmpleado);
            cmd.Parameters.AddWithValue("@idCargo", e.idCargo);
            cmd.Parameters.AddWithValue("@fecContrato", e.fecContrato);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            { throw ex; }
            finally { cn.Close(); }
        }

        public void BajaEmpleado(Empleado e)
        {
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_EmpleadoBaja", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idempleado", e.idEmpleado);
            try
            {
                cn.Open();
                bool ires = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (SqlException ex)
            { throw ex; }
            finally { cn.Close(); }

        }

        public Empleado BuscarEmpleado(int id)
        {
            Empleado emp = null;
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_EmpleadosDatos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEmpleado", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    emp = new Empleado()
                    {
                        idEmpleado = Convert.ToInt32(dr[0]),
                        apeEmpleado = dr[1].ToString(),
                        nombEmpleado = dr[2].ToString(),
                        FecNac = Convert.ToDateTime(dr[3]),
                        dirEmpleado = dr[4].ToString(),
                        idDistrito = Convert.ToInt32(dr[5]),
                        celEmpleado = dr[6].ToString(),
                        idCargo = Convert.ToInt32(dr[7]),
                        fecContrato = Convert.ToDateTime(dr[8])
                    };
                }
                dr.Close();
            }
            catch (SqlException ex)
            { throw ex; }
            finally { cn.Close(); }
            return emp;
        }

        public void InsertarEmpleado(Empleado e)
        {
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_EmpleadoCrear", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@apeEmpleado", e.apeEmpleado);
            cmd.Parameters.AddWithValue("@nombEmpleado", e.nombEmpleado);
            cmd.Parameters.AddWithValue("@fecNac", e.FecNac);
            cmd.Parameters.AddWithValue("@dirEmpleado", e.dirEmpleado);
            cmd.Parameters.AddWithValue("@idDistrito", e.idDistrito);
            cmd.Parameters.AddWithValue("@celEmpleado", e.celEmpleado);
            cmd.Parameters.AddWithValue("@idCargo", e.idCargo);
            cmd.Parameters.AddWithValue("@fecContrato", e.fecContrato);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            { throw ex; }
            finally { cn.Close(); }
        }

        public List<Empleado> listarEmpleado()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_Empleados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empleado emp = new Empleado()
                    {
                        idEmpleado = Convert.ToInt32(dr[0]),
                        apeEmpleado = dr[1].ToString(),
                        nombEmpleado = dr[2].ToString(),
                        FecNac = Convert.ToDateTime(dr[3]),
                        dirEmpleado = dr[4].ToString(),
                        idDistrito = Convert.ToInt32(dr[5]),
                        celEmpleado = dr[6].ToString(),
                        idCargo = Convert.ToInt32(dr[7]),
                        fecContrato = Convert.ToDateTime(dr[8])
                    };
                    lista.Add(emp);
                }
                dr.Close();
            }
            catch (SqlException ex)
            { throw ex; }
            finally { cn.Close(); }
            return lista;
        }
    }
}