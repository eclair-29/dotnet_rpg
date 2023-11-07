using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<ServiceResponse<GetCharacterDto>> CreateCharacter(CreateCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = _autoMapper.Map<Character>(newCharacter);

            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            // serviceResponse.Data = characters.Select(c => _autoMapper.Map<GetCharacterDto>(c)).ToList(); // same with _autoMapper.Map<List<GetCharacterDto>>(characters)
            serviceResponse.Data = _autoMapper.Map<GetCharacterDto>(character);
            serviceResponse.Message = "Character successfully created.";

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
            var character = characters.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<GetCharacterDto>
            {
                Data = _autoMapper.Map<GetCharacterDto>(character)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            try
            {
                if (character is null)
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not exist.");

                character.Name = updatedCharacter.Name;
                character.HealthPoints = updatedCharacter.HealthPoints;
                character.Strength = updatedCharacter.Strength;
                character.Agility = updatedCharacter.Agility;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = _autoMapper.Map<GetCharacterDto>(character);
                serviceResponse.Message = "Character successfully updated.";

            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}