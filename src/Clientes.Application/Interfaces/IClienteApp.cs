using Clientes.Application.DTO;
using Clientes.Application.Request;
using Clientes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Interfaces
{
   public interface IClienteApp : IAppBase<Cliente, ClienteRequest, ClienteDTO>
   {
        Task<List<ClienteDTO>?> ObterDadosPorNomeCpf(string nomeCpf);
    }
}
