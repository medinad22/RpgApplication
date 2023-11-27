using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RpgApplication.Config;
using RpgApplication.Entities;
using RpgApplication.Models;

namespace RpgApplication.Services
{
    public class MongoService
    {

        private readonly IMongoCollection<PersonagemEntity> _personagemCollection;
        private readonly IMapper _mapper;

        public MongoService(IOptions<PersonagemDatabaseSettings> personagemServices, IMapper mapper)
        {
            var mongoClient = new MongoClient(personagemServices.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(personagemServices.Value.DatabaseName);
            _personagemCollection = mongoDatabase.GetCollection<PersonagemEntity>
                (personagemServices.Value.PersonagemCollectionName);
            _mapper = mapper;
        }

        public async Task create(Personagem personagem)
        {
            //var entity = new PersonagemEntity();

            var entity = _mapper.Map<PersonagemEntity>(personagem);
            entity.createdAt = DateTime.Now;
            
            await _personagemCollection.InsertOneAsync(entity);
        }
    }
}
