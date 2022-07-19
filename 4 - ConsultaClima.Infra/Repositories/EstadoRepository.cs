using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Context;
using ConsultaClima.Infra.Interfaces;

namespace ConsultaClima.Infra.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository{
        private readonly ConsultaClimaContext _context;

        public EstadoRepository(ConsultaClimaContext context) : base(context)
        {
            _context = context;
        }
    }
}