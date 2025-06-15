using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Fabricas;
using ExploradorDeMarte.API.Dominio.Mapeadores;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Servicos
{
    public class ServicoPlanalto : IServicoPlanalto
    {
        private IPlanalto? _planalto;

        public PlanaltoDTO CriarPlanalto(PlanaltoDTO dto)
        {
            if (_planalto != null)
                throw new InvalidOperationException("O planalto já foi criado.");

            _planalto = FabricaDePlanalto.Criar(dto);

            return PlanaltoMap.ParaDTO(_planalto);
        }

        public PlanaltoDTO AtualizarPlanalto(PlanaltoDTO dto)
        {
            if (_planalto == null)
                throw new InvalidOperationException("Nenhum planalto existente para atualizar.");

            _planalto = FabricaDePlanalto.Criar(dto);

            return PlanaltoMap.ParaDTO(_planalto);
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

        public IPlanalto? ObterEntidadePlanalto() => _planalto;
    }
}
