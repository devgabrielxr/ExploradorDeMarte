using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoPlanalto
{
        PlanaltoDTO CriarPlanalto(PlanaltoDTO dto);
        PlanaltoDTO AtualizarPlanalto(PlanaltoDTO dto);
        void RemoverPlanalto();
        PlanaltoDTO? ObterPlanalto();
        IPlanalto? ObterEntidadePlanalto();

}
