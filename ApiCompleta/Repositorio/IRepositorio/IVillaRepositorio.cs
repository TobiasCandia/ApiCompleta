using ApiCompleta.Models;

namespace ApiCompleta.Repositorio.IRepositorio
{
	public interface INumeroVillaRepositorio : IRepositorio<Villa>
	{
		Task<Villa> Actualizar(Villa entidad);
	}
}
