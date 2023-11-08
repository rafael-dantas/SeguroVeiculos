using SeguroVeiculos.Dominio.Entidades;

namespace SeguroVeiculos.Repositorio.Interfaces
{
    public interface ISeguroRepositorio
    {
        void Gravar(Seguro seguro);

        IEnumerable<Seguro> ListaDeSeguros(string nomeSegurado, string documentoSegurado);
    }
}
