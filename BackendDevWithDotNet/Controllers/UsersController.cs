using BackendDevWithDotNet.Models;
using BackendDevWithDotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendDevWithDotNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        return Ok(userService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetById(int id)
    {
        var user = userService.GetById(id);
        if (user is null)
        {
            return NotFound(new { message = $"User with ID {id} was not found." });
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> Create([FromBody] UserCreateRequest request)
    {
        var createdUser = userService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:int}")]
    public ActionResult<User> Update(int id, [FromBody] UserUpdateRequest request)
    {
        var updatedUser = userService.Update(id, request);
        if (updatedUser is null)
        {
            return NotFound(new { message = $"User with ID {id} was not found." });
        }

        return Ok(updatedUser);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = userService.Delete(id);
        if (!isDeleted)
        {
            return NotFound(new { message = $"User with ID {id} was not found." });
        }

        return NoContent();
    }
}
