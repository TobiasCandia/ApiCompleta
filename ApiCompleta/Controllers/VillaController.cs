﻿using ApiCompleta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompleta.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VillaController : ControllerBase
	{
		[HttpGet]

        public IEnumerable<Villa> GetVillas()
		{
			return new List<Villa>()
			{
				new Villa{Id=1, Name="Vista a la Piscina"},
				new Villa{Id=2, Name="Vista a la Playa"}
			};
		}
    }
}
