using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctionsEmpresa.Dominio.Contratos;
using AzureFunctionsEmpresa.Dados.Repositorios;
using MongoDB.Bson;
using AzureFunctionsEmpresa.Dominio.Entidades;
using System.Net;
using AzureFunctions.Extensions.Swashbuckle.Attribute;

namespace AzureFunctionsEmpresa.Functions
{
    public class RestaurantesFunctions
    {
        private readonly IRestauranteRepositorio _restauranteRepositorio;

        public RestaurantesFunctions(IRestauranteRepositorio restauranteRepositorio)
        {
            _restauranteRepositorio = restauranteRepositorio;
        }

        /// <summary>
        /// Retorna todos os restaurantes
        /// </summary>
        /// <returns> Restaurantes </returns>
        [ProducesResponseType(typeof(Restaurante[]), (int)HttpStatusCode.OK)]
        [FunctionName("TodosRestaurantes")]
        [QueryStringParameter("filtro", "Filtro de retorno para os restaurantes", DataType = typeof(string), Required = false)]
        public async Task<IActionResult> TodosRestaurantes(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TodosRestaurantes")]
                         HttpRequest req, ILogger log)
        {
            var produtos = await _restauranteRepositorio.TodosRestaurante(req.Query["filtro"]);
            return new OkObjectResult(produtos);
        }

        /// <summary>
        /// Retorna o resturante pelo seu id
        /// </summary>     
        /// <param name="id"> código interno </param>
        /// <returns> Restaurante </returns>
        [ProducesResponseType(typeof(Restaurante), (int)HttpStatusCode.OK)]
        [FunctionName("RestaurantePorId")]
        public async Task<IActionResult> RestaurantePorId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",Route = "RestaurantePorId/{id:int}")]
            HttpRequest req, ILogger log, int id)
        {
            var produto = await _restauranteRepositorio.RestaurantePorId(id);
            return new OkObjectResult(produto);
        }

        /// <summary>
        /// Cria um resturante
        /// </summary>     
        /// <returns> true/false </returns>
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [FunctionName("CriarRestaurante")]
        public async Task<IActionResult> CriarRestaurante(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post",Route = "CriarRestaurante")]
            [RequestBodyType(typeof(Restaurante), "restaurante")]
            HttpRequest req, ILogger log)
        {
            using (var reader = new StreamReader(req.Body))
            {
                var restaurante = JsonConvert.DeserializeObject<Restaurante>(await reader.ReadToEndAsync());
                await _restauranteRepositorio.CriarRestaurante(restaurante);
            }
            return new OkObjectResult(true);
        }

        /// <summary>
        /// Atualiza o Restaurante
        /// </summary>
        /// <returns>true/false</returns>
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [FunctionName("AtualizarRestaurante")]
        public async Task<IActionResult> AtualizarRestaurante(
         [HttpTrigger(AuthorizationLevel.Anonymous, "put",Route = "AtualizarRestaurante")]
            [RequestBodyType(typeof(Restaurante), "restaurante")]
            HttpRequest req, ILogger log)
        {
            using (var reader = new StreamReader(req.Body))
            {
                var restaurante = JsonConvert.DeserializeObject<Restaurante>(await reader.ReadToEndAsync());
                await _restauranteRepositorio.AtualizarRestaurante(restaurante);
            }
            return new OkObjectResult(true);
        }

        /// <summary>
        /// Exclui o resturante pelo seu id
        /// </summary>     
        /// <param name="id"> código interno </param>
        /// <returns> Restaurante </returns>
        [ProducesResponseType(typeof(Restaurante), (int)HttpStatusCode.OK)]
        [FunctionName("ExcluirRestaurante")]
        public async Task<IActionResult> ExcluirRestaurante(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete",Route = "ExcluirRestaurante/{id:int}")]
            HttpRequest req, ILogger log, int id)
        {
            await _restauranteRepositorio.ExcluirRestaurante(id);
            return new OkObjectResult(true);
        }
    }
}
