using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.Entidades.Interfaces
{
    public interface ISonda
    {
        ICoordenada Coordenada { get; }
        eDirecao Direcao { get; }
    }
}
