using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyCarterApp;
using Xunit;


namespace MyTests
{
    public class TestServerBuilder
    {
        private TestServer testServer;
        private Action<IServiceCollection> configureTestServices = _ => {};
        private IWebHostBuilder hostBuilder;
        private Action<ContainerBuilder> configureTestContainer = _ => {};

        public TestServerBuilder() {
            hostBuilder = new WebHostBuilder()
                .ConfigureWebHostBuilder();                
        }

        public TestServerBuilder With<T>(Action<ContainerBuilder> extraConfig) where T: class
        {
            if (extraConfig == null)
            {
                throw new ArgumentNullException(nameof(extraConfig));
            }

            var previous = configureTestContainer;
            configureTestContainer = container => {
                previous(container);
                extraConfig(container);
            };
            return this;
        }

        public TestServerBuilder WithMock<T>(Type serviceType, Mock<T> serviceMock) where T: class
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (serviceMock == null)
            {
                throw new ArgumentNullException(nameof(serviceMock));
            }

            var previous = configureTestContainer;
            configureTestContainer = container => {
                previous(container);
                container.RegisterInstance(serviceMock.Object).As(serviceType);
            };
            return this;
        }

        public TestServer Build() {
            hostBuilder
                .ConfigureTestServices(configureTestServices)
                .ConfigureTestContainer(configureTestContainer);
            testServer = new TestServer(hostBuilder);
            return testServer;
        }

        public void Dispose()
        {
            testServer?.Dispose();
        }
    }
}