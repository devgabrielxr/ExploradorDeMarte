namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Coordenada
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
