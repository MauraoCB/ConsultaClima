using AutoMapper;
using ConsultaClima.Infra.Interfaces;
using ConsultaClima.Services.DTO;
using ConsultaClima.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaClima.Services.Services
{
    public class EstadoService : IEstadoService{
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;



        public EstadoService(
            IMapper mapper,
            IEstadoRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
       
        }

        public async Task<IList<EstadoDTO>> GetEstadosAsync(){
            var estados = await _estadoRepository.GetAllAsync();
            var estadosDTO = _mapper.Map<IList<EstadoDTO>>(estados);

            return estadosDTO;
        }
    }
}