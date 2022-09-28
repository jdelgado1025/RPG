using RPG.DataTransferObjects.Character;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private List<Character> characters = new List<Character>();
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAll()
        {
            return new ServiceResponse<List<GetCharacterDTO>>() {Data = characters};
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}