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

        public async Task Create(Personagem personagem)
        {
            var entity = _mapper.Map<PersonagemEntity>(personagem);
            entity.createdAt = DateTime.Now;
            await _personagemCollection.InsertOneAsync(entity);
        }

        public IEnumerable<PersonagemEntity> FindPersonagens(int? forca)
        {

            return _personagemCollection.Find(BuildFilter(forca)).ToList();
        }

        internal IEnumerable<PersonagemEntity> FindPersonagens(SearchQueryDto? searchQueryDto)
        {
            return _personagemCollection.Find(BuildFilter(searchQueryDto)).ToList();
        }

        private FilterDefinition<PersonagemEntity> BuildFilter(int? forcaParam)
        {
            FilterDefinition<PersonagemEntity> filters = Builders<PersonagemEntity>.Filter.Empty;

            if (forcaParam is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Forca, forcaParam);
            }

            FilterDefinition<PersonagemEntity> filterDefinition = Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Forca, forcaParam);

            return filters;


        }

        private FilterDefinition<PersonagemEntity> BuildFilter(SearchQueryDto? searchQueryDto)
        {

            FilterDefinition<PersonagemEntity> filters = Builders<PersonagemEntity>.Filter.Empty;

            if (searchQueryDto is null)
            {
                return filters;
            }

            if (searchQueryDto.Forca is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Forca, searchQueryDto.Forca);
            }

            if (searchQueryDto.ForcaGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Forca, searchQueryDto.ForcaGt);
            }

            if (searchQueryDto.ForcaLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Forca, searchQueryDto.ForcaLt);
            }

            if (searchQueryDto.Nome is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Nome, searchQueryDto.Nome); //| Builders<PersonagemEntity>.Filter.Regex(personagem => personagem.Nome, searchQueryDto.Nome);
            }

            if (searchQueryDto.Sabedoria is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Sabedoria, searchQueryDto.Sabedoria);
            }

            if (searchQueryDto.SabedoriaGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Sabedoria, searchQueryDto.SabedoriaGt);
            }

            if (searchQueryDto.SabedoriaLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Sabedoria, searchQueryDto.SabedoriaLt);
            }

            if (searchQueryDto.Destreza is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Destreza, searchQueryDto.Destreza);
            }

            if (searchQueryDto.DestrezaGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Destreza, searchQueryDto.DestrezaGt);
            }

            if (searchQueryDto.DestrezaLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Destreza, searchQueryDto.DestrezaLt);
            }

            if (searchQueryDto.Constituicao is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Constituicao, searchQueryDto.Constituicao);
            }

            if (searchQueryDto.ConstituicaoGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Constituicao, searchQueryDto.ConstituicaoGt);
            }

            if (searchQueryDto.ConstituicaoLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Constituicao, searchQueryDto.ConstituicaoLt);
            }

            if (searchQueryDto.Inteligencia is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Inteligencia, searchQueryDto.Inteligencia);
            }

            if (searchQueryDto.InteligenciaGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Inteligencia, searchQueryDto.InteligenciaGt);
            }

            if (searchQueryDto.InteligenciaLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Inteligencia, searchQueryDto.InteligenciaLt);
            }

            if (searchQueryDto.Sabedoria is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Sabedoria, searchQueryDto.Sabedoria);
            }

            if (searchQueryDto.SabedoriaGt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Gt(personagem => personagem.Sabedoria, searchQueryDto.SabedoriaGt);
            }

            if (searchQueryDto.SabedoriaLt is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Lt(personagem => personagem.Sabedoria, searchQueryDto.SabedoriaLt);
            }

            if (searchQueryDto.Carisma is not null)
            {
                filters &= Builders<PersonagemEntity>.Filter.Eq(personagem => personagem.Carisma, searchQueryDto.Carisma);
            }

            return filters;


        }
    }
}
