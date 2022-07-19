using ConsultaClima.Domain.Entities;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaClima.Infra.Interfaces
{

    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<List<T>> GetCidadesMaisAsync();
    }
}
