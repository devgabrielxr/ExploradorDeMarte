using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Fabricas
{
    public static class FabricaDePlanalto
    {
        public static IPlanalto Criar(PlanaltoDTO dto)
        {
            if (dto.LimiteX <= 0 || dto.LimiteY <= 0)
                throw new ArgumentException("Os limites do planalto devem ser maiores que zero.");

            return new Planalto(dto.LimiteX, dto.LimiteY);
        }
    }
}
