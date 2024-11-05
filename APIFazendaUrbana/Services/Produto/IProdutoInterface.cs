using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<ProdutoModel>> EditarProduto(ProdutoModel produto);
        Task<ResponseModel<ProdutoModel>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto);
        Task<ResponseModel<ProdutoModel>> DeletarProduto(int id);
    }
}
