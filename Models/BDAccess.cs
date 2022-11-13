using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DSW_CL1_JOSUE_CHUPICA.Models
{
    public class BDAccess
    {
        public SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);


        public List<Producto> ListarProductoNombre(String nombProducto, String nombCategoria) 
        {
            List<Producto> lista = new List<Producto>();
            SqlCommand cmd = new SqlCommand("usp_ConsultaProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombProducto", nombProducto);
            cmd.Parameters.AddWithValue("@nombCategoria", nombCategoria);
            try 
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        idProducto = int.Parse(dr[0].ToString()),
                        nomProducto = dr[1].ToString(),
                        nomProveedor = dr[2].ToString(),
                        nombreCategoria = dr[3].ToString(),
                        cantUnidad = dr[4].ToString(),
                        precioUnidad = decimal.Parse(dr[5].ToString()),
                        stock = int.Parse(dr[6].ToString())
                    };
                    lista.Add(prod);
                }
                dr.Close();
                cn.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}