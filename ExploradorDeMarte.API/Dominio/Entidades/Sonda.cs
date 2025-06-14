using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Sonda : ISonda
    {
        public ICoordenada Coordenada { get; private set; }
        public eDirecao Direcao { get; private set; }

        public Sonda(ICoordenada coordenada, eDirecao direcao)
        {
            Coordenada = coordenada;
            Direcao = direcao;
        }
    }
}
