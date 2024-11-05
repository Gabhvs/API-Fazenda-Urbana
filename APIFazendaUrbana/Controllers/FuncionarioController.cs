using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Cliente;
using APIFazendaUrbana.Services.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet("ListarFuncionarios")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> ListarFuncionarios()
        {
            var funcionario = await _funcionarioInterface.ListarFuncionarios();
            return Ok(funcionario);
        }

        [HttpPost("CriarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            var funcionario = await _funcionarioInterface.CriarFuncionario(funcionarioCriacaoDto);
            return Ok(funcionario);
        }

        [HttpPut("EditarFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> EditarAutor(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            var funcionario = await _funcionarioInterface.EditarFuncionario(funcionarioEdicaoDto);
            return Ok(funcionario);
        }

        [HttpDelete("ExcluirFuncionario")]
        public async Task<ActionResult<ResponseModel<List<FuncionarioModel>>>> ExcluirFuncionario(int idFuncionario)
        {
            var funcionario = await _funcionarioInterface.ExcluirFuncionario(idFuncionario);
            return Ok(funcionario);
        }
    }
}
