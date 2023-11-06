using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CharacterController : ControllerBase
    {

        static readonly List<Character> characters = new()
        {
            new(),
            new() {
                Id = 1,
                Class = RpgClass.Mage
            }
        };
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> CreateCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(_characterService.CreateCharacter(newCharacter));
        }
    }
}