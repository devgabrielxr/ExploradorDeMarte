using ExploradorDeMarte.API.Dominio.DTOs;
namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoPlanalto
{
        PlanaltoDTO CriarPlanalto(PlanaltoDTO dto);
        PlanaltoDTO AtualizarPlanalto(PlanaltoDTO dto);
        void RemoverPlanalto();
        PlanaltoDTO? ObterPlanalto();
}
