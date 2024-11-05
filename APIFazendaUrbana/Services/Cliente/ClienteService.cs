using APIFazendaUrbana.Data;
using APIFazendaUrbana.Dto.Cliente;
using APIFazendaUrbana.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFazendaUrbana.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                if(_context.Clientes.FirstOrDefault(x => x.CPF == clienteCriacaoDto.CPF) != null)
                {
                    throw new Exception("Cadastro já existente");
                }

                var cliente = new ClienteModel()
                {
                    NomeCliente = clienteCriacaoDto.NomeCliente,
                    CPF = clienteCriacaoDto.CPF.Replace("-", "").Replace(".", "").Trim(),
                    Email = clienteCriacaoDto.Email,
                    Senha = clienteCriacaoDto.Senha
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var clientes = await _context.Clientes.ToListAsync();

                resposta.Dados = clientes;
                resposta.Mensagem = "Todos os clientes foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<ClienteModel>> BuscarCliente(string cpf)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var clienteSelecionado = _context.Clientes.FirstOrDefault(x => x.CPF == cpf.Replace("-", "").Replace(".", "").Trim());

                if (clienteSelecionado == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Cliente não cadastrado";
                    return resposta;
                }

                resposta.Dados = clienteSelecionado;
                resposta.Mensagem = "Cliente localizado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
        public async Task<ResponseModel<ClienteModel>> EditarCliente(ClienteModel cliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var clienteSelecionado = _context.Clientes.FirstOrDefault(x => x.Id == cliente.Id);

                if (clienteSelecionado == null)
                    throw new BadHttpRequestException("Este cliente não foi encontrado.");

                clienteSelecionado.NomeCliente = cliente.NomeCliente;
                clienteSelecionado.Senha = cliente.Senha;
                clienteSelecionado.Email = cliente.Email;

                _context.Update(clienteSelecionado);
                await _context.SaveChangesAsync();

                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente atualizado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<ClienteModel>> DeletarCliente(string cpf)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var clienteSelecionado = _context.Clientes.FirstOrDefault(x => x.CPF == cpf.Replace("-", "").Replace(".", "").Trim());

                if (clienteSelecionado == null)
                    throw new Exception("Este cliente não foi encontrado.");

                _context.Remove(clienteSelecionado);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Cliente deletado com sucesso";
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
