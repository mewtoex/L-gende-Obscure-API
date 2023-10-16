using Légende_Obscure.Model;
using Légende_Obscure.Services;
using Légende_Obscure.Util.ModelDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Légende_Obscure.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class loginController : ControllerBase
    {
        TokenService tServcie = new TokenService();
        private readonly LoginDB _loginService;

        public loginController(LoginDB loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{id}")]
        public OkObjectResult Get(string id)
        {
            var token = tServcie.GenerateToken(id);
            return Ok(new { Token = token });
            
        }


        [HttpGet("testE")]
        public OkObjectResult Get2(int id)
        {

            var result = _loginService.BuscarTodos();
            return Ok(new { Teste = result });

        }


        [HttpGet("testAuthorize")]
        [Authorize]
        public OkObjectResult Get12(int id)
        {

            return Ok(new { Teste = "M" });

        }


        [HttpPost("logar")]
        [Authorize]
        public OkObjectResult Post(User value)
        {
            return Ok(new { Teste = "M" });

        }

    }
}
