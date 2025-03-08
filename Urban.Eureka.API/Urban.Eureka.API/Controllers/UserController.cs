using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urban.Eureka.API.Model;
using Urban.Eureka.API.Repository;

namespace Urban.Eureka.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				return Ok(await _userRepository.Get());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				if (id <= 0)
					return BadRequest();

				return Ok(await _userRepository.Get(id));
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] User user)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				int id = await _userRepository.Add(user);
				return CreatedAtAction(nameof(Get), new { id = id }, user);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] User user)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				await _userRepository.Update(user);
				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				if (id <= 0)
					return BadRequest();

				await _userRepository.Delete(id);
				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
