using RpgApplication.Entities;
using RpgApplication.Interfaces;
using RpgApplication.Models;

namespace RpgApplication.Services
{
    public class RPGService : IRPGService
    {

        private readonly MongoService _mongoService;

        public RPGService(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        public IEnumerable<PersonagemEntity> findPersonagens(int? forca)
        {

            return _mongoService.FindPersonagens(forca);
            
        }

        public IEnumerable<PersonagemEntity> findPersonagens(SearchQueryDto? searchQueryDto)
        {

            return _mongoService.FindPersonagens(searchQueryDto);
            
        }

        public async Task savePersonagem(Person person)
        {

            if (person is not null)
            {
                var personagem = new Personagem(person.Name);
                Console.WriteLine(personagem.ToString());
                await _mongoService.Create(personagem);
            }

            //throw new NotImplementedException();
        }
    }
}
