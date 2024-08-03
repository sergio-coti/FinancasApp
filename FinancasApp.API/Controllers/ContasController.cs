using Azure.Core;
using FinancasApp.Domain.Dtos;
using FinancasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaDomainService? _contaDomainService;

        public ContasController(IContaDomainService? contaDomainService)
        {
            _contaDomainService = contaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaResponseDto), 201)]
        public IActionResult Post([FromBody] ContaRequestDto request)
        {
            var response = _contaDomainService?.Criar(request);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult Put(Guid id, [FromBody] ContaRequestDto request)
        {
            var response = _contaDomainService?.Alterar(id, request);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            var response = _contaDomainService?.Excluir(id);
            return StatusCode(200, response);
        }

        [HttpGet("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<ContaResponseDto>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax)
        {
            var response = _contaDomainService?.Consultar(dataMin, dataMax);
            if (response.Any())
                return StatusCode(200, response);
            else
                return StatusCode(204); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            var response = _contaDomainService?.ObterPorId(id);
            if(response != null)
                return StatusCode(200, response);
            else
                return StatusCode(204);
        }
    }
}
