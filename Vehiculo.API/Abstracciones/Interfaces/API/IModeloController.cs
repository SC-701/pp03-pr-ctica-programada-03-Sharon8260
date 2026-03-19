using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IModeloController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);
        Task<IActionResult> ObtenerPorMarca(Guid idMarca);
        Task<IActionResult> Agregar(Modelo modelo);
        Task<IActionResult> Editar(Guid id, Modelo modelo);
        Task<IActionResult> Eliminar(Guid id);
    }
}