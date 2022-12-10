using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servico.Cadastros;

namespace PSICAP2.Controllers
{
    public class HomeController : Controller
    {
        ProdutoServico produtoServico = new ProdutoServico();
        // GET: Home
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }
    }
}