using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;

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
        #endregion
    }
}
