using ConsultaClima.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Interfaces
{
 public   interface IPrevisaoClimaService
    {
        Task<List<PrevisaoClimaDTO>> GetPrevisaoClima(int cidadeId);
    }
}
