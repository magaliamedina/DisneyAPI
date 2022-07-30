using DisneyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Repositories
{
    public interface ICharacterRepository
    {
        public List<Character> ListAllCharacters(); 
        public void AddCharacter(Character character); 
        public Character EditCharacter(Character updatedCharacter); 
        public bool DeleteCharacter(int id);
        public Character GetById(int id); //GetById
    }
}
