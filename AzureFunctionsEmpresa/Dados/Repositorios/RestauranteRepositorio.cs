using AzureFunctionsEmpresa.Dominio.Contratos;
using AzureFunctionsEmpresa.Dominio.Entidades;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dados.Repositorios
{
    public class RestauranteRepositorio : IRestauranteRepositorio
    {
        public async Task AtualizarRestaurante(Restaurante restaurante)
        {
            await MongoContext.Restaurantes.ReplaceOneAsync(x => x.Id == restaurante.Id, restaurante);
        }

        public async Task CriarRestaurante(Restaurante restaurante)
        {
            await MongoContext.Restaurantes.InsertOneAsync(restaurante);
        }

        public async Task ExcluirRestaurante(int id)
        {
            await MongoContext.Restaurantes.DeleteOneAsync(x => x.Restaurant_id == id.ToString());
        }

        public async Task<Restaurante> RestaurantePorId(int id)
        {
            return await MongoContext.Restaurantes.Find(x => x.Restaurant_id == id.ToString()).FirstOrDefaultAsync();
        }

        public async Task<List<Restaurante>> TodosRestaurante(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
                return await MongoContext.Restaurantes.AsQueryable().ToListAsync();
            else
                return await MongoContext.Restaurantes.Find(x => x.Name.Contains(filtro)).ToListAsync();
        }
    }
}
