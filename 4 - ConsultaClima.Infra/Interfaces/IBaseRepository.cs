using System.Threading.Tasks;
using ConsultaClima.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace ConsultaClima.Infra.Interfaces{
    public interface IBaseRepository<T> where T : Base{

        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}