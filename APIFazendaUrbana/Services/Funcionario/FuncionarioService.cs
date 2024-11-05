using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<FuncionarioModel>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();

            try
            {
                var funcionario = new FuncionarioModel()
                {
                   NomeFuncionario = funcionarioCriacaoDto.NomeFuncionario,
                   CPF = funcionarioCriacaoDto.CPF,
                   Funcao = funcionarioCriacaoDto.Funcao
                };

                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionario criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();

            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == funcionarioEdicaoDto.Id);

                if (funcionario == null)
                {
                    resposta.Mensagem = "Nenhum funcionario localizado";
                    return resposta;
                }

                funcionario.Funcao = funcionarioEdicaoDto.Funcao;

                _context.Update(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Alterações feitas com sucesso!!!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> ExcluirFuncionario(int idFuncionario)
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();

            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionarioBanco => funcionarioBanco.Id == idFuncionario);

                if (funcionario == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }

                _context.Remove(funcionario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Funcionarios.ToListAsync();
                resposta.Mensagem = "Funcionario removido com sucessso!!!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios()
        {
            ResponseModel<List<FuncionarioModel>> resposta = new ResponseModel<List<FuncionarioModel>>();
            try
            {
                var funcionarios = await _context.Funcionarios.ToListAsync();

                resposta.Dados = funcionarios;
                resposta.Mensagem = "Todos os funcionarios foram listados";

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
