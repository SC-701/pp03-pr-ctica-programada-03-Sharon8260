using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class MarcaDA : IMarcaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MarcaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(Marca marca)
        {
            string query = @"AgregarMarca";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = marca.Id,
                Nombre = marca.Nombre
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, Marca marca)
        {
            await VerificarMarcaExiste(Id);

            string query = @"EditarMarca";
            return await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id,
                Nombre = marca.Nombre
            });
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarMarcaExiste(Id);

            string query = @"EliminarMarca";
            return await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id });
        }

        public async Task<IEnumerable<Marca>> Obtener()
        {
            string query = @"ObtenerMarcas";
            return await _sqlConnection.QueryAsync<Marca>(query);
        }

        public async Task<Marca> Obtener(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultado = await _sqlConnection.QueryAsync<Marca>(query, new { Id });
            return resultado.FirstOrDefault();
        }

        private async Task VerificarMarcaExiste(Guid Id)
        {
            var marca = await Obtener(Id);
            if (marca == null)
                throw new Exception("La marca no existe");
        }
    }
}