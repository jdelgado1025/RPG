namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAll();
        Task<ServiceResponse<Character>> GetCharacter(int id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}