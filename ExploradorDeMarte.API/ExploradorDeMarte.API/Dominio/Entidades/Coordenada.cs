namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Coordenada
    {
        public int X { get; }
        public int Y { get; }

        public Coordenada(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
