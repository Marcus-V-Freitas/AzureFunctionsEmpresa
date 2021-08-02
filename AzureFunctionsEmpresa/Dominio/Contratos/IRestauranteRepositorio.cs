using AzureFunctionsEmpresa.Dominio.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dominio.Contratos
{
    public interface IRestauranteRepositorio
    {
        Task<List<Restaurante>> TodosRestaurante(string filtro);
        Task<Restaurante> RestaurantePorId(int id);
        Task CriarRestaurante(Restaurante restaurante);
        Task AtualizarRestaurante(Restaurante restaurante);
        Task ExcluirRestaurante(int id);
    }
}
