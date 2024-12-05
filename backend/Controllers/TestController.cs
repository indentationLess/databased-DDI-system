using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApiTestController : ControllerBase
{
	[HttpGet]
	public IActionResult GetMessage()
	{
		return Ok(new { message = "Hello from the ApiTest controller!" });
	}
}
