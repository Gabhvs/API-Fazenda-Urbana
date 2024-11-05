using APIFazendaUrbana.Dto.Fornecedor;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Fornecedor;
using APIFazendaUrbana.Services.Vendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorInterface _fornecedorInterface;
        public FornecedorController(IFornecedorInterface fornecedorInterface)
        {
            _fornecedorInterface = fornecedorInterface;
        }

        [HttpGet("ListarFornecedores")]
        public async Task<ActionResult<ResponseModel<List<FornecedorModel>>>> ListarFornecedores()
        {
            var fornecedor = await _fornecedorInterface.ListarFornecedores();
            return Ok(fornecedor);
        }

        [HttpPost("CriarFornecedor")]
        public async Task<ActionResult<ResponseModel<List<FornecedorModel>>>> CriarVenda(FornecedorCriacaoDto fornecedorCriacaoDto)
        {
            var fornecedor = await _fornecedorInterface.CriarFornecedor(fornecedorCriacaoDto);
            return Ok(fornecedor);
        }
    }
}
