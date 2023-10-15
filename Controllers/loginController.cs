using Légende_Obscure.Services;
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


        [HttpGet("{id}")]
        public OkObjectResult Get(string id)
        {
            var token = tServcie.GenerateToken(id);
            return Ok(new { Token = token });
            
        }


        [HttpGet("testAuthorize")]
        [Authorize]
        public OkObjectResult Get2(int id)
        {
          
            return Ok(new { Teste ="M"});

        }

        [HttpPost]
        [Authorize]
        public void Post([FromBody] string value)
        {
        }


        [HttpPost("{id}")]
        [Authorize]
        public string Post2([FromBody] string value)
        {
            return "";
        }


    }
}
