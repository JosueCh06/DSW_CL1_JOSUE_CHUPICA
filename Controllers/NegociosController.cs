using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DSW_CL1_JOSUE_CHUPICA.Models;

namespace DSW_CL1_JOSUE_CHUPICA.Controllers
{
    public class NegociosController : Controller
    {
        // GET: Negocios
        BDAccess db = new BDAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaProductosXNombre(String nombre = null, String categoria = null)
        {
            if (nombre == null) nombre = string.Empty;
            if (categoria == null) categoria = string.Empty;

            ViewBag.nombre = nombre;
            ViewBag.categoria = categoria;

            return View(db.ListarProductoNombre(nombre, categoria));
        }
    }
}