using Microsoft.AspNetCore.Mvc;
using SeguroVeiculos.API.DTO;
using SeguroVeiculos.Servico.Interfaces;

namespace SeguroVeiculos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly ISeguroServico _seguroServico;
        public SeguroController(ISeguroServico seguroServico)
        {
            _seguroServico = seguroServico;
        }

        [HttpPost]
        public IActionResult Post(SeguroDTO dto)
        {
            if (_seguroServico.Gravar(SeguroDTO.Criar(dto)))
            {
                return Ok("Seguro gravado com sucesso.");
            }
            else
            {
                return BadRequest("Ocorreu um erro inesperado.");
            }
        }

        [HttpGet("lista")]
        public IActionResult Get()
        {
            var response = _seguroServico.ListaSeguros(null);
            return response.Count() > 0 ? Ok(SeguroResponseDTO.Criar(response.ToList())) : NotFound("Registros não encontrados");
        }

        [HttpGet]
        public IActionResult Get(string nomeOuDocumento)
        {            
            var response = _seguroServico.ListaSeguros(nomeOuDocumento);
            return response.Count() > 0 ? Ok(SeguroResponseDTO.Criar(response.ToList())) : NotFound("Registro não encontrados");
        }
    }
}
