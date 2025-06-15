using ExploradorDeMarte.API.Dominio.Comandos;
using ExploradorDeMarte.API.Dominio.Comandos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Fabricas;

public class FabricaDeComandoSonda
{
    public static IComandoSonda Criar(char comando)
    {
        return comando switch
        {
            'L' => new ComandoGirarEsquerda(),
            _ => throw new ArgumentException($"Comando inválido: {comando}")
        };
    }
}
