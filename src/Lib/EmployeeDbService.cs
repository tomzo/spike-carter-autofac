using System.Collections.Generic;

namespace Lib
{
    public class EmployeeDbService : IEmployeeService
    {
        public List<Employee> GetAll()
        {
            //TODO db connection and query
            return new List<Employee>() {
                new Employee() { Name = "Demo" }
            };
        }
    }
}