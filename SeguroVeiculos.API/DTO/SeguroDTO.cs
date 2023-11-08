using SeguroVeiculos.Dominio.Entidades;
using System.Diagnostics;

namespace SeguroVeiculos.API.DTO
{
    public class SeguroDTO
    {
        public string NomeSegurado { get; set; }
        public string DocumentoSegurado { get; set; }
        public int IdadeSegurado { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public decimal ValorVeiculo { get; set; }

        public static Seguro Criar(SeguroDTO dto) =>
           new Seguro
           {
               NomeSegurado = dto.NomeSegurado,
               DocumentoSegurado = dto.DocumentoSegurado,
               IdadeSegurado = dto.IdadeSegurado,
               MarcaVeiculo = dto.MarcaVeiculo,
               ModeloVeiculo = dto.ModeloVeiculo,
               ValorVeiculo = dto.ValorVeiculo
           };
    }

    public class SeguroResponseDTO
    {
        public int Id { get; set; }
        public string NomeSegurado { get; set; }
        public string DocumentoSegurado { get; set; }
        public int IdadeSegurado { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public decimal ValorVeiculo { get; set; }        
        public decimal ValorSeguro { get; set; }

        public static List<SeguroResponseDTO> Criar(List<Seguro> seguros)
        {

            var lista = new List<SeguroResponseDTO>();
            seguros.ForEach(x => lista.Add(new SeguroResponseDTO
            {
                Id = x.Id,
                NomeSegurado = x.NomeSegurado,
                DocumentoSegurado = x.DocumentoSegurado,
                IdadeSegurado = x.IdadeSegurado,
                MarcaVeiculo = x.MarcaVeiculo,
                ModeloVeiculo = x.ModeloVeiculo,
                ValorVeiculo = x.ValorVeiculo,               
                ValorSeguro = x.ValorSeguro
            }));

            return lista;
        }
            
    }   
}
