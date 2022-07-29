using ConsultaClima.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Interfaces
{
    public interface ICidadeService{

        Task<IList<CidadeDTO>> GetCidadesAsync();
        Task<IList<CidadeDTO>> GetByEstadoAsync(int estadoId);     
        Task<IList<CidadeDTO>> SearchByNameAsync(string nome);

        Task<IList<CidadeDTO>> GetCidadesMaisQuentes(); 
        Task<IList<CidadeDTO>> GetCidadesMaisFrias();
    }
}