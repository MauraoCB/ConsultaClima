using AutoMapper;
using ConsultaClima.API.ViewModels;
using ConsultaClima.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaClima.API.Controllers
{
    public class PrevisaoClimaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPrevisaoClimaService _previsaoClimaService;

        public PrevisaoClimaController(
            IMapper mapper,
            IPrevisaoClimaService previsaoClimaService)

        {
            _mapper = mapper;
            _previsaoClimaService = previsaoClimaService;
        }



        [HttpGet]
        [Route("/api/v1/PrevisaoClima/GetPrevisaoClimaAsync/{cidadeId}")]
        public async Task<IActionResult> GetPrevisaoClimaAsync(int cidadeId)
        {
            try
            {
                var PrevisaoClima = await _previsaoClimaService.GetPrevisaoClima(cidadeId);


                return Ok(new ResultViewModel
                {
                    Message = "Previsão de clima encontrada com sucesso!",
                    Success = true,
                    Data = PrevisaoClima
                });
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
