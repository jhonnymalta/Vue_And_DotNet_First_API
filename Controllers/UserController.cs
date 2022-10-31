using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("/")]
        public IActionResult Get()
        {
            var repository = new UserRepository(AppDbContex.connection);
            return Ok(repository.GetAll());
        }
        [HttpPost("/")]
        public IActionResult Post(UserModel model)
        {
            var repository = new UserRepository(AppDbContex.connection);
            repository.Post(model);
            return Created($"/{model.Id}", model);

        }
        [HttpGet("/{id:int}")]
        public IActionResult GetById(int id)
        {
            var repository = new UserRepository(AppDbContex.connection);
            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPut("/{id:int}")]
        public IActionResult Put([FromBody] UserModel model, [FromRoute] int id)
        {
            var userID = id;
            var repository = new UserRepository(AppDbContex.connection);
            var alteredModel = repository.Put(model, userID);
            return Ok(alteredModel);
        }
        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var repository = new UserRepository(AppDbContex.connection);
            var userToRemove = repository.GetById(id);
            if (userToRemove == null)
            {
                return NotFound();
            }
            repository.Delete(id);
            return Ok(userToRemove);
        }


    }
}