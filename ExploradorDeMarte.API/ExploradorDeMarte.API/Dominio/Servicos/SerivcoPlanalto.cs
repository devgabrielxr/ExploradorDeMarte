using ExploradorDeMarte.API.Dominio.Entidades;

namespace ExploradorDeMarte.API.Dominio.Servicos
{
    public class ServicoPlanalto
    {
        private Planalto? _planalto;

        public Planalto CriarPlanalto(int limiteX, int limiteY)
        {
            if (_planalto != null)
                throw new InvalidOperationException("O planalto já foi criado.");

            _planalto = new Planalto(limiteX, limiteY);
            return _planalto;
        }

        public Planalto AtualizarPlanalto(int limiteX, int limiteY)
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

        public Planalto? ObterPlanalto() => _planalto;
    }
}
