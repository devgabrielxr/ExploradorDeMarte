using ExploradorDeMarte.API.Dominio.Servicos;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Fabricas
{
    public static class FabricaDeServicoPlanalto
    {
        public static IServicoPlanalto Criar()
        {
            return new ServicoPlanalto();
        }
    }
}
