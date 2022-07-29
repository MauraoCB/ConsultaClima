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
                    Message = "Cidades encontradas com sucesso!",
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
        [Route("/api/v1/cidades/GetCidadesByName/{nome}")]
        public async Task<IActionResult> GetCidadesByName(string nome)
        {
            try
            {
                var cidades = await _cidadeService.SearchByNameAsync(nome);


                return Ok(new ResultViewModel
                {
                    Message = "Cidades encontradas com sucesso!",
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
        [Route("/api/v1/cidades/GetCidadesMaisQuentes")]
        public async Task<IActionResult> GetCidadesMaisQuentes()
        {
            try
            {
                var cidades = await _cidadeService.GetCidadesMaisQuentes();


                return Ok(new ResultViewModel
                {
                    Message = "Cidades encontradas com sucesso!",
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
        [Route("/api/v1/cidades/GetCidadesMaisFrias")]
        public async Task<IActionResult> GetCidadesMaisFrias()
        {
            try
            {
                var cidades = await _cidadeService.GetCidadesMaisFrias();


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