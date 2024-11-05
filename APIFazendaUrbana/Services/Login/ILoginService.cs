using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;

namespace APIFazendaUrbana.Services.Login
{
    public interface ILoginService
    {
        Task<ResponseModel<ClienteModel>> Login(ClienteCriacaoDto cliente);
    }
}
