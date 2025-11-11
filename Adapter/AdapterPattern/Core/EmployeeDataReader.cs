using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Core
{
    public class EmployeeDataReader
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {

                    FullName = "Tasneem Elhussiny",
                    PayItems = new List<PayItem>()
                    {
                        new PayItem() { Name = "Basic Salary", Value = 1000 },
                        new PayItem() { Name = "Trasportation", Value = 250 },
                        new PayItem() { Name = "Medical Insurance", Value = -150 }
                    }
                },
                new Employee()
                {

                    FullName = "Ezz Ahmed",
                    PayItems = new List<PayItem>()
                    {
                        new PayItem() { Name = "Basic Salary", Value = 1000 },
                        new PayItem() { Name = "Trasportation", Value = 250 },
                        new PayItem() { Name = "Medical Insurance", Value = -150 }
                    }
                }

            };
        }
    }
}
