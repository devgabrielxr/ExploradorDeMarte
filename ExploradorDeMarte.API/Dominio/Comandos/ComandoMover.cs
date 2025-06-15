using ExploradorDeMarte.API.Dominio.Comandos.Interfaces;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Comandos;

public class ComandoMover : IComandoSonda
{
    public void Executar(ISonda sonda, IPlanalto planalto, IEnumerable<ISonda> todasAsSondas)
    {
        var proxima = sonda.ObterProximaCoordenada();

        if (!planalto.PosicaoEhValida(proxima.X, proxima.Y))
            throw new InvalidOperationException("Movimento inválido: a sonda sairia dos limites do planalto.");

        var haColisao = todasAsSondas.Any(s =>
            s != sonda &&
            s.Coordenada.X == proxima.X &&
            s.Coordenada.Y == proxima.Y
        );

        if (haColisao)
            throw new InvalidOperationException("Movimento inválido: já existe uma sonda nesta posição.");

        sonda.MoverPara(proxima);
    }
}
