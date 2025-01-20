using Microsoft.AspNetCore.Mvc;

namespace New_folder.Controllers;

public class PersonController : ControllerBase
{
    
    [HttpGet("greet")]
    public IActionResult Greet()
    {
        return Ok("Namaste");
    }

    [HttpGet("address/{name}/{ward}/{locality}")]
    public IActionResult Address(string name, int ward, string locality)
    {
        return Ok($"Namaste, {name}, You are from Birtamod {ward} and your tole is {locality}.");
    }

    [HttpGet("email/{email}/address")]
    public IActionResult Email(string email)
    {
        return Ok($"Namaste, your email is {email}");
    }

    [HttpGet("hello")]
    public IActionResult Hello([FromQuery] string name)
    {
        return Ok($"Hello, {name}");
    }
    
    [HttpGet("hi/{name}")]
    public IActionResult Hi(string name)
    {
        try
        {
            throw new Exception("This is a exception");
            return Ok($"Hello {name}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}