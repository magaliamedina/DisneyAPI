using DisneyData.Models;
using DisneyDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.Services
{
    public interface ICharacterService
    {
        public List<Character> DetailsCharacters();
        public List<CharacterListDTO> ListCharacters();
        public void AddCharacter(CharacterDTO character);
        public Character EditCharacter(int id, CharacterDTO updatedCharacter);
        public bool DeleteCharacter(int id);
        public Character GetById(int id); //GetById
        public List<Character> GetByName(string name);
        public List<Character> GetByAge(int age);
        public List<Character> GetByMovie(int movieId);
    }
}
