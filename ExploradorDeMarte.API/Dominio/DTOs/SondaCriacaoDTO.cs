namespace ExploradorDeMarte.API.Dominio.DTOs
{
    public class SondaCriacaoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }
        public string Direcao { get; set; } = "N";
    }
}


