using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFazendaUrbana.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<ClienteModel>> Login(ClienteCriacaoDto cliente)
        {
            var resposta = new ResponseModel<ClienteModel>();
            try
            {
                var clienteSelecionado = _context.Clientes.FirstOrDefault(x => x.CPF == cliente.CPF.Replace("-", "").Replace(".", "").Trim() && x.Senha == cliente.Senha);

                if (clienteSelecionado is not null)
                {
                    resposta.Dados = clienteSelecionado;
                    resposta.Mensagem = "Logado com sucesso";
                    return resposta;
                }
                else
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Não foi possível autenticar o usuário";
                    return resposta;
                }
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
