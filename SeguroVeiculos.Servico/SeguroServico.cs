using SeguroVeiculos.Dominio.Entidades;
using SeguroVeiculos.Repositorio.Interfaces;
using SeguroVeiculos.Servico.Interfaces;

namespace SeguroVeiculos.Servico
{
    public class SeguroServico : ISeguroServico
    {
        private readonly ISeguroRepositorio _seguroRepositorio;

        public SeguroServico(ISeguroRepositorio seguroRepositorio)
        {
            _seguroRepositorio = seguroRepositorio;
        }

        public bool Gravar(Seguro seguro)
        {
            try
            {
                seguro.ValorSeguro = Calcular.ValorDoSeguro(seguro.ValorVeiculo);
                _seguroRepositorio.Gravar(seguro);

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Seguro> ListaSeguros(string nomeSegurado, string documentoSegurado)
        {
            return _seguroRepositorio.ListaDeSeguros(nomeSegurado, documentoSegurado);
        }
    }
}