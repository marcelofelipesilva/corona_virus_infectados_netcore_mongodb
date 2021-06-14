using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corona_virus_infectados_netcore_mongodb.Models
{
    public class InfectadoDto
    {
        public string Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
