using System.ComponentModel.DataAnnotations;
namespace ApiCompleta.Models.Dto
{
	public class VillaDto
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }
    }
}
