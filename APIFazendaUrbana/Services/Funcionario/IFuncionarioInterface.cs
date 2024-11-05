using APIFazendaUrbana.Dto.Funcionario;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Funcionario
{
    public interface IFuncionarioInterface
    {
        Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios();
        Task<ResponseModel<List<FuncionarioModel>>> CriarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto);
        Task<ResponseModel<List<FuncionarioModel>>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto);
        Task<ResponseModel<List<FuncionarioModel>>> ExcluirFuncionario(int idFuncionario);
    }
}
