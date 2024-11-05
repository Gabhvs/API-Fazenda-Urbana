using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;
using APIFazendaUrbana.Services.Produto;
using APIFazendaUrbana.Services.Vendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasInterface _vendasInterface;
        public VendasController(IVendasInterface vendasInterface)
        {
            _vendasInterface = vendasInterface;
        }

        [HttpGet("ListarVendas")]
        public async Task<ActionResult<ResponseModel<List<VendasModel>>>> ListarVendas()
        {
            var venda = await _vendasInterface.ListarVendas();
            return Ok(venda);
        }

        [HttpPost("CriarVendas")]
        public async Task<ActionResult<ResponseModel<List<VendasModel>>>> CriarVenda(VendasCriacaoDto vendasCriacaoDto)
        {
            var venda = await _vendasInterface.CriarVendas(vendasCriacaoDto);
            return Ok(venda);
        }
    }
}
