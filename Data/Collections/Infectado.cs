using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corona_virus_infectados_netcore_mongodb.Data
{
    public class Infectado
    {
      
            public Infectado(string id, DateTime dataNascimento, string sexo, string estado, string cidade)
            {
                this.Id = id;
                this.DataNascimento = dataNascimento;
                this.Sexo = sexo;
                this.Estado = estado;
                this.Cidade = cidade;
            }

            // auto gerando id pelo mongo db
            [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
            public string Id { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Sexo { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
        }
    }
}
