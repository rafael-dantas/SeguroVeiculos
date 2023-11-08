
namespace SeguroVeiculos.Dominio.Entidades
{
    public class Seguro
    {
        public int Id { get; set; }
        public string NomeSegurado { get; set; }
        public string DocumentoSegurado { get; set; }
        public int IdadeSegurado { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public decimal ValorVeiculo { get; set; }      
        public decimal ValorSeguro { get; set; }
    }
}
