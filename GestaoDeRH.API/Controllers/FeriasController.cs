using GestaoDeRH.Aplicacao.Ferias.Interfaces;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;
using GestaoDeRH.Aplicacao.Recrutamento;
using GestaoDeRH.Dominio.FeriasColaborador;
using GestaoDeRH.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestaoDeRH.Aplicacao.Ferias.DTO;

namespace GestaoDeRH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeriasController(ISolicitarFerias solicitarFerias) : ControllerBase
    {
        [HttpPost("Ferias")]
        public async Task<IActionResult> NovaFerias(SolicitarFeriasDto dto)
        {
            var resultado = await solicitarFerias.Ferias(dto);

            if (resultado.Sucesso)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }
    }
}
