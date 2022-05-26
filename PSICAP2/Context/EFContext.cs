using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSICAP2.Models;
using System.Data.Entity;

namespace PSICAP2.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
