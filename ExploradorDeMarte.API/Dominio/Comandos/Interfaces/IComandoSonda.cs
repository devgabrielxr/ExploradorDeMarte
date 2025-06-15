using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Comandos.Interfaces
{
    public interface IComandoSonda
    {
        void Executar(ISonda sonda, IPlanalto planalto, IEnumerable<ISonda> todasAsSondas);
    }
}


