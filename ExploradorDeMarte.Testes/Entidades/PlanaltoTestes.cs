using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Fabricas;

namespace ExploradorDeMarte.Testes.Entidades
{
    public class PlanaltoTestes
    {
        [Fact(DisplayName = "Deve criar planalto com limites válidos")]
        public void Criar_Planalto_Valido()
        {
            // Arrange
            var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });

            // Assert
            Assert.Equal(5, planalto.LimiteX);
            Assert.Equal(5, planalto.LimiteY);
        }

        [Theory(DisplayName = "Deve validar posições dentro e fora dos limites")]
        [InlineData(2, 3, true)]
        [InlineData(6, 6, false)]
        [InlineData(-1, 0, false)]
        public void PosicaoEhValida_DeveFuncionar(int x, int y, bool esperado)
        {
            var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
            var resultado = planalto.PosicaoEhValida(x, y);

            Assert.Equal(esperado, resultado);
        }

        [Fact(DisplayName = "Deve lançar exceção se limites forem inválidos")]
        public void Criar_Planalto_Com_Limites_Invalidos()
        {
            Assert.Throws<ArgumentException>(() => FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = -1, LimiteY = -1 }));
        }
    }

}
