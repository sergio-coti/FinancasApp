using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinancasApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //atributo
        private readonly ICategoriaDomainService _categoriaDomainService;

        //construtor para inicializar os atributos da classe (injeção de dependência)
        public CategoriasController(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoriaResponseDto), 201)]
        public IActionResult Post(CategoriaRequestDto request)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);
                var response = _categoriaDomainService.Criar(request, usuarioId);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult Put(Guid id, CategoriaRequestDto request)
        {
            try
            {
                var response = _categoriaDomainService.Alterar(id, request);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _categoriaDomainService.Excluir(id);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);
                var response = _categoriaDomainService.Consultar(usuarioId);

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
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _categoriaDomainService.ObterPorId(id);

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
