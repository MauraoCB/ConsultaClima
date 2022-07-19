using System.Text.Json.Serialization;

namespace ConsultaClima.Services.DTO{
    public class EstadoDTO{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public EstadoDTO()
        {}

        public EstadoDTO(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            UF = uf;
        }
    }
}