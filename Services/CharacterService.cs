using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public class CharacterService : ICharacterService
    {
        static readonly List<Character> characters = new()
        {
            new(),
            new() {
                Id = 1,
                Class = RpgClass.Mage
            }
        };
        private readonly IMapper _autoMapper;

        public CharacterService(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> CreateCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var characterWithNewId = _autoMapper.Map<Character>(newCharacter);

            characterWithNewId.Id = characters.Max(character => character.Id) + 1;
            characters.Add(characterWithNewId);
            serviceResponse.Data = characters.Select(character => _autoMapper.Map<GetCharacterDto>(character)).ToList(); // same with _autoMapper.Map<List<GetCharacterDto>>(characters)

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>
            {
                Data = _autoMapper.Map<List<GetCharacterDto>>(characters)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(character => character.Id == id);
            var serviceResponse = new ServiceResponse<GetCharacterDto>
            {
                Data = _autoMapper.Map<GetCharacterDto>(character)
            };

            return serviceResponse;
        }
    }
}