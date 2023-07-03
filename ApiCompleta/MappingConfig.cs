using ApiCompleta.Models;
using ApiCompleta.Models.Dto;
using AutoMapper;

namespace ApiCompleta
{
	public class MappingConfig : Profile
	{
		public MappingConfig() 
		{
			CreateMap<Villa, VillaDto>();
			CreateMap<VillaDto, Villa>();

			CreateMap<Villa, VillaCreateDto>().ReverseMap();
			CreateMap<Villa, VillaUpdateDto>().ReverseMap();
		}
	}
}
