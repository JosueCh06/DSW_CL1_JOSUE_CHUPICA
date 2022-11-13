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
    public class DistritoDAO : IDistritoDAO<Distrito>
    {
        public List<Distrito> listarDistrito()
        {
            List<Distrito> temporal = new List<Distrito>();
            SqlConnection cn = BDAcceso.ConexionBD();
            SqlCommand cmd = new SqlCommand("usp_Distrito", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Distrito car = new Distrito
                    {
                        idDistrito = Convert.ToInt32(dr[0]),
                        nombDistrito = dr[1].ToString()
                    };
                    temporal.Add(car);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex) { throw ex; }
            return temporal;
        }
    }
}