using Autofac;
using Autofac.Core;

namespace MyCarterApp
{
    public class MyAutofacModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder) {
            builder.RegisterType<MyProvider>().As<IProvider>();
        }
    }
}