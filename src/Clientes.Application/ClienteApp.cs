using AutoMapper;
using Clientes.Application.DTO;
using Clientes.Application.Interfaces;
using Clientes.Application.Request;
using Clientes.Domain.Entidades;
using Clientes.Domain.Interfaces;

namespace Clientes.Application
{
    public class ClienteApp : AppBase<Cliente, ClienteRequest, ClienteDTO>, IClienteApp
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteApp(IClienteRepositorio clienteRepositorio, 
                          IMapper mapper) : base(clienteRepositorio, mapper)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<List<ClienteDTO>?> ObterDadosPorNomeCpf(string nomeCpf)
        {
            var resultado = await _clienteRepositorio.ObterDadosPorNomeCpf(nomeCpf);
            var response = _mapper.Map<List<ClienteDTO>?>(resultado);
            
            return response;
        }
      }
}
