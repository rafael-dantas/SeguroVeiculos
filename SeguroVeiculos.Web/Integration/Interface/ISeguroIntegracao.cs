using SeguroVeiculos.Web.Models;

namespace SeguroVeiculos.Web.Integration.Interface
{
    public interface ISeguroIntegracao
    {
        void Gravar(SeguroViewModel model);
        List<SeguroViewModel> ListarSegurados(string nomeSegurado, string documentoSegurado);
    }
}
