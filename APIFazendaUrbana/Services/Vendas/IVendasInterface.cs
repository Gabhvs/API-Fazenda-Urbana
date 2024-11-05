using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Vendas
{
    public interface IVendasInterface
    {
        Task<ResponseModel<List<VendasModel>>> ListarVendas();
        Task<ResponseModel<List<VendasModel>>> CriarVendas(VendasCriacaoDto vendasCriacaoDto);
    }
}
