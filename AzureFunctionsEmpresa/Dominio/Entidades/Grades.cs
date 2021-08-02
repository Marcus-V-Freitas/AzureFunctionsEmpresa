using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsEmpresa.Dominio.Entidades
{
    public class Grades
    {
        [BsonElement("date")]
        [BsonRequired()]
        public DateTime Date { get; private set; }

        [BsonElement("grade")]
        [BsonRequired()]
        public string Grade { get; private set; }

        [BsonElement("score")]
        public int? Score { get; private set; }
    }
}
