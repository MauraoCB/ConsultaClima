using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Domain.Entities
{
  public   class Cidade:Base
    {
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
        public ICollection<PrevisaoClima>PrevisaoClima  { get; set; }
        public Cidade()
        { }

        public Cidade(int id, string nome, int estadoId)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
        }
    }
}
