using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
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
        public IActionResult Criar(CriarUsuarioRequestDto request)
        {
            try
            {
                var response = _usuarioDomainService.Criar(request);
                return StatusCode(201, response);
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

        [HttpPost("autenticar")]
        public IActionResult Autenticar(AutenticarUsuarioRequestDto request)
        {
            try
            {
                var response = _usuarioDomainService.Autenticar(request);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
