using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dominio.Entidades
{
    public class Address
    {
        [BsonElement("building")]
        [BsonRequired()]
        public string Building { get; private set; }

        [BsonElement("street")]
        [BsonRequired()]
        public string Street { get; private set; }

        [BsonElement("zipcode")]
        [BsonRequired()]
        public string Zipcode { get; private set; }

        [BsonElement("coord")]
        [BsonRequired()]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double[] Coord { get; private set; }
    }
}
