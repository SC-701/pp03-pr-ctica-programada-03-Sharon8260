using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase, IModeloController
    {
        private IModeloFlujo _modeloFlujo;
        private ILogger<ModeloController> _logger;

        public ModeloController(IModeloFlujo modeloFlujo, ILogger<ModeloController> logger)
        {
            _modeloFlujo = modeloFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Modelo modelo)
        {
            var resultado = await _modeloFlujo.Agregar(modelo);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, [FromBody] Modelo modelo)
        {
            if (!await VerificarModeloExiste(Id))
                return NotFound("El modelo no existe");

            var resultado = await _modeloFlujo.Editar(Id, modelo);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            if (!await VerificarModeloExiste(Id))
                return NotFound("El modelo no existe");

            await _modeloFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _modeloFlujo.Obtener();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _modeloFlujo.Obtener(Id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet("marca/{IdMarca}")]
        public async Task<IActionResult> ObtenerPorMarca(Guid IdMarca)
        {
            var resultado = await _modeloFlujo.ObtenerPorMarca(IdMarca);
            return Ok(resultado);
        }

        private async Task<bool> VerificarModeloExiste(Guid Id)
        {
            return await _modeloFlujo.Obtener(Id) != null;
        }
    }
}