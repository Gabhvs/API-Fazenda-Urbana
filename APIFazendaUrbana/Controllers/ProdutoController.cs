using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Funcionario;
using APIFazendaUrbana.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produto = await _produtoInterface.ListarProdutos();
            return Ok(produto);
        }

        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> CriarProduto([FromForm] ProdutoCriacaoDto produtoCriacaoDto )
        {
            var produto = await _produtoInterface.CriarProduto(produtoCriacaoDto);
            return Ok(produto);
        }

        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpPut("EditarProduto")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> EditarProduto(ProdutoModel produtoParaAtualizar)
        {
            var produto = await _produtoInterface.EditarProduto(produtoParaAtualizar);
            return Ok(produto);
        }

        /// <summary>
        /// Obrigatório
        /// </summary>
        [HttpDelete("DeletarProduto")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> DeletarProduto(int id)
        {
            var produto = await _produtoInterface.DeletarProduto(id);
            return Ok(produto);
        }

    }
}
