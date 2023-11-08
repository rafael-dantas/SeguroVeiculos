using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculos.Servico
{
    internal static class Calcular
    {
        private static decimal MARGEM_SEGURANCA = 3;
        private static decimal LUCRO = 5;

        public static decimal ValorDoSeguro(decimal valorVeiculo)
        {
            var taxaRisco = TaxaDeRisco(valorVeiculo);
            var premioDeRisco = PremioDeRisco(taxaRisco, valorVeiculo);
            var premioPuro = PremioPuro(premioDeRisco);
            var premioComercial = PremioComercial(premioPuro);

            return Math.Round(premioComercial, 2 , MidpointRounding.ToZero);
        }

        internal static decimal TaxaDeRisco(decimal valorVeiculo)
        {
            return ((valorVeiculo * 5)/(valorVeiculo * 2)) / 100;
        }

        internal static decimal PremioDeRisco(decimal taxaRisco, decimal valorVeiculo)
        {
            return taxaRisco * valorVeiculo;
        }

        internal static decimal PremioPuro(decimal premioDeRisco)
        {
            return premioDeRisco * (1 + (MARGEM_SEGURANCA / 100));
        }

        internal static decimal PremioComercial(decimal premioPuro)
        {
            return ((LUCRO / 100) * premioPuro) + premioPuro;
        }
    }
}
