using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using MVCClinica.Data;
using MVCClinica.Models;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        private MedicoDbContext context = new MedicoDbContext();

        //Listar todos
        // GET: Medico
        public ActionResult Index()
        {
            var medicos = context.Medicos.ToList();
            return View("Index", medicos);
        }

        //Traer médicos por especialidad

        public ActionResult Index(string especialidad)
        {
            var medicos = (from m in context.Medicos where m.Especialidad == especialidad select m).ToList();
            return View("Index", medicos);
        }

        //Carga

        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View("Create", medico);
        }

        //Modificación

        public ActionResult Edit(int id)
        {
            Medico medico = context.Medicos.Find(id);

            if (medico != null)
            {
                return View("Edit", medico);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Entry(medico).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View("Edit", medico);
        }

        //Eliminación
        public ActionResult Delete(int id)
        {
            Medico medico = context.Medicos.Find(id);

            if (medico != null)
            {
                return View("Delete", medico);
            }
            else return HttpNotFound();
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = context.Medicos.Find(id);

            context.Medicos.Remove(medico);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Ver detalle de un médico por Id
        public ActionResult Detail(int id)
        {
            Medico medico = context.Medicos.Find(id);

            if (medico != null)
            {
                return View("Detail", medico);
            }
            else return HttpNotFound();
        }

        
    }
}