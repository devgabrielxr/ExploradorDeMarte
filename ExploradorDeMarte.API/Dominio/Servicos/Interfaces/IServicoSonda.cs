using ExploradorDeMarte.API.Dominio.DTOs;

namespace ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

public interface IServicoSonda
{
    SondaDTO CriarSonda(SondaDTO dto);
    List<SondaDTO> ObterSondas();
    SondaDTO MoverSonda(string nomeSonda, string comandos);
}
