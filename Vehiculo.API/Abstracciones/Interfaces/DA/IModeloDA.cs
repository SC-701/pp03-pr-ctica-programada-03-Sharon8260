using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IModeloDA
    {
        Task<IEnumerable<Modelo>> Obtener();
        Task<Modelo> Obtener(Guid Id);
        Task<IEnumerable<Modelo>> ObtenerPorMarca(Guid IdMarca);
        Task<Guid> Agregar(Modelo modelo);
        Task<Guid> Editar(Guid Id, Modelo modelo);
        Task<Guid> Eliminar(Guid Id);
    }
}