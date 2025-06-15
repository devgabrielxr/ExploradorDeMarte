using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Fabricas
{
    public static class FabricaDeCoordenada
    {
        public static ICoordenada Criar(int x = 0, int y = 0)
        {
            return new Coordenada(x, y);
        }
    }
}
