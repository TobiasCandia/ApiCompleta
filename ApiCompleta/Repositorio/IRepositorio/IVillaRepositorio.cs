using ApiCompleta.Models;

namespace ApiCompleta.Repositorio.IRepositorio
{
	public interface IVillaRepositorio : IRepositorio<Villa>
	{
		Task<Villa> Actualizar(Villa entidad);
	}
}
