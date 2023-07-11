using ApiCompleta.Datos;
using ApiCompleta.Models;
using ApiCompleta.Models.Dto;
using ApiCompleta.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiCompleta.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class VillaController : ControllerBase
	{

		private readonly ILogger<VillaController> _logger;
		private readonly IVillaRepositorio _villaRepo;
		private readonly IMapper _mapper;
		protected ApiResponse _response;

		public VillaController(ILogger<VillaController> logger, IVillaRepositorio villaRepo, IMapper mapper)
		{
			_logger = logger;
			_villaRepo = villaRepo;
			_mapper = mapper;
			_response = new();
		}

		[HttpGet]
		[Route("ListaVillas")]
		[ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ApiResponse>> GetVillas()
		{
			try
			{
				_logger.LogInformation("Obtener las Villas");

				IEnumerable<Villa> villaList = await _villaRepo.ObtenerTodos();

				_response.Resultado = _mapper.Map<IEnumerable<VillaDto>>(villaList);
				_response.statusCode = System.Net.HttpStatusCode.OK;

				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsExitoso = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };	
			}
			return _response;
			
		}

		[HttpGet("id:int", Name ="GetVilla")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ApiResponse>> GetVilla(int id)
		{
			try
			{
				if (id == 0)
				{
					_logger.LogError("Error al traer Villa con Id" + id);
					_response.statusCode = HttpStatusCode.BadRequest;
					_response.IsExitoso = false;
					return BadRequest(_response);
				}
				var villa = await _villaRepo.Obtener(v => v.Id == id);

				if (villa == null)
				{
					_response.statusCode = HttpStatusCode.NotFound;
					_response.IsExitoso = false;
					return NotFound(_response);
				}

				_response.Resultado = _mapper.Map<VillaDto>(villa);
				_response.statusCode = HttpStatusCode.OK;

				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsExitoso = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpPost]
		[Route("IngresarVilla")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task <ActionResult<ApiResponse>> CrearVilla([FromBody] VillaCreateDto createDto) 
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				if (await _villaRepo.Obtener(v => v.Name.ToLower() == createDto.Name.ToLower()) != null)
				{
					ModelState.AddModelError("NombreExiste", "La Villa con ese Nombre ya exite!");
					return BadRequest(ModelState);
				}

				if (createDto == null)
				{
					return BadRequest(createDto);
				}

				Villa modelo = _mapper.Map<Villa>(createDto);

				modelo.FechaCreacion = DateTime.Now;
				modelo.FechaActualizacion = DateTime.Now;
				await _villaRepo.Crear(modelo);
				_response.Resultado = modelo;
				_response.statusCode = HttpStatusCode.Created;

				return CreatedAtRoute("GetVilla", new { id = modelo.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.IsExitoso = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete("Eliminar/{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteVilla(int id)
		{
			try
			{
				if (id == 0)
				{
					_response.IsExitoso= false;
					_response.statusCode = HttpStatusCode.NotFound;
					return BadRequest(_response);
				}
				var villa = await _villaRepo.Obtener(v => v.Id == id);
				if (villa == null)
				{
					_response.IsExitoso = false;
					_response.statusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				await _villaRepo.Remover(villa);

				_response.statusCode = HttpStatusCode.NoContent;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsExitoso = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return BadRequest(_response);
		}

		[HttpPut("Editar/{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		
		public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto updateDto)
		{
			if (updateDto == null || id!= updateDto.Id)
			{
				_response.IsExitoso = false;
				_response.statusCode = HttpStatusCode.BadRequest;
				return BadRequest(_response);
			}

			Villa modelo = _mapper.Map<Villa>(updateDto);

			await _villaRepo.Actualizar(modelo);
			_response.statusCode = HttpStatusCode.NoContent;

			return Ok(_response);
		}
    }
}
