using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using ExploradorDeMarte.API.Dominio.Fabricas;

namespace ExploradorDeMarte.Testes.Servicos
{
    public class ServicoPlanaltoTestes
    {
        private IServicoPlanalto CriarServico() =>
            FabricaDeServicoPlanalto.Criar();

        [Fact(DisplayName = "Deve criar um planalto com limites válidos")]
        public void CriarPlanalto_ComLimitesValidos_DeveRetornarDTO()
        {
            // Arrange
            var dto = new PlanaltoDTO { LimiteX = 5, LimiteY = 5 };
            var servico = CriarServico();

            // Act
            var resultado = servico.CriarPlanalto(dto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(5, resultado.LimiteX);
            Assert.Equal(5, resultado.LimiteY);
        }
    }
}
