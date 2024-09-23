using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaDomainService _contaDomainService;

        public ContasController(IContaDomainService contaDomainService)
        {
            _contaDomainService = contaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaResponseDto), 201)]
        public IActionResult Post(ContaRequestDto request)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);
                var response = _contaDomainService.Criar(request, usuarioId);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult Put(Guid id, ContaRequestDto request)
        {
            try
            {
                var response = _contaDomainService.Alterar(id, request);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _contaDomainService.Excluir(id);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<ContaResponseDto>), 200)]
        public IActionResult GetAll(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);
                var response = _contaDomainService.Consultar(dataMin, dataMax, usuarioId);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _contaDomainService.ObterPorId(id);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
