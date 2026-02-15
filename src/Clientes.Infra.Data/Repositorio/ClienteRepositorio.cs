using Clientes.Domain.Entidades;
using Clientes.Domain.Interfaces;
using Clientes.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;


namespace Clientes.Infra.Data.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ClienteDbContext context) : base(context)
        {
        }

        public async Task<List<Cliente>?> ObterDadosPorNomeCpf(string nomeCpf)
        {
           var response =  await _context.Set<Cliente>()
                .Where(x => (x.CpfCnpj.Contains(nomeCpf)) 
                            || (x.Nome.ToUpper().Contains(nomeCpf.ToUpper())))
                .ToListAsync();

            return response;
        }
    }
}
