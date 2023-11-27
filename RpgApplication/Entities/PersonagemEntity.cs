using MongoDB.Bson.Serialization.Attributes;

namespace RpgApplication.Entities
{
    public class PersonagemEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("forca")]
        public int Forca { get; set; }
        [BsonElement("destreza")]
        public int Destreza { get; set; }
        [BsonElement("constituicao")]
        public int Constituicao { get; set; }
        [BsonElement("inteligencia")]
        public int Inteligencia { get; set; }
        [BsonElement("sabedoria")]
        public int Sabedoria { get; set; }
        [BsonElement("carisma")]
        public int Carisma { get; set; }
        [BsonElement("nome")]
        public string? Nome { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
