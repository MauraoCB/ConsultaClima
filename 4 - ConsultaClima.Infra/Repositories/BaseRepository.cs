using System.Linq;
using ConsultaClima.Infra.Context;
using System.Threading.Tasks;
using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace ConsultaClima.Infra.Repositories{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base{
        private readonly ConsultaClimaContext _context;

        public BaseRepository(ConsultaClimaContext context)
        {
            _context = context;
        }   
        
        //Como n�o ser�o atualizadas as tabelas, os m�todos POST e PUT n�o existem

        public virtual async Task<T> GetAsync(int id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x=>x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}