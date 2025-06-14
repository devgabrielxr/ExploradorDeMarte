namespace ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

public interface IPlanalto
{
    #region Propriedades
    int LimiteX { get; }
    int LimiteY { get; }
    #endregion

    #region Métodos
    bool PosicaoEhValida(int x, int y);
    bool PosicaoEhValida(Coordenada coordenada);
    #endregion
}
