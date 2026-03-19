using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class MarcaFlujo : IMarcaFlujo
    {
        private readonly IMarcaDA _marcaDA;

        public MarcaFlujo(IMarcaDA marcaDA)
        {
            _marcaDA = marcaDA;
        }

        public async Task<Guid> Agregar(Marca marca)
        {
            return await _marcaDA.Agregar(marca);
        }

        public async Task<Guid> Editar(Guid Id, Marca marca)
        {
            return await _marcaDA.Editar(Id, marca);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _marcaDA.Eliminar(Id);
        }

        public async Task<IEnumerable<Marca>> Obtener()
        {
            return await _marcaDA.Obtener();
        }

        public async Task<Marca> Obtener(Guid Id)
        {
            return await _marcaDA.Obtener(Id);
        }
    }
}