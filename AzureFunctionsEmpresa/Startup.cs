using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using AzureFunctionsEmpresa.Dados.Repositorios;
using AzureFunctionsEmpresa.Dominio.Contratos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
[assembly: WebJobsStartup(typeof(AzureFunctionsEmpresa.Startup))]

namespace AzureFunctionsEmpresa
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IRestauranteRepositorio, RestauranteRepositorio>();

            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
            {
                opts.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
                opts.AddCodeParameter = true;
                opts.PrependOperationWithRoutePrefix = true;
                opts.XmlPath = "AzureFunctionsEmpresa.xml";
                opts.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "Documento Swagger",
                        Description = "Documento Swagger Restaurante",
                        Version = "v1"
                    }
                };
                opts.Title = "Swagger Restaurante";

                opts.ConfigureSwaggerGen = x =>
                {
                    x.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : new Guid().ToString());
                };
            });
        }
    }
}
