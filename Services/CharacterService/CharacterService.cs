using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private List<Character> characters = new List<Character>();
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public async Task<List<Character>> GetAll()
        {
            return characters;
        }

        public async Task<Character> GetCharacter(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}