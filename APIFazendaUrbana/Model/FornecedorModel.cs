using System.Text.Json.Serialization;

namespace APIFazendaUrbana.Model
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CNPJ { get; set; }
        public string Adubo { get; set; }
        public int QuantidadeAdubo { get; set; }
        public string Agrotoxico { get; set; }
        public int QuantidadeAgrotoxico { get; set; }
        public string Muda { get; set; }
        public int QuantidadeMuda { get; set; }

    }
}
