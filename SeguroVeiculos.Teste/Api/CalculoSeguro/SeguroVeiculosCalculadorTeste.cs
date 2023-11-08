using SeguroVeiculos.Teste.Api.Mock;

namespace SeguroVeiculos.Teste.Api.CalculoSeguro
{
    public class SeguroVeiculosCalculadorTeste
    {
        private readonly Dominio.Entidades.Seguro seguroMock;

        public SeguroVeiculosCalculadorTeste()
        {
            seguroMock = SeguroMock.SeguroFake();
        }

        [Fact]
        public async Task CalcularTaxaDeRisco()
        {
            var taxaDeRisco = Servico.Calcular.TaxaDeRisco(seguroMock.ValorVeiculo);           

            Assert.Equal(taxaDeRisco, 0.025M);
        }

        [Fact]
        public async Task CalcularPremioDeRisco()
        {
            var taxaDeRisco = Servico.Calcular.TaxaDeRisco(seguroMock.ValorVeiculo);
            var premioDeRisco = Servico.Calcular.PremioDeRisco(taxaDeRisco, seguroMock.ValorVeiculo);

            Assert.Equal(premioDeRisco, 250.00M);
        }

        [Fact]
        public async Task CalcularPremioPuro()
        {
            var taxaDeRisco = Servico.Calcular.TaxaDeRisco(seguroMock.ValorVeiculo);
            var premioDeRisco = Servico.Calcular.PremioDeRisco(taxaDeRisco, seguroMock.ValorVeiculo);
            var premioPuro = Servico.Calcular.PremioPuro(premioDeRisco);

            Assert.Equal(premioPuro, 257.50M);
        }

        [Fact]
        public async Task CalcularPremioComercial()
        {
            var taxaDeRisco = Servico.Calcular.TaxaDeRisco(seguroMock.ValorVeiculo);
            var premioDeRisco = Servico.Calcular.PremioDeRisco(taxaDeRisco, seguroMock.ValorVeiculo);
            var premioPuro = Servico.Calcular.PremioPuro(premioDeRisco);
            var premioComercial = Servico.Calcular.PremioComercial(premioPuro);

            Assert.Equal(premioComercial, 270.375M);
        }

        [Fact]
        public async Task CalcularValorSeguro()
        {
            var taxaDeRisco = Servico.Calcular.ValorDoSeguro(seguroMock.ValorVeiculo);

            Assert.Equal(taxaDeRisco, 270.37M);
        }
    }
}
