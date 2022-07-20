using System;
namespace ConsultaClima.Services.DTO
{
    public class PrevisaoClimaDTO
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao{ get; set; }
        public string Clima { get; set; }
        public double TemperaturaMinima { get; set; }
        public double TemperaturaMaxima { get; set; }
        public CidadeDTO Cidade { get; set; }

        public PrevisaoClimaDTO()
        {}

        public PrevisaoClimaDTO(int id,  int cidadeId, DateTime dataPrevisao, double temperaturaMaxima, double temperaturaMinima)
        {
            Id = id;
            CidadeId = cidadeId;
            DataPrevisao = dataPrevisao;
            TemperaturaMaxima = temperaturaMaxima;
            TemperaturaMinima = temperaturaMinima;

        }
    }
}