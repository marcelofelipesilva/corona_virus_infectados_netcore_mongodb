using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corona_virus_infectados_netcore_mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {

            var infectado = new Infectado(dto.Id, dto.DataNascimento, dto.Sexo, dto.Estado, dto.Cidade);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpGet("{Id}")]
        public ActionResult ObterInfectadoPorID(string Id)
        {
            var infectado = _infectadosCollection.Find(
                Builders<Infectado>.Filter.Where(_ => _.Id == Id)).ToList();

            return Ok(infectado);
        }
        // atualizando campos atraves do id

        [HttpPut]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {

            var infectados = _infectadosCollection.UpdateOne(
                Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id),
                Builders<Infectado>.Update.Set("dataNascimento", dto.DataNascimento)
                .Set("sexo", dto.Sexo).Set("estado", dto.Estado).Set("cidade", dto.Cidade));




            return Ok("Atualizado com sucesso");
        }

        //deleta infectado por id

        [HttpDelete("{Id}")]
        public ActionResult DeletarInfectado(string Id)
        {

            var infectados = _infectadosCollection.DeleteOne(
                Builders<Infectado>.Filter.Where(_ => _.Id == Id));


            return Ok("Deletado com sucesso");
        }
    }
}
