using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSICAP2.Models;
using PSICAP2.Context;

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
    }
}