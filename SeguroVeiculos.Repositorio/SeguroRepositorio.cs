using SeguroVeiculos.Dominio.Entidades;
using SeguroVeiculos.Repositorio.Interfaces;

namespace SeguroVeiculos.Repositorio
{
    public class SeguroRepositorio : ISeguroRepositorio
    {
        private readonly SeguroVeiculosContext _context;

        public SeguroRepositorio(SeguroVeiculosContext context)
        {
            _context = context;
        }

        public void Gravar(Seguro seguro)
        {
            _context.Add(seguro);
            _context.SaveChanges();
        }

        public IEnumerable<Seguro> ListaDeSeguros(string nomeSegurado, string documentoSegurado)
        {
            return _context.Seguros.Where(x => (string.IsNullOrEmpty(nomeSegurado) || x.NomeSegurado.Contains(nomeSegurado)) 
                                            && (string.IsNullOrEmpty(documentoSegurado) || x.DocumentoSegurado == documentoSegurado)).ToList();
        }
    }
}
