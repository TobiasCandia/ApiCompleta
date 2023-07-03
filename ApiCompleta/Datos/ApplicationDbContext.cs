using ApiCompleta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiCompleta.Datos
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<Villa> Villas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Villa>().HasData(
				new Villa()
				{
					Id = 1,
					Name = "Villa Real",
					Detalle = "Detalle de la Villa...",
					ImagenUrl = "",
					Ocupantes = 5,
					MetrosCuadrados = 50,
					Tarifa = 20,
					Amenidad = "",
					FechaCreacion = DateTime.Now,
					FechaActualizacion = DateTime.Now
				},
				new Villa()
				{
					Id = 2,
					Name = "Premium Vista a la Piscina",
					Detalle = "Detalle de la Villa...",
					ImagenUrl = "",
					Ocupantes = 4,
					MetrosCuadrados = 40,
					Tarifa = 10,
					Amenidad = "",
					FechaCreacion = DateTime.Now,
					FechaActualizacion = DateTime.Now
				});
		}

	}
}
