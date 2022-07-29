using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Context;
using ConsultaClima.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaClima.Infra.Repositories
{


    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        private readonly ConsultaClimaContext _context;
        
        private readonly DateTime _startDate; 
        private readonly DateTime _endDate;

        public CidadeRepository(ConsultaClimaContext context) : base(context)
        {
            _context = context;

            _startDate = DateTime.Today;
            _endDate = DateTime.Today.AddDays(1);
        }

        public async Task<List<Cidade>> GetCidadesMaisFrias()
        {
            var cidadesMaisFrias = _context.Cidades.Include(c => c.PrevisaoClima.Where(d => d.DataPrevisao >= _startDate && d.DataPrevisao < _endDate)
                                                             .OrderBy(t => t.TemperaturaMaxima).Take(3))
                                                     .Include(e => e.Estado).ToList();
            return await Task.FromResult(cidadesMaisFrias);
        }

        public async Task<List<Cidade>> GetCidadesMaisQuentes()
        {
            var cidadesMaisQuentes =  _context.Cidades.Include(c => c.PrevisaoClima.Where(d=> d.DataPrevisao >= _startDate && d.DataPrevisao < _endDate)
                                                              .OrderByDescending(t=>t.TemperaturaMaxima).Take(3) )
                                                     .Include(e => e.Estado).ToList();
            return await Task.FromResult(cidadesMaisQuentes);
        }
    }
}
