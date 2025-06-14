using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Mapeadores
{
    public static class PlanaltoMap
    {
        public static PlanaltoDTO ParaDTO(this IPlanalto planalto)
        {
            return new PlanaltoDTO
            {
                LimiteX = planalto.LimiteX,
                LimiteY = planalto.LimiteY
            };
        }
    }
}
