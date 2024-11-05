using System.Text.Json.Serialization;

namespace APIFazendaUrbana.Model
{
    public class ClienteModel
    {
        public int Id { get; set; } 
        public string NomeCliente { get; set; }
        public string CPF {  get; set; }
        public string Email { get;set; }
        public string Senha { get; set; }
    }
}
