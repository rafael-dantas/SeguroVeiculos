using SeguroVeiculos.Dominio.Entidades;

namespace SeguroVeiculos.Teste.Api.Mock
{
    public static class SeguroMock
    {
        public static Seguro SeguroFake() =>
            new Seguro
            {
                DocumentoSegurado = "99999999999",
                IdadeSegurado = 18,
                MarcaVeiculo = "Chevrolet",
                ModeloVeiculo = "Tracker",
                NomeSegurado = "Teste mock",
                ValorVeiculo = 10000.00M
            };
    }
}
