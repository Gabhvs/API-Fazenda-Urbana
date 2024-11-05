using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> BuscarCliente(string cpf);
        Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto);
        Task<ResponseModel<ClienteModel>> EditarCliente(ClienteModel cliente);
        Task<ResponseModel<ClienteModel>> DeletarCliente(string cpf);
    }
}
