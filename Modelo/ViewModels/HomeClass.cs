using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class HomeClass
    {
        public IQueryable<Produto> listaProdutoLancamento;
        public IQueryable<Produto> listaprodutoDestaques;
    }
}
