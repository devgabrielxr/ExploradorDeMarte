using ExploradorDeMarte.API.Dominio.DTOs;
using ExploradorDeMarte.API.Dominio.Entidades;
using ExploradorDeMarte.API.Dominio.Entidades.Interfaces;
using ExploradorDeMarte.API.Dominio.Enumeradores;

namespace ExploradorDeMarte.API.Dominio.Fabricas
{
    public static class FabricaDeSonda
    {
        private static int _contadorId = 1;

        private static ISonda Criar(string nome, int x, int y, eDirecao direcao)
        {
            var coordenada = new Coordenada(x, y);
            var id = _contadorId++;

            return new Sonda(id, nome, coordenada, direcao);
        }

        public static ISonda Criar(SondaDTO dto)
        {
            return Criar(dto.Nome, dto.X, dto.Y, dto.Direcao);
        }
    }
}
