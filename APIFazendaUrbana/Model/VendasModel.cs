using System.Text.Json.Serialization;

namespace APIFazendaUrbana.Model
{
    public class VendasModel
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string QuantidadeVendida {  get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaDePagamento { get; set; }
    }
}
