using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> CreateCharacter(Character newCharacter);
    }
}