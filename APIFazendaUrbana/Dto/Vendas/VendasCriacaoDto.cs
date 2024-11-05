namespace APIFazendaUrbana.Dto.Vendas
{
    public class VendasCriacaoDto
    {
        public string Produto { get; set; }
        public string QuantidadeVendida { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaDePagamento { get; set; }
    }
}
