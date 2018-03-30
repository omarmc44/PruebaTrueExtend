using Colegio.Models;
using Colegio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Colegio.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: TipoEstudiante
        public ActionResult Index()
        {
            AlumnoRepositorio ar = new AlumnoRepositorio();
            ModelState.Clear();
            return View(ar.AlumnoLista());
        }

        // GET: TipoEstudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoEstudiante/Create
        public ActionResult Create()
        {
            
            TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
            ViewBag.TipoEstudianteId = te.TipoEstudianteLista().Select(x => new SelectListItem { Text = x.TipoEstudiante, Value= Convert.ToString(x.TipoEstudianteId)});
            return View();
        }

        // POST: TipoEstudiante/Create
        [HttpPost]
        public ActionResult Create(AlumnoModel obj)
        {
            try
            {
                AlumnoRepositorio ar = new AlumnoRepositorio();
                ar.AlumnoInsert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AlumnoModel", "Create"));
            }
        }

        // GET: TipoEstudiante/Edit/5
        public ActionResult Edit(int id)
        {
            AlumnoRepositorio ar = new AlumnoRepositorio();
            TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();

            //PROVEEDOR
            string TipoEstudianteSeleccionado = (from x in te.TipoEstudianteLista()
                                            where x.TipoEstudianteId == id
                                            select x.TipoEstudianteId.ToString()).FirstOrDefault();
            ViewBag.TipoEstudianteId = new SelectList(te.TipoEstudianteLista(), "TipoEstudianteId", "TipoEstudiante", TipoEstudianteSeleccionado);

            return View(ar.AlumnoLista().Find(obj => obj.AlmunoId == id));
        }

        // POST: TipoEstudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AlumnoModel obj)
        {
            try
            {
                AlumnoRepositorio ar = new AlumnoRepositorio();
                ar.AlumnoUpdate(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AlumnoModel", "Edit"));
            }
        }

        // GET: TipoEstudiante/Delete/5
        public ActionResult Delete(int id)
        {
            AlumnoRepositorio ar = new AlumnoRepositorio();
            return View(ar.AlumnoLista().Find(obj => obj.AlmunoId == id));
        }

        // POST: TipoEstudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AlumnoModel obj)
        {
            try
            {
                AlumnoRepositorio ar = new AlumnoRepositorio();
                ar.AlumnoDelete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AlumnoModel", "Edit"));
            }
        }
    }
}
