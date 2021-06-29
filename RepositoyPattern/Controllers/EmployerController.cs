using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RepositoyPattern.Domain.Entities;
using RepositoyPattern.Domain.Repositories;
using System.Threading.Tasks;

namespace RepositoyPattern.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployer()
        {
            var employer = await _employerRepository.GetAll();
            return Ok(employer);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var employer = await _employerRepository.GetById(id);
            return Ok(employer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddEmployer([FromBody] Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
              _employerRepository.Add(employer);
            return CreatedAtAction(nameof(GetById), new { id = employer.Id }, employer);
        }

        [HttpPut]
        public IActionResult UpdateEmployer([FromBody] Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _employerRepository.Update(employer);
            return Ok();
        }
    }
}
