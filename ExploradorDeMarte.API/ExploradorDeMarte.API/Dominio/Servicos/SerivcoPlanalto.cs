using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Servicos
{
    public class ServicoPlanalto : IServicoPlanalto
    {
        private Planalto? _planalto;

        public IPlanalto CriarPlanalto(int limiteX, int limiteY)
        {
            if (_planalto != null)
                throw new InvalidOperationException("O planalto já foi criado.");

            _planalto = new Planalto(limiteX, limiteY);
            return _planalto;
        }

        public IPlanalto AtualizarPlanalto(int limiteX, int limiteY)
        {
            if (_planalto == null)
                throw new InvalidOperationException("Nenhum planalto existente para atualizar.");

            _planalto = new Planalto(limiteX, limiteY);
            return _planalto;
        }

        public void RemoverPlanalto()
        {
            if (_planalto == null)
                throw new InvalidOperationException("Nenhum planalto existente para remover.");

            _planalto = null;
        }

        public IPlanalto? ObterPlanalto() => _planalto;
    }
}
