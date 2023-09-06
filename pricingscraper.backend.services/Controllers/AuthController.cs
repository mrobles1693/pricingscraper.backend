using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IAuthBL service;
        private readonly int expirationMin;

        public AuthController(IConfiguration _configuration, IAuthBL _service)
        {
            secretKey = _configuration["JWTConfig:secretKey"];
            service = _service;
            expirationMin = 10;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<string>>> AuthLogin([FromBody] UsuarioDTO request)
        {

            SqlRspDTO rsp = await service.AuthUser(request);

            if (rsp.nCod > 0)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim("userId", rsp.nCod.ToString()));
                claims.AddClaim(new Claim("userName", rsp.sMsj));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(expirationMin),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<string> { success = true, data = token, errMsj = "" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<string> { success = false, data = "", errMsj = rsp.sMsj });
            }
        }
    }
}
