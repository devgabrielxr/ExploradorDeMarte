using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Mapeadores
{
    public static class SondaMap
    {
        public static SondaDTO ParaDTO(this ISonda sonda)
        {
            return new SondaDTO
            {
                Nome = sonda.Nome,
                X = sonda.Coordenada.X,
                Y = sonda.Coordenada.Y
            };
        }
    }
}
