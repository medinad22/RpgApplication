
using Microsoft.AspNetCore.Mvc;
using RpgApplication.Entities;
using RpgApplication.Interfaces;
using RpgApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RpgApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgController : ControllerBase
    {
        private readonly IRPGService _rpgService;

        public RpgController(IRPGService rpgService)
        {
            _rpgService = rpgService;
        }



        // GET: api/<RpgController>
        [HttpGet]
        public IEnumerable<PersonagemEntity> Get([FromQuery(Name = "forca")] int forca)
        {

            return _rpgService.findPersonagens(forca);
        }


        // GET: api/<RpgController>
        [HttpGet("test")]
        public IEnumerable<PersonagemEntity> GetQueries([FromQuery(Name = "forca")] int? forca,
                                                        [FromQuery(Name = "forcaGt")] int? forcaGt,
                                                        [FromQuery(Name = "forcaLt")] int? forcaLt,
                                                        [FromQuery(Name = "destreza")] int? destreza,
                                                        [FromQuery(Name = "destrezaGt")] int? destrezaGt,
                                                        [FromQuery(Name = "destrezaLt")] int? destrezaLt,
                                                        [FromQuery(Name = "constituicao")] int? constituicao,
                                                        [FromQuery(Name = "constituicaoGt")] int? constituicaoGt,
                                                        [FromQuery(Name = "constituicaoLt")] int? constituicaoLt,
                                                        [FromQuery(Name = "inteligencia")] int? inteligencia,
                                                        [FromQuery(Name = "inteligenciaGt")] int? inteligenciaGt,
                                                        [FromQuery(Name = "inteligenciaLt")] int? inteligenciaLt,
                                                        [FromQuery(Name = "sabedoria")] int? sabedoria,
                                                        [FromQuery(Name = "sabedoriaGt")] int? sabedoriaGt,
                                                        [FromQuery(Name = "sabedoriaLt")] int? sabedoriaLt,
                                                        [FromQuery(Name = "carisma")] int? carisma,
                                                        [FromQuery(Name = "nome")] string? nome)
        {

            SearchQueryDto searchQueryDto = new SearchQueryDto(forca, forcaGt, forcaLt, destreza, destrezaGt, destrezaLt, constituicao, constituicaoGt, constituicaoLt, inteligencia, inteligenciaGt, inteligenciaLt, sabedoria, sabedoriaGt, sabedoriaLt, carisma, nome);
            return _rpgService.findPersonagens(searchQueryDto);

        }

        [HttpGet("test2")]
        public IEnumerable<PersonagemEntity> GetQueries([FromQuery] SearchQueryDto searchQueryDto)
        {

            return _rpgService.findPersonagens(searchQueryDto);

        }
        /*
               // GET api/<RpgController>/5
               [HttpGet("{id}")]
               public string Get(int id)
               {
                   return "value";
               }

               // POST api/<RpgController>
               [HttpPost]
               public void Post([FromBody] string value)
               {
               }

               // PUT api/<RpgController>/5
               [HttpPut("{id}")]
               public void Put(int id, [FromBody] string value)
               {
               }

               // DELETE api/<RpgController>/5
               [HttpDelete("{id}")]
               public void Delete(int id)
               {
               }
        */
    }
}
