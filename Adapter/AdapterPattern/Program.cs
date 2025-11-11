using AdapterPattern.Core;
using System.Text;
using System.Text.Json;

namespace AdapterPattern
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var payrollCalcUrl = "http://localhost:5078/api/PayrollCalculatorController";
            var reader = new EmployeeDataReader();
            var employees = reader.GetEmployees();

            var client = new HttpClient();
            foreach (var employee in employees)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, payrollCalcUrl);
                request.Content = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                var responseJson = await response.Content.ReadAsStringAsync();

                var salary = decimal.Parse(responseJson);
                Console.WriteLine($"Salary for Employee `{employee.FullName}` as of today = {salary}");
            }
            Console.ReadKey();
        }
    }
}
