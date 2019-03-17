using Carter;
using Carter.ModelBinding;
using Carter.Request;
using Carter.Response;

namespace Lib
{
    public class EmployeeModule : CarterModule
    {
        public EmployeeModule(IEmployeeService employeeService) 
        {
            // see more examples at https://github.com/CarterCommunity/Carter/blob/master/samples/CarterSample/Features/Actors/ActorsModule.cs

            Get("/employee/list", async(req, res, routeData) => {
                var list = employeeService.GetAll();
                await res.Negotiate(list);
            });
        }
    }
}