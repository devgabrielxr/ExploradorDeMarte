using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Enumeradores;
using ExploradorDeMarte.API.Dominio.Fabricas;
using ExploradorDeMarte.API.Dominio.Servicos;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using Moq;

namespace ExploradorDeMarte.Testes.Servicos;

public class ServicoSondaTestes
{
    private readonly Mock<IServicoPlanalto> _mockPlanalto;
    private readonly IServicoSonda _servicoSonda;

    public ServicoSondaTestes()
    {
        _mockPlanalto = new Mock<IServicoPlanalto>();
        _servicoSonda = new ServicoSonda(_mockPlanalto.Object);
    }

    [Fact(DisplayName = "Deve criar sonda com coordenadas válidas e posição livre")]
    public void CriarSonda_Valida_DeveRetornarDTO()
    {
        // Arrange
        var dto = new SondaDTO
        {
            Nome = "Sonda 1",
            X = 2,
            Y = 3,
            Direcao = eDirecao.Norte
        };

        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });

        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

        // Act
        var resultado = _servicoSonda.CriarSonda(dto);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(dto.Nome, resultado.Nome);
        Assert.Equal(dto.X, resultado.X);
        Assert.Equal(dto.Y, resultado.Y);
        Assert.Equal(dto.Direcao, resultado.Direcao);
    }


}
