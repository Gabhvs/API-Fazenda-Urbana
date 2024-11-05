using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Vendas
{
    public class VendasService : IVendasInterface
    {
        private readonly AppDbContext _context;

        public VendasService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<ResponseModel<List<VendasModel>>> CriarVendas(VendasCriacaoDto vendasCriacaoDto)
        {
            ResponseModel<List<VendasModel>> resposta = new ResponseModel<List<VendasModel>>();

            try
            {
                var vendas = new VendasModel()
                {
                    Produto = vendasCriacaoDto.Produto,
                    QuantidadeVendida = vendasCriacaoDto.QuantidadeVendida,
                    ValorTotal = vendasCriacaoDto.ValorTotal,
                    FormaDePagamento = vendasCriacaoDto.FormaDePagamento
                };

                _context.Add(vendas);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Vendas.ToListAsync();
                resposta.Mensagem = "Venda registrada com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<VendasModel>>> ListarVendas()
        {
            ResponseModel<List<VendasModel>> resposta = new ResponseModel<List<VendasModel>>();
            try
            {
                var vendas = await _context.Vendas.ToListAsync();

                resposta.Dados = vendas;
                resposta.Mensagem = "Todos as vendas foram listados";

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
