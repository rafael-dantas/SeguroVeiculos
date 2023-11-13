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

        public IEnumerable<Seguro> ListaSeguros(string nomeOuDocumento)
        {
            string nome = null;
            string documento = null;

            if (EhDocumento(nomeOuDocumento))
            {
                documento = nomeOuDocumento;
            }
            else
            {
                nome = nomeOuDocumento;
            }

            return _seguroRepositorio.ListaDeSeguros(nome, documento);
        }

        private bool EhDocumento(string nomeOuDocumento)
        {
            if(long.TryParse(nomeOuDocumento, out _))
            {
                return nomeOuDocumento.Length == 11;                
            }

            return false;
        }
    }
}