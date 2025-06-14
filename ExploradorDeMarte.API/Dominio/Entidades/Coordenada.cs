using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Coordenada : ICoordenada
    {
        #region Propriedades
        public int X { get; }
        public int Y { get; }
        #endregion

        #region Construtor
        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
