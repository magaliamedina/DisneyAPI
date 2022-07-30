using DisneyData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DisneyDbContext _context;

        public CharacterRepository(DisneyDbContext context)
        {
            _context = context;
        }

        public void AddCharacter(Character character)
        {
            if (character != null)
            {
                try
                {
                    _context.Characters.Add(character);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool DeleteCharacter(int id)
        {
            var pet = _context.Characters.Find(id);
            if (pet != null)
            {
                try
                {
                    _context.Characters.Remove(pet);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return true;
            }
            return false;
        }

        public Character EditCharacter(Character updatedCharacter)
        {
            try
            {
                _context.Update(updatedCharacter);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updatedCharacter;
        }

        public Character GetById(int id)
        {
            return _context.Characters.Find(id);
        }

        public List<Character> ListAllCharacters()
        {
            return _context.Characters.Include(p => p.Movie).ToList();
        }
    }
}
