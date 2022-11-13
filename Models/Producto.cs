using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSW_CL1_JOSUE_CHUPICA.Models
{
    public class Producto
    {
		public int idProducto { get; set; }
		public String nomProducto { get; set; }
		public String nomProveedor { get; set; }
		public String nombreCategoria { get; set; }
		public String cantUnidad { get; set; }
		public decimal precioUnidad { get; set; } 
		public int stock { get; set; }

	}
}