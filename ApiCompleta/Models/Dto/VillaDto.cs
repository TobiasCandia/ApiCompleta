﻿using System.ComponentModel.DataAnnotations;
namespace ApiCompleta.Models.Dto
{
	public class VillaDto
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string? Name { get; set; }

		public string? Detalle { get; set; }

        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public double MetrosCuadrados { get; set; }

		public string? ImagenUrl { get; set; }

		public string? Amenidad { get; set; }
    }
}
