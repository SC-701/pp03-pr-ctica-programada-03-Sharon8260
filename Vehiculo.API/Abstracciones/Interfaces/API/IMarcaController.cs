using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IMarcaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);
        Task<IActionResult> Agregar(Marca marca);
        Task<IActionResult> Editar(Guid id, Marca marca);
        Task<IActionResult> Eliminar(Guid id);
    }
}