using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MyCarterApp;
using Xunit;

namespace MyTests
{
    
    public class IntegrationTest
    {

        [Fact]
        public async Task FullStackTest()
        {
            using(var testServer = new TestServerBuilder().Build()) {
                var client = testServer.CreateClient();
                var result = await client.GetStringAsync("/");
                Assert.Equal("Hello from MyProvider", result);
            }
        }

        [Fact]
        public async Task WithMockTest()
        {
            var mock = new Moq.Mock<IProvider>();
            mock.Setup(m => m.Greet()).Returns("Hello from mock");
            using(var testServer = new TestServerBuilder()
                .WithMock<IProvider>(typeof(IProvider), mock)
                .Build()) {
                var client = testServer.CreateClient();
                var result = await client.GetStringAsync("/");
                Assert.Equal("Hello from mock", result);
            }
        }
    }
}