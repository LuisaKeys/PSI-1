using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSICAP2.Models;
using PSICAP2.Context;
using System.Net;
using System.Data.Entity;

namespace PSICAP2.Controllers
{
   
    public class FabricanteController : Controller
    {
        private static IList<Fabricante> fabricantes = new List<Fabricante>()
       {
       new Fabricante() { FabricanteId = 1, Nome = "LG"},
       new Fabricante() { FabricanteId = 2, Nome = "Microsoft"}
       };
        private EFContext context = new EFContext();

        // GET: Fabricante
        public ActionResult Index()
        {
            return View(fabricantes);
            //return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            //context.Fabricantes.Add(fabricante);
            //context.SaveChanges();
            fabricantes.Add(fabricante);
            fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            return RedirectToAction("Index");
        }
        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                //context.Entry(fabricante).State = EntityState.Modified;
                //context.SaveChanges();
                fabricantes.Remove(
                fabricantes.Where(f => f.FabricanteId == fabricante.FabricanteId).First());
                fabricantes.Add(fabricante);
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            fabricantes.Remove(fabricante);
            return RedirectToAction("Index");
            //if (fabricante == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(fabricante);
        }
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}