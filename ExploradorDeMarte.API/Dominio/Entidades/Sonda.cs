using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;
using ExploradorDeMarte.API.Dominio.Fabricas;

namespace ExploradorDeMarte.API.Dominio.Entidades
{
    public class Sonda : ISonda
    {
        #region Propriedades
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public ICoordenada Coordenada { get; private set; }
        public eDirecao Direcao { get; private set; }
        #endregion

        #region Construtores
        public Sonda(int id, string nome, ICoordenada coordenada, eDirecao direcao)
        {
            Id = id;
            Nome = nome;
            Coordenada = coordenada;
            Direcao = direcao;
        }
        #endregion

        #region Métodos
        public void GirarEsquerda()
        {
            Direcao = Direcao switch
            {
                eDirecao.Norte => eDirecao.Oeste,
                eDirecao.Oeste => eDirecao.Sul,
                eDirecao.Sul => eDirecao.Leste,
                eDirecao.Leste => eDirecao.Norte,
                _ => throw new InvalidOperationException($"Direção inválida: {Direcao}")
            };
        }

        public void GirarDireita()
        {
            Direcao = Direcao switch
            {
                eDirecao.Norte => eDirecao.Leste,
                eDirecao.Leste => eDirecao.Sul,
                eDirecao.Sul => eDirecao.Oeste,
                eDirecao.Oeste => eDirecao.Norte,
                _ => throw new InvalidOperationException($"Direção inválida: {Direcao}")
            };
        }

        public ICoordenada ObterProximaCoordenada()
        {
            return Direcao switch
            {
                eDirecao.Norte => FabricaDeCoordenada.Criar(Coordenada.X, Coordenada.Y + 1),
                eDirecao.Sul => FabricaDeCoordenada.Criar(Coordenada.X, Coordenada.Y - 1),
                eDirecao.Leste => FabricaDeCoordenada.Criar(Coordenada.X + 1, Coordenada.Y),
                eDirecao.Oeste => FabricaDeCoordenada.Criar(Coordenada.X - 1, Coordenada.Y),
                _ => throw new InvalidOperationException($"Direção inválida: {Direcao}")
            };
        }

        public void MoverPara(ICoordenada novaCoordenada)
        {
            Coordenada = novaCoordenada;
        }

        #endregion
    }
}
