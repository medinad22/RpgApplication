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

        public async Task savePersonagem(Person person)
        {

            if (person is not null)
            {
                var personagem = new Personagem(person.Name);
                Console.WriteLine(personagem.ToString());
                await _mongoService.create(personagem);
            }

            //throw new NotImplementedException();
        }
    }
}
