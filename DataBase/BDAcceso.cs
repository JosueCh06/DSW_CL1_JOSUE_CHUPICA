using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace DSW_CL1_JOSUE_CHUPICA.DataBase
{
    public class BDAcceso
    {
        public static SqlConnection ConexionBD()
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);
            return cn;
        }
    }
}