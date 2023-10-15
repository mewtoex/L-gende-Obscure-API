using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Légende_Obscure.Services
{
    public class TokenService
    {
        
        public string chaveSecreta = "SuaChaveSuperSecretaComPeloMenos256BitsOuMais";

        string issuer = "MinhaAplicacaoAPI";

        string audience = "ClientesDaMinhaAPI";

        private string GerarTokenJwt()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(chaveSecreta));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(600),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(String user)
        {
            return GerarTokenJwt();
        }

    }
}
