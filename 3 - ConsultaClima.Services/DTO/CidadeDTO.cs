using System.Text.Json.Serialization;

namespace ConsultaClima.Services.DTO{
    public class CidadeDTO{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public int EstadoId { get; set; }

        public CidadeDTO()
        {}

        public CidadeDTO(int id, string nome, string uf, int estadoId)
        {
            Id = id;
            Nome = nome;
            UF = uf;
            EstadoId = estadoId;
        }
    }
}