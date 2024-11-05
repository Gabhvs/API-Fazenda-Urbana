using APIFazendaUrbana.Dto.Fornecedor;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Fornecedor
{
    public interface IFornecedorInterface
    {
        Task<ResponseModel<List<FornecedorModel>>> ListarFornecedores();
        Task<ResponseModel<List<FornecedorModel>>> CriarFornecedor(FornecedorCriacaoDto fornecedorCriacaoDto);
    }
}
