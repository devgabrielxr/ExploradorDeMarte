using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExploradorDeMarte.API.Controladores
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SondaController : ControllerBase
    {
        private readonly IServicoSonda _servicoSonda;

        public SondaController(IServicoSonda servicoSonda)
        {
            _servicoSonda = servicoSonda;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] SondaDTO dto)
        {
            try
            {
                var resultado = _servicoSonda.CriarSonda(dto);

                return CreatedAtAction(nameof(ObterTodas), new { nome = resultado.Nome }, new
                {
                    mensagem = "Sonda criada com sucesso!",
                    resultado
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            var sondas = _servicoSonda.ObterSondas();
            return Ok(sondas);
        }

        [HttpPut("mover")]
        public IActionResult Mover([FromBody] ComandoMovimentarSondaDTO dto)
        {
            try
            {
                var resultado = _servicoSonda.MoverSonda(dto.Nome, dto.Comandos);

                return Ok(new
                {
                    mensagem = "Sonda movimentada com sucesso!",
                    resultado
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return UnprocessableEntity(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }
    }
}
