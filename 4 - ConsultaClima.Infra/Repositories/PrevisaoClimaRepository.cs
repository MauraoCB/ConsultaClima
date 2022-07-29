using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Context;
using ConsultaClima.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Infra.Repositories
{
  
    public class PrevisaoClimaRepository : BaseRepository<PrevisaoClima>, IPrevisaoClimaRepository
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        private readonly ConsultaClimaContext _context;

        public PrevisaoClimaRepository(ConsultaClimaContext context) : base(context)
        {
            _context = context;

            _startDate = DateTime.Today;
            _endDate = DateTime.Today.AddDays(7);

        }

        public async Task<List<PrevisaoClima>> GetPrevisaoClima(int cidadeId)
        {
            var previsaoClima = _context.PrevisaoClima.Where(d => d.DataPrevisao >= _startDate && d.DataPrevisao < _endDate && d.CidadeId == cidadeId)
                                                      .Include(c => c.Cidade.Estado)
                                                      .OrderBy(t => t.DataPrevisao).ToList();

            return await Task.FromResult(previsaoClima);
        }
    }
}
