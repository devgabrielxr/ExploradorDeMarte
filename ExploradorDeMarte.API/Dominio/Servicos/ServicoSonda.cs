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

            if (_sondas.Any(s => s.Nome.Equals(dto.Nome, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Já existe uma sonda com esse nome.");

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

        public void RemoverSonda(string nome)
        {
            var sonda = _sondas.FirstOrDefault(s => s.Nome == nome)
                ?? throw new InvalidOperationException($"Sonda com nome '{nome}' não encontrada.");

            _sondas.Remove(sonda);
        }

        public SondaDTO MoverSonda(string nomeSonda, string comandos)
        {
            var sonda = _sondas.FirstOrDefault(s => s.Nome == nomeSonda)
                ?? throw new InvalidOperationException($"Sonda com nome '{nomeSonda}' não encontrada.");

            var planalto = _servicoPlanalto.ObterEntidadePlanalto()
                ?? throw new InvalidOperationException("Nenhum planalto foi criado.");

            foreach (char comandoChar in comandos)
            {
                var comando = FabricaDeComandoSonda.Criar(comandoChar);
                comando.Executar(sonda, planalto, _sondas);
            }

            return SondaMap.ParaDTO(sonda);
        }
    }
}
