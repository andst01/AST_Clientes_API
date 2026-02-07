using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes.Domain.Entidades;
using Clientes.Infra.Data.Mapeamento;

namespace Clientes.Infra.Data.Contexto
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
