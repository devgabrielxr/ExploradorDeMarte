using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ExploradorDeMarte.API.Controladores
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanaltoController : ControllerBase
    {
        private readonly ServicoPlanalto _servicoPlanalto;

        public PlanaltoController(ServicoPlanalto servicoPlanalto)
        {
            _servicoPlanalto = servicoPlanalto;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PlanaltoDTO dto)
        {
            try
            {
                var planalto = _servicoPlanalto.CriarPlanalto(dto.LimiteX, dto.LimiteY);

                return CreatedAtAction(nameof(Obter), new { }, new
                {
                    mensagem = "Planalto criado com sucesso!",
                    limiteX = planalto.LimiteX,
                    limiteY = planalto.LimiteY
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
        }

        [HttpGet]
        public IActionResult Obter()
        {
            var planalto = _servicoPlanalto.ObterPlanalto();

            if (planalto == null)
                return NotFound(new { erro = "Planalto ainda não foi criado ou removido." });

            return Ok(new
            {
                limiteX = planalto.LimiteX,
                limiteY = planalto.LimiteY
            });
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] PlanaltoDTO dto)
        {
            try
            {
                var planalto = _servicoPlanalto.AtualizarPlanalto(dto.LimiteX, dto.LimiteY);

                return Ok(new
                {
                    mensagem = "Planalto atualizado com sucesso!",
                    limiteX = planalto.LimiteX,
                    limiteY = planalto.LimiteY
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult Remover()
        {
            try
            {
                _servicoPlanalto.RemoverPlanalto();

                return Ok(new
                {
                    mensagem = "Planalto removido com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }
    }
}
