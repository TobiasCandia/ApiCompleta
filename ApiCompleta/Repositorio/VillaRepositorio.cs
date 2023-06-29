using ApiCompleta.Datos;
using ApiCompleta.Models;
using ApiCompleta.Repositorio.IRepositorio;

namespace ApiCompleta.Repositorio
{
	public class VillaRepositorio : Repositorio<Villa>, INumeroVillaRepositorio
	{
		private readonly ApplicationDbContext _db;

		public VillaRepositorio(ApplicationDbContext db) : base(db) 
		{
			_db = db;
		}

		public async Task<Villa> Actualizar(Villa entidad)
		{
			entidad.FechaActualizacion = DateTime.Now;
			_db.NumeroVillas.Update(entidad);
			await _db.SaveChangesAsync();
			return entidad;
		}
	}
}
