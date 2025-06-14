using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoPlanalto
{
        IPlanalto CriarPlanalto(int limiteX, int limiteY);
        IPlanalto AtualizarPlanalto(int limiteX, int limiteY);
        void RemoverPlanalto();
        IPlanalto? ObterPlanalto();

}
