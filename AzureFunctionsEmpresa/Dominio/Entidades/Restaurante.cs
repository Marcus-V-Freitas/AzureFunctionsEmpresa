using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dominio.Entidades
{
    public class Restaurante
    {
        [BsonId()]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("address")]
        [BsonRequired()]
        public Address Address { get; private set; }

        [BsonElement("borough")]
        [BsonRequired()]
        public string Borough { get; private set; }

        [BsonElement("cuisine")]
        [BsonRequired()]
        public string Cuisine { get; private set; }

        [BsonElement("grades")]
        [BsonRequired()]
        public Grades[] Grades { get; private set; }

        [BsonElement("name")]
        [BsonRequired()]
        public string Name { get; private set; }

        [BsonElement("restaurant_id")]
        [BsonRequired()]
        public string Restaurant_id { get; private set; }
    }
}
