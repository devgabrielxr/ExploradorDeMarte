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

        public Planalto? ObterPlanalto() => _planalto;
    }
}
