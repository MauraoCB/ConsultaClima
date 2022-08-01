using ConsultaClima.Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsultaClima.Services.DTO{
    public class CidadeDTO{
        public int Id { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
        public ICollection<PrevisaoClima> PrevisaoClima { get; set; }

        public CidadeDTO()
        {}

        public CidadeDTO(int id, string nome, int estadoId)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
        }
    }
}