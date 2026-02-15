using Clientes.Application.DTO;
using Clientes.Application.Interfaces;
using Clientes.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApp _clienteApp;
        public ClienteController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet]
        [Route("ObterTodos")]
        [ProducesResponseType(typeof(List<ClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterTodos()
        {
            var clientes = await _clienteApp.ObterTodosAsync();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("Obter/{id}")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var cliente = await _clienteApp.ObterPorIdAssyn(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpGet]
        [Route("ObterDadosPorNomeCpf")]
        [ProducesResponseType(typeof(List<ClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterDadosPorNomeCpf(string termo)
        {
            var clientes = await _clienteApp.ObterDadosPorNomeCpf(termo);
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Novo")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Novo(ClienteRequest request)
        {
            var createdCliente = await _clienteApp.AdicionarAsync(request);
            return Ok(createdCliente);
        }

        [HttpPut]
        [Route("Atualizar")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(ClienteRequest request)
        {
            var updatedCliente = await _clienteApp.AtualizarAsync(request, request.Id);
            if (updatedCliente == null) return NotFound();
            return Ok(updatedCliente);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Excluir(int id)
        {
            var deleted = await _clienteApp.ExcluirAsync(id);
            if (!deleted.Mensagem.Sucesso) return NotFound();
            return Ok(deleted);
        }
    }
}
