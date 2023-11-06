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
        public List<Character> CreateCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(character => character.Id == id);

            if (character is not null) return character;
            throw new Exception("Character not found");
        }
    }
}