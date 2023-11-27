using AutoMapper;
using RpgApplication.Entities;

namespace RpgApplication.Models
{
    public class PersonagemMapper : Profile
    {

        public PersonagemMapper()
        {

            CreateMap<Personagem, PersonagemEntity>();
        }
    }
}
