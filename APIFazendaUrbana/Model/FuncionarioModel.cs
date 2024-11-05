using System.Text.Json.Serialization;

namespace APIFazendaUrbana.Model
{
    public class FuncionarioModel
    {
       
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string CPF { get; set; }
        public string Funcao { get; set; }
        
    }
}
