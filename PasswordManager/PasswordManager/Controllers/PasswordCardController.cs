using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Repositories;

namespace PasswordManager.Controllers
{
    [ApiController]
    [Route("password-cards")]
    public class PasswordCardController : Controller
    {
        private readonly IPasswordCardRepository _repository;

        public PasswordCardController(IPasswordCardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PasswordCard>), StatusCodes.Status200OK)]
        public IActionResult FindAll()
        {
            var models = _repository.FindAll();
            return Ok(models);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(PasswordCard), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] PasswordCard body)
        {
            body.Id = Guid.NewGuid();
            _repository.Add(body);
            return Ok(body);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<PasswordCard>), StatusCodes.Status200OK)]
        public IActionResult FindById(string name)
        {
            var models = _repository.FindByName(name);
            return Ok(models);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, [FromBody] PasswordCard body)
        {
            body.Id = id;
            _repository.Update(body);
            return Ok(body);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
