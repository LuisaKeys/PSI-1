using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servico.Cadastros;
using Modelo.ViewModels;

namespace PSICAP2.Controllers
{
    public class HomeController : Controller
    {
        ProdutoServico produtoServico = new ProdutoServico();
        // GET: Home
        public ActionResult Index()
        {
            HomeClass home = new HomeClass();

            home.listaprodutoDestaques = produtoServico.ObterProdutosClassificadosPorData();
            home.listaProdutoLancamento = produtoServico.ObterProdutosClassificadosPorDestaque();
            return View(home);

            //return View(produtoServico.ObterProdutosClassificadosPorNome());
        }
    }
}