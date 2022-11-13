using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DSW_CL1_JOSUE_CHUPICA.Entity;
using DSW_CL1_JOSUE_CHUPICA.Models;

namespace DSW_CL1_JOSUE_CHUPICA.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        CargoDAO objcargo = new CargoDAO();
        DistritoDAO objdist = new DistritoDAO();
        EmpleadoDAO objemp = new EmpleadoDAO();

        public ActionResult Index()
        {
            return View(objemp.listarEmpleado().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(objemp.BuscarEmpleado(id));
        }

        public ActionResult Create()
        {
            ViewBag.distrito = new SelectList(
                objdist.listarDistrito(), "idDistrito", "nombDistrito");
            ViewBag.cargo = new SelectList(
                objcargo.listarCargos(), "idCargo", "desCargo");
            return View(new Empleado());
        }

        [HttpPost]
        public ActionResult Create(Empleado e)
        {
            try
            {
                if (ModelState.IsValid) {
                    objemp.InsertarEmpleado(e);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            { return View(); }
        }

        public ActionResult Edit(int id) 
        {
            Empleado emp = objemp.BuscarEmpleado(id);
            ViewBag.distrito = new SelectList(
                objdist.listarDistrito(), "idDistrito", "nombDistrito",emp.idDistrito);
            ViewBag.cargo = new SelectList(
                objcargo.listarCargos(), "idCargo", "desCargo",emp.idCargo);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Empleado e) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objemp.ActualizarEmpleado(e);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            { return View(); }
        }

        public ActionResult Delete(int id)
        {
            Empleado emp = objemp.BuscarEmpleado(id);
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado emp = objemp.BuscarEmpleado(id);
            objemp.BajaEmpleado(emp);
            return RedirectToAction("Index");
        }
    }
}