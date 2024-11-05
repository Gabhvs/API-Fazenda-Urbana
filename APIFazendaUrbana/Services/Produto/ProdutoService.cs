using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Produto;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }

        public async Task<ResponseModel<ProdutoModel>> CriarProduto(ProdutoCriacaoDto produtoCriacaoDto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();

            try
            {

                var produto = new ProdutoModel()
                {
                    Produto = produtoCriacaoDto.Produto,
                    Quantidade = produtoCriacaoDto.Quantidade,
                    Preco = produtoCriacaoDto.Preco,
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = null;
                resposta.Mensagem = "Produto criado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<ProdutoModel>> EditarProduto(ProdutoModel produto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();

            try
            {
                var produtoSelecionado = await _context.Produtos.FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == produtoBanco.Id);

                if (produtoSelecionado == null)
                    throw new Exception("Este produto não foi encontrado.");

                produtoSelecionado.Produto = produto.Produto;
                produtoSelecionado.Quantidade = produto.Quantidade;
                produtoSelecionado.Preco = produto.Preco;

                _context.Update(produtoSelecionado);
                await _context.SaveChangesAsync();

                resposta.Dados = null;
                resposta.Mensagem = "Alterações feitas com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<ProdutoModel>> DeletarProduto(int id)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);

                if (produto == null)
                    throw new Exception("Este produto não foi encontrado.");

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Produto removido com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
}
