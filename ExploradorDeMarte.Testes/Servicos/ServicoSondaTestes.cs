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

    [Fact(DisplayName = "Deve estourar exceção ao cadastrar sonda com nome já criada.")]
    public void CriarSonda_ComNomeJaCriada_DeveLancarExcecao()
    {
        // Arrange
        var dtoOriginal = new SondaDTO
        {
            Nome = "Sonda 1",
            X = 2,
            Y = 3,
            Direcao = eDirecao.Norte
        };

        var dtoDuplicado = new SondaDTO
        {
            Nome = "Sonda 1",
            X = 3,
            Y = 4,
            Direcao = eDirecao.Leste
        };

        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });

        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);
        _servicoSonda.CriarSonda(dtoOriginal);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() =>
            _servicoSonda.CriarSonda(dtoDuplicado)
        );

        // Assert
        Assert.Equal("Já existe uma sonda com esse nome.", ex.Message);
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

    [Fact(DisplayName = "Deve mover a sonda corretamente com uma sequencia de comandos")]
    public void MoverSonda_ComandosValidos_DeveAtualizarPosicao()
    {
        // Arrange
        var dto = new SondaDTO
        {
            Nome = "Sonda 1",
            X = 1,
            Y = 2,
            Direcao = eDirecao.Norte
        };


        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });

        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

        _servicoSonda.CriarSonda(dto);

        // Act
        var resultado = _servicoSonda.MoverSonda("Sonda 1", "LMLMLMLMM");

        // Assert
        Assert.Equal(1, resultado.X);
        Assert.Equal(3, resultado.Y);
        Assert.Equal(eDirecao.Norte, resultado.Direcao);
    }

    [Fact(DisplayName = "Deve lançar exceção ao receber comando inválido")]
    public void MoverSonda_ComandoInvalido_DeveLancarExcecao()
    {
        // Arrange
        var dto = new SondaDTO
        {
            Nome = "Sonda 2",
            X = 1,
            Y = 0,
            Direcao = eDirecao.Norte
        };

        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });

        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

        _servicoSonda.CriarSonda(dto);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            _servicoSonda.MoverSonda("Sonda 2", "LMX")
        );

        Assert.Contains("Comando inválido", ex.Message);
    }

    [Fact(DisplayName = "Deve remover sonda existente com sucesso")]
    public void RemoverSonda_Existente_DeveRemoverComSucesso()
    {
        // Arrange
        var dto = new SondaDTO
        {
            Nome = "Sonda 3",
            X = 2,
            Y = 2,
            Direcao = eDirecao.Sul
        };

        var planalto = FabricaDePlanalto.Criar(new PlanaltoDTO { LimiteX = 5, LimiteY = 5 });
        _mockPlanalto.Setup(p => p.ObterEntidadePlanalto()).Returns(planalto);

        _servicoSonda.CriarSonda(dto);

        // Act
        _servicoSonda.RemoverSonda("Sonda 3");

        // Assert
        var sondas = _servicoSonda.ObterSondas();
        Assert.DoesNotContain(sondas, s => s.Nome == "Sonda 3");
    }
}
