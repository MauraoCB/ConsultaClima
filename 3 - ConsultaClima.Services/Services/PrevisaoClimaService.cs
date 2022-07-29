using AutoMapper;
using ConsultaClima.Infra.Interfaces;
using ConsultaClima.Services.DTO;
using ConsultaClima.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Services
{
 public   class PrevisaoClimaService : IPrevisaoClimaService
    {
        private readonly IMapper _mapper;
        private readonly IPrevisaoClimaRepository _previsaoClimaRepository;



        public PrevisaoClimaService(
            IMapper mapper,
            IPrevisaoClimaRepository previsaoClimaRepository)
        {
            _mapper = mapper;
            _previsaoClimaRepository = previsaoClimaRepository;

        }

        public async Task<List<PrevisaoClimaDTO>> GetPrevisaoClima(int cidadeId)
        {
            var previsaoClima = await _previsaoClimaRepository.GetPrevisaoClima(cidadeId);
            var previsaoClimaDTO = _mapper.Map<IList<PrevisaoClimaDTO>>(previsaoClima);

            return previsaoClimaDTO.ToList();
        }
    }
}
