using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation GetByEmployeeId(string employeeId);
        Compensation Create(Compensation compensation);
    }
}
