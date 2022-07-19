using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Context;
using ConsultaClima.Infra.Interfaces;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Infra.Repositories
{
   

    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        private readonly ConsultaClimaContext _context;

        public CidadeRepository(ConsultaClimaContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<T>> GetCidadesMaisAsync()
        {
            return await _context.Cidades. ;
        }
    }
}
