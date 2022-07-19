using ConsultaClima.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Interfaces
{
    public interface IEstadoService{

        Task<IList<EstadoDTO>> GetEstadosAsync();      
    }
}