using AutoMapper;
using ConsultaClima.Infra.Interfaces;
using ConsultaClima.Services.DTO;
using ConsultaClima.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cidadeRepository;



        public CidadeService(
            IMapper mapper,
            ICidadeRepository cidadeRepository )
        {
            _mapper = mapper;
            _cidadeRepository = cidadeRepository;

        }

        public async Task<IList<CidadeDTO>> GetByEstadoAsync(int estadoId)
        {
            var cidades = await _cidadeRepository.GetAllAsync();
            var cidadesDTO = _mapper.Map<IList<CidadeDTO>>(cidades);

            return cidadesDTO.Where(c=> c.EstadoId == estadoId).ToList();
        }

        public async Task<IList<CidadeDTO>> GetCidadesAsync()
        {
            var cidades = await _cidadeRepository.GetAllAsync();
            var cidadesDTO = _mapper.Map<IList<CidadeDTO>>(cidades);

            return cidadesDTO;
        }

        public async Task<IList<CidadeDTO>> SearchByNameAsync(string nome)
        {
            var cidades = await _cidadeRepository.GetAllAsync();
            var cidadesDTO = _mapper.Map<IList<CidadeDTO>>(cidades);

            return cidadesDTO.Where(c => c.Nome.ToLower().Contains (nome.ToLower())).ToList();
        }



        public async Task<IList<CidadeDTO>> GetCidadesMaisQuentes()
        {
            var cidades = await _cidadeRepository.GetCidadesMaisQuentes();
            var cidadesDTO = _mapper.Map<IList<CidadeDTO>>(cidades);

            return cidadesDTO;
        }
    }
}