using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Fabricas
{
    public static class FabricaDePlanalto
    {
        public static IPlanalto Criar(PlanaltoDTO dto)
        {
            return new Planalto(dto.LimiteX, dto.LimiteY);
        }
    }
}
