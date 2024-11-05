using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            if (clientes.Status)
            {
                return Ok(clientes);
            }
            else
            {
                return BadRequest(clientes);
            }
        }

        [HttpGet("BuscarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> BuscarCliente(string cpf)
        {
            var clientes = await _clienteInterface.BuscarCliente(cpf);

            if (clientes.Status)
            {
                return Ok(clientes);
            }
            else
            {
                return BadRequest(clientes);
            }
        }
        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            var clientes = await _clienteInterface.CriarCliente(clienteCriacaoDto);
            if (clientes.Status)
            {
                return Ok(clientes);
            }
            else
            {
                return BadRequest(clientes);
            };
        }

        [HttpPut("EditarCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteModel cliente)
        {
            var clienteAtualizado = await _clienteInterface.EditarCliente(cliente);
            if (clienteAtualizado.Status)
            {
                return Ok(clienteAtualizado);
            }
            else
            {
                return BadRequest(clienteAtualizado);
            }
        }

        [HttpDelete("DeletarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> EditarCliente(string cpf)
        {
            var cliente = await _clienteInterface.DeletarCliente(cpf);
            if (cliente.Status)
            {
                return Ok(cliente);
            }
            else
            {
                return BadRequest(cliente);
            }
        }
    }
}
