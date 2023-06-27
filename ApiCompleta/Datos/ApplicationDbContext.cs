using ApiCompleta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCompleta.Datos
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Villa> Villas {get; set;}
	}
}
