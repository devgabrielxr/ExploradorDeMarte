using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.Entidades.Interfaces
{
    public interface ISonda
    {
        #region Propriedades
        int Id { get; }
        string Nome { get; }
        ICoordenada Coordenada { get; }
        eDirecao Direcao { get; }
        #endregion

        #region Métodos
        void GirarEsquerda();
        void GirarDireita();
        ICoordenada ObterProximaCoordenada();
        void MoverPara(ICoordenada novaCoordenada);
        #endregion
    }
}
