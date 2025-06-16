using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Enumeradores;
using ExploradorDeMarte.API.Dominio.Fabricas;

namespace ExploradorDeMarte.Testes.Entidades
{
    public class SondaTestes
    {
        [Fact(DisplayName = "Deve girar a sonda para a esquerda corretamente")]
        public void GirarEsquerda_DeveAlterarDirecao()
        {
            // Arrange
            var dto = new SondaDTO
            {
                Nome = "Teste",
                X = 1,
                Y = 1,
                Direcao = eDirecao.Norte
            };
            var sonda = FabricaDeSonda.Criar(dto);

            // Act
            sonda.GirarEsquerda();

            // Assert
            Assert.Equal(eDirecao.Oeste, sonda.Direcao);
        }

        [Fact(DisplayName = "Deve girar a sonda para a direita corretamente")]
        public void GirarDireita_DeveAlterarDirecao()
        {
            // Arrange
            var dto = new SondaDTO
            {
                Nome = "Teste",
                X = 1,
                Y = 1,
                Direcao = eDirecao.Norte
            };
            var sonda = FabricaDeSonda.Criar(dto);

            // Act
            sonda.GirarDireita();

            // Assert
            Assert.Equal(eDirecao.Leste, sonda.Direcao);
        }

        [Fact(DisplayName = "Deve retornar próxima coordenada corretamente")]
        public void ObterProximaCoordenada_DeveRetornarCoordenadaNova()
        {
            // Arrange
            var dto = new SondaDTO
            {
                Nome = "Teste",
                X = 1,
                Y = 1,
                Direcao = eDirecao.Norte
            };

            var sonda = FabricaDeSonda.Criar(dto);

            // Act
            var proxima = sonda.ObterProximaCoordenada();

            // Assert
            Assert.Equal(1, proxima.X);
            Assert.Equal(2, proxima.Y);
        }

        [Fact(DisplayName = "Deve mover a sonda para nova coordenada")]
        public void MoverPara_DeveAtualizarCoordenada()
        {
            // Arrange
            var dto = new SondaDTO
            {
                Nome = "Teste",
                X = 1,
                Y = 1,
                Direcao = eDirecao.Norte
            };
            var sonda = FabricaDeSonda.Criar(dto);
            var nova = FabricaDeCoordenada.Criar(2, 2);

            // Act
            sonda.MoverPara(nova);

            // Assert
            Assert.Equal(2, sonda.Coordenada.X);
            Assert.Equal(2, sonda.Coordenada.Y);
        }
    }

}

