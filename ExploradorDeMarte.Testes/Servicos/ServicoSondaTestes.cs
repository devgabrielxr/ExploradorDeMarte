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

    [Fact(DisplayName = "Deve retornar todas as sondas registradas")]
    public void ObterSondas_QuandoSondasForemCriadas_DeveRetornarListaDTO()
    {
        // Arrange
        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

        var dto1 = new SondaDTO
        {
            Nome = "Sonda A",
            X = 1,
            Y = 2,
            Direcao = eDirecao.Norte
        };

        var dto2 = new SondaDTO
        {
            Nome = "Sonda B",
            X = 2,
            Y = 3,
            Direcao = eDirecao.Leste
        };

        _servicoSonda.CriarSonda(dto1);
        _servicoSonda.CriarSonda(dto2);

        // Act
        var sondas = _servicoSonda.ObterSondas();

        // Assert
        Assert.NotNull(sondas);
        Assert.Equal(2, sondas.Count);

        Assert.Contains(sondas, s => s.Nome == "Sonda A" && s.X == 1 && s.Y == 2 && s.Direcao == eDirecao.Norte);
        Assert.Contains(sondas, s => s.Nome == "Sonda B" && s.X == 2 && s.Y == 3 && s.Direcao == eDirecao.Leste);
    }

}
