using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaDomainService _categoriaDomainService;

        public CategoriasController(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoriaResponseDto), 201)]
        public IActionResult Post(CategoriaRequestDto dto)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);

                var response = _categoriaDomainService.Criar(dto, usuarioId);

                return StatusCode(201, response);
            }
            catch(ApplicationException e )
            {
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult Put(Guid id, CategoriaRequestDto dto)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);

                var response = _categoriaDomainService.Alterar(id, dto, usuarioId);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);

                var response = _categoriaDomainService.Excluir(id, usuarioId);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponseDto>), 200)]
        public IActionResult Get() 
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);

                var response = _categoriaDomainService.Consultar(usuarioId);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);

                var response = _categoriaDomainService.ObterPorId(id, usuarioId);

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
