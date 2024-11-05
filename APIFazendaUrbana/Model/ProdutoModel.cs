using System.Text.Json.Serialization;

namespace APIFazendaUrbana.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco {  get; set; }
    }
}
