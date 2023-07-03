using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCompleta.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace ApiCompleta.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutenticacionController : ControllerBase
	{
		private readonly string secretKey;

		public AutenticacionController(IConfiguration config)
		{
			secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
		}

		[HttpPost]
		[Route("Validar")]

		public IActionResult Validar([FromBody] Usuario request)
		{
			if(request.correo == "t@gmail.com" && request.clave == "123")
			{
				var keyBytes = Encoding.ASCII.GetBytes(secretKey);
				var claims = new ClaimsIdentity();

				claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.correo));

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = claims,
					Expires = DateTime.UtcNow.AddMinutes(5),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

				string tokencreado = tokenHandler.WriteToken(tokenConfig);

				return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
			}
			else
			{
				return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
			}
		}
	}
}
