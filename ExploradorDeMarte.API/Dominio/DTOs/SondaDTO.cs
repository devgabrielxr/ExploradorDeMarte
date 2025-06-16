using System.Text.Json.Serialization;
using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.DTOs;

public class SondaDTO
{
    public string Nome { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }

    /// <summary>
    /// Direção real utilizada internamente na aplicação. Ignorada na serialização JSON.
    /// </summary>
    [JsonIgnore]
    public eDirecao Direcao { get; set; }

    /// <summary>
    /// Direção como texto (ex: "N", "S", "L", "O"). Usada para entrada e saída da API.
    /// </summary>
    [JsonPropertyName("direcao")]
    public string DirecaoTexto
    {
        get => Direcao switch
        {
            eDirecao.Norte => "N",
            eDirecao.Sul => "S",
            eDirecao.Leste => "E",
            eDirecao.Oeste => "W",
            _ => string.Empty
        };
        set => Direcao = value?.Trim().ToUpper() switch
        {
            "N" => eDirecao.Norte,
            "S" => eDirecao.Sul,
            "E" => eDirecao.Leste,
            "W" => eDirecao.Oeste,
            _ => throw new ArgumentException("Direção inválida. Use: N, S, E ou W.")
        };
    }
}
