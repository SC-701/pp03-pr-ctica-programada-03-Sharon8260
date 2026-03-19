using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class ModeloDA : IModeloDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(Modelo modelo)
        {
            string query = @"AgregarModelo";
            return await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = modelo.Nombre,
                IdMarca = modelo.IdMarca
            });
        }

        public async Task<Guid> Editar(Guid Id, Modelo modelo)
        {
            await VerificarModeloExiste(Id);

            string query = @"EditarModelo";
            return await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id,
                Nombre = modelo.Nombre,
                IdMarca = modelo.IdMarca
            });
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarModeloExiste(Id);

            string query = @"EliminarModelo";
            return await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id });
        }

        public async Task<IEnumerable<Modelo>> Obtener()
        {
            string query = @"ObtenerModelos";
            return await _sqlConnection.QueryAsync<Modelo>(query);
        }

        public async Task<Modelo> Obtener(Guid Id)
        {
            string query = @"ObtenerModelo";
            var resultado = await _sqlConnection.QueryAsync<Modelo>(query, new { Id });
            return resultado.FirstOrDefault();
        }

        public async Task<IEnumerable<Modelo>> ObtenerPorMarca(Guid IdMarca)
        {
            string query = @"ObtenerModelosPorMarca";
            return await _sqlConnection.QueryAsync<Modelo>(query, new { IdMarca });
        }

        private async Task VerificarModeloExiste(Guid Id)
        {
            var modelo = await Obtener(Id);
            if (modelo == null)
                throw new Exception("El modelo no existe");
        }
    }
}