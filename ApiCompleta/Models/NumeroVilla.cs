﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ApiCompleta.Models
{
	public class NumeroVilla
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

		[Required]
        public int VillaId { get; set; }

		[ForeignKey("VillaId")]
        public Villa Villa { get; set; }

        public string DetalleEspecial { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
