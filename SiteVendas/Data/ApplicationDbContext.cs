using System;
using System.Collections.Generic;
using System.Text;
using business.classes;
using business.Join;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SiteVendas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LojaCliente> LojaCliente { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LojaCliente>().HasKey(p => new { p.ClienteId, p.LojaId });

            base.OnModelCreating(builder);
        }
    }
}
