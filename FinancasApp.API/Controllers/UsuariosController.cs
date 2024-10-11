using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuariosController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), 201)]
        public IActionResult Criar(CriarUsuarioRequestDto dto)
        {
            try
            {
                var response = _usuarioDomainService.Criar(dto);

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

        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponseDto), 200)]
        public IActionResult Autenticar(AutenticarUsuarioRequestDto dto) 
        {
            try
            {
                var response = _usuarioDomainService.Autenticar(dto);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                //HTTP 401 (UNAUTHORIZED)
                return StatusCode(401, new { e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
