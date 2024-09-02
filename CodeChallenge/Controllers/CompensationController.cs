using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
    [Route("api/compensation")]
    [ApiController]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;
        private readonly IEmployeeService _employeeService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService, IEmployeeService employeeService)
        {
            _logger = logger;
            _compensationService = compensationService;
            _employeeService = employeeService;
        }

        [HttpPut("{employeeId}/{salary}")]
        public IActionResult SetCompensation(string employeeId, string salary)
        {
            _logger.LogDebug($"Recieved set employee compensation request for '{employeeId}'");

            var employee = _employeeService.GetById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var compensation = new Compensation(employeeId, salary);

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { employeeId = employee.EmployeeId }, compensation);
        }

        [HttpGet("{employeeId}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(string employeeId)
        {
            _logger.LogDebug($"Received compensation get request for '{employeeId}'");

            var compensation = _compensationService.GetByEmployeeId(employeeId);

            if (compensation == null)
            {
                return NotFound($"No employee compensation found matching Employee ID '{employeeId}'");
            }

            return Ok(compensation);
        }
    }
}
