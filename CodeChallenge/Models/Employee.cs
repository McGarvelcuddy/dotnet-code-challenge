using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Models
{
    public class Employee
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        public List<Employee> DirectReports { get; set; }


        public int GetTotalReports()
        {
            int totalReports = 0;

            if (DirectReports != null)
            {
                totalReports += DirectReports.Count;

                foreach (var report in DirectReports)
                {
                    totalReports += report.GetTotalReports();
                }
            }

            return totalReports;
        }
    }
}
