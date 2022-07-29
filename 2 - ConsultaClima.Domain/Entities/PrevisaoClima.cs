using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Domain.Entities
{
  public  class PrevisaoClima:Base
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public double TemperaturaMinima { get; set; }
        public double TemperaturaMaxima { get; set; }

        public Cidade Cidade{ get; set; }
    }
}
