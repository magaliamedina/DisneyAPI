using DisneyData.Models;
using DisneyDomain.DTO;
using DisneyDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyWebAPI.Controllers
{
    [Route("characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: chatacters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> ListCharacters()
        {
            var characters = _characterService.DetailsCharacters();
            if (characters == null)
            {
                return NotFound();
            }
            return characters;
        }

        // GET: characters/juan
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Character>>> ListByName(string name)
        {
            var characters = _characterService.GetByName(name);
            if (characters == null)
            {
                return NotFound();
            }
            return characters;
        }

        // GET: characters/30
        [HttpGet("{age:int}")]
        public async Task<ActionResult<IEnumerable<Character>>> ListByAge(int age)
        {
            var characters = _characterService.GetByAge(age);
            if (characters == null)
            {
                return NotFound();
            }
            return characters;
        }

        // GET: characters/5
        [HttpGet("movies/{movieId:int}")]
        public async Task<ActionResult<IEnumerable<Character>>> GetByMovie(int movieId)
        {
            var characters = _characterService.GetByMovie(movieId);
            if (characters == null)
            {
                return NotFound();
            }
            return characters;
        }

        // PUT: characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterDTO character)
        {
            try
            {
                _characterService.EditCharacter(id, character);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: characters
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterDTO character)
        {
            var characters = _characterService.DetailsCharacters();
            if (characters == null)
            {
                return Problem("Entity set 'DisneyDbContext.Characters'  is null.");
            }
            try
            {
                _characterService.AddCharacter(character);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Ok(character);
            return CreatedAtAction("ListCharacters", new { id = character.ID }, character);
        }

        // DELETE: characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var characters = _characterService.DetailsCharacters();
            if (characters == null)
            {
                return NotFound();
            }
            try
            {
                var deleteFlag = _characterService.DeleteCharacter(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
    }
}
