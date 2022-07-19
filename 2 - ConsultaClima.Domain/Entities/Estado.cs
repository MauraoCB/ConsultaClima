using System.Collections.Generic;

namespace ConsultaClima.Domain.Entities
{
    public class Estado : Base
    {

        public ICollection<Cidade> Cidades { get; set; }
        public string UF { get; set; }

        public Estado()
        { }

        public Estado(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            UF = uf;
        }
    }
}