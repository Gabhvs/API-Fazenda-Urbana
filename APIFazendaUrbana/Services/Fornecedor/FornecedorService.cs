using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Fornecedor;
using APIFazendaUrbana.Dto.Vendas;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Fornecedor
{
    public class FornecedorService : IFornecedorInterface
    {
        private readonly AppDbContext _context;

        public FornecedorService(AppDbContext context)
        {
            _context = context;

        }

        public async  Task<ResponseModel<List<FornecedorModel>>> CriarFornecedor(FornecedorCriacaoDto fornecedorCriacaoDto)
        {
            ResponseModel<List<FornecedorModel>> resposta = new ResponseModel<List<FornecedorModel>>();

            try
            {
                var fornecedor = new FornecedorModel()
                {
                    NomeEmpresa = fornecedorCriacaoDto.NomeEmpresa,
                    CNPJ = fornecedorCriacaoDto.CNPJ,
                    Adubo = fornecedorCriacaoDto.Adubo,
                    QuantidadeAdubo = fornecedorCriacaoDto.QuantidadeAdubo,
                    Agrotoxico = fornecedorCriacaoDto.Agrotoxico,
                    QuantidadeAgrotoxico  = fornecedorCriacaoDto.QuantidadeAgrotoxico,
                    Muda =  fornecedorCriacaoDto.Muda,
                    QuantidadeMuda = fornecedorCriacaoDto.QuantidadeMuda
                };

                _context.Add(fornecedor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Fornecedores.ToListAsync();
                resposta.Mensagem = "Fornecedor registrado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FornecedorModel>>> ListarFornecedores()
        {
            ResponseModel<List<FornecedorModel>> resposta = new ResponseModel<List<FornecedorModel>>();
            try
            {
                var fornecedor = await _context.Fornecedores.ToListAsync();

                resposta.Dados = fornecedor;
                resposta.Mensagem = "Todos os fornecedores foram listados";

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
