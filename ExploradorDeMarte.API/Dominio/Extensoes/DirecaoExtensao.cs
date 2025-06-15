using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.Extensoes
{
    public static class DirecaoExtensao
    {
        public static eDirecao ParaDirecaoEnum(this string direcao)
        {
            return direcao.ToUpper() switch
            {
                "N" => eDirecao.Norte,
                "S" => eDirecao.Sul,
                "E" => eDirecao.Leste,
                "W" => eDirecao.Oeste,
                _ => throw new ArgumentException($"Direção inválida: {direcao}. Use N, S, E ou W.")
            };
        }
    }
}
