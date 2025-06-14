using ExploradorDeMarte.API.Dominio.DTOs;
namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoPlanalto
{
        PlanaltoDTO CriarPlanalto(int limiteX, int limiteY);
        PlanaltoDTO AtualizarPlanalto(int limiteX, int limiteY);
        void RemoverPlanalto();
        PlanaltoDTO? ObterPlanalto();
}
