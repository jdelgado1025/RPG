namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAll();
        Task<Character> GetCharacter(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}