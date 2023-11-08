using SeguroVeiculos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculos.Servico.Interfaces
{
    public interface ISeguroServico
    {
        bool Gravar(Seguro seguro);

        IEnumerable<Seguro> ListaSeguros(string nomeSegurado, string documentoSegurado);
    }
}
