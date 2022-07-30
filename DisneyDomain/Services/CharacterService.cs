using DisneyData.Models;
using DisneyData.Repositories;
using DisneyDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public void AddCharacter(CharacterDTO characterDTO)
        {
            try
            {
                Character character = new Character()
                {
                    //Image = characterDTO.Image,
                    Name = characterDTO.Name,
                    Age = characterDTO.Age,
                    Weight = characterDTO.Weight,
                    History = characterDTO.History,
                    MovieID = characterDTO.MovieID
                };
                _characterRepository.AddCharacter(character);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCharacter(int id)
        {
            try
            {
                return _characterRepository.DeleteCharacter(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Character EditCharacter(int id, CharacterDTO updateCharacter)
        {
            var oldCharacter = GetById(id);
            if (oldCharacter != null)
            {
                //el id no se modifica
                oldCharacter.Name = updateCharacter.Name;
                //oldCharacter.Image = updateCharacter.Image;
                oldCharacter.Age = updateCharacter.Age;
                oldCharacter.Weight = updateCharacter.Weight;
                oldCharacter.History = updateCharacter.History;
                //oldCharacter.MovieID = updateCharacter.MovieID;
                try
                {
                    return _characterRepository.EditCharacter(oldCharacter);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return null;
        }

        public Character GetById(int id)
        {
            return _characterRepository.GetById(id);
        }

        public List<Character> GetByMovie(int movieId)
        {
            return _characterRepository.ListAllCharacters().Where(c => c.MovieID == movieId).ToList();
        }

        public List<Character> GetByName(string name)
        {
            return _characterRepository.ListAllCharacters().Where(c => c.Name == name).ToList();
        }

        public List<Character> GetByAge(int age)
        {
            return _characterRepository.ListAllCharacters().Where(c => c.Age == age).ToList();
        }

        public List<Character> DetailsCharacters()
        {
            return _characterRepository.ListAllCharacters().ToList();
        }

        public List<CharacterListDTO> ListCharacters()
        {
            throw new NotImplementedException();
        }
    }
}
