using AutoMapper;
using ConsultaClima.API.ViewModels;
using ConsultaClima.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsultaClima.API.Controllers
{

    [ApiController]
    public class EstadoController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IEstadoService _estadoService;

        public EstadoController(
            IMapper mapper,
            IEstadoService estadoService )
          
        {
            _mapper = mapper;
            _estadoService = estadoService;
        }
     

        [HttpGet]        
        [Route("/api/v1/Estados/GetEstados")]
        public async Task<IActionResult> GetEstados()
        {
            try
            {
                var estados = await _estadoService.GetEstadosAsync();


                return Ok(new ResultViewModel
                {
                    Message = "Estados encontrados com sucesso!",
                    Success = true,
                    Data = estados
                });
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}