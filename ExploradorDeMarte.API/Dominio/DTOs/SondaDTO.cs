using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.DTOs;

public class SondaDTO
{
    public string Nome { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public eDirecao Direcao { get; set; }
}
