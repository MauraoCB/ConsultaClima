using AutoMapper;
using ConsultaClima.API.ViewModels;
using ConsultaClima.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsultaClima.API.Controllers
{

    [ApiController]
    public class CidadeController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly ICidadeService _cidadeService;

        public CidadeController(
            IMapper mapper,
            ICidadeService cidadeService )
          
        {
            _mapper = mapper;
            _cidadeService = cidadeService;
        }

        

        [HttpGet]
        [Route("/api/v1/cidades/GetByEstadoAsync/{estadoId}")]
        public async Task<IActionResult> GetByEstadoAsync(int estadoId)
        {
            try
            {
                var cidades = await _cidadeService.GetByEstadoAsync(estadoId);


                return Ok(new ResultViewModel
                {
                    Message = "cidades encontrados com sucesso!",
                    Success = true,
                    Data = cidades
                });
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpGet]        
        [Route("/api/v1/cidades/GetCidadesByName")]
        public async Task<IActionResult> GetcidadesName()
        {
            try
            {
                var cidades = await _cidadeService.GetCidadesAsync();


                return Ok(new ResultViewModel
                {
                    Message = "cidades encontrados com sucesso!",
                    Success = true,
                    Data = cidades
                });
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}