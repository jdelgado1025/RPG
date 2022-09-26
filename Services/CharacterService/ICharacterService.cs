using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAll();
        Task<Character> GetCharacter(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}