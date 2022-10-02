using AutoMapper;
using RPG.DataTransferObjects.Character;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly RpgContext _context;

        public CharacterService(IMapper mapper, RpgContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = _mapper.Map<Character>(newCharacter);
            
            try
            {
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
                response.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync(); //_mapper.Map<List<GetCharacterDTO>>(characters);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();

            var character = await _context.Characters.FindAsync(id);

            if(character == null)
            {
                response.Success = false;
                response.Message = $"Character with id {id} does not exist";
                return response;
            }

            try
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                response.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAll()
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            var characters = await _context.Characters.ToListAsync();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response; //_mapper.Map<List<GetCharacterDTO>>(characters);
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            var response = new ServiceResponse<GetCharacterDTO>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);//characters.FirstOrDefault(c => c.Id == id);
            response.Data = _mapper.Map<GetCharacterDTO>(character);

            if(character == null)
            {
                response.Success = false;
                response.Message = $"The character with id {id} does not exist.";
            }
            
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Name = updatedCharacter.Name;
                character.Strength = updatedCharacter.Strength;

                // _context.Entry(character).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}