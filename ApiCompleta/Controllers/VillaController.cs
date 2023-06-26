using ApiCompleta.Datos;
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

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
		{
			return Ok(VillaStore.villaList);
		}

		[HttpGet("id:int")]

		public ActionResult <VillaDto> GetVilla(int id)
		{
			if(id == 0)
			{
				return BadRequest();
			}
			var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

			if (villa == null)
			{
				return NotFound();
			}

			return Ok(villa);
		}
    }
}
