﻿using ApiCompleta.Models.Dto;

namespace ApiCompleta.Datos
{
	public static class VillaStore
	{
		public static List<VillaDto> villaList = new List<VillaDto>
		{
			new VillaDto() {Id=1, Name="Vista a la Piscina"},
			new VillaDto() {Id=2, Name="Vista a la Playa"}
		};
	}
}
