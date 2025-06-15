using ExploradorDeMarte.API.Dominio.DTOs;

namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoSonda
{
    SondaDTO CriarSonda(SondaDTO dto);
    List<SondaDTO> ObterSondas();
    void RemoverSonda(string nome);
    SondaDTO MoverSonda(string nomeSonda, string comandos);
}
