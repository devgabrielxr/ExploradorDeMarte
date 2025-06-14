using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExploradorDeMarte.API.Controladores
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanaltoController : ControllerBase
    {
        private readonly IServicoPlanalto _servicoPlanalto;

        #region Construtores
        public PlanaltoController(IServicoPlanalto servicoPlanalto)
        {
            _servicoPlanalto = servicoPlanalto;
        }
        #endregion

        #region Métodos
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

        [HttpPost]
        public IActionResult Criar([FromBody] PlanaltoDTO dto)
        {
            try
            {
                var planalto = _servicoPlanalto.CriarPlanalto(dto);

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

        [HttpPut]
        public IActionResult Atualizar([FromBody] PlanaltoDTO dto)
        {
            try
            {
                var planalto = _servicoPlanalto.AtualizarPlanalto(dto);

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
        #endregion
    }
}
