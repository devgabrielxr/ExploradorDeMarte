using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Fabricas;
using ExploradorDeMarte.API.Dominio.Mapeadores;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

namespace ExploradorDeMarte.API.Dominio.Servicos
{
    public class ServicoSonda : IServicoSonda
    {
        private readonly IServicoPlanalto _servicoPlanalto;
        private readonly List<ISonda> _sondas = new();

        public ServicoSonda(IServicoPlanalto servicoPlanalto)
        {
            _servicoPlanalto = servicoPlanalto;
        }

        public SondaDTO CriarSonda(SondaDTO dto)
        {
            var planalto = _servicoPlanalto.ObterEntidadePlanalto();

            if (planalto == null)
                throw new InvalidOperationException("Nenhum planalto foi criado.");

            if (!planalto.PosicaoEhValida(dto.X, dto.Y))
                throw new InvalidOperationException("A posição da sonda está fora dos limites do planalto.");

            if (_sondas.Any(s => s.Coordenada.X == dto.X && s.Coordenada.Y == dto.Y))
                throw new InvalidOperationException("Já existe uma sonda nessa coordenada.");

            var sonda = FabricaDeSonda.Criar(dto);
            _sondas.Add(sonda);

            return SondaMap.ParaDTO(sonda);
        }

        public List<SondaDTO> ObterSondas()
        {
            return _sondas
                .Select(s => s.ParaDTO())
                .ToList();
        }
    }
}
