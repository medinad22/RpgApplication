using RpgApplication.Entities;
using RpgApplication.Models;

namespace RpgApplication.Interfaces
{
    public interface IRPGService
    {
        IEnumerable<PersonagemEntity> findPersonagens(int? forca);
        IEnumerable<PersonagemEntity> findPersonagens(SearchQueryDto? searchQueryDto);
        Task savePersonagem(Person person);

    }
}
