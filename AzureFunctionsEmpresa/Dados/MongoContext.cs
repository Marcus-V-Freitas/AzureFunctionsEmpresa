using AzureFunctionsEmpresa.Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dados
{
    public static class MongoContext
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings:ConexaoMongo", EnvironmentVariableTarget.Process);

        public static IMongoDatabase BancoDeDados
        {
            get
            {
                IMongoClient client = new MongoClient(ConnectionString);
                return client.GetDatabase("sample_restaurants");

            }
        }

        public static IMongoCollection<Restaurante> Restaurantes
        {
            get
            {
                return BancoDeDados.GetCollection<Restaurante>("restaurants");
            }
        }
    }
}
