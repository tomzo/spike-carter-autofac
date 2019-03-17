using Autofac;
using Autofac.Core;
using Lib;

namespace MyCarterApp
{
    public class MyAutofacModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder) {
            builder.RegisterType<MyProvider>().As<IProvider>();
            builder.RegisterType<EmployeeDbService>().As<IEmployeeService>();
        }
    }
}