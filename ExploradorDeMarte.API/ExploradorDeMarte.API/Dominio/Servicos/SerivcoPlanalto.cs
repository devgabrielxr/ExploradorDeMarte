using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Mapeadores;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Servicos
{
    public class ServicoPlanalto : IServicoPlanalto
    {
        private Planalto? _planalto;

        public PlanaltoDTO CriarPlanalto(int limiteX, int limiteY)
        {
            if (_planalto != null)
                throw new InvalidOperationException("O planalto já foi criado.");

            _planalto = new Planalto(limiteX, limiteY);
            var retorno = PlanaltoMap.ParaDTO(_planalto);

            return retorno;
        }

        public PlanaltoDTO AtualizarPlanalto(int limiteX, int limiteY)
        {
            if (_planalto == null)
                throw new InvalidOperationException("Nenhum planalto existente para atualizar.");

            _planalto = new Planalto(limiteX, limiteY);
            var retorno = PlanaltoMap.ParaDTO(_planalto);

            return retorno;
        }

        public void RemoverPlanalto()
        {
            if (_planalto == null)
                throw new InvalidOperationException("Nenhum planalto existente para remover.");

            _planalto = null;
        }

        public PlanaltoDTO? ObterPlanalto()
        {
            return _planalto == null ? null : PlanaltoMap.ParaDTO(_planalto);
        }
    }
}
