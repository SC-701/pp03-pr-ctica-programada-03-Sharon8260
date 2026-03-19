using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMarcaFlujo
    {
        Task<IEnumerable<Marca>> Obtener();
        Task<Marca> Obtener(Guid Id);
        Task<Guid> Agregar(Marca marca);
        Task<Guid> Editar(Guid Id, Marca marca);
        Task<Guid> Eliminar(Guid Id);
    }
}