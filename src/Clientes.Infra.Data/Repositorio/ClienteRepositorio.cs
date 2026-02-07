using Clientes.Domain.Entidades;
using Clientes.Domain.Interfaces;
using Clientes.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infra.Data.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ClienteDbContext context) : base(context)
        {
        }
    }
}
