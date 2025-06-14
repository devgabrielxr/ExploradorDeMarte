using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Planalto : IPlanalto
    {
        #region Propriedades
        public int LimiteX { get; private set; }
        public int LimiteY { get; private set; }
        #endregion

        #region Construtor
        public Planalto(int limiteX, int limiteY)
        {
            if (limiteX <= 0 || limiteY <= 0)
                throw new ArgumentException("Os limites do planalto devem ser positivos.");

            LimiteX = limiteX;
            LimiteY = limiteY;
        }
        #endregion

        #region Métodos
        public bool PosicaoEhValida(int x, int y)
        {
            return x >= 0 && x <= LimiteX && y >= 0 && y <= LimiteY;
        }

        public bool PosicaoEhValida(ICoordenada coordenada)
        {
            return PosicaoEhValida(coordenada.X, coordenada.Y);
        }
        #endregion
    }
}
