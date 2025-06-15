using ExploradorDeMarte.API.Dominio.Comandos.Interfaces;
using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;
using ExploradorDeMarte.API.Dominio.Fabricas;
using Moq;

namespace ExploradorDeMarte.Testes.Comandos
{
    public class ComandoGirarEsquerdaTestes
    {

        [Fact(DisplayName = "Fábrica deve criar comando de girar à esquerda e executar corretamente")]
        public void Executar_DeveGirarSondaParaEsquerda()
        {
            // Arrange
            var dto = new SondaDTO
            {
                Nome = "Sonda Teste",
                X = 1,
                Y = 1,
                Direcao = eDirecao.Norte
            };

            var planalto = new Mock<IPlanalto>().Object;
            var outrasSondas = new List<ISonda>();
            var sonda = FabricaDeSonda.Criar(dto);
            IComandoSonda comando = FabricaDeComandoSonda.Criar('L');

            // Act
            comando.Executar(sonda, planalto, outrasSondas);

            // Assert
            Assert.Equal(eDirecao.Oeste, sonda.Direcao);
        }
    }
}


