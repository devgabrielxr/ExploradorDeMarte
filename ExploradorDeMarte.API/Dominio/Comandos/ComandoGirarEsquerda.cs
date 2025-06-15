using ExploradorDeMarte.API.Dominio.Comandos.Interfaces;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Comandos
{
    public class ComandoGirarEsquerda : IComandoSonda
    {
        public void Executar(ISonda sonda, IPlanalto _, IEnumerable<ISonda> __)
        {
            sonda.GirarEsquerda();
        }
    }
}


