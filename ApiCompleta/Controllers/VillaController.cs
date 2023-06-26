using ApiCompleta.Models;
using ApiCompleta.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompleta.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VillaController : ControllerBase
	{
		[HttpGet]

        public IEnumerable<VillaDto> GetVillas()
		{
			return new List<VillaDto>()
			{
				new VillaDto{Id=1, Name="Vista a la Piscina"},
				new VillaDto{Id=2, Name="Vista a la Playa"}
			};
		}
    }
}
