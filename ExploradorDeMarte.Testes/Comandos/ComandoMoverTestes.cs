using ExploradorDeMarte.API.Dominio.Comandos.Interfaces;
using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Fabricas;
using Moq;
using ExploradorDeMarte.API.Dominio.Enumeradores;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.Testes.Comandos
{
    public class ComandoMoverTestes
    {
        private readonly Mock<IServicoPlanalto> _mockPlanalto;
        public ComandoMoverTestes()
        {
            _mockPlanalto = new Mock<IServicoPlanalto>();
        }

        [Fact(DisplayName = "Deve mover a sonda para frente se posição for válida e livre")]
        public void Executar_MovimentoValido_DeveMover()
        {
            // Arrange
            var dto = new SondaDTO { Nome = "Sonda", X = 0, Y = 0, Direcao = eDirecao.Norte };
            var sonda = FabricaDeSonda.Criar(dto);

            var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
            _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

            var outrasSondas = new List<ISonda>();
            IComandoSonda comando = FabricaDeComandoSonda.Criar('M');

            // Act
            comando.Executar(sonda, planalto, outrasSondas);

            // Assert
            Assert.Equal(0, sonda.Coordenada.X);
            Assert.Equal(1, sonda.Coordenada.Y); // Direcao default: Norte
        }

        [Fact(DisplayName = "Deve lançar exceção se a próxima coordenada estiver fora do planalto")]
        public void Executar_ForaDosLimites_DeveLancarExcecao()
        {
            // Arrange
            var dto = new SondaDTO { Nome = "Sonda", X = 4, Y = 5, Direcao = eDirecao.Norte };
            var sonda = FabricaDeSonda.Criar(dto);

            var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
            _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

            IComandoSonda comando = FabricaDeComandoSonda.Criar('M');

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                comando.Executar(sonda, planalto, new List<ISonda>())
            );

            Assert.Equal("Movimento inválido: a sonda sairia dos limites do planalto.", ex.Message);
        }

        [Fact(DisplayName = "Deve lançar exceção se já houver outra sonda na próxima posição")]
        public void Executar_Colisao_DeveLancarExcecao()
        {
            // Arrange
            var dto = new SondaDTO { Nome = "Sonda", X = 0, Y = 0, Direcao = eDirecao.Norte };
            var sonda = FabricaDeSonda.Criar(dto);

            var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
            _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

            var dtoBloqueadora = new SondaDTO { Nome = "Outra", X = 0, Y = 1, Direcao = eDirecao.Sul };
            var sondaBloqueadora = FabricaDeSonda.Criar(dtoBloqueadora);

            var outrasSondas = new List<ISonda> { sondaBloqueadora };

            IComandoSonda comando = FabricaDeComandoSonda.Criar('M');

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                comando.Executar(sonda, planalto, outrasSondas)
            );

            Assert.Equal("Movimento inválido: já existe uma sonda nesta posição.", ex.Message);
        }
    }
}
