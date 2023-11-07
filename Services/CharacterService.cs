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
        public async Task<ServiceResponse<List<Character>>> CreateCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();

            characters.Add(newCharacter);
            serviceResponse.Data = characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>
            {
                Data = characters
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(character => character.Id == id);
            var serviceResponse = new ServiceResponse<Character>
            {
                Data = character
            };

            return serviceResponse;
        }
    }
}