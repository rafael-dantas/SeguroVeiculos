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
            var query = _context.Seguros.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nomeSegurado))
            {
                query.Where(x => x.NomeSegurado == nomeSegurado);
            }

            if (!string.IsNullOrWhiteSpace(documentoSegurado))
            {
                query.Where(x => x.DocumentoSegurado == documentoSegurado);
            }

            return query.ToList();
        }
    }
}
