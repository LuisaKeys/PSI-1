using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Modelo.Cadastros;


namespace Modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Categoria")]
        public long CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    
    }
}