using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public string EmployeeId { get; set; }
        public string Salary { get; set; }
        public DateTime EffectiveDate { get; set; }

        public Compensation(string employeeId, string salary)
        {
            EmployeeId = employeeId;
            Salary = salary;
            EffectiveDate = DateTime.Now;
        }
    }
}
