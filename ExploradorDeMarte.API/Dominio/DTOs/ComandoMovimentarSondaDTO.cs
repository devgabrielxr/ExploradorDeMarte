using System.ComponentModel.DataAnnotations;

namespace ExploradorDeMarte.API.Dominio.DTOs;

public class ComandoMovimentarSondaDTO
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Comandos { get; set; } = string.Empty;
}
