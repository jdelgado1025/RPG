using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private List<Character> characters = new List<Character>();

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Character>> GetAll(){
            return Ok(characters);
        }

        [HttpGet("{id")]
        public ActionResult<Character> GetCharacter(int id){

            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            characters.Add(newCharacter);
            return characters;
        }
    }
}