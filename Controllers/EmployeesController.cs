using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeProducerService _employeeProducerProducerService;
        private readonly IEmployeeConsumerService _employeeConsumerService;

        public EmployeesController(
            IEmployeeProducerService employeeProducerProducerService,
            IEmployeeConsumerService employeeConsumerService)
        {
            _employeeProducerProducerService = employeeProducerProducerService;
            _employeeConsumerService = employeeConsumerService;
        }

        // GET: api/Employees
        public async Task<ActionResult<Employee>> GetEmployee()
        {
            await Task.Yield();

            return _employeeConsumerService.ConsumeEmployee();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeProducerProducerService.Produce(employee);
            return employee;
        }
    }
}
