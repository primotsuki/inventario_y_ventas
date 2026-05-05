    using backend_autores.Models;
    using backend_autores.Models.DTORequests;
    using backend_autores.Services;
    using Microsoft.AspNetCore.Mvc;
namespace backend_autores.Controllers
{

    [ApiController]
    [Route("api/obras")]
    public class ObraController : ControllerBase
    {
        private readonly IObraService _obraService;

        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateObra([FromBody] DTOObraCreate dtoObraCreate)
        {
            var obra = await _obraService.CreateObra(dtoObraCreate);
            return CreatedAtAction(nameof(CreateObra), new { id = obra.Id }, obra);
        }

        [HttpGet]
        public async Task<IActionResult> GetObras()
        {
            var obras = await _obraService.GetObras();
            return Ok(obras);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateObra(int id, [FromBody] DTOObraUpdate dtoObraUpdate)
        {
            var updatedObra = await _obraService.UpdateObra(id, dtoObraUpdate);
            if (updatedObra == null)
            {
                return NotFound();
            }
            return Ok(updatedObra);
        }
        [HttpGet("autores")]
        public async Task<IActionResult> GetAutores()
        {
            var autores = await _obraService.getAutores();
            return Ok(autores);
        }
        [HttpPost("autores")]
        public async Task<IActionResult> CreateAutor([FromBody] string autorNombre) 
        {
            var autor = await _obraService.createAutor(autorNombre);
            if (autor == null)
            {
                return BadRequest("No se pudo crear el autor.");
            }
            return CreatedAtAction(nameof(CreateAutor), new { id = autor.Id }, autor);
        }
    }
}