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
    public class CargoDAO : ICargoDAO<Cargo>
    {
        public List<Cargo> listarCargos()
        {
                List<Cargo> temporal = new List<Cargo>();
                SqlConnection cn = BDAcceso.ConexionBD();
                SqlCommand cmd = new SqlCommand("usp_Cargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cargo car = new Cargo()
                    {
                        idCargo = Convert.ToInt32(dr[0]),
                        desCargo = dr[1].ToString()
                    };
                    temporal.Add(car);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex){ throw ex; }
            return temporal;
        }
    }
}