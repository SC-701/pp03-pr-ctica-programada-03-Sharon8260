using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private readonly IModeloDA _modeloDA;

        public ModeloFlujo(IModeloDA modeloDA)
        {
            _modeloDA = modeloDA;
        }

        public async Task<Guid> Agregar(Modelo modelo)
        {
            return await _modeloDA.Agregar(modelo);
        }

        public async Task<Guid> Editar(Guid Id, Modelo modelo)
        {
            return await _modeloDA.Editar(Id, modelo);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _modeloDA.Eliminar(Id);
        }

        public async Task<IEnumerable<Modelo>> Obtener()
        {
            return await _modeloDA.Obtener();
        }

        public async Task<Modelo> Obtener(Guid Id)
        {
            return await _modeloDA.Obtener(Id);
        }

        public async Task<IEnumerable<Modelo>> ObtenerPorMarca(Guid IdMarca)
        {
            return await _modeloDA.ObtenerPorMarca(IdMarca);
        }
    }
}