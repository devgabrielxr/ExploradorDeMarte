using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using ExploradorDeMarte.API.Dominio.Servicos;

namespace ExploradorDeMarte.Testes.Servicos
{
    public class ServicoPlanaltoTestes
    {
        private readonly IServicoPlanalto _servicoPlanalto;

        public ServicoPlanaltoTestes()
        {
            _servicoPlanalto = new ServicoPlanalto();
        }

        [Fact(DisplayName = "Deve criar um planalto com limites válidos")]
        public void CriarPlanalto_ComLimitesValidos_DeveRetornarDTO()
        {
            // Arrange
            var dto = new PlanaltoDTO { LimiteX = 5, LimiteY = 5 };

            // Act
            var resultado = _servicoPlanalto.CriarPlanalto(dto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(5, resultado.LimiteX);
            Assert.Equal(5, resultado.LimiteY);
        }

        [Fact(DisplayName = "Deve retornar DTO ao obter planalto existente")]
        public void ObterPlanalto_QuandoExiste_DeveRetornarDTO()
        {
            // Arrange
            var dto = new PlanaltoDTO { LimiteX = 4, LimiteY = 4 };
            _servicoPlanalto.CriarPlanalto(dto);

            // Act
            var resultado = _servicoPlanalto.ObterPlanalto();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(4, resultado.LimiteX);
            Assert.Equal(4, resultado.LimiteY);
        }

        [Fact(DisplayName = "Deve retornar null ao obter planalto inexistente")]
        public void ObterPlanalto_QuandoNaoExiste_DeveRetornarNull()
        {
            // Act
            var resultado = _servicoPlanalto.ObterPlanalto();

            // Assert
            Assert.Null(resultado);
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar planalto com limites negativos")]
        public void CriarPlanalto_ComLimitesNegativos_DeveLancarExcecao()
        {
            // Arrange
            var dto = new PlanaltoDTO { LimiteX = -1, LimiteY = 2 };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _servicoPlanalto.CriarPlanalto(dto));
            Assert.Equal("Os limites do planalto devem ser positivos.", ex.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção ao atualizar com limites inválidos")]
        public void AtualizarPlanalto_ComLimitesInvalidos_DeveLancarExcecao()
        {
            // Arrange
            _servicoPlanalto.CriarPlanalto(new PlanaltoDTO { LimiteX = 2, LimiteY = 2 });

            var dtoInvalido = new PlanaltoDTO { LimiteX = 0, LimiteY = -3 };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _servicoPlanalto.AtualizarPlanalto(dtoInvalido));
            Assert.Equal("Os limites do planalto devem ser positivos.", ex.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção ao criar planalto com zero")]
        public void CriarPlanalto_ComZero_DeveLancarExcecao()
        {
            // Arrange
            var dto = new PlanaltoDTO { LimiteX = 0, LimiteY = 0 };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _servicoPlanalto.CriarPlanalto(dto));
            Assert.Equal("Os limites do planalto devem ser positivos.", ex.Message);
        }
    }
}
