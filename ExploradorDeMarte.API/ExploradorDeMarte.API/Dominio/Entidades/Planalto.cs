namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Planalto
    {
        public int LimiteX { get; }
        public int LimiteY { get; }

        public Planalto(int limiteX, int limiteY)
        {
            if (limiteX <= 0 || limiteY <= 0)
                throw new ArgumentException("Os limites do planalto devem ser positivos.");

            LimiteX = limiteX;
            LimiteY = limiteY;
        }

        public bool PosicaoEhValida(int x, int y)
        {
            return x >= 0 && x <= LimiteX && y >= 0 && y <= LimiteY;
        }

        public bool PosicaoEhValida(Coordenada coordenada)
        {
            return PosicaoEhValida(coordenada.X, coordenada.Y);
        }
    }
}
