using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        public Compensation GetByEmployeeId(string employeeId)
        {
            var compensation = _compensationContext.Compensations.AsQueryable().SingleOrDefault(e => e.EmployeeId == employeeId);

            return compensation;
        }

        public Compensation Add(Compensation compensation)
        {
            var existingCompensation = GetByEmployeeId(compensation.EmployeeId);

            if (existingCompensation == null)
            {
                _compensationContext.Compensations.Add(compensation);
            }
            else
            {
                existingCompensation.Salary = compensation.Salary;
                existingCompensation.EffectiveDate = compensation.EffectiveDate;
            }

            return compensation;
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}
