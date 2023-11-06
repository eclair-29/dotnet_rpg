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
        static readonly Character knight = new();

        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(knight);
        }
    }
}