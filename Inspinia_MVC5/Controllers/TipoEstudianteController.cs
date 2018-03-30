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
    public class TipoEstudianteController : Controller
    {
        // GET: TipoEstudiante
        public ActionResult Index()
        {
            TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
            ModelState.Clear();
            return View(te.TipoEstudianteLista());
        }

        // GET: TipoEstudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoEstudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEstudiante/Create
        [HttpPost]
        public ActionResult Create(TipoEstudianteModel obj)
        {
            try
            {
                TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
                te.TipoEstudianteInsert(obj);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "TipoEstudianteModel", "Create"));
            }
        }

        // GET: TipoEstudiante/Edit/5
        public ActionResult Edit(int id)
        {
            TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
            return View(te.TipoEstudianteLista().Find(obj => obj.TipoEstudianteId == id));
        }

        // POST: TipoEstudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoEstudianteModel obj)
        {
            try
            {
                TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
                te.TipoEstudianteUpdate(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "TipoEstudianteModel", "Edit"));
            }
        }

        // GET: TipoEstudiante/Delete/5
        public ActionResult Delete(int id)
        {
            TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
            return View(te.TipoEstudianteLista().Find(obj => obj.TipoEstudianteId == id));
        }

        // POST: TipoEstudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TipoEstudianteModel obj)
        {
            try
            {
                TipoEstudianteRepositorio te = new TipoEstudianteRepositorio();
                te.TipoEstudianteDelete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "TipoEstudianteModel", "Edit"));
            }
        }
    }
}
