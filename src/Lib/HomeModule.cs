namespace MyCarterApp
{
    using Carter;
    using Microsoft.AspNetCore.Http;

    public class HomeModule : CarterModule
    {
        public HomeModule(IProvider service)
        {
            Get("/carter", async(req, res, routeData) => await res.WriteAsync(service.Greet()));
        }
    }
}
