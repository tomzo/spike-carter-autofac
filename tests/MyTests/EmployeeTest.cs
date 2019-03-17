using System.Threading.Tasks;
using Lib;
using Newtonsoft.Json.Linq;
using Xunit;

namespace MyTests
{
    public class EmployeeTest
    {
        [Fact]
        public async Task ShouldReturnJsonListOfEmployees()
        {
            var mock = new Moq.Mock<IEmployeeService>();
            mock.Setup(m => m.GetAll()).Returns(new System.Collections.Generic.List<Employee>() {
                new Employee() { Name = "John" },
                new Employee() { Name = "Jane" }
            });
            using(var testServer = new TestServerBuilder()
                .WithMock<IEmployeeService>(typeof(IEmployeeService), mock)
                .Build()) 
            {
                var client = testServer.CreateClient();
                var result = await client.GetStringAsync("/employee/list");
                var items = JArray.Parse(result);
                Assert.Equal(2, items.Count);
            }
        }
    }
}