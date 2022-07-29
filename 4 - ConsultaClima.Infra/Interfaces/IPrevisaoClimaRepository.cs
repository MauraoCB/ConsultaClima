using ConsultaClima.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsultaClima.Infra.Interfaces
{
public interface IPrevisaoClimaRepository : IBaseRepository<PrevisaoClima>
    {
        Task<List<PrevisaoClima>> GetPrevisaoClima(int cidadeId);
    }
}
